<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="projet_gestion_centreSportif._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
<div class="container">
    <div class="row">
        <h1>Centre Sportif Claude Robillard</h1>
        <p class="lead">Nous offrons toutes sortes d'activités!</p>
        <p><a runat="server" href="~/About" class="btn btn-primary btn-lg">En savoir plus &raquo;</a></p>
    </div>
</div>
<script type="text/javascript">
    $(document).ready(function () {
        $('.carousel').carousel({
            interval: 3000,
            pause: "false"
        });
    });
</script>
</asp:Content>
