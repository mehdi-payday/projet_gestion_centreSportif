<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MesActivites.aspx.cs" Inherits="projet_gestion_centreSportif.Partiels.MesActivites" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h2>Mes Activités</h2>
        <asp:GridView runat="server" ID="activites" class="table table-striped" AllowPaging="True" AllowSorting="True" DataSourceID="MySQL" autogeneratecolumns="false">
            <Columns>
                <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <asp:LinkButton ID="btnDetails" runat="server" CausesValidation="false" OnClick="seeDetails" CommandArgument='<%# Eval("id")%>' CommandName="detail" Text="Détails">

                        </asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="nom" headertext="Nom" />
                <asp:BoundField DataField="description" headertext="Description" />
                <asp:BoundField DataField="tempsRestant" headertext="Temps Restant" DataFormatString="{0} jours" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="MySQL" runat="server" 
            ConnectionString="<%$ ConnectionStrings:centresportifConnectionString %>" 
            ProviderName="<%$ ConnectionStrings:centresportifConnectionString.ProviderName %>" 
            SelectCommand="SELECT activite.id, activite.nom, activite.description, DATEDIFF(inscription.date_fin, inscription.date_debut) as tempsRestant FROM activite, inscription
            WHERE inscription.idMembre = @ID
            AND inscription.idActivite = activite.id;" >
        </asp:SqlDataSource>
        <a runat="server" href="~/Partiels/Activite" class="btn btn-primary">Parcourir les activités disponibles</a>
    </div>
</asp:Content>
