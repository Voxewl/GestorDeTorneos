<%@ Page Title="Agendar Partido" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Agendar.aspx.cs" Inherits="Gestor_Torneos.Pages.Partidos.Agendar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2 class="text-white mt-4 mb-3">Agendar Partido</h2>

    <div class="mb-3">
        <label class="form-label text-white">Torneo</label>
        <asp:DropDownList ID="ddlTorneos" runat="server" CssClass="form-select" AutoPostBack="true" OnSelectedIndexChanged="ddlTorneos_SelectedIndexChanged"></asp:DropDownList>
    </div>

    <div class="mb-3">
        <label class="form-label text-white">Equipo 1</label>
        <asp:DropDownList ID="ddlEquipo1" runat="server" CssClass="form-select"></asp:DropDownList>
    </div>

    <div class="mb-3">
        <label class="form-label text-white">Equipo 2</label>
        <asp:DropDownList ID="ddlEquipo2" runat="server" CssClass="form-select"></asp:DropDownList>
    </div>

    <div class="mb-3">
        <label class="form-label text-white">Fecha del Partido</label>
        <asp:TextBox ID="txtFecha" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
    </div>

    <div class="mb-3">
        <asp:Button ID="btnAgendar" runat="server" Text="Agendar Partido" CssClass="btn btn-success" OnClick="btnAgendar_Click" />
    </div>

    <div class="table-responsive mt-4">
        <asp:GridView ID="gvPartidos" runat="server" AutoGenerateColumns="False"
            CssClass="table table-dark table-bordered"
            DataKeyNames="ID_Partido"
            OnRowEditing="gvPartidos_RowEditing"
            OnRowUpdating="gvPartidos_RowUpdating"
            OnRowCancelingEdit="gvPartidos_RowCancelingEdit"
            OnRowDeleting="gvPartidos_RowDeleting">

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
                            OnClientClick="return confirm('¿Deseas eliminar este partido?');">
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

                <asp:BoundField DataField="ID_Partido" HeaderText="ID" ReadOnly="True" />
                <asp:BoundField DataField="Torneo" HeaderText="Torneo" ReadOnly="True" />

                <asp:TemplateField HeaderText="Equipo 1">
                    <ItemTemplate><%# Eval("Equipo1") %></ItemTemplate>
                    <EditItemTemplate>
                        <asp:DropDownList ID="ddlEquipo1Edit" runat="server" CssClass="form-select"></asp:DropDownList>
                    </EditItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Equipo 2">
                    <ItemTemplate><%# Eval("Equipo2") %></ItemTemplate>
                    <EditItemTemplate>
                        <asp:DropDownList ID="ddlEquipo2Edit" runat="server" CssClass="form-select"></asp:DropDownList>
                    </EditItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Fecha">
                    <ItemTemplate><%# Eval("Fecha", "{0:yyyy-MM-dd HH:mm}") %></ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtFechaEdit" runat="server" CssClass="form-control"
                            Text='<%# Bind("Fecha", "{0:yyyy-MM-ddTHH:mm}") %>' TextMode="DateTimeLocal" />
                    </EditItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
