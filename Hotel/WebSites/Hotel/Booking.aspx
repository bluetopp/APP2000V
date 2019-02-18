<%@ Page Title="Good Hotel - Booking" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Booking.aspx.cs" Inherits="Booking" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HovedBilde" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="boooking">
        <asp:Label ID="AvailableRoomList" runat="Server"></asp:Label>
        <asp:Label ID="KinaLabel" runat="Server"></asp:Label>
        <table>
            <tr>
                <th>
                    <asp:Label ID="Label1" runat="Server"></asp:Label></th>
                <th>
                    <asp:Literal runat="server" Text="Antall rom igjen: " ID="kinaAntall" EnableViewState="false" /></th>
            </tr>
        </table>
        <br />
        <asp:Button ID="Chinatown" Class="btn btn-primary btn-lg" runat="server" OnClick="Chinatown_Click" Text="Velg 'The Chinatown Single'" />
        <asp:Label ID="DubaiLabel" runat="Server"></asp:Label>
        <table>
            <tr>
                <th>
                    <asp:Label ID="Label2" runat="Server"></asp:Label></th>
                <th>
                    <asp:Literal runat="server" Text="Antall rom igjen: " ID="dubaiAntall" EnableViewState="false" /></th>
            </tr>
        </table>
        <br />
        <asp:Button ID="Dubai" Class="btn btn-primary btn-lg" runat="server" OnClick="Dubai_Click" Text="Velg 'The Dubai Double'" />
        <asp:Label ID="FrenchLabel" runat="Server"></asp:Label>
        <table>
            <tr>
                <th>
                    <asp:Label ID="Label3" runat="Server"></asp:Label></th>
                <th>
                    <asp:Literal runat="server" Text="Antall rom igjen: " ID="frenchAntall" EnableViewState="false" /></th>
            </tr>
        </table>
        <br />
        <asp:Button ID="France" Class="btn btn-primary btn-lg" runat="server" Text="Velg 'Le Royaume des Cieux'" OnClick="France_Click" />
        <asp:Label ID="ItalianLabel" runat="Server"></asp:Label>
        <table>
            <tr>
                <th>
                    <asp:Label ID="Label4" runat="Server"></asp:Label></th>
                <th>
                    <asp:Literal runat="server" Text="Antall rom igjen: " ID="italianAntall" EnableViewState="false" /></th>
            </tr>
        </table>
        <br />
        <asp:Button ID="Italian" Class="btn btn-primary btn-lg" runat="server" Text="Velg 'The Italian Job'" OnClick="Italian_Click" />

    </div>
</asp:Content>

