<%@ Page Title="Manage Account" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="projet_gestion_centreSportif.Account.Manage" %>

<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
<h2><%: Title %>.</h2>

<div>
    <asp:PlaceHolder runat="server" ID="successMessage" Visible="false" ViewStateMode="Disabled">
    <p class="text-success"><%: SuccessMessage %></p>
</asp:PlaceHolder>
</div>

<div class="container">        
    <h4>Changer vos informations</h4>       
    <hr />
    <div  data-toggle="validator">
        <asp:Label class="text-success" ID="change_info_message" runat="server" visible="false"></asp:Label>
        <div class="form-group row">
            <label for="firstname" class="col-xs-3 col-form-label">Nouveau nom:</label>
            <div class="col-xs-9">
                <asp:TextBox ID="newNom" type="text" class="form-control" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="form-group row">
            <label for="lastma,e" class="col-xs-3 col-form-label">Nouveau prénom :</label>
            <div class="col-xs-9">
                <asp:TextBox ID="newPrenom" type="text" class="form-control" runat="server"></asp:TextBox>
            </div>
        </div>
        <asp:Button ID="btnChangeInfo" OnClick="ChangeInfo" runat="server" class="btn btn-default " Text="Changer" />
    </div>  
    <br />
    <h4>Changer de mot de passe</h4>
    <hr />
    <div  data-toggle="validator">
        <asp:Label class="text-success" ID="changePassowrd_message" runat="server" visible="false"></asp:Label>
        <div class="form-group row">
            <label for="currentPassword" class="col-xs-3 col-form-label">Mot de passe acctuel :</label>
            <div class="col-xs-9">
                <asp:TextBox ID="currentPassword" type="password" class="form-control" runat="server"></asp:TextBox>
                <asp:Label class="text-danger" ID="current_password_error" runat="server" visible="false"></asp:Label>
            </div>
        </div>
        <div class="form-group row">
            <label for="newPassword1" class="col-xs-3 col-form-label">Nouveau mot de passe :</label>
            <div class="col-xs-9">
                <asp:TextBox ID="newPassword1" type="password" class="form-control" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="form-group row">
            <label for="newPassword2" class="col-xs-3 col-form-label">Confirmer mot de passe :</label>
            <div class="col-xs-9">
                <asp:TextBox ID="newPassword2" type="password" data-match="MainContent_newPassword1" class="form-control" runat="server"></asp:TextBox>
                <asp:Label  class="text-danger" ID="new_password_error" runat="server" visible="false"></asp:Label>
            </div>
        </div>
        <asp:Button ID="btnChangePassword" OnClick="ChangePassword" runat="server" class="btn btn-default " Text="Changer" />
    </div>
    <br />
    <div>
        <h4>Historique de connexion</h4>
        <hr />
        <asp:GridView ID="LoginHistory" class="table table-striped" runat="server" DataSourceID="MySQL" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="nom" headertext="Nom" />
                <asp:BoundField DataField="prenom" headertext="Prenom" />
                <asp:BoundField DataField="email" headertext="Adresse courriel" />
                <asp:BoundField DataField="date" headertext="Date de connexion" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="MySQL" runat="server" 
        ConnectionString="<%$ ConnectionStrings:centresportifConnectionString %>" 
        ProviderName="<%$ ConnectionStrings:centresportifConnectionString.ProviderName %>">
        </asp:SqlDataSource>
    </div>
    
</div>
</asp:Content>
