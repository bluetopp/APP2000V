<%@ Page Title="Good Hotel - Endre bestillingen" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="EndreBestilling.aspx.cs" Inherits="EndreBestilling" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HovedBilde" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <div class="bestillingskjema">
        <asp:Label ID="feilmeldingLabel" Runat="Server"></asp:Label>
        <asp:Label ID="endreBestillingLabel" Runat="Server">
        <h2>Informasjon om bestilling</h2>
        <h4>Fornavn: <b><asp:Label ID="fornavnValgt" Runat="Server"></asp:Label></b></h4>
        <h4>Etternavn: <b><asp:Label ID="etternavnValgt" Runat="Server"></asp:Label></b></h4>
        <h4>Telefonnummer: <b><asp:Label ID="tlfValgt" Runat="Server"></asp:Label></b></h4>
        <h4>Romtype: <b><asp:Label ID="romTypeValgt" Runat="Server"></asp:Label></b></h4> <br /> 
        <h2>Du kan nå endre følgende verdier nedenfor</h2>
        Fra dato valgt  <asp:Textbox ID="fraDatoValgt" Class="bestillinginput" Text="Ingen fra dato valgt" Runat="Server" required></asp:Textbox> <br />
        Til dato valgt  <asp:Textbox ID="tilDatoValgt" Class="bestillinginput" Text="Ingen til dato valgt" Runat="Server" required></asp:Textbox> <br />             
        <asp:Button id="Button1" Text="Endre bestilling!" Class="btn btn-primary btn-lg" OnClick="EndreBestillingen" runat="server"/>
            </asp:Label>
     </div>
        <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
        <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
        <script>$(function () { $( "#<%= fraDatoValgt.ClientID %>" ).datepicker({ minDate: 0, dayNamesMin: [ "Sø", "Ma", "Ti", "On", "To", "Fr", "Lø" ], firstDay: 1, dateFormat: 'dd/mm/yy', orientation: "bottom" }); });</script>
        <script>$(function () { $( "#<%= tilDatoValgt.ClientID %>" ).datepicker({ minDate: 0, dayNamesMin: [ "Sø", "Ma", "Ti", "On", "To", "Fr", "Lø" ], firstDay: 1, dateFormat: 'dd/mm/yy', orientation: "bottom" }); });</script>


</asp:Content>

