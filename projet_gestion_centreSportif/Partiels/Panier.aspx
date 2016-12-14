<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Panier.aspx.cs" Inherits="projet_gestion_centreSportif.Partiels.Panier" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
        $("#myCarousel").remove();
    });
    </script>
    <div>
        <img class="banner" src="../Content/Images/banner_black.JPG" />
    </div>
    <h2>Panier</h2>
    <asp:Panel ID="panierVide" runat="server" visible="false">
        <div class="alert alert-danger">
            <strong>Dommage!</strong> Votre panier est vide
        </div>
    </asp:Panel>
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
    <asp:Button ID="checkoutBouton" runat="server" class="btn btn-warning" onclick="toggleCheckout" Text="Passer a la caisse" />
    <asp:Panel ID="errorPanel" runat="server" visible="false">
        <div class="alert alert-danger alert-dismissible">
            <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
            <strong>Erreur!</strong> <asp:Label runat="server" ID="error"></asp:Label>
        </div>
    </asp:Panel>
    <asp:Panel ID="checkoutPanel" runat="server" Visible="false">
        <h2>Informations de paiement</h2>
        <hr />
        <div>
            <asp:UpdatePanel ID="UpdatePanelCheckout" runat="server">
                <ContentTemplate>
                    <div class="form-group row">
                        <asp:Label runat="server" AssociatedControlID="nomField" CssClass="col-sm-3 col-form-label">Identifiant de carte:</asp:Label>
                        <div class="col-sm-9">
                            <asp:TextBox ID="nomField" type="text" class="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group row">
                        <asp:Label runat="server" AssociatedControlID="adresseField" CssClass="col-sm-3 col-form-label">Adresse:</asp:Label>
                        <div class="col-sm-9">
                            <asp:TextBox ID="adresseField" type="text" class="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group row">
                        <asp:Label runat="server" AssociatedControlID="noCarteField" CssClass="col-sm-3 col-form-label">No de carte:</asp:Label>
                        <div class="col-sm-9">
                            <asp:TextBox ID="noCarteField" type="text" class="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group row">
                        <asp:Label runat="server" AssociatedControlID="expirationField" CssClass="col-sm-3 col-form-label">Expiration:</asp:Label>
                        <div class="col-sm-9">
                            <asp:TextBox ID="expirationField" type="text" class="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group row">
                        <asp:Label runat="server" AssociatedControlID="cvcField" CssClass="col-sm-3 col-form-label">CVC:</asp:Label>
                        <div class="col-sm-9">
                            <asp:TextBox ID="cvcField" type="text" class="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <asp:Button ID="btnPayer" OnClick="payerActivites" runat="server" class="btn btn-danger " Text="Payer" />
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>  
    </asp:Panel>
</asp:Content>
