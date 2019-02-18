<%@ Page Title="Good Hotel - Om Oss" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="About.aspx.cs" Inherits="About" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HovedBilde" Runat="Server">

    <div class="bildecontainer">
            <img src="pictures/goodhotellondon1.jpg" alt="Bilde av det lukseriøse hotellet, Good Hotel" style="width:100%; height:auto; min-height: 500px;" />
            <div class="innledning">
                <p><h3>Om <img class="logo" src="pictures/krone2.png" alt="Logo til Good Hotel" /> <span>Hotellet</span></h3> <br />
                Vi ønsker deg velkommen til Good hotel, et hotel med moderne fasiliteter og komfort. <br /> Hos oss kan du utforske Norge med stil og luksus!
                    </p>
            </div>
        </div>

</asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div id="omOss">
        <h2>Vårt storslagne hotell har alt du kan drømme om</h2>
            <br />
        <img src="pictures/the-goodest-hotel-of-them-all.png" alt="Et bilde av good hotel sine uteplasser" style="max-width: 100%; height: auto;"/>
            <br />
            <br />
    <ul>
        <li>Hotellet ble opprinnlig startet som luksushotell i London</li>
        <li>Etter enorm etterspørsel fra Nordmenn, så har hotellet kommet til Norge i Gudbrandsdalen!</li>
        <li>Hotellet har kasino, bibliotek, svømmebasseng, spa, store ballsaler, konferanserom, egne resturanter og mer!</li>
        <li>Men hotellet stopper ikke bare der, opplev Gudbrandsdalen! Et av de store dalførene på Østlandet</li>
        <li>Dalen strekker seg 230 km fra Lillehammer ved Mjøsa, 124 moh og opp til Lesjaskogsvatnet</li>
        <li>Opplev de syv nasjonalparkene, kjent for sin overflod av lokalprodusert mat, gammel arkitektur samt gode ski-og vandreforhold!</li>
        <li>Besøke Good Hotel på vinteren? Dra til Hafjell eller Kvitfjell aplinsenter for en dag i bakken med slalån eller snowboard!</li>
        <li>Omgivelsene stopper ikke bare der, utforsk grotter, driv med fjellklatring, fjellridning, bike park og mye mer!</li>
        <li>Så hvorfor nøle, besøk Gudbrandsdalen og Good Hotel idag, og utforsk Norge med oss!</li>
    </ul>
        </div>
</asp:Content>
