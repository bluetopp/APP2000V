using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HotellBestilling;
using MySql.Data;
using MySql.Data.MySqlClient;

public partial class Booking2 : System.Web.UI.Page
{
    protected void Page_LoadComplete(object sender, EventArgs e)
    {

        //Sjekker om det er en postback på siden
        //Hvis det ikke er det, så skal den kjøre
        //Postback kjører Page_LoadComplete igjen
        //og er for å unngå at den skal kjøre to ganger

        if (!Page.IsPostBack)
        {
            //Nedenfor så henter jeg ut verdiene jeg vil ha
            //via Request.QueryString. Disse blir sendt over
            //i URL'en fra Booking.aspx. Verdiene blir lagt i en string

            string fradato = Request.QueryString["fradato"];
            string tildato = Request.QueryString["tildato"];
            string personer = Request.QueryString["personer"];
            string romtype = Request.QueryString["romtype"];

            //Legger verdiene fra forrige side over
            //i input fields for å bestille et rom

            fraDatoValgt.Text = fradato;
            tilDatoValgt.Text = tildato;
            antallPersonerValgt.Text = personer;
            romTypeValgt.Text = romtype;

            string ChinatownSingle = "The Chinatown Single";
            string DubaiDouble = "The Dubai Double";
            string LeRoyale = "Le Royale des Cieux";
            string ItalianJob = "The Italian Job";

            //Her konverterer vi navnene slik at de er bedre
            //lesbare for brukerne.

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
    }

    protected void SendBestilling(object sender, EventArgs e)
    {
        string telefon = tlf.Text;
        telefonError.Text = "";
        fornavnError.Text = "";
        etternavnError.Text = "";
        bool valid = true;
        string KinaEnkel = "china";
        string DubaiDobbel = "dubai";
        string French = "french";
        string Italia = "italian";

        //Siden jeg skal ha norsk format på dato på hjemmesiden
        //så må jeg konvertere dette til engelsk format til databasen.
        //Så under benytter jeg meg av DateTime for å parse det eksakte formatet
        //og så gjøre det om til et datoformat som passer for oppsettet i databasen vår
        //Hvis jeg ikke gjør dette så får vi en stor error med SQL setningen

        DateTime dt1 = DateTime.ParseExact(fraDatoValgt.Text, "dd/mm/yyyy", CultureInfo.InvariantCulture);
        string innsjekkingParsed = dt1.ToString("yyyy/mm/dd");

        DateTime dt2 = DateTime.ParseExact(tilDatoValgt.Text, "dd/mm/yyyy", CultureInfo.InvariantCulture);
        string utsjekkingParsed = dt2.ToString("yyyy/mm/dd");

        //Under så konverterer jeg om verdiene som blir hentet til en verdi
        //som passer til oppsettet i databasen.
        //The Chinatown Single ser feks bedre ut enn bare verdien "china" som
        //vi benytter oss av i databasen for regler.

        if (romTypeValgt.Text == "The Chinatown Single")
        {
            romTypeValgt.Text = KinaEnkel;
        }

        if (romTypeValgt.Text == "The Dubai Double")
        {
            romTypeValgt.Text = DubaiDobbel;
        }

        if (romTypeValgt.Text == "Le Royale des Cieux")
        {
            romTypeValgt.Text = French;
        }

        if (romTypeValgt.Text == "The Italian Job")
        {
            romTypeValgt.Text = Italia;
        }


        //Under så sjekker jeg om lengden
        //på tlf nummeret er 8 tegn (norskt tlf nummer)
        //og hvis den ikke er 8 tegn så er det ugyldig.
        //Stringen blir sendt til en label, og valid blir false
        //som stopper programmet

        if (telefon.Length != 8)
        {
            string telefonFeil = ("<p style='color: red;'>Telefonnummeret har feil format!</p>");
            telefonError.Text = telefonFeil;
            valid = false;
        }

        //Legger result1 og result2 i en boolsk verdi
        //(true/false) og sjekker om disse kun er bokstaver

        bool result1 = fornavn.Text.All(Char.IsLetter);
        bool result2 = etternavn.Text.All(Char.IsLetter);

        //Hvis de ikke er bare bokstaver, så får man feil

        if (result1 == false)
        {
            string fornavnFeil = ("<p style='color: red;'>Fornavnet kan kun bestå av bokstaver!</p>");
            fornavnError.Text = fornavnFeil;
            valid = false;
        }

        if (result2 == false)
        {
            string etternavnFeil = ("<p style='color: red;'>Etternavnet kan kun bestå av bokstaver!</p>");
            etternavnError.Text = etternavnFeil;
            valid = false;
        }

        //Hvis valid er false, så stoppes programmet

        if (!valid)
        {
            return;
        }

        //error og succeed er meldinger om spørringen går igjennom eller ikke
        System.Diagnostics.Debug.WriteLine(tlf.Text);
        string error = ("<h2>En feil har oppstått! Vennligst prøv igjen senere </h2>");
        string succeed = ("<body class='booking2'></body><h2>Takk for din bestilling! Din bestilling vil bli behandlet så fort som mulig <br> Sjekke status på bestilling? Sjekk status <a href=SjekkBestilling?&tlf=" + tlf.Text + ">her!</a></h2>");

        //Sender en ny forespørsel til databasemanager (klasse filen)
        //og sender over koblingen. Så lager vi en string (query)
        //og lager en spørring. Denne blir sendt over med metoden
        //Query. Så sjekker den om spørringen går igjennom eller ikke
        //(bedre beskrevet i databasemanager.cs filen

        DatabaseManager.Open("46.9.246.190", "24440", "hotell", "admin", "admin");
        string query = ("INSERT INTO bestillinger (romtype, fradato, tildato, tlf, fornavn, etternavn) VALUES ('" + romTypeValgt.Text + "', '" + innsjekkingParsed + "', '" + utsjekkingParsed + "', " + tlf.Text + ", '" + fornavn.Text + "', '" + etternavn.Text + "');");
        System.Diagnostics.Debug.WriteLine(query);
        bool success = DatabaseManager.NonQuery(query);

        //I filen DatabaseManager.cs så har vi en metode som heter NonQuery
        //som sjekker om antall rader tilbake gjør om spørringen går igjennom eller ikke
        //Hvis den går igjennom så får vi "succeed", hvis ikke så får vi "error"
        //Den er bedre beskrevet i DatabaseManager.cs, som ligger under App_Code mappen

        if (success)
        {
            tilbakemeldingLabel.Text = succeed;
            bestillingsskjema.Visible = false;
        }
        else
        {
            tilbakemeldingLabel.Text = error;
            bestillingsskjema.Visible = false;
        }

    }

}
