<%@ Page Title="Gestion - Membres" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Membre.aspx.cs" Inherits="projet_gestion_centreSportif.Admin.membre.Membre" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Admin Panel - Activite</h2>
    <div class="container liste-membres">
        <% foreach (var membre in membres){ %>
            <div class="thumbnail carte-membre">
                <img src="../../Content/membre.png" alt="Photo du membre" class="img-thumnail"/>
                <div class="caption">
                    <h3 class="thumbnail-title"><%= membre.Prenom + " " + membre.Nom %></h3>
                    <p><strong>Id:</strong> <span class="pull-right"><%= membre.Id %></span></p>
                    <p><strong>IsAdmin: </strong> <span class="pull-right"><%= membre.IsAdmin == 1? true: false %></span></p>
                    <p><strong>Email:</strong> <span class="pull-right"><%= membre.Email %></span></p>
                </div>
            </div>
        <% } %>
    </div>
</asp:Content>
