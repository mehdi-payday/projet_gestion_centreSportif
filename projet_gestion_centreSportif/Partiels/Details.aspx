<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Details.aspx.cs" Inherits="projet_gestion_centreSportif.Partiels.Details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <%
        int idActivite=-1;
        projet_gestion_centreSportif.Models.Activite activite = null;
        if (Request.Params.Get("id") == null || Request.Params.Get("id") == "") {
            Response.Redirect("Activite.aspx");
        }
        else {
            if (!int.TryParse(Request.Params.Get("id"), out idActivite)) {
                Response.Redirect("Activite.aspx");
            }
            else {
                activite = new projet_gestion_centreSportif.Services.ActiviteService().Read(idActivite);
                if(activite == null) {
                    Response.Redirect("Activite.aspx");
                }
            }
        }
    %>
    <div class="container">
        <h2>Détails de l'activité <%= activite.Nom %></h2>
        <%-- <img alt="" src="<%= activite.Image %>" /> --%>
        <asp:Image ID="imageActivite" runat="server" />
        <p style="text-align: justify;"><%= activite.Description %></p>
        <p>  
            Durée de l'activité : <%= activite.Duree %> jours
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            Prix : <%= activite.Prix %> $
        </p>
        <a runat="server" Class="btn btn-warning" href="~/Partiels/Activite">Retourner aux activités</a>
        <asp:LoginView runat="server" ViewStateMode="Disabled">
            <AnonymousTemplate>
                
            </AnonymousTemplate>
            <%-- Si l'utilisateur est connecté, on affiche le bouton --%>
            <LoggedInTemplate>
                <% if (!Context.User.IsInRole("admin") && !hasActivite(int.Parse(Request.Params.Get("id")))) { %>
                    <%-- <asp:Label ID="lblInscrire" runat="server" Text="S'inscrire dès maintenant !   "></asp:Label> --%>
                    <asp:Button ID="btnInscrire" runat="server" Text="Ajouter au panier" OnClick="btnInscrire_Click" Class="btn btn-primary" />
                <% } %>
            </LoggedInTemplate>
        </asp:LoginView>
    </div>
</asp:Content>
