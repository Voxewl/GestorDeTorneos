<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegistrarEquipo.aspx.cs" Inherits="Gestor_Torneos.Pages.Jugadores.RegistrarEquipo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5 text-light">
        <h2 class="mb-4">Asignar Jugador a Equipo</h2>

        <div class="mb-3">
            <label for="ddlJugadores" class="form-label">Selecciona un jugador:</label>
            <asp:DropDownList ID="ddlJugadores" runat="server"
                CssClass="form-select bg-dark text-light border-secondary"
                DataSourceID="SqlDataSourceDDLJugadorId"
                DataTextField="Alias" DataValueField="JugadorId">
            </asp:DropDownList>
            <asp:SqlDataSource ID="SqlDataSourceDDLJugadorId" runat="server"
                ConnectionString='<%$ ConnectionStrings:DefaultConnection %>'
                SelectCommand="SELECT JugadorId, Alias FROM Jugadores">
            </asp:SqlDataSource>
        </div>

        <div class="mb-3">
            <label for="ddlEquipos" class="form-label">Selecciona un equipo:</label>
            <asp:DropDownList ID="ddlEquipos" runat="server"
                CssClass="form-select bg-dark text-light border-secondary"
                DataSourceID="SqlDataSourceDdlEquipo"
                DataTextField="Nombre" DataValueField="ID_Equipo">
            </asp:DropDownList>
            <asp:SqlDataSource ID="SqlDataSourceDdlEquipo" runat="server"
                ConnectionString='<%$ ConnectionStrings:DefaultConnection %>'
                SelectCommand="SELECT ID_Equipo, Nombre FROM Equipos">
            </asp:SqlDataSource>
        </div>

        <asp:Button ID="btnAsignar" runat="server" Text="Asignar"
            CssClass="btn btn-outline-primary" OnClick="btnAsignar_Click" />

        <asp:Label ID="lblMensaje" runat="server"
            CssClass="d-block mt-3 text-success"></asp:Label>
    </div>

    <div class="table-responsive mt-4">
    <asp:GridView ID="gvJugadoresEquipos" runat="server"
        CssClass="table table-dark table-bordered"
        AutoGenerateColumns="false"
        DataKeyNames="JugadorId,ID_Equipo"
        OnRowDeleting="gvJugadoresEquipos_RowDeleting"
        AllowPaging="True" AllowSorting="True"
        DataSourceID="SqlDataSourceGVEquipoJugador">

        <Columns>
            <asp:TemplateField HeaderText="Acciones">
                <ItemTemplate>
                    <asp:LinkButton ID="btnEliminar" runat="server"
                        CssClass="btn btn-outline-danger btn-sm"
                        CommandName="Delete"
                        OnClientClick="return confirm('¿Estás seguro de eliminar esta asignación?');">
                        <i class="bi bi-trash"></i> Eliminar
                    </asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:BoundField DataField="JugadorId" HeaderText="ID Jugador" ReadOnly="True" />
            <asp:BoundField DataField="Alias" HeaderText="Alias del Jugador" />
            <asp:BoundField DataField="ID_Equipo" HeaderText="ID Equipo" ReadOnly="True" />
            <asp:BoundField DataField="NombreEquipo" HeaderText="Nombre del Equipo" />
            <asp:BoundField DataField="FechaIngreso" HeaderText="Fecha de Ingreso" DataFormatString="{0:yyyy-MM-dd}" />
        </Columns>
    </asp:GridView>

    <asp:SqlDataSource ID="SqlDataSourceGVEquipoJugador" runat="server"
        ConnectionString='<%$ ConnectionStrings:DefaultConnection %>'
        SelectCommand="SELECT JugadorId, Alias, ID_Equipo, NombreEquipo, FechaIngreso FROM vw_JugadoresEquipos">
    </asp:SqlDataSource>
</div>

</asp:Content>
