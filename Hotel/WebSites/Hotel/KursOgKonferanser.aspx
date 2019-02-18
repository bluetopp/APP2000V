<%@ Page Title="Good Hotel - Kurs og Konferanser" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="KursOgKonferanser.aspx.cs" Inherits="KursOgKonferanser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HovedBilde" Runat="Server">

    <div class="bildecontainer">
            <img src="pictures/storkonferanse.jpg" alt="Bilde av våre kurs og konferanser" style="width:100%; height:auto; min-height: 500px;" />
            <div class="innledning">
                <p><h3>Kurs <img class="logo" src="pictures/krone2.png" alt="Logo til Good Hotel" /> <span>Konferanser</span></h3> <br />
                Mer enn bare et møte. Book rom for kurs og konferanser idag!
                    </p>
            </div>
        </div>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

    <div id="kursOgKonferanser">
        <h2>Vi tilbyr våres lokaler for alle kurs, møter og konferanser!</h2>
    <ul>
        <li>Vi kan ta imot alt fra 2 til 2000 personer</li>
        <li>I tillegg til kurs og konferanser, så kan rom også bli benyttet til topp hemmlige møter</li>
        <li>Alle møterom er toppmoderne og tilpasset etter oppsett og behov</li>
        <li>Hurtig og topp moderne fiber teknologi fra Altibox, 5 Gb/s ned og opplastningshastighet</li>
        <li>Over 100 rom å velge imellom</li>
        <li>Partnerskap med ulike land og firmaer verden over, alltid noe spennende å se på!</li>
        <li>Flere kurs og ukeslange konferanser blir holdt året rundt</li>
    </ul>
            </div>
    <div id="kommendeArrangementer">
        <h2>Liste over kommende arrangementer</h2>
        <div style="overflow-x:auto;">
        <table align="right" style="width:100%">
            <tr>
                <th align="left">Arrangementnavn</th>
                <th align="left">Foreleser</th>
                <th align="left">Fra dato</th>
                <th align="left">Til dato</th>
            </tr>
            <tr>
                <td align="left">IT Global Security</td>
                <td align="left">Microsoft</td>
                <td align="left">20/05/2018</td>
                <td align="left">28/05/2018</td>
            </tr>
            <tr>
                <td align="left">International Conferance on Business Management</td>
                <td align="left">Philip Kotler</td>
                <td align="left">01/06/2018</td>
                <td align="left">03/06/2018</td>
            </tr>
            <tr>
                <td align="left">International Conferance on E-Business</td>
                <td align="left">Amazon</td>
                <td align="left">04/06/2018</td>
                <td align="left">06/06/2018</td>
            </tr>
            <tr>
                <td align="left">Are there really multiple universes?</td>
                <td align="left">Alain Aspect</td>
                <td align="left">07/06/2018</td>
                <td align="left">14/06/2018</td>
            </tr>
            <tr>
                <td align="left">Quantum Mechanics: Qbits and its functions</td>
                <td align="left">NASA</td>
                <td align="left">15/06/2018</td>
                <td align="left">22/06/2018</td>
            </tr>
            <tr>
                <td align="left">Sjakkens entrepenør: Hvordan jeg ble stor</td>
                <td align="left">Magnus Carlsen</td>
                <td align="left">23/06/2018</td>
                <td align="left">24/06/2018</td>
            </tr>
            <tr>
                <td align="left">How to become rich!</td>
                <td align="left">Bill Gates</td>
                <td align="left">25/06/2018</td>
                <td align="left">30/06/2018</td>
            </tr>
            <tr>
                <td align="left">Conferance on Communication Software and Networks</td>
                <td align="left">Apple</td>
                <td align="left">01/07/2018</td>
                <td align="left">07/07/2018</td>
            </tr>
        </table>
            </div>
        </div>
</asp:Content>

