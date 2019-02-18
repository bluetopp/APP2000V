<%@ Page Title="Good Hotel - Mat og Drikke" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="MatOgDrikke.aspx.cs" Inherits="MatOgDrikke" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HovedBilde" Runat="Server">

    <div class="bildecontainer">
            <img src="pictures/restaurantlokale.jpg" alt="Bilde av den eksklusive Restaurant Good" style="width:100%; height:auto; min-height: 500px;" />
            <div class="innledning">
                <p><h3>Mat <img class="logo" src="pictures/krone2.png" alt="Logo til Good Hotel" /> <span>Drikke</span></h3> <br />
                En kulinarisk opplevelse hos Restaurant Good, ferskere råvarer får du ikke!
                    </p>
            </div>
        </div>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

    <div id="matOgDrikke">
        <h2>Velkommen til våre resturanter, noen av de beste i verden!</h2>
        <br />
        <img src="pictures/resturant-goodest.jpg" alt="Bilde av resturant good" style="max-width:100%; height:auto;"/>
        <br />
        <br />
    <ul>
        <li>Resturantene har plass til alle og enhver, store og små!</li>
        <li>Daglige leveranser, time for time for å få de ferskeste råvarene</li>
        <li>Vår headchef Gordy Ramsen har over 30 års erfaring i bransjen, du vil bli fornøyd!</li>
        <li>Tre Michelinstjerner!</li>
        <li>Avslappende og rolig atmosfære, beroliggende bakgrunnsmusikk spilt live i resturantene</li>
        <li>Dine smaksløker skal forstås at de settes pris på</li>
        <li>Et minne for livet, garantert</li>
    </ul>
        <a href="Contact.aspx" style="text-decoration:none;"><h2>Kontakt oss idag for reservasjon!</h2></a>
            </div>

</asp:Content>

