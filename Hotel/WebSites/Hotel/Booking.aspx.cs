using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data;
using HotellBestilling;
using MySql.Data.MySqlClient;

public partial class Booking : System.Web.UI.Page
{
    public int romtype = 0;

    public void Page_LoadComplete(object sender, EventArgs e)
    {
        //Sjekker om det er en postback på siden
        //Hvis det ikke er det, så skal den kjøre
        //Postback kjører Page_LoadComplete igjen
        //og er for å unngå at den skal kjøre to ganger

        if (!Page.IsPostBack)
        {
            //Nedenfor så henter jeg ut verdiene jeg vil ha
            //via Request.QueryString. Disse blir sendt over
            //i URL'en fra Default.aspx. Verdiene blir lagt i en string

            string fradato = Request.QueryString["fradato"];
            string tildato = Request.QueryString["tildato"];
            string personer = Request.QueryString["personer"];

            string china = Request.QueryString["china"];
            string dubai = Request.QueryString["dubai"];
            string french = Request.QueryString["french"];
            string italian = Request.QueryString["italian"];

            //Under kjører vi en en inline if (?) for å sjekke om
            //det eksisterer noe i det vi henter ut. 0|0 er for
            //å sjekke om det er noe i "splitten" (|) på stringen

            china = (china == "" || china == null) ? "0|0" : china;
            dubai = (dubai == "" || dubai == null) ? "0|0" : dubai;
            french = (french == "" || french == null) ? "0|0" : french;
            italian = (italian == "" || italian == null) ? "0|0" : italian;

            int chinaCount = int.Parse(china.Split('|')[1]);
            int dubaiCount = int.Parse(dubai.Split('|')[1]);
            int frenchCount = int.Parse(french.Split('|')[1]);
            int italianCount = int.Parse(italian.Split('|')[1]);

            string kinaTell = chinaCount.ToString();
            kinaAntall.Text = kinaTell;

            string dubaiTell = dubaiCount.ToString();
            dubaiAntall.Text = dubaiTell;

            string frenchTell = frenchCount.ToString();
            frenchAntall.Text = frenchTell;

            string italianTell = italianCount.ToString();
            italianAntall.Text = italianTell;

            //Koden nedenfor bruker inline-if (?) til å sjekke
            //om knappen skal være synlig eller ikke.
            //Den blir synlig hvis det er ledige rom igjen
            //og blir skjult hvis det ikke er noen ledige rom igjen

            Chinatown.Visible = (chinaCount <= 0) ? false : true;
            Dubai.Visible = (dubaiCount <= 0) ? false : true;
            France.Visible = (frenchCount <= 0) ? false : true;
            Italian.Visible = (italianCount <= 0) ? false : true;

            //Gjør samme som ovenfor, bare med labels istedenfor
            //(teksten og bildet som kommer)

            KinaLabel.Visible = (chinaCount <= 0) ? false : true;
            DubaiLabel.Visible = (dubaiCount <= 0) ? false : true;
            FrenchLabel.Visible = (frenchCount <= 0) ? false : true;
            ItalianLabel.Visible = (italianCount <= 0) ? false : true;

            //Gjør det samme som ovenfor, bare med labels istedenfor
            //(teksten til antall rom igjen)

            Label1.Visible = (chinaCount <= 0) ? false : true;
            Label2.Visible = (dubaiCount <= 0) ? false : true;
            Label3.Visible = (frenchCount <= 0) ? false : true;
            Label4.Visible = (italianCount <= 0) ? false : true;

            //Gjør samme som ovenfor, bare med literals istedenfor
            //(sjekker antall rom som er igjen)

            kinaAntall.Visible = (chinaCount <= 0) ? false : true;
            dubaiAntall.Visible = (dubaiCount <= 0) ? false : true;
            frenchAntall.Visible = (frenchCount <= 0) ? false : true;
            italianAntall.Visible = (italianCount <= 0) ? false : true;

            String[] split = china.Split('|');

            //Under sender jeg stringen antallromigjen til labels

            string antallromigjen = ("Antall rom igjen: ");
            Label1.Text = antallromigjen;
            Label2.Text = antallromigjen;
            Label3.Text = antallromigjen;
            Label4.Text = antallromigjen;

            //Her legger jeg inn html kode for å få opp en mer fancy side

            string kinaText = ("<div class='kolonne'><h2>The Chinatown Single</h2><br><img src='pictures/romsingle.jpg' style='max-width:100%;' alt='Bilde av et av våre Chinatown Single rom'/><br><br><p id='romtekst'>The Chinatown Single er det perfekte rom for deg som reiser alene. Rommet er utstyrt med minibar med ulike varianter av drikkevarer som faller enhver i smak, 65 tommer tv og våre King Size bed med fløyelsmyk sengetøy av ypperste kvalitet! Badet består av både dusj og badekar som standard, så her unner vi ingenting! Husk at daglig massasje er også inkludert i prisen samt frokost på rommet for den som har dårlig med tid. Dette rommet vil du garantert elske!<br><br></p><br><h4><b>Dette rommet inkluderer</b></h4><br><ul><li>Minibar</li><li>65 tommer 4k tv</li><li>King Size seng</li><li>Dusj og badekar</li><li>Daglig massasje</li><li>Frokost på rommet inkludert</li><li>Ypperlig for en person</li></ul><br /><b>Pris per natt: 50 000,- NOK</b><br /></div>");
            KinaLabel.Text = kinaText;

            string dubaiText = ("<div class='kolonne'><h2>The Dubai Double</h2><br><img src='pictures/romdouble.jpg' style='max-width:100%;' alt='Bilde av et av våre Dubai Double rom'/><br><br><p id='romtekst'>The Dubai Double er det perfekte rom for det forelskede par på reise. Hvis et rom med Extra King Size bed av top kvalitet, dempende lys og høytalere utstyrt i tak og vegger hvor du kan spille den musikk du ønsker ikke faller i smak, vet ikke vi. Våre Dubai Double rom har eksklusive bad perfekt for to, dobbel dusj, doble vasker og sist men ikke minst boblebad på terassen med utsikt over byens fasade bør i hvertfall gjøre susen. Om dere ikke er nyforelsket vil dere bli det nå!<br></p><br><h4><b>Dette rommet inkluderer</b></h4><ul><li>Minibar</li><li>To King Size senger</li><li>Justerende lys med fargevalg</li><li>PA Anlegg for ypperlig musikk</li><li>65 tommer 4k tv</li><li>Dobbel dusj samt doble vasker</li><li>Terasse med boblebad og ypperlig utsikt</li><li>Ypperlig for to personer</li></ul><br /><b>Pris per natt: 100 000,- NOK</b></div>");
            DubaiLabel.Text = dubaiText;

            string frenchText = ("<div class='kolonne'><h2>Le Royaume des Cieux</h2><br><img src='pictures/goodfrench.jpg' style='max-width:100%;' alt='Bilde av et av våre eksklusive fransk spesial rom'/><br><br><p id='romtekst'>Går det ann å oppleve fransk kultur uten å måtte dra til kjærlighetens land? Da er Le Royaume des Cieux rommet for dere. Duften av forelskelse fyller rommet, og Paris er like rundt hjørnet. Med innebygd fontene og ekte fransk musikk i bakgrunn kan Frankrike virkelig oppleves her hos oss. Badet består av stor og dusj, stort badekar og doble vasker som standard. Om dere er to par på utskikk på noe uten det vanlige, er valget her. Bienvenue!<br><br></p><br><h4><b>Dette rommet inkluderer</b></h4><ul><li>Minibar med gratis påfyll</li><li>65 tommer 4k tv</li><li>Fire King Size senger</li><li>Stort bad med dusj og badekar</li><li>Innebygd fontene</li><li>Frokost på rommet inkludert</li></ul><br /><b>Pris per natt: 200 000,- NOK</b><br /></div>");
            FrenchLabel.Text = frenchText;

            string italianText = ("<div class='kolonne'><h2>The Italian Job</h2><br><img src='pictures/rompenthouse.jpg' style='max-width:100%;' alt='Bilde av et av våre eksklusive penthouses'/><br><br><p id='romtekst'>The Italian Job er for den som vet hva han vil ha. Toppen av kransekaka. Prikken over I&#39;en. Her er det verken mindre, heller mer. To etasjer, tre soverom, ett master bedroom, tre bad, to kjøkken, egen mini kinosal hvor ukens filmer spilles dagen lang. 360 grader med veranda, to boblebad. Egen bar kun utstyrt med de beste årganger og egen bartender på job KUN for deg. Daglig massasje og frokost på døren. Velkommen hjem, til ditt hjem<br><br><br><h4><b>Dette rommet inkluderer</b></h4><ul><li>Minibar med gratis påfyll</li><li>65 tommer 4k tv</li><li>To etasjer</li><li>Tre soverom + ett master bedroom</li><li>Tre bad inkludert dusj og badekar</li><li>To kjøkken</li><li>Egen mini kinosal</li><li>360 graders terasse med to boblebad</li><li>Daglig massasje</li><li>Frokost på rommet inkludert</li></ul><br /><b>Pris per natt: 500 000,- NOK</b><br /></div>");
            ItalianLabel.Text = italianText;

            //Under er en if sjekk om det er noe i stringene china, dubai, french eller italian
            //Hvis det ikke er noe der, så er det ingen ledige rom
            //Ellers så vil den vise listen over tilgjenlige romtyper

            if (string.IsNullOrEmpty(china) && string.IsNullOrEmpty(dubai) && string.IsNullOrEmpty(french) && string.IsNullOrEmpty(italian))
            {
                string error = ("<h2>Beklager, ingen ledige rom i den gitte tidsperioden</h2>");
                AvailableRoomList.Text = error;
            }
            else
            {
                string correct = ("<h2>Nedenfor er en liste over romtyper som matcher ditt søk!</h2>");
                AvailableRoomList.Text = correct;
            }
        }
    }

    //Under så lager jeg klassefelt med fradato, tildato
    //og personer, og requester disse verdiene med querystring

    public dynamic Fradato => Request.QueryString["fradato"];
    public dynamic Tildato => Request.QueryString["tildato"];
    public dynamic Personer => Request.QueryString["personer"];

    //Under har jeg laget en metode som skal ta verdiene og sende
    //disse videre. Metoden blir kalt opp når en trykker på knappene
    //og sender de diverse romtype verdiene videre.
    //Da har altså kunden valgt et rom!

    public void SendData(string romtype)
    {
        string datastring = "";
        datastring += "&fradato=" + Fradato + "&tildato=" + Tildato + "&personer=" + Personer + "&romtype=" + romtype;
        Response.Redirect("Booking2.aspx?" + datastring);
    }

    //Under ligger alle kodene til knappene
    //som kaller opp metoden SendData().

    protected void Chinatown_Click(object sender, EventArgs e)
    {
        string romtype = "china";
        SendData(romtype);
    }

    protected void Dubai_Click(object sender, EventArgs e)
    {
        string romtype = "dubai";
        SendData(romtype);
    }

    protected void France_Click(object sender, EventArgs e)
    {
        string romtype = "french";
        SendData(romtype);
    }

    protected void Italian_Click(object sender, EventArgs e)
    {
        string romtype = "italian";
        SendData(romtype);
    }
}


