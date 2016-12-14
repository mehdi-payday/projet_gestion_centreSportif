<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Confirmation.aspx.cs" Inherits="projet_gestion_centreSportif.Partiels.Confirmation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
     $(document).ready(function () {
        $("#myCarousel").remove();
    });
    </script>
    <div>
        <img class="banner" src="../Content/Images/banner_black.JPG" />
    </div>
    <div class="container">
        <h2>Confirmation de transaction</h2>
        <p>Votre transaction a été effectué avec succès!</p>
        <a runat="server" href="~/" class="btn btn-primary">Retourner a l'accueil</a>
    </div>
</asp:Content>