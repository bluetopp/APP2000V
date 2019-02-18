<%@ Page Title="Good Hotel - Kasino" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Casino.aspx.cs" Inherits="Casino" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HovedBilde" Runat="Server">

    <div class="bildecontainer">
            <img src="pictures/goodcasino.jpg" alt="Bilde av Good Casino" style="width:100%; height:auto; min-height: 500px;" />
            <div class="innledning">
                <p><h3>Good <img class="logo" src="pictures/krone2.png" alt="Logo til Good Hotel" /> <span>Casino</span></h3> <br />
                Bli millionær på ditt hotellbesøk!
                    </p>
            </div>
        </div>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

        <div id="casino">
        <h2>Hvorfor dra til Las Vegas, når vi heller kan åpne Las Vegas her?</h2>
            <br />
            <img src="pictures/casino-rulett.jpg" alt="Et bilde av casino rullett" style="max-width: 100%; height: auto;"/>
            <br />
            <br />
    <ul>
        <li>Rekker med rulettmaskiner, Black Jack, Baccarat, Poker, Craps og mye mer!</li>
        <li>Årlige Texas Holdem Poker turneringer</li>
        <li>Premiepotten øker årlig, med en gevinst på over 100 millioner norske kroner!</li>
        <li>Topp moderne maskiner og lokale</li>
        <li>Staben er av verdensklasse, med kjennskap til alle regler</li>
        <li>Åpen bar så du kan nyte verdens dyreste drinker mens du håver inn millioner</li>
        <li>Fold, eller call? All in</li>
    </ul>
        </div>


</asp:Content>

