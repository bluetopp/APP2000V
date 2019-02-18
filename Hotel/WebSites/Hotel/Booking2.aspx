<%@ Page Title="Good Hotel - Booking" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Booking2.aspx.cs" Inherits="Booking2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HovedBilde" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:Label ID="tilbakemeldingLabel" runat="Server"></asp:Label>
    <asp:Label ID="bestillingsskjema" runat="Server">
    <div class="bestillingskjema">
        <h2>Fyll inn bestillingsskjema nedenfor!</h2>
        Fornavn        
        <asp:TextBox ID="fornavn" AutoPostBack="false" placeholder="Skriv inn ditt fornavn" Class="bestillinginput" runat="server" required></asp:TextBox><br />
        <asp:Label ID="fornavnError" runat="Server"></asp:Label>
        Etternavn      
        <asp:TextBox ID="etternavn" AutoPostBack="false" placeholder="Skriv inn ditt etternavn" Class="bestillinginput" runat="server" required></asp:TextBox><br />
        <asp:Label ID="etternavnError" runat="Server"></asp:Label>
        Telefonnummer  
        <asp:TextBox ID="tlf" AutoPostBack="false" type="number" placeholder="Skriv inn ditt telefonnummer" Class="bestillinginput" runat="server" required></asp:TextBox><br />
        <asp:Label ID="telefonError" runat="Server"></asp:Label>
        Fra dato valgt 
        <asp:TextBox ID="fraDatoValgt" AutoPostBack="false" Class="bestillinginput" Text="Ingen fra dato valgt" runat="Server" required></asp:TextBox>
        <br />
        Til dato valgt 
        <asp:TextBox ID="tilDatoValgt" AutoPostBack="false" Class="bestillinginput" Text="Ingen til dato valgt" runat="Server" required></asp:TextBox>
        <br />
        Antall Personer
        <asp:TextBox ID="antallPersonerValgt" AutoPostBack="false" Class="bestillinginput" Text="Ingen personer valgt" runat="Server" ReadOnly required></asp:TextBox>
        <br />
        Romtype        
        <asp:TextBox ID="romTypeValgt" AutoPostBack="false" Class="bestillinginput" Text="Ingen rom valgt" runat="Server" ReadOnly required></asp:TextBox>
        <br />
        <asp:Button ID="Button1" Text="Send bestilling!" Class="btn btn-primary btn-lg" OnClick="SendBestilling" runat="server" /><br /><br />
        <p class="solid"><b>Til informasjon:</b><br />Alle bestillinger som ikke har fått tildelt rom kan slettes på "sjekk status" på hovedsiden.<br />Alle bestillinger som skal avbestilles må skje innen 24 timer før overnattingen for å få full refusjon for rommet</p>
        <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
        <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
        <script>$(function () { $( "#<%= fraDatoValgt.ClientID %>" ).datepicker({ minDate: 0, dayNamesMin: [ "Sø", "Ma", "Ti", "On", "To", "Fr", "Lø" ], firstDay: 1, dateFormat: 'dd/mm/yy', orientation: "bottom" }); });</script>
        <script>$(function () { $( "#<%= tilDatoValgt.ClientID %>" ).datepicker({ minDate: 0, dayNamesMin: [ "Sø", "Ma", "Ti", "On", "To", "Fr", "Lø" ], firstDay: 1, dateFormat: 'dd/mm/yy', orientation: "bottom" }); });</script>
    </div>
    </asp:Label>
</asp:Content>

