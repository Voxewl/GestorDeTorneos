<%@ Page Title="Registrar Equipo" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Registrar.aspx.cs" Inherits="Gestor_Torneos.Pages.Equipos.Registrar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="text-center text-white mt-4 mb-4">
        <h2>Registro de Equipos</h2>
    </div>

    <asp:Literal ID="ltlMensaje" runat="server"></asp:Literal>

    <div class="card bg-dark text-white p-4 mb-4">
        <div class="row">
            <!-- Campo de texto -->
            <div class="col-md-8 mb-3">
                <label for="txtNombreEquipo" class="form-label">Nombre del Equipo:</label>
                <asp:TextBox ID="txtNombreEquipo" runat="server" 
                    CssClass="form-control bg-dark text-white border-secondary w-100" 
                    Placeholder="Nombre del equipo" />
            </div>

            <!-- Botón -->
            <div class="col-md-4 mb-3">
                <label class="form-label">&nbsp;</label>
                <asp:Button ID="btnRegistrarEquipo" runat="server" 
                    Text="Registrar Equipo" 
                    CssClass="btn btn-primary w-100" 
                    OnClick="btnRegistrarEquipo_Click" />
            </div>
        </div>
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
                <asp:TemplateField HeaderText="Acciones">
                    <ItemTemplate>
                        <asp:LinkButton ID="btnEditar" runat="server" CssClass="btn btn-primary btn-sm me-1"
                            CommandName="Edit">
                            <i class="bi bi-pencil"></i> Editar
                        </asp:LinkButton>
                        <asp:LinkButton ID="btnEliminar" runat="server" CssClass="btn btn-danger btn-sm"
                            CommandName="Delete"
                            OnClientClick="return confirm('¿Deseas eliminar este equipo?');">
                            <i class="bi bi-trash"></i> Eliminar
                        </asp:LinkButton>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:LinkButton ID="btnActualizar" runat="server" CssClass="btn btn-success btn-sm me-1"
                            CommandName="Update">
                            <i class="bi bi-check-lg"></i> Guardar
                        </asp:LinkButton>
                        <asp:LinkButton ID="btnCancelar" runat="server" CssClass="btn btn-secondary btn-sm"
                            CommandName="Cancel">
                            <i class="bi bi-x-lg"></i> Cancelar
                        </asp:LinkButton>
                    </EditItemTemplate>
                </asp:TemplateField>

                <asp:BoundField DataField="ID_Equipo" HeaderText="ID" ReadOnly="True" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre del Equipo" />
            </Columns>
        </asp:GridView>

        <asp:SqlDataSource ID="SqlDataSourceEquipos" runat="server"
            ConnectionString='<%$ ConnectionStrings:DefaultConnection %>'
            SelectCommand="SELECT ID_Equipo, Nombre FROM Equipos" />
    </div>
</asp:Content>
