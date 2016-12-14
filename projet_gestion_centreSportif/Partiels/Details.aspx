<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Details.aspx.cs" Inherits="projet_gestion_centreSportif.Partiels.Details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
        $("#myCarousel").remove();
    });
    </script>
    <%--<div>
        <img class="banner" src="../Content/Images/banner_black.JPG" />
    </div>--%>
    <div class="container">
        <h2>Détails de l'activité <asp:Label ID="lblNom" runat="server" Text=""></asp:Label></h2>
        <%-- <img alt="" src="<%= activite.Image %>" /> --%>
        <asp:Image ID="imageActivite" runat="server" />
        <p style="text-align: justify;">
            <asp:Label ID="lblDescription" runat="server" Text=""></asp:Label></p>
        <p>  
            Durée de l'activité : <asp:Label ID="lblDuree" runat="server" Text=""></asp:Label>&nbsp;jours
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            Prix : <asp:Label ID="lblPrix" runat="server" Text=""></asp:Label>&nbsp;$
        </p>
        <asp:Panel ID="errorPanel" runat="server" visible="false">
            <div class="alert alert-danger alert-dismissible">
                <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
                <strong>Erreur!</strong> <asp:Label runat="server" ID="error"></asp:Label>
            </div>
        </asp:Panel>
        <a runat="server" Class="btn btn-warning" href="~/Partiels/Activite">Retourner aux activités</a>
        <asp:LoginView runat="server" ViewStateMode="Disabled">
            <%-- Si l'utilisateur est connecté, on affiche le bouton --%>
            <LoggedInTemplate>
                <% 
                    int idActivite = -1;
                    if (int.TryParse(Request.Params.Get("id"), out idActivite)) {
                        if (!Context.User.IsInRole("admin")) { 
                %>
                            <asp:Button ID="btnInscrire" runat="server" Text="Ajouter au panier" OnClick="btnInscrire_Click" Class="btn btn-primary" />
                <% 
                        }
                    }
                %>
            </LoggedInTemplate>
        </asp:LoginView>
    </div>
</asp:Content>
