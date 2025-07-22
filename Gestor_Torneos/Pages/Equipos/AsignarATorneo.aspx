<%@ Page Title="Asignar Equipos a Torneo" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AsignarATorneo.aspx.cs" Inherits="Gestor_Torneos.Pages.Torneos.AsignarATorneo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2 class="text-white mt-4">Asignar Equipo a Torneo</h2>

    <div class="row mb-3">
        <div class="col-md-6">
            <label class="text-white">Torneo</label>
            <asp:DropDownList ID="ddlTorneos" runat="server" CssClass="form-select" AutoPostBack="true" OnSelectedIndexChanged="ddlTorneos_SelectedIndexChanged" />
        </div>
        <div class="col-md-6">
            <label class="text-white">Equipo</label>
            <asp:DropDownList ID="ddlEquipos" runat="server" CssClass="form-select" />
        </div>
    </div>

    <asp:Button ID="btnAsignar" runat="server" CssClass="btn btn-success mb-3" Text="Asignar Equipo" OnClick="btnAsignar_Click" />

    <asp:Label ID="lblMensaje" runat="server" CssClass="text-info fw-bold"></asp:Label>

    <h4 class="text-white mt-4">Equipos asignados al torneo</h4>
    <asp:GridView ID="gvAsignados" runat="server" AutoGenerateColumns="False" CssClass="table table-dark table-bordered"
        DataKeyNames="ID_Equipo"
        OnRowDeleting="gvAsignados_RowDeleting">
        <Columns>
            <asp:BoundField DataField="NombreEquipo" HeaderText="Equipo" />
            <asp:BoundField DataField="FechaRegistro" HeaderText="Fecha Registro" DataFormatString="{0:yyyy-MM-dd HH:mm}" />
            <asp:CommandField ShowDeleteButton="True" DeleteText="Eliminar" />
        </Columns>
    </asp:GridView>
</asp:Content>
