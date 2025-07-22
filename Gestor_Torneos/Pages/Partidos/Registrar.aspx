<%--<%@ Page Title="Registrar Partido" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Registrar.aspx.cs" Inherits="Gestor_Torneos.Pages.Partidos.Registrar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="text-center text-white mb-4">
        <h2>Registro de Partidos</h2>
    </div>

    <asp:Literal ID="ltlMensaje" runat="server"></asp:Literal>

    <div class="card bg-dark text-white p-4 mb-4">
        <div class="row mb-3">
            <div class="col-md-6 mb-3">
                <label for="ddlEquipo1" class="form-label">Equipo Local:</label>
                <asp:DropDownList ID="ddlEquipo1" runat="server" CssClass="form-select bg-dark text-white border-secondary" DataSourceID="SqlEquipos" DataTextField="Nombre" DataValueField="ID_Equipo"></asp:DropDownList>
            </div>
            <div class="col-md-6 mb-3">
                <label for="ddlEquipo2" class="form-label">Equipo Visitante:</label>
                <asp:DropDownList ID="ddlEquipo2" runat="server" CssClass="form-select bg-dark text-white border-secondary" DataSourceID="SqlEquipos" DataTextField="Nombre" DataValueField="ID_Equipo"></asp:DropDownList>
            </div>
        </div>
        <div class="mb-3">
            <label for="txtFecha" class="form-label">Fecha del Partido:</label>
            <asp:TextBox ID="txtFecha" runat="server" TextMode="Date" CssClass="form-control bg-dark text-white border-secondary"></asp:TextBox>
        </div>
        <asp:Button ID="btnRegistrarPartido" runat="server" Text="Registrar Partido" CssClass="btn btn-primary w-100" OnClick="btnRegistrarPartido_Click" />
    </div>

    <div class="table-responsive">
        <asp:GridView ID="gvPartidos" runat="server" CssClass="table table-dark table-bordered"
            AutoGenerateColumns="false" DataKeyNames="ID_Partido"
            AllowPaging="True" AllowSorting="True" DataSourceID="SqlDataSourcePartidos">
            <Columns>
                <asp:BoundField DataField="ID_Partido" HeaderText="ID" ReadOnly="True" />
                <asp:BoundField DataField="Equipo1" HeaderText="EquipoLocal" />
                <asp:BoundField DataField="Equipo2" HeaderText="EquipoVisitante" />
                <asp:BoundField DataField="Fecha" HeaderText="Fecha" />
            </Columns>
        </asp:GridView>

        <asp:SqlDataSource ID="SqlEquipos" runat="server"
            ConnectionString='<%$ ConnectionStrings:DefaultConnection %>'
            SelectCommand="SELECT ID_Equipo, Nombre FROM Equipos" />

        <asp:SqlDataSource ID="SqlDataSourcePartidos" runat="server"
            ConnectionString='<%$ ConnectionStrings:DefaultConnection %>'
            SelectCommand="SELECT ID_Partido, Equipo1, Equipo2, Fecha FROM vw_PartidosResumen">
        </asp:SqlDataSource>
    </div>
</asp:Content>--%>
