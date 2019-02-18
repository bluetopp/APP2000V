<%@ Page Title="Good Hotel - Kontakt oss" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Contact.aspx.cs" Inherits="Contact" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HovedBilde" Runat="Server">

    <div class="bildecontainer">
            <img src="pictures/kontaktoss.png" alt="Bilde av Good Hotels ansatte" style="width:100%; height:auto; min-height:500px;" />
            <div class="innledning">
                <p><h3>Kontakt <img class="logo" src="pictures/krone2.png" alt="Logo til Good Hotel" /> <span>Oss</span></h3> <br />
                Noe du lurer på? Ris eller ros? Kontakt oss idag!
                    </p>
            </div>
        </div>

</asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

           <ul class="kontakt">
            <div>
                <h2>Vi ønsker deg og dine en rik opplevelse, som virkelig setter sitt preg hos dere for resten av livet. Vi står for gode inntrykk, en herlig opplevelse og minner for livet.</h2> <br />
                <img src="pictures/kontaktosss.jpg" alt="Et bilde av en dame som venter på å bli kontaktet fra deg!" style="width:100%; height:auto; max-width:100%;" />
                <h4>For å få dine eventuelle spørsmål oppklart er det aldri vits i å nøle. Vi kommer alltid tilbake til deg innen én time. Ta kontakt nå!</h4>
                <h4>Ring oss på <u>+47 123 45 678</u> eller send oss mail på <u>support@goodhotel.com</u></h4>
            </div>  

</asp:Content>
