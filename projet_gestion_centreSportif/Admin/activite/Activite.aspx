<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Activite.aspx.cs" Inherits="projet_gestion_centreSportif.Admin.activite.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h2>Admin Panel - Activite</h2>
        <asp:GridView runat="server" ID="activites" class="table table-striped" AllowPaging="True" AllowSorting="True" DataSourceID="MySQL">
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
            </Columns>

        </asp:GridView>
        <asp:SqlDataSource ID="MySQL" runat="server"
             ConnectionString="<%$ ConnectionStrings:centresportifConnectionString %>" 
            DeleteCommand="DELETE FROM `activite` WHERE `id`=@ID" 
            InsertCommand="INSERT INTO `activite`(`nom`, `description`, `prix`, `duree`) VALUES (?,?,?,?)" 
            ProviderName="<%$ ConnectionStrings:centresportifConnectionString.ProviderName %>" 
            SelectCommand="SELECT `id`, `nom`, `description`, `prix`, `duree` FROM `activite`;" 
            UpdateCommand="UPDATE activite SET nom = @Nom, description = @Description, prix = @Prix, duree = @Duree WHERE (id = @ID)">
            <UpdateParameters>
                <asp:Parameter Name="Nom" Type="String"/>
                <asp:Parameter Name="Description" Type="String"/>
                <asp:Parameter Name="Prix"  Type="Double"/>
                <asp:Parameter Name="Duree" Type="Int32"/>
                <asp:Parameter Name="ID" Type="Int32"/>
            </UpdateParameters>
            <DeleteParameters>
                <asp:Parameter Name="ID" Type="Int32"/>
            </DeleteParameters>
        </asp:SqlDataSource>
    </div>
</asp:Content>
