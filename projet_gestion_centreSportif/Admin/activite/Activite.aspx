<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Activite.aspx.cs" Inherits="projet_gestion_centreSportif.Admin.activite.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h2>Admin Panel - Activite</h2>
        <asp:GridView runat="server" ID="activites" class="table table-striped">

        </asp:GridView>
    </div>
</asp:Content>
