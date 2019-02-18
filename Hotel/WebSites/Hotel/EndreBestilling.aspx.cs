using HotellBestilling;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EndreBestilling : System.Web.UI.Page
{
    //En egendefinert klasse (Order) laget av Marius Storvik.
    //Det er en datastrukturklasse for å holde
    //bestillingsdata fra databasen

    class Order
    {

        public string roomType;
        public string fromDate;
        public string toDate;
        public string status;
        public int phoneNumber;
        public string firstName;
        public string lastName;


        public Order(string roomType, string fromDate, string toDate, int phoneNumber, string firstName, string lastName)
        {
            this.roomType = roomType;
            this.fromDate = fromDate;
            this.toDate = toDate;
            this.phoneNumber = phoneNumber;
            this.firstName = firstName;
            this.lastName = lastName;
        }

    }

    protected void Page_LoadComplete(object sender, EventArgs e)
    {
            //Her sender vi en forespørsel til databasen
            //for å hente ut den orderen som brukeren til endre
        
            string ordrenummer = Request.QueryString["value"];

            DatabaseManager.Open("46.9.246.190", "24440", "hotell", "admin", "admin");
            DataSet result = DatabaseManager.Query
                (
                    "SELECT romtype, fradato, tildato, tlf, fornavn, etternavn FROM bestillinger WHERE bestillingID='" + ordrenummer + "';"
                );

                //Vi legger så det vi finner i en liste

                List<Order> OrderList = new List<Order>();

                string roomType;
                DateTime fromDate;
                DateTime toDate;
                string firstName;
                string lastName;
                int phoneNumber;
                
                //Vi looper så igjennom verdiene og legger dette i en liste

                foreach (DataRow row in result.Tables["result"].Rows)
                {
                    roomType = (string)row["romtype"];
                    fromDate = (DateTime)row["fradato"];
                    toDate = (DateTime)row["tildato"];
                    firstName = (string)row["fornavn"];
                    lastName = (string)row["etternavn"];
                    phoneNumber = (int)row["tlf"];
                    string fromDateString = fromDate.ToShortDateString();
                    string toDateString = toDate.ToShortDateString();
                    Order order = new Order(roomType, fromDateString, toDateString, phoneNumber, firstName, lastName);
                    OrderList.Add(order);
                }

                //Under så looper vi igjeonnom liste
                //og plasserer der verdiene skal i riktig
                //rekkefølge

                for (int i = 0; i < OrderList.Count; i++)
                {
                    string fornavn = OrderList[i].firstName;
                    string etternavn = OrderList[i].lastName;
                    int telefon = OrderList[i].phoneNumber;
                    string romtype = OrderList[i].roomType;
                    string fradato = OrderList[i].fromDate;
                    string tildato = OrderList[i].toDate;
                    string tildelt = OrderList[i].status;
                    fornavn = (OrderList[i].firstName);
                    etternavn = (OrderList[i].lastName);

                    string ChinatownSingle = "The Chinatown Single";
                    string DubaiDouble = "The Dubai Double";
                    string LeRoyale = "Le Royale des Cieux";
                    string ItalianJob = "The Italian Job";

                    string telefonen = telefon.ToString();

                    fornavnValgt.Text = fornavn;
                    etternavnValgt.Text = etternavn;
                    tlfValgt.Text = telefonen;
                    fraDatoValgt.Text = fradato;
                    tilDatoValgt.Text = tildato;
                    romTypeValgt.Text = romtype;

                    if (romTypeValgt.Text == "china")
                    {
                        romTypeValgt.Text = ChinatownSingle;
                    }

                    if (romTypeValgt.Text == "dubai")
                    {
                        romTypeValgt.Text = DubaiDouble;
                    }

                    if (romTypeValgt.Text == "french")
                    {
                        romTypeValgt.Text = LeRoyale;
                    }

                    if (romTypeValgt.Text == "italian")
                    {
                        romTypeValgt.Text = ItalianJob;
                    }
                }

                //For å vise et bedre datoformat, så bytter vi ut
                //. med / istedenfor

        string output1 = fraDatoValgt.Text.Replace(".", "/");
        string output2 = tilDatoValgt.Text.Replace(".", "/");

        fraDatoValgt.Text = output1;
        tilDatoValgt.Text = output2;
    }
        
    
        
    protected void EndreBestillingen(object sender, EventArgs e)
    {
        //Siden jeg skal ha norsk format på dato på hjemmesiden
        //så må jeg konvertere dette til engelsk format til databasen.
        //Så under benytter jeg meg av DateTime for å parse det eksakte formatet
        //og så gjøre det om til et datoformat som passer for oppsettet i databasen vår
        //Hvis jeg ikke gjør dette så får vi en stor error med SQL setningen

        DateTime dt1 = DateTime.ParseExact(fraDatoValgt.Text, "dd/mm/yyyy", CultureInfo.InvariantCulture);
        string innsjekkingParsed = dt1.ToString("yyyy/mm/dd");

        DateTime dt2 = DateTime.ParseExact(tilDatoValgt.Text, "dd/mm/yyyy", CultureInfo.InvariantCulture);
        string utsjekkingParsed = dt2.ToString("yyyy/mm/dd");

        //Under så åpner vi en ny databaseforbindelse
        //og sender UPDATE spørringen vår til databasen
        //Vi sjekker om den gikk igjennom ved hjelp
        //av NonQuery funksjonen vår

        string ordrenummer = Request.QueryString["value"];
        string error = ("<body class='endrebestilling'></body><h2>En feil har oppstått! Vennligst prøv igjen senere </h2>");
        string succeed = ("<body class='endrebestilling'></body><h2>Din ordre er nå oppdatert<br><a href='javascript:history.go(-1)'>Gå tilbake til den forrige siden</a></h2>");
        DatabaseManager.Open("46.9.246.190", "24440", "hotell", "admin", "admin");
        string query = ("UPDATE bestillinger SET fradato='" + innsjekkingParsed + "', tildato='" + utsjekkingParsed + "' WHERE bestillingID='" + ordrenummer + "';");
        bool success = DatabaseManager.NonQuery(query);

        if (success)
        {
            feilmeldingLabel.Text = succeed;
            endreBestillingLabel.Visible = false;
        }
        else
        {
            feilmeldingLabel.Text = error;
            endreBestillingLabel.Visible = false;
        }
    }
}