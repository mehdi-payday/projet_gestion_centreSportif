<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Panier.aspx.cs" Inherits="projet_gestion_centreSportif.Partiels.Panier" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            
        });
    </script>
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
                            <asp:RequiredFieldValidator CssClass="text-danger" ControlToValidate="nomField" runat="server" ErrorMessage="Ce champ ne peut être vide." Display="Dynamic"> </asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group row">
                        <asp:Label runat="server" AssociatedControlID="adresseField" CssClass="col-sm-3 col-form-label">Adresse:</asp:Label>
                        <div class="col-sm-9">
                            <asp:TextBox ID="adresseField" type="text" class="form-control" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator  CssClass="text-danger" ControlToValidate="adresseField" runat="server" ErrorMessage="Ce champ ne peut être vide." Display="Dynamic"> </asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group row">
                        <asp:Label runat="server" AssociatedControlID="noCarteField" CssClass="col-sm-3 col-form-label">No de carte:</asp:Label>
                        <div class="col-sm-9">
                            <asp:TextBox ID="noCarteField" type="number" class="form-control" runat="server"></asp:TextBox>
                            <asp:RegularExpressionValidator 
                               Display = "Dynamic" CssClass="text-danger" ControlToValidate = "noCarteField" ID="RegularExpressionValidator1" ValidationExpression = "^[\s\S]{14,19}$" runat="server" ErrorMessage="Votre numbero de carte de crédit n'est pas valide">
                            </asp:RegularExpressionValidator>
                            <asp:RequiredFieldValidator CssClass="text-danger" ControlToValidate="noCarteField" runat="server" ErrorMessage="Ce champ ne peut être vide." Display="Dynamic"> </asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group row">
                        <asp:Label runat="server" AssociatedControlID="expirationField" CssClass="col-sm-3 col-form-label">Expiration:</asp:Label>
                        <div class="col-sm-9">
                            <asp:TextBox ID="expirationField" type="" class="form-control datepicker" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator CssClass="text-danger" ControlToValidate="expirationField" runat="server" ErrorMessage="Ce champ ne peut être vide." Display="Dynamic"> </asp:RequiredFieldValidator>

                        </div>
                    </div>
                    <div class="form-group row">
                        <asp:Label runat="server" AssociatedControlID="cvcField" CssClass="col-sm-3 col-form-label">CVC:</asp:Label>
                        <div class="col-sm-9">
                            <asp:TextBox ID="cvcField" type="number" class="form-control" runat="server"></asp:TextBox>
                            <asp:RegularExpressionValidator 
                                Display = "Dynamic" CssClass="text-danger"  ControlToValidate = "cvcField" ID="RegularExpressionValidator3" ValidationExpression = "^[\s\S]{3,3}$" runat="server" ErrorMessage="Le CVC est composé de 3 chiffres">
                            </asp:RegularExpressionValidator>
                            <asp:RequiredFieldValidator CssClass="text-danger" ControlToValidate="cvcField" runat="server" ErrorMessage="Ce champ ne peut être vide." Display="Dynamic"> </asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <asp:Button ID="btnPayer" OnClick="payerActivites" runat="server" class="btn btn-danger " Text="Payer" />
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>  
    </asp:Panel>
</asp:Content>
