<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Details.aspx.cs" Inherits="projet_gestion_centreSportif.Partiels.Details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <%--
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
    --%>
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
        <a runat="server" Class="btn btn-warning" href="~/Partiels/Activite">Retourner aux activités</a>
        <asp:LoginView runat="server" ViewStateMode="Disabled">
            <AnonymousTemplate>
                
            </AnonymousTemplate>
            <%-- Si l'utilisateur est connecté, on affiche le bouton --%>
            <LoggedInTemplate>
                <% 
                    int idActivite = -1;
                    if (int.TryParse(Request.Params.Get("id"), out idActivite)) {
                        if (!Context.User.IsInRole("admin") && !hasActivite(idActivite)) { 
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
