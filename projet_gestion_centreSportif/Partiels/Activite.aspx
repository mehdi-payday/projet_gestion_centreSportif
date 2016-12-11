<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Activite.aspx.cs" Inherits="projet_gestion_centreSportif.Partiels.Activite" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h2>Activite</h2>
        <asp:LoginView runat="server" ViewStateMode="Disabled">
            <AnonymousTemplate>
                <p>Notre centre offre aux membres les activités suivantes :</p>
                <asp:GridView runat="server" ID="activitesAnon" class="table table-striped" AllowPaging="True" AllowSorting="True" DataSourceID="MySQL" autogeneratecolumns="false">
                    <Columns>
                        <asp:BoundField DataField="nom" headertext="Nom" />
                        <asp:BoundField DataField="description" headertext="Description" />
                        <asp:BoundField DataField="prix" headertext="Prix" DataFormatString="{0:C}" />
                        <asp:BoundField DataField="duree" headertext="Duree" DataFormatString="{0} jours"/>
                    </Columns>
                </asp:GridView>
            </AnonymousTemplate>
            <%-- Si l'utilisateur est connecté, on affiche le bouton --%>
            <LoggedInTemplate>
                <p>Vous pouvez vous inscrire aux activités suivantes :</p>
                <asp:GridView runat="server" ID="activites" class="table table-striped" AllowPaging="True" AllowSorting="True" DataSourceID="MySQL" autogeneratecolumns="false">
                    <Columns>
                        <asp:TemplateField ShowHeader="False">
                            <ItemTemplate>
                                <asp:LinkButton ID="btnInscription" runat="server" CausesValidation="false" OnClick="addActivite" CommandArgument='<%# Eval("id")%>' CommandName="inscrire" Text="S'inscrire">

                                </asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="nom" headertext="Nom" />
                        <asp:BoundField DataField="description" headertext="Description" />
                        <asp:BoundField DataField="prix" headertext="Prix" DataFormatString="{0:C}" />
                        <asp:BoundField DataField="duree" headertext="Duree" DataFormatString="{0} jours"/>
                    </Columns>
                </asp:GridView>
            </LoggedInTemplate>
        </asp:LoginView>

        <asp:SqlDataSource ID="MySQL" runat="server"
            ConnectionString="<%$ ConnectionStrings:centresportifConnectionString %>" 
            ProviderName="<%$ ConnectionStrings:centresportifConnectionString.ProviderName %>" 
            SelectCommand="SELECT `id`, `nom`, `description`, `prix`, `duree` FROM `activite`;" >
        </asp:SqlDataSource>
    </div>
</asp:Content>
