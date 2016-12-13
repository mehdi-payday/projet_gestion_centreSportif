<%@ Page Title="Gestion de compte" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="projet_gestion_centreSportif.Account.Manage" %>

<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
<h2><%: Title %>.</h2>
<div class="form-horizontal">        
    <h4>Changer vos informations</h4>       
    <hr />
    <div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server"><ContentTemplate> 
        <asp:Label class="text-success" ID="change_info_message" runat="server" visible="false"></asp:Label>
        <div class="form-group row">
            <asp:Label runat="server" AssociatedControlID="newNom" CssClass="col-sm-3 col-form-label">Nouveau nom:</asp:Label>
            <div class="col-sm-9">
                <asp:TextBox ID="newNom" type="text" class="form-control" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="form-group row">
            <asp:Label runat="server" AssociatedControlID="newPrenom" CssClass="col-sm-3 col-form-label">Nouveau prénom :</asp:Label>
            <div class="col-sm-9">
                <asp:TextBox ID="newPrenom" type="text" class="form-control" runat="server"></asp:TextBox>
            </div>
        </div>
        <asp:Button ID="btnChangeInfo" OnClick="ChangeInfo" runat="server" class="btn btn-default " Text="Changer" />
            </ContentTemplate></asp:UpdatePanel>
    </div>  
    <br />
    <h4>Changer de mot de passe</h4>
    <hr />
    <div >
        <asp:UpdatePanel ID="UpdatePanel2" runat="server"><ContentTemplate> 
        <div class="form-group">
            <asp:Label class="text-success" ID="changePassowrd_message" runat="server" visible="false"></asp:Label>
            <asp:Label runat="server" AssociatedControlID="currentPassword" CssClass="col-sm-3 col-form-label">Mot de passe acctuel :</asp:Label>
            <div class="col-sm-9">
                <asp:TextBox runat="server" ID="currentPassword" type="password" CssClass="form-control"/>
                <asp:Label class="text-danger" ID="current_password_error" runat="server" visible="false"></asp:Label>
            </div>
        </div>
        <br />
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="newPassword1" CssClass="col-sm-3 col-form-label">Nouveau mot de passe :</asp:Label>
            <div class="col-sm-9">
                <asp:TextBox runat="server" ID="newPassword1" TextMode="Password" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="newPassword1"
                CssClass="text-danger" ErrorMessage="Ce champ est obligatoire." validationgroup="passwords"/>
            </div>
            <asp:Label runat="server" AssociatedControlID="newPassword2" CssClass="col-sm-3 col-form-label">Confirmer mot de passe :</asp:Label>
            <div class="col-sm-9">
                <asp:TextBox runat="server" ID="newPassword2" TextMode="Password" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="newPassword2"
                CssClass="text-danger" Display="Dynamic" ErrorMessage="Ce champ est obligatoire." validationgroup="passwords" />
                <asp:CompareValidator runat="server" ControlToCompare="newPassword1" ControlToValidate="newPassword2"
                CssClass="text-danger" Display="Dynamic" ErrorMessage="Les mots de passe ne correspondent pas."/>
            </div>
        </div>
        <asp:Button runat="server" OnClick="ChangePassword" validationgroup="passwords" Text="Changer" CssClass="btn btn-default" />
        </ContentTemplate></asp:UpdatePanel>
    </div>
    <br />
    <div>
        <h4>Historique de connexion</h4>
        <hr />
        <asp:GridView ID="LoginHistory" class="table table-striped" runat="server" DataSourceID="MySQL" AutoGenerateColumns="False" AllowPaging="True" AllowSorting="True">
        <Columns>
            <asp:BoundField DataField="nom" headertext="Nom" />
            <asp:BoundField DataField="prenom" headertext="Prenom" />
            <asp:BoundField DataField="email" headertext="Adresse courriel" />
            <asp:BoundField DataField="date" headertext="Date de connexion" />
            <asp:BoundField DataField="ipAdresse" headertext="Adresse IP" />
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="MySQL" runat="server" 
    ConnectionString="<%$ ConnectionStrings:centresportifConnectionString %>" 
    ProviderName="<%$ ConnectionStrings:centresportifConnectionString.ProviderName %>">
</asp:SqlDataSource>
</div>

</div>
</asp:Content>
