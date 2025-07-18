<%@ Page Title="Registrar Torneo" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Registrar.aspx.cs" Inherits="Gestor_Torneos.Pages.Torneos.Registrar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="text-center text-white mb-4">
        <h2>Registro de Torneos</h2>
    </div>

    <asp:Literal ID="ltlMensaje" runat="server"></asp:Literal>

    <div class="card bg-dark text-white p-4 mb-4">
        <div class="mb-3">
            <label for="txtNombreTorneo" class="form-label">Nombre del Torneo:</label>
            <asp:TextBox ID="txtNombreTorneo" runat="server" CssClass="form-control bg-dark text-white border-secondary" Placeholder="Nombre del torneo"></asp:TextBox>
        </div>
        <div class="mb-3">
            <label for="txtFechaInicio" class="form-label">Fecha de Inicio:</label>
            <asp:TextBox ID="txtFechaInicio" runat="server" TextMode="Date" CssClass="form-control bg-dark text-white border-secondary"></asp:TextBox>
        </div>
        <asp:Button ID="btnRegistrarTorneo" runat="server" Text="Registrar Torneo" CssClass="btn btn-primary w-100" OnClick="btnRegistrarTorneo_Click" />
    </div>

    <div class="table-responsive">
        <asp:GridView ID="gvTorneos" runat="server" CssClass="table table-dark table-bordered"
            AutoGenerateColumns="false" DataKeyNames="TorneoId"
            AllowPaging="True" AllowSorting="True" DataSourceID="SqlDataSourceTorneos">
            <Columns>
                <asp:BoundField DataField="TorneoId" HeaderText="ID" ReadOnly="True" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre del Torneo" />
                <asp:BoundField DataField="FechaInicio" HeaderText="Fecha de Inicio" />
            </Columns>
        </asp:GridView>

        <asp:SqlDataSource ID="SqlDataSourceTorneos" runat="server"
            ConnectionString='<%$ ConnectionStrings:DefaultConnection %>'
            SelectCommand="SELECT TorneoId, Nombre, FechaInicio FROM Torneos">
        </asp:SqlDataSource>
    </div>
</asp:Content>
