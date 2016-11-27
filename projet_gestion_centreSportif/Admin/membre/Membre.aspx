<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Membre.aspx.cs" Inherits="projet_gestion_centreSportif.Admin.membre.Membre" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <ul>
        <% foreach (var membre in membres){ %>
            <li><%= membre.Prenom %></li>
        <% } %>
    </ul>
</asp:Content>
