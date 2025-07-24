<%@ Page Title="Registrar Jugador" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Registrar.aspx.cs" Inherits="Gestor_Torneos.Pages.Jugadores.Registrar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="text-center text-white mt-4 mb-4">
        <h2>Registro de Jugadores</h2>
    </div>

    <asp:Literal ID="ltlMensaje" runat="server"></asp:Literal>

    <div class="card bg-dark text-white p-4 mb-4">
        <div class="row">
            <div class="col-md-4 mb-3">
                <label for="ddlUsuarios" class="form-label">Seleccionar Usuario:</label>
                <asp:DropDownList ID="ddlUsuarios" runat="server" CssClass="form-select bg-dark text-white border-secondary w-100" 
                    DataSourceID="SqlDataSourceUserName" DataTextField="UserName" DataValueField="Id"></asp:DropDownList>
                <asp:SqlDataSource runat="server" ID="SqlDataSourceUserName" 
                    ConnectionString='<%$ ConnectionStrings:DefaultConnection %>' 
                    SelectCommand="SELECT Id, UserName FROM AspNetUsers" />
            </div>

            <div class="col-md-4 mb-3">
                <label for="txtAlias" class="form-label">Alias del Jugador:</label>
                <asp:TextBox ID="txtAlias" runat="server" CssClass="form-control bg-dark text-white border-secondary w-100" 
                    Placeholder="Alias del jugador"></asp:TextBox>
            </div>

            <div class="col-md-4 mb-3">
                <label class="form-label">&nbsp;</label> <!-- espacio para alinear -->
                <asp:Button ID="btnRegistrar" runat="server" Text="Registrar Jugador" CssClass="btn btn-success w-100" OnClick="btnRegistrar_Click" />
            </div>
        </div>
    </div>

    <div class="table-responsive">
        <asp:GridView ID="gvJugadores" runat="server" CssClass="table table-dark table-bordered"
            AutoGenerateColumns="False" DataKeyNames="JugadorId"
            OnRowEditing="gvJugadores_RowEditing"
            OnRowCancelingEdit="gvJugadores_RowCancelingEdit"
            OnRowUpdating="gvJugadores_RowUpdating"
            OnRowDeleting="gvJugadores_RowDeleting"
            AllowPaging="True" AllowSorting="True" DataSourceID="SqlDataSourceGVJugadores">
            <Columns>
                <asp:TemplateField HeaderText="Acciones">
                    <ItemTemplate>
                        <asp:LinkButton ID="btnEditar" runat="server" CssClass="btn btn-primary btn-sm me-1"
                            CommandName="Edit">
                            <i class="bi bi-pencil"></i> Editar
                        </asp:LinkButton>
                        <asp:LinkButton ID="btnEliminar" runat="server" CssClass="btn btn-danger btn-sm"
                            CommandName="Delete"
                            OnClientClick="return confirm('¿Deseas eliminar este jugador?');">
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

                <asp:BoundField DataField="JugadorId" HeaderText="JugadorId" ReadOnly="True" SortExpression="JugadorId" />
                <asp:BoundField DataField="Alias" HeaderText="Alias" SortExpression="Alias" />
                <asp:BoundField DataField="UserName" HeaderText="UserName" SortExpression="UserName" />
                <asp:BoundField DataField="FechaRegistro" HeaderText="FechaRegistro" SortExpression="FechaRegistro" />
            </Columns>
        </asp:GridView>

        <asp:SqlDataSource runat="server" ID="SqlDataSourceGVJugadores"
            ConnectionString='<%$ ConnectionStrings:DefaultConnection %>'
            SelectCommand="SELECT JugadorId, Alias, UserName, FechaRegistro FROM vw_Jugadores" />
    </div>
</asp:Content>
