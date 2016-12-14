<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="projet_gestion_centreSportif.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Nous joindre</h2>
    <div class="container">
        <div class="max-width">
            <img runat="server" src="~/Content/Images/About/front_1.jpg" alt="Centre sportif" style="width:1000px; height:auto"> 
        </div>
        <address>
           <h3>Coordonnées</h3>
           Complexe sportif <br />
           1000, avenue émile-Journault <br />
           Montréal (Québec) H2M 2E7 <br />
           <strong>Téléphone : </strong>  514 872-6900 <br />
           <strong>Télécopieur : </strong>  514 872-4718
        </address>

        <address>
            <h3>Heures d'ouverture</h3>
            Du lundi au vendredi, de 7 h à 22 h<br />
            Les samedis et les dimanches, de 7 h à 20 h<br />
            <br />
            <strong>Horaire</strong> (de début septembre à la fin juin)<br />
            Du lundi au vendredi, de 7 h à 22 h<br />
            Les samedis et les dimanches, de 7 h à 20 h
        </address>
        <address>
            <strong>Support:</strong>   <a href="mailto:Support@Claude-Roubillard.com">Support@Claude-Roubillard.com</a><br />
            <strong>Marketing:</strong> <a href="mailto:Marketing@Claude-Roubillard.com">Marketing@Claude-Roubillard.com</a>
        </address>
   </div>
</asp:Content>
