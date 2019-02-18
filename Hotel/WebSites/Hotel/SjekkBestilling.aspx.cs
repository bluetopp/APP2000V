using HotellBestilling;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SjekkBestilling : System.Web.UI.Page
{
    //En egendefinert klasse (Order) laget av Marius Storvik
    //Det er en datastrukturklasse for å holde
    //bestillingsdata fra databasen

    class Order
    {

        public int orderID;
        public string roomType;
        public string fromDate;
        public string toDate;
        public string status;
        public int phoneNumber;
        public string firstName;
        public string lastName;


        public Order(int orderID, string roomType, string fromDate, string toDate,
            string status, string firstName, string lastName)
        {
            this.orderID = orderID;
            this.roomType = roomType;
            this.fromDate = fromDate;
            this.toDate = toDate;
            this.status = status;
            this.firstName = firstName;
            this.lastName = lastName;
        }

    }

    public int currentTab = 1;

    protected void Page_LoadComplete(object sender, EventArgs e)
    {

        //Sjekker om det er en postback på siden
        //Hvis det ikke er det, så skal den kjøre
        //Postback kjører Page_LoadComplete igjen
        //og er for å unngå at den skal kjøre to ganger

        if (!IsPostBack)
        {
            //Nedenfor så henter jeg ut verdiene jeg vil ha
            //via Request.QueryString. Disse blir sendt over
            //i URL'en fra Default.aspx. Verdiene blir lagt i en string

            string telefon = Request.QueryString["tlf"];

            //Starter en ny tilkobling til databasen
            //og lager en ny spørring til databasen.

            DatabaseManager.Open("46.9.246.190", "24440", "hotell", "admin", "admin");
            DataSet result = DatabaseManager.Query
                (
                    "SELECT bestillingID, romtype, fradato, tildato, tildelt, fornavn, etternavn FROM bestillinger WHERE tlf='" + telefon + "';"
                );

            //Hvis resultatet fra datasett listen result
            //er tom, så har den ikke funnet noen bestillinger
            //med angitt telefonnummer

            bestillingSkjema.Visible = (result.Tables["result"].Rows.Count == 0) ? false : true;
            informasjon.Visible = (result.Tables["result"].Rows.Count == 0) ? false : true;

            if (result.Tables["result"].Rows.Count == 0)
            {
                string feilmelding = ("<h2>Fant ingen bestillinger med angitt telefonnummer!</h2>");
                FeilmeldingLabel.Text = feilmelding;
                return;
            }

            //Instansierer en ny liste

            List<Order> OrderList = new List<Order>();

            //Oppretter variabler som må bli brukt
            //for å legge verdier i variablene

            int orderID;
            string roomType;
            DateTime fromDate;
            DateTime toDate;
            string assigned;
            string firstName;
            string lastName;

            //Lager en loop for å "loope" over result.Tables
            //for å hente ut verdiene og legge alle disse
            //verdiene i en liste som heter OrderList.

            foreach (DataRow row in result.Tables["result"].Rows)
            {
                orderID = (int)row["bestillingID"];
                roomType = (string)row["romtype"];
                fromDate = (DateTime)row["fradato"];
                toDate = (DateTime)row["tildato"];
                assigned = (string)row["tildelt"];
                firstName = (string)row["fornavn"];
                lastName = (string)row["etternavn"];
                string fromDateString = fromDate.ToShortDateString();
                string toDateString = toDate.ToShortDateString();
                Order order = new Order(orderID, roomType, fromDateString, toDateString, assigned, firstName, lastName);
                OrderList.Add(order);
            }

            string fornavn = "";
            string etternavn = "";

			//Lager en for loop for å lage tabellen
			//og for å legge verdiene inn i tabellen.
			//Må ha for loop fordi det kan være flere
			//verdier i listen OrderList.
			//En kunde kan ha flere bestillinger liggende

			for (int i = 0; i < OrderList.Count; i++)
            {
                int ordr = OrderList[i].orderID;
                string romtype = OrderList[i].roomType;
                string fradato = OrderList[i].fromDate;
                string tildato = OrderList[i].toDate;
                string tildelt = OrderList[i].status;
                fornavn = (OrderList[i].firstName);
                etternavn = (OrderList[i].lastName);

                string ordrenummer = ordr.ToString();
                string ikketildelt = "Rom ikke tildelt";
                string tildelt1 = "Rom tildelt";
                string ChinatownSingle = "The Chinatown Single";
                string DubaiDouble = "The Dubai Double";
                string LeRoyale = "Le Royale des Cieux";
                string ItalianJob = "The Italian Job";

                //Lager nye celler til tabellen og looper
                //verdiene inn i riktig plassering

				TableRow row2 = new TableRow();

				var cell1 = new TableCell();
                var cell2 = new TableCell();
                var cell3 = new TableCell();
                var cell4 = new TableCell();
                var cell5 = new TableCell();

                cell1.Text = ordrenummer;
                cell2.Text = romtype;
                cell3.Text = fradato;
                cell4.Text = tildato;
                cell5.Text = tildelt;

                row2.Cells.Add(cell1);
                row2.Cells.Add(cell2);
                row2.Cells.Add(cell3);
                row2.Cells.Add(cell4);
                row2.Cells.Add(cell5);
                table.Rows.Add(row2);

                //Under er kun en konverting av verdiene som
                //kommer fra databasen og til tabellen
                //slik at brukeren forstår verdiene bedre

                if (cell5.Text == "false")
                {
                    cell5.Text = ikketildelt;
                }

                if (cell5.Text == "true")
                {
                    cell5.Text = tildelt1;
                }

                if (cell2.Text == "china")
                {
                    cell2.Text = ChinatownSingle;
                }

                if (cell2.Text == "dubai")
                {
                    cell2.Text = DubaiDouble;
                }

                if (cell2.Text == "french")
                {
                    cell2.Text = LeRoyale;
                }

                if (cell2.Text == "italian")
                {
                    cell2.Text = ItalianJob;
                }

            }

            //table.Rows.RemoveAt(1) fjerener en tom celle
            //som alltid kommer på toppen av

			table.Rows.RemoveAt(1);

            phonenumberList.Text = telefon;
            firstnameList.Text = fornavn;
            lastnameList.Text = etternavn;
        }

    }

    //Under ligger koden for slett bestilling knappen

    protected void slett(object sender, EventArgs e)
    {
        int value;
        if (Int32.TryParse(hf1.Value, out value))
        {
        }

        //For å kunne nå verdier så må jeg benytte meg av litt javascript
        //Det kalles for hiddenfield og er et skjult felt som ingen kan nå
        //Det er hovedsakelig for å få verdiene fra klient siden og til
        //server siden. Javascript er på klient siden, mens denne koden
        //som vi skriver om her skjer på server siden
        //Se SjekkBestilling.aspx filen for å se de hidden fieldsa

        string verdi = value.ToString();
        string value2 = hf2.Value;
        string tildelt = "Rom tildelt";

        int sjekk = Int32.Parse(verdi);

        //Er verdien 0 så har de ikke valgt noen bestilling

        if (sjekk == 0)
        {
            string feilmelding = ("<h2>Du må velge en bestilling!</h2>");
            FeilmeldingLabel.Text = feilmelding;
            return;
        }

        //En kan ikke slette rom som er tildelt, da må du kontakte kundeservice
        //for å få lov til dette
        //En kan tenke at det er en åpen ordre når den ikke er tildelt
        //mens når den er tildelt så er den "sendt" og "låst"

        if (value2 == tildelt)
        {
            Label1.Text = "<h2 style='color:red;'>Du kan ikke slette bestilling som er tildelt. Vennligst kontakt oss direkte for hjelp</h2>";
            return;
        }


        //Definerer feilmeldinger til å bli printet i html format
        //og starter en ny kobling mot databasen
        //Den sender også DELETE sql spørring for å slette valgt verdi
        //Under benytter vi igjen NonQuery for å sjekke om spørringen
        //gikk igjennom

        string error = ("<body class='sjekkbestilling'></body><h2>En feil har oppstått! Vennligst prøv igjen senere </h2>");
        string succeed = ("<body class='sjekkbestilling'></body><h2>Din valgte bestilling har nå blitt slettet<br><a href='javascript:history.go(-1)'>Gå tilbake til den forrige siden</a></h2>");
        DatabaseManager.Open("46.9.246.190", "24440", "hotell", "admin", "admin");
        string query = ("DELETE FROM bestillinger WHERE bestillingID = '" + verdi + "';");
        bool success = DatabaseManager.NonQuery(query);


        if (success)
        {
            Label1.Text = succeed;
            bestillingSkjema.Visible = false;
            informasjon.Visible = false;
        }
        else
        {
            Label1.Text = error;
            bestillingSkjema.Visible = false;
            informasjon.Visible = false;
        }
    }

    //Under så ligger koden for endre knappen

    protected void endre(object sender, EventArgs e)
    {
        //Samme som ovenfor, så henter vi verdier
        //fra hidden field for å hente verdier
        //som er fra tabellen i javascript
        //til serversiden i denne koden C#
        //En må gjøre det på denne måten
        //for å få tak i verdier når vi ønsker
        //å benytte oss av klikkbare tabeller

        int value;
        if (Int32.TryParse(hf1.Value, out value))
        {
        }

        string tildelt = "Rom tildelt";
        string value2 = hf2.Value;
        string verdi2 = value.ToString();
        int sjekk = Int32.Parse(verdi2);

        //Hvis sjekk inneholder 0, så betyr det at
        //vi ikke har valgt noe i tabellen

        if (sjekk == 0)
        {
            string feilmelding = ("<h2>Du må velge en bestilling!</h2>");
            FeilmeldingLabel.Text = feilmelding;
            return;
        }

        //Igjen vi kan ikke endre rom
        //som er allerede tildelt

        if (value2 == tildelt)
        {
            Label1.Text = "<h2 style='color:red;'>Du kan ikke endre rom som er tildelt. Vennligst kontakt oss direkte for hjelp</h2>";
            return;
        }

        //Her tar vi med verdien og sender
        //den over til EndreBestilling.aspx
        //De verdiene som er i hidden field
        //er "ordrenummeret", og er alt vi
        //trenger for å unikt kjenne igjen
        //de ulike radene som er valgt

        string verdi = value.ToString();

        string dataString = "";
        dataString += "&value=" + hf1.Value;
        Response.Redirect("EndreBestilling.aspx?" + dataString);
    }
}

