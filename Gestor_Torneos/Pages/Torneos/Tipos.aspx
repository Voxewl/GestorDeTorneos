<%@ Page Title="Tipos de Torneo" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Tipos.aspx.cs" Inherits="Gestor_Torneos.Pages.Torneos.Tipos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2 class="text-white mt-4 mb-3">Registrar Tipo de Torneo</h2>

    <div class="mb-4">
        <div class="form-inline d-flex flex-wrap">
            <asp:TextBox ID="txtNombreTipo" runat="server" CssClass="form-control me-2 mb-2" placeholder="Nombre del tipo de torneo" />
            <asp:Button ID="btnAgregarTipo" runat="server" CssClass="btn btn-success mb-2" Text="Agregar" OnClick="btnAgregarTipo_Click" />
        </div>
    </div>

    <div class="table-responsive">
        <asp:GridView ID="gvTiposTorneo" runat="server" AutoGenerateColumns="False"
            CssClass="table table-dark table-bordered"
            DataKeyNames="TipoId"
            OnRowDeleting="gvTiposTorneo_RowDeleting"
            OnRowEditing="gvTiposTorneo_RowEditing"
            OnRowCancelingEdit="gvTiposTorneo_RowCancelingEdit"
            OnRowUpdating="gvTiposTorneo_RowUpdating">
            
            <Columns>
                <asp:TemplateField HeaderText="Acciones">
                    <ItemTemplate>
                        <asp:LinkButton ID="btnEditar" runat="server" CssClass="btn btn-primary btn-sm me-1"
                            CommandName="Edit">
                            <i class="bi bi-pencil"></i> Editar
                        </asp:LinkButton>
                        <asp:LinkButton ID="btnEliminar" runat="server"
                            CssClass="btn btn-danger btn-sm"
                            CommandName="Delete"
                            OnClientClick="return confirm('¿Deseas eliminar este tipo de torneo?');">
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

                <asp:BoundField DataField="TipoId" HeaderText="ID" ReadOnly="True" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre del Tipo" SortExpression="Nombre" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
