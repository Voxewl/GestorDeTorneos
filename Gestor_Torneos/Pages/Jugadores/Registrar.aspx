<%@ Page Title="Registrar Jugador" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Registrar.aspx.cs" Inherits="Gestor_Torneos.Pages.Jugadores.Registrar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="text-center text-white mb-4">
        <h2>Registro de Jugadores</h2>
    </div>

    <asp:Literal ID="ltlMensaje" runat="server"></asp:Literal>

    <div class="card bg-dark text-white p-4 mb-4">
        <div class="row mb-3">
            <div class="col-md-6 mb-3">
                <label for="ddlUsuarios" class="form-label">Seleccionar Usuario:</label>
                <asp:DropDownList ID="ddlUsuarios" runat="server" CssClass="form-select bg-dark text-white border-secondary" DataSourceID="SqlDataSourceUserName" DataTextField="UserName" DataValueField="Id"></asp:DropDownList>
                <asp:SqlDataSource runat="server" ID="SqlDataSourceUserName" ConnectionString='<%$ ConnectionStrings:DefaultConnection %>' SelectCommand="SELECT Id, UserName FROM AspNetUsers"></asp:SqlDataSource>
            </div>
            <div class="col-md-6 mb-3">
                <label for="txtAlias" class="form-label">Alias del Jugador:</label>
                <asp:TextBox ID="txtAlias" runat="server" CssClass="form-control bg-dark text-white border-secondary" Placeholder="Alias del jugador"></asp:TextBox>
            </div>
        </div>
        <asp:Button ID="btnRegistrar" runat="server" Text="Registrar Jugador" CssClass="btn btn-primary w-100" OnClick="btnRegistrar_Click" />
    </div>

    <div class="table-responsive">
        <asp:GridView ID="gvJugadores" runat="server" CssClass="table table-dark table-bordered"
            AutoGenerateColumns="false" DataKeyNames="JugadorId"
            OnRowEditing="gvJugadores_RowEditing"
            OnRowCancelingEdit="gvJugadores_RowCancelingEdit"
            OnRowUpdating="gvJugadores_RowUpdating"
            OnRowDeleting="gvJugadores_RowDeleting"
            AllowPaging="True" AllowSorting="True" DataSourceID="SqlDataSourceGVJugadores">
            <Columns>
                <asp:BoundField DataField="JugadorId" HeaderText="JugadorId" ReadOnly="True" SortExpression="JugadorId" />
                <asp:BoundField DataField="Alias" HeaderText="Alias" SortExpression="Alias" />
                <asp:BoundField DataField="UserName" HeaderText="UserName" SortExpression="UserName" />
                <asp:BoundField DataField="FechaRegistro" HeaderText="FechaRegistro" SortExpression="FechaRegistro" />
            </Columns>
        </asp:GridView>

        <asp:SqlDataSource runat="server" ID="SqlDataSourceGVJugadores"
            ConnectionString='<%$ ConnectionStrings:DefaultConnection %>'
            SelectCommand="SELECT JugadorId, Alias, UserName, FechaRegistro FROM vw_Jugadores">
        </asp:SqlDataSource>
    </div>
</asp:Content>
