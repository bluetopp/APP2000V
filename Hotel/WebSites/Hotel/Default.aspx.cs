using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HotellBestilling
{
    public partial class _Default : Page
    {
        public void Page_LoadComplete(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Button1.Click += new EventHandler(this.SjekkRom);
                Console.WriteLine("tekst");
            }
        }



        public void SjekkRom(object sender, EventArgs e)
        {
            //Sjekker om brukeren faktisk har tastet inn telefonnummer

            if (string.IsNullOrEmpty(innsjekking.Text) && string.IsNullOrEmpty(utsjekking.Text) && string.IsNullOrEmpty(personer.Text))
            {
                string error = ("<h2>Alle feltene må fylles inn!</h2>");
                Feilmelding.Text = error;
            }

            //Åpner opp en databaseforbindelse

            Button clickedButton = (Button)sender;
            DatabaseManager.Open("46.9.246.190", "24440", "hotell", "admin", "admin");

            //Siden jeg skal ha norsk format på dato på hjemmesiden
            //så må jeg konvertere dette til engelsk format til databasen.
            //Så under benytter jeg meg av DateTime for å parse det eksakte formatet
            //og så gjøre det om til et datoformat som passer for oppsettet i databasen vår
            //Hvis jeg ikke gjør dette så får vi en stor error med SQL setningen

            DateTime dt1 = DateTime.ParseExact(innsjekking.Text, "dd/mm/yyyy", CultureInfo.InvariantCulture);
            string innsjekkingParsed = dt1.ToString("yyyy/mm/dd");

            DateTime dt2 = DateTime.ParseExact(utsjekking.Text, "dd/mm/yyyy", CultureInfo.InvariantCulture);
            string utsjekkingParsed = dt2.ToString("yyyy/mm/dd");

            //Henter liste med alle romtypene og hvor mange rom som er ledige for hver type
            //Her bruker vi en metode som ligger i BookingData.cs under mappen App_Code
            List<TypeCount> typeCount = BookingData.GetAvailableRoomsForPeriod(innsjekkingParsed, utsjekkingParsed, int.Parse(personer.Text));

            //Legger sammen alle typene og antallene inn i en lang streng. Formatet er a=type|antall& (& hvis det skal fortsette)
            //En kan legge til så mange en vil, det er bare å fortsette på typeCount.
            //Alt blir lagt til ved å loope det i en for loop

            string dataString = "";
            string temp = "";

            for (int i = 0; i < typeCount.Count; i++)
            {
                if (i == 0)
                {
                    temp = typeCount[i].type + "=" + typeCount[i].type + "|" + typeCount[i].count;
                }
                else
                {
                    temp = "&" + typeCount[i].type + "=" + typeCount[i].type + "|" + typeCount[i].count;
                }
                dataString += temp;

            }

            dataString += "&fradato=" + innsjekking.Text + "&tildato=" + utsjekking.Text + "&personer=" + personer.Text;

            //Send med URL'en til neste side
            //Du kan se i URL'en på nettsiden at den blir mye større
            Response.Redirect("Booking.aspx?" + dataString);
        }

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

        //Denne under er for sjekk bestilling funksjonen
        //Her tar vi med telefonnummeret og legger det i URL'en
        //Hvis vi skulle hatt en realistisk løsning
        //så måtte vi ha sjekket dette mot en server
        //som sier at brukeren faktisk er den man er
        //Telefonnummeret blir sjekket i databasen på SjekkBestilling.aspx.cs

        protected void SjekkBestilling(object sender, EventArgs e)
        {
            string dataString = "";
            dataString += "&tlf=" + SjekkBestillingFelt.Text;
            Response.Redirect("SjekkBestilling.aspx?" + dataString);
        }
    }
}