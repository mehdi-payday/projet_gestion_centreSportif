<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Activite.aspx.cs" Inherits="projet_gestion_centreSportif.Admin.activite.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h2>Admin Panel - Activite</h2>
        <table class="table table-striped table-hover activite-table">
            <tr>
                <th>Id</th>
                <th>Nom</th>
                <th>Prix</th>
                <th>Description</th>
                <th>Duree</th>
            </tr>
            <% foreach (var activite in activites) { %>
                <tr>
                    <td><%= activite.id %></td>
                    <td><%= activite.Nom %></td>
                    <td><%= activite.Prix %></td>
                    <td><%= activite.Description %></td>
                    <td><%= activite.Duree %></td>
                </tr>
            <% } %>
        </table>
    </div>
</asp:Content>
