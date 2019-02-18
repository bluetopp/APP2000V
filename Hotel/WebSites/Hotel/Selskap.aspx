<%@ Page Title="Good Hotel - Selskap" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Selskap.aspx.cs" Inherits="Selskap" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HovedBilde" Runat="Server">

    <div class="bildecontainer">
            <img src="pictures/bryllup2.jpg" alt="Bilde av et nygift par hos Good Hotel" style="width:100%; height:auto; min-height: 500px;" />
            <div class="innledning">
                <p><h3>Selskap <img class="logo" src="pictures/krone2.png" alt="Logo til Good Hotel" /> <span>Bryllup</span></h3> <br />
                Hos Good Hotel får du de fineste ballsaler til din drømmedag!
                    </p>
            </div>
        </div>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

    <div id="selskap">
        <h2>Våre selskapslokaler passer alle typer selskaper!</h2>
        <br />
        <img src="pictures/flower-girl.jpg" alt="Vakre bryllupsjenter klare for den store dagen" style="max-width:100%; height:auto;"/>
        <br />
        <br />
    <ul>
        <li>Perfekt for bryllup!</li>
        <li>Vi har i en årrekke inviet stormforelskede personer i ekteskap</li>
        <li>Dette er din dag, og vi vil gjøre alt for at den skal bli perfekt!</li>
        <li>Våre selskapsrom er laget av de beste, for de beste</li>
        <li>Måltider laget av vår headchef Gordy Ramsen</li>
        <li>Åpen bar med de beste årgangsvin</li>
        <li>Er dere klare for innvielse? Vi er klare!</li>
    </ul>
        </div>
    <a href="Contact.aspx" style="text-decoration:none;"><h2>Kontakt oss idag for planlegging av din drømmedag!</h2></a>
          

</asp:Content>

