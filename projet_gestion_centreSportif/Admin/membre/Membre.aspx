<%@ Page Title="Gestion - Membres" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Membre.aspx.cs" Inherits="projet_gestion_centreSportif.Admin.membre.Membre" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Admin Panel - Membre</h2>
    <asp:GridView runat="server" ID="membres" class="table table-striped" AllowPaging="True" AllowSorting="True" DataSourceID="MySQL" DataKeyNames="id" autogeneratecolumns="false">
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                <asp:BoundField DataField="id" headertext="ID" ReadOnly="true" />
                <asp:BoundField DataField="prenom" headertext="Prenom" />
                <asp:BoundField DataField="nom" headertext="Nom" />
                <asp:BoundField DataField="email" headertext="Adresse courriel" />
                <asp:TemplateField HeaderText="Administrateur?">
                    <ItemTemplate>
                        <asp:Label ID="isAdminLabel" runat="server" Text='<%# (Convert.ToDecimal(Eval("isAdmin")) > 0) ? "Vrai" : "Faux"   %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="MySQL" runat="server"
            ConnectionString="<%$ ConnectionStrings:centresportifConnectionString %>" 
            DeleteCommand="DELETE FROM `membre` WHERE `id` = @ID;"
            InsertCommand="INSERT INTO `membre`(`prenom`, `nom`, `email`, `password`) VALUES (?,?,?,?);" 
            ProviderName="<%$ ConnectionStrings:centresportifConnectionString.ProviderName %>" 
            SelectCommand="SELECT `id`, `prenom`, `nom`, `email`, `password`, `isAdmin` FROM `membre`;"
            UpdateCommand="UPDATE `membre` SET `prenom` = @Prenom, `nom` = @Nom, `email` = @Email WHERE (`id` = @ID);">
            <InsertParameters>
                <asp:Parameter Name="Prenom" Type="String"/>
                <asp:Parameter Name="Nom" Type="String"/>
                <asp:Parameter Name="Email"  Type="String"/>
                <asp:Parameter Name="Password" Type="String"/>
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="Prenom" Type="String"/>
                <asp:Parameter Name="Nom" Type="String"/>
                <asp:Parameter Name="Email" Type="String"/>
                <asp:Parameter Name="ID" Type="Int32"/>
            </UpdateParameters>
            <DeleteParameters>
                <asp:Parameter Name="ID" Type="Int32"/>
            </DeleteParameters>
        </asp:SqlDataSource>
        <asp:FormView id="formview" runat="server" DataSourceID="MySQL" RenderOuterTable="false">
            <ItemTemplate>
                <asp:Button ID="btnInsert" runat="Server" CommandName="New" Text="Nouveau" Class="btn btn-warning" />
            </ItemTemplate>
            <InsertItemTemplate>
                <table border="1"  class="table table-striped">
                    <tr>
                        <th>Nom</th>
                        <th>Prenom</th>
                        <th>Email</th>
                        <th>Password</th>
                    </tr>
                    <tr>
                        <td><asp:TextBox ID="TextBox1" runat="Server" Text='<%# Bind("Nom")%>'></asp:TextBox></td>
                        <td><asp:TextBox ID="TextBox2" runat="Server" Text='<%# Bind("Prenom")%>'></asp:TextBox></td>
                        <td><asp:TextBox ID="TextBox3" runat="Server" Text='<%# Bind("Email")%>'></asp:TextBox></td>
                        <td><asp:TextBox ID="TextBox4" runat="Server" Text='<%# Bind("Password")%>'></asp:TextBox></td>     
                </table>
                <asp:Button ID="btnSave" runat="Server" CommandName="insert" Text="Inserer" Class="btn btn-primary" />
                <asp:Button ID="Button1" runat="Server" CommandName="Cancel" Text="Annuler" Class="btn btn-warning" />
        </InsertItemTemplate>
        </asp:FormView>
</asp:Content>
