<%@ Page Title="Good Hotel - Hovedsiden" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="false" CodeFile="Default.aspx.cs" Inherits="HotellBestilling._Default" %>

<asp:content ContentPlaceHolderID="HovedBilde" runat="server">

<div class="bildecontainer">
            <img src="pictures/good-hotel-hoved.jpg" class="hoved1" alt="Bilde av det legendariske Good Hotel" style="width:100%; height:auto;" />
            <div class="innledning">
                <p><h3>Good <img class="logo" alt="Logo av Good Hotel" src="pictures/krone2.png" /> <span>Hotel</span></h3 <br />
                En kulinarisk og luksuriøs opplevelse, book hos oss idag!
                </p>
                <div class="booking">
        <asp:Textbox type="text" ID="innsjekking" AutoPostBack="false" name="innsjekking" placeholder="Velg innsjekkingsdato" runat="server"/><br /><asp:Textbox type="text" AutoPostBack="false" name="utsjekking" ID="utsjekking" placeholder="Velg utsjekkingsdato" runat="server"/><br /><asp:DropDownList runat="server" AutoPostBack="false" ID="personer"><asp:ListItem Value="">Velg antall personer</asp:ListItem><asp:ListItem Text="1" Value="1" /><asp:ListItem Text="2" Value="2" /><asp:ListItem Text="3" Value="3" /><asp:ListItem Text="4" Value="4" /></asp:DropDownList><br /><asp:Button id="Button1" Text="Se ledige rom" UseSubmitBehavior="false" Class="btn btn-primary btn-lg" OnClick="SjekkRom" runat="server"/><br>
        </div>
            </div>
        </div>
       
        <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
        <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
        <script>$(function () { $( "#<%= innsjekking.ClientID %>" ).datepicker({ minDate: 0, dayNamesMin: [ "Sø", "Ma", "Ti", "On", "To", "Fr", "Lø" ], firstDay: 1, dateFormat: 'dd/mm/yy', orientation: "bottom" }); });</script>
        <script>$(function () { $( "#<%= utsjekking.ClientID %>" ).datepicker({ minDate: 0, dayNamesMin: [ "Sø", "Ma", "Ti", "On", "To", "Fr", "Lø" ], firstDay: 1, dateFormat: 'dd/mm/yy', orientation: "bottom" }); });</script>

</asp:content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="Feilmelding" Runat="Server"></asp:Label>
    <h2>Sjekke status på bestilling? Tast inn telefonnummeret under og sjekk nå!</h2>
    <asp:Textbox type="text" ID="SjekkBestillingFelt" name="sjekkbestilling" placeholder="Skriv inn telefonnummer" runat="server"/><asp:Button id="SjekkBestillingKnapp" Text="Sjekk bestilling" Class="btn btn-primary btn-lg" UseSubmitBehavior="false" OnClick="SjekkBestilling" runat="server"/>
    <asp:Label ID="FeilmeldingLabel" Runat="Server"></asp:Label>
    <div class="row"> 
  <div class="column">
    <a href="MatOgDrikke.aspx" style="text-decoration:none; color:inherit;"><img src="pictures/frokost.jpg" alt="Et bilde av en deilig frokost ved Good Hotel" />
            <h2>Eksklusive måltider</h2>
            <p>For Good Hotel så er kun de ferskeste råvarene gode nok, derfor kan vi garantere at hvert måltid er eksklusivt!</p></a>
	<a href="KursOgKonferanser.aspx" style="text-decoration:none; color:inherit;"><img src="pictures/konferanse.jpg" alt="Et bilde av en stor konferanse ved Good Hotel" />
            <h2>Kurs og konferanser</h2>
            <p>Med vårt topp moderne konferanserom med plass til 250 personer, så er det ingen problemer å holde konferanser eller kurs hos oss!</p></a>		
  </div>
  <div class="column">
    <a href="Selskap.aspx" style="text-decoration:none; color:inherit;"><img src="pictures/bryllup.jpg" alt="En lykkelig dag for et lykkelig par, et bryllup ved Good Hotel"/>
            <h2>Selskap</h2>
            <p>For alle store og små øyeblikk, så passer våres selskapsrom alle! Få ditt selskap skreddersydd for din anledning!</p></a>
	<a href="Casino.aspx" style="text-decoration:none; color:inherit;"><img src="pictures/kasino.jpg" alt="Et storslagent rom fylt med maskiner og poker, casino ved Good Hotel!" />
            <h2>Casino</h2>
            <p>Spill på vårt splitter nye casino! Topp moderne med stort utvalg av spill! Vi garanterer at du vil bli millionær!</p></a>
  </div>
</div>

</asp:Content>
