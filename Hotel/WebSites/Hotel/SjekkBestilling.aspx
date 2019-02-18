<%@ Page Title="Good Hotel - Sjekk bestilling" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="SjekkBestilling.aspx.cs" Inherits="SjekkBestilling" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HovedBilde" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:Label ID="FeilmeldingLabel" Runat="Server"></asp:Label>
    <asp:Label ID="bestillingSkjema" runat="Server">
    <h2>Dine bestillinger:</h2>
    <h4>Fornavn: <b><asp:Label ID="firstnameList" Runat="Server"></asp:Label></b></h4>
    <h4>Etternavn: <b><asp:Label ID="lastnameList" Runat="Server"></asp:Label></b></h4>
    <h4>Telefonnummer: <b><asp:Label ID="phonenumberList" Runat="Server"></asp:Label></b></h4>

    <div style="overflow-x:auto;">
    <asp:Table Class="tabell" ID="table" runat="server">
            <asp:TableHeaderRow runat="server">
                <asp:TableHeaderCell Text="Ordrenummer"></asp:TableHeaderCell>
                <asp:TableHeaderCell Text="Romtype"></asp:TableHeaderCell>
                <asp:TableHeaderCell Text="Fra Dato"></asp:TableHeaderCell>
                <asp:TableHeaderCell Text="Til Dato"></asp:TableHeaderCell>
                <asp:TableHeaderCell Text="Status"></asp:TableHeaderCell>
            </asp:TableHeaderRow>
         <asp:TableRow>
            <asp:TableCell></asp:TableCell>
            <asp:TableCell></asp:TableCell>
            <asp:TableCell></asp:TableCell>
            <asp:TableCell></asp:TableCell>
            <asp:TableCell></asp:TableCell>
        </asp:TableRow>
    </asp:Table>
        </div>
        </asp:Label>
    <asp:HiddenField ID="hf1" runat="server" />
    <asp:HiddenField ID="hf2" runat="server" />
    <div class="selected"></div>
    <script>
        var currentTab = "<%=currentTab%>";

        $("#MainContent_table tr").click(function(){
   $(this).addClass('selected').siblings().removeClass('selected');    
   var value=$(this).find('td:first').html();   

            var hiddenField = document.getElementById('<%= hf1.ClientID %>');
            hiddenField.value = value;

        });
        $("#MainContent_table tr").click(function(){
        $(this).addClass('selected').siblings().removeClass('selected'); 
        var value2 = $(this).find('td:last').html();
        var hiddenField2 = document.getElementById('<%= hf2.ClientID %>');
            hiddenField2.value = value2;
            });

    //Ovenfor her så kan du se "hidden fieldsene".
    //Det er som sagt kun en måte å få de rette verdiene
    //fra klient siden og over til server siden
    //Vi må ha dette når vi ønsker en klikkbar
    //tabell

    </script>
    <br />
    <asp:Label ID="informasjon" Runat="Server">
    <h4>Klikk på den bestillingen du vil endre/slette i tabellen ovenfor</h4>
    <h4>Husk at du kun kan endre/slette bestillinger på de bestillingene som ikke har tildelt rom</h4>
    <h4>Kontakt oss hvis du vil slette/endre bestilling på tildelte rom</h4><br />
    <asp:Button id="Button1" Text="Slett valgt bestilling" Class="btn btn-primary btn-lg" OnClick="slett" runat="server"/> <asp:Button id="Button2" Text="Endre valgt bestilling" Class="btn btn-primary btn-lg" OnClick="endre" runat="server"/>
    <br />
                    </asp:Label>
    <asp:Label ID="Label1" Runat="Server"></asp:Label>
</asp:Content>

