<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Activite.aspx.cs" Inherits="projet_gestion_centreSportif.Admin.activite.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h2>Admin Panel - Activite</h2>
        <asp:GridView runat="server" ID="activites" class="table table-striped" AllowPaging="True" AllowSorting="True" DataSourceID="MySQL" DataKeyNames="id" autogeneratecolumns="false">
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                <asp:BoundField DataField="id" headertext="ID" />
                <asp:BoundField DataField="nom" headertext="Nom" />
                <asp:BoundField DataField="description" headertext="Description" />
                <asp:BoundField DataField="prix" headertext="Prix" />
                <asp:BoundField DataField="duree" headertext="Duree" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="MySQL" runat="server"
             ConnectionString="<%$ ConnectionStrings:centresportifConnectionString %>" 
            DeleteCommand="DELETE FROM `activite` WHERE `id`=@ID" 
            InsertCommand="INSERT INTO `activite`(`nom`, `description`, `prix`, `duree`) VALUES (?,?,?,?)" 
            ProviderName="<%$ ConnectionStrings:centresportifConnectionString.ProviderName %>" 
            SelectCommand="SELECT `id`, `nom`, `description`, `prix`, `duree` FROM `activite`;"
            UpdateCommand="UPDATE activite SET nom = @Nom, description = @Description, prix = @Prix, duree = @Duree WHERE (id = @ID)">
            <InsertParameters>
                <asp:Parameter Name="Nom" Type="String"/>
                <asp:Parameter Name="Description" Type="String"/>
                <asp:Parameter Name="Prix"  Type="Double"/>
                <asp:Parameter Name="Duree" Type="Int32"/>
            </InsertParameters>
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
        <asp:FormView id="formview" runat="server" DataSourceID="MySQL" RenderOuterTable="false">
            <ItemTemplate>
                <asp:Button ID="btnInsert" runat="Server" CommandName="New" Text="Nouveau" Class="btn btn-warning" />
            </ItemTemplate>
            <InsertItemTemplate>
                <table border="1"  class="table table-striped">
                    <tr>
                        <th>Nom</th>
                        <th>Description</th>
                        <th>Prix</th>
                        <th>Duree</th>
                    </tr>
                    <tr>
                        <td><asp:TextBox ID="TextBox1" runat="Server" Text='<%# Bind("Nom")%>'></asp:TextBox></td>
                        <td><asp:TextBox ID="TextBox2" runat="Server" Text='<%# Bind("Description")%>'></asp:TextBox></td>
                        <td><asp:TextBox ID="TextBox3" runat="Server" Text='<%# Bind("Prix")%>'></asp:TextBox></td>
                        <td><asp:TextBox ID="TextBox4" runat="Server" Text='<%# Bind("Duree")%>'></asp:TextBox></td>     
                </table>
                <asp:Button ID="btnSave" runat="Server" CommandName="insert" Text="Inserer" Class="btn btn-primary" />
                <asp:Button ID="Button1" runat="Server" CommandName="Cancel" Text="Annuler" Class="btn btn-warning" />
        </InsertItemTemplate>
        </asp:FormView>
    </div>
</asp:Content>
