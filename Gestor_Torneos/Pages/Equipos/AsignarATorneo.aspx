<%@ Page Title="Asignar Equipos a Torneo" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AsignarATorneo.aspx.cs" Inherits="Gestor_Torneos.Pages.Torneos.AsignarATorneo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2 class="text-white mt-4 mb-4">Asignar Equipo a Torneo</h2>

    <div class="card bg-dark text-white p-4 mb-4">
        <div class="row">
            <!-- Torneo -->
            <div class="col-md-4 mb-3">
                <label for="ddlTorneos" class="form-label">Torneo</label>
                <asp:DropDownList ID="ddlTorneos" runat="server"
                    CssClass="form-select bg-dark text-light border-secondary w-100"
                    AutoPostBack="true" OnSelectedIndexChanged="ddlTorneos_SelectedIndexChanged" />
            </div>

            <!-- Equipo -->
            <div class="col-md-4 mb-3">
                <label for="ddlEquipos" class="form-label">Equipo</label>
                <asp:DropDownList ID="ddlEquipos" runat="server"
                    CssClass="form-select bg-dark text-light border-secondary w-100" />
            </div>

            <!-- Botón -->
            <div class="col-md-4 mb-3">
                <label class="form-label">&nbsp;</label>
                <asp:Button ID="btnAsignar" runat="server" CssClass="btn btn-success w-100" Text="Asignar Equipo" OnClick="btnAsignar_Click" />
            </div>
        </div>

        <asp:Label ID="lblMensaje" runat="server" CssClass="d-block mt-2 text-info fw-bold"></asp:Label>
    </div>

    <h4 class="text-white mb-3">Equipos asignados al torneo</h4>
    <div class="table-responsive">
        <asp:GridView ID="gvAsignados" runat="server" AutoGenerateColumns="False" CssClass="table table-dark table-bordered"
            DataKeyNames="ID_Equipo"
            OnRowDeleting="gvAsignados_RowDeleting">
            <Columns>
                <asp:BoundField DataField="NombreEquipo" HeaderText="Equipo" />
                <asp:BoundField DataField="FechaRegistro" HeaderText="Fecha Registro" DataFormatString="{0:yyyy-MM-dd HH:mm}" />
                <asp:TemplateField HeaderText="Acciones">
                    <ItemTemplate>
                        <asp:LinkButton ID="btnEliminar" runat="server" CssClass="btn btn-danger btn-sm"
                            CommandName="Delete"
                            OnClientClick="return confirm('¿Deseas eliminar este equipo del torneo?');">
                            <i class="bi bi-trash"></i> Eliminar
                        </asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
