<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Panier.aspx.cs" Inherits="projet_gestion_centreSportif.Partiels.Panier" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Panier</h2>
    <asp:GridView runat="server" ID="activites" class="table table-striped" AllowPaging="True" AllowSorting="True" autogeneratecolumns="false">
        <Columns>
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:LinkButton ID="btnSuppression" runat="server" CausesValidation="false" OnClick="removeActivite" CommandArgument='<%# Eval("id")%>' Text="Retirer">

                    </asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:LinkButton ID="btnDetails" runat="server" CausesValidation="false" OnClick="seeDetails" CommandArgument='<%# Eval("id")%>' CommandName="detail" Text="Détails">

                    </asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Nom" headertext="Nom" />
            <asp:BoundField DataField="Description" headertext="Description" />
            <asp:BoundField DataField="Prix" headertext="Prix" DataFormatString="{0:C2}" />
            <asp:BoundField DataField="Duree" headertext="Duree" DataFormatString="{0} jours"/>
        </Columns>
    </asp:GridView>
    <asp:Button runat="server" class="btn btn-warning" onclick="toggleCheckout" Text="Checkout" />
    <asp:Panel ID="errorPanel" runat="server" visible="false">
        <div class="alert alert-danger alert-dismissible">
            <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
            <strong>Erreur!</strong> <asp:Label runat="server" ID="error"></asp:Label>
        </div>
    </asp:Panel>
    <asp:Panel ID="checkoutPanel" runat="server" Visible="false">
        <h2>Checkout</h2>
    </asp:Panel>
</asp:Content>