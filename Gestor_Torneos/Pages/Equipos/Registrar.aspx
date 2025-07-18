<%@ Page Title="Registrar Equipo" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Registrar.aspx.cs" Inherits="Gestor_Torneos.Pages.Equipos.Registrar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="text-center text-white mb-4">
        <h2>Registro de Equipos</h2>
    </div>

    <asp:Literal ID="ltlMensaje" runat="server"></asp:Literal>

    <div class="card bg-dark text-white p-4 mb-4">
        <div class="mb-3">
            <label for="txtNombreEquipo" class="form-label">Nombre del Equipo:</label>
            <asp:TextBox ID="txtNombreEquipo" runat="server" CssClass="form-control bg-dark text-white border-secondary" Placeholder="Nombre del equipo"></asp:TextBox>
        </div>
        <asp:Button ID="btnRegistrarEquipo" runat="server" Text="Registrar Equipo" CssClass="btn btn-primary w-100" OnClick="btnRegistrarEquipo_Click" />
    </div>

    <div class="table-responsive">
        <asp:GridView ID="gvEquipos" runat="server" CssClass="table table-dark table-bordered"
            AutoGenerateColumns="false" DataKeyNames="ID_Equipo"
            OnRowEditing="gvEquipos_RowEditing"
            OnRowCancelingEdit="gvEquipos_RowCancelingEdit"
            OnRowUpdating="gvEquipos_RowUpdating"
            OnRowDeleting="gvEquipos_RowDeleting"
            AllowPaging="True" AllowSorting="True" DataSourceID="SqlDataSourceEquipos">
            <Columns>
                <asp:BoundField DataField="ID_Equipo" HeaderText="ID" ReadOnly="True" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre del Equipo" />
            </Columns>
        </asp:GridView>

        <asp:SqlDataSource ID="SqlDataSourceEquipos" runat="server"
            ConnectionString='<%$ ConnectionStrings:DefaultConnection %>'
            SelectCommand="SELECT ID_Equipo, Nombre FROM Equipos">
        </asp:SqlDataSource>
    </div>
</asp:Content>
