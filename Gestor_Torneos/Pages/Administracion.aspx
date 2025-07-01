<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Administracion.aspx.cs" Inherits="Gestor_Torneos.Pages.Administracion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container bg-dark text-white p-4 rounded">
        <!-- Gestión de Roles -->
        <div class="row mt-4">
            <div class="col-md-4">
                <div class="card bg-dark text-white">
                    <div class="card-header"><h5>Gestión de Roles</h5></div>
                    <div class="card-body">
                        <asp:Label ID="Label1" runat="server" Text="Crear Rol" CssClass="text-white"></asp:Label>
                        <asp:TextBox ID="txtRolName" runat="server" CssClass="form-control bg-secondary text-white"></asp:TextBox>
                        <br />
                        <asp:Button ID="btnCrearRol" runat="server" Text="Crear" CssClass="btn btn-primary mb-2" OnClick="btnCrearRol_Click" />
                        <asp:Button ID="btnEliminarRol" runat="server" Text="Eliminar" CssClass="btn btn-danger mb-2" OnClick="btnEliminarRol_Click" />
                        <asp:Label ID="lblIdRol" runat="server" Visible="False" />
                        <asp:Label ID="lblIdUser" runat="server" Visible="False" />
                    </div>
                </div>
            </div>

            <div class="col-md-8">
                <div class="card bg-dark text-white">
                    <div class="card-header"><h5>Roles Existentes</h5></div>
                    <div class="card-body">
                        <asp:GridView ID="gvRolName" runat="server" AutoGenerateColumns="False"
                            DataKeyNames="Id" DataSourceID="SqlDataSource1"
                            CssClass="table table-bordered table-dark"
                            OnSelectedIndexChanged="gvRolName_SelectedIndexChanged">
                            <Columns>
                                <asp:CommandField ShowSelectButton="True" ButtonType="Button" />
                                <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True" SortExpression="Id" />
                                <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                            </Columns>
                        </asp:GridView>

                        <asp:SqlDataSource ID="SqlDataSource1" runat="server"
                            ConnectionString='<%$ ConnectionStrings:DefaultConnection %>'
                            SelectCommand="SELECT Id, Name FROM AspNetRoles" />
                    </div>
                </div>
            </div>
        </div>

        <!-- Mensaje de éxito rol -->
        <div class="row mt-2">
            <div class="col-md-12">
                <asp:Panel ID="Panel1" runat="server" CssClass="alert alert-success alert-dismissible fade show" Visible="false">
                    <button type="button" class="close" data-dismiss="alert">&times;</button>
                    <strong>¡Éxito!</strong> Operación ejecutada sobre el rol con éxito.
                </asp:Panel>
            </div>
        </div>

        <!-- Gestión de Usuarios -->
        <div class="row mt-4">
            <div class="col-md-5">
                <div class="card bg-dark text-white">
                    <div class="card-header"><h5>Gestión de Usuarios</h5></div>
                    <div class="card-body">
                        <asp:Label ID="Label3" runat="server" Text="Nombre Del Usuario:" CssClass="text-white"></asp:Label>
                        <asp:TextBox ID="txtUserName" runat="server" CssClass="form-control bg-secondary text-white"></asp:TextBox>
                        <br />
                        <asp:Label ID="Label8" runat="server" Text="Correo Electrónico:" CssClass="text-white"></asp:Label>
                        <asp:TextBox ID="txtCorreo" runat="server" CssClass="form-control bg-secondary text-white"></asp:TextBox>
                        <br />
                        <asp:Label ID="Label4" runat="server" Text="Contraseña:" CssClass="text-white"></asp:Label>
                        <asp:TextBox ID="txtPass" runat="server" CssClass="form-control bg-secondary text-white" TextMode="Password" />
                        <br />
                        <asp:Label ID="Label5" runat="server" Text="Confirmar Contraseña:" CssClass="text-white"></asp:Label>
                        <asp:TextBox ID="txtConfirmar" runat="server" CssClass="form-control bg-secondary text-white" TextMode="Password" />
                        <br />
                        <asp:Button ID="btnCrearUsuario" runat="server" Text="Crear Usuario" CssClass="btn btn-primary mb-2" OnClick="btnCrearUsuario_Click" />
                        <asp:Button ID="btnBorrarUsuario" runat="server" Text="Borrar Usuario" CssClass="btn btn-danger mb-2" OnClick="btnBorrarUsuario_Click" />
                    </div>
                </div>
            </div>

            <div class="col-md-7">
                <div class="card bg-dark text-white">
                    <div class="card-header"><h5>Usuarios Existentes</h5></div>
                    <div class="card-body">
                        <asp:GridView ID="gvUsuarios" runat="server" AutoGenerateColumns="False"
                            DataKeyNames="Id" DataSourceID="SqlDataSource2"
                            CssClass="table table-bordered table-dark"
                            OnSelectedIndexChanged="gvUsuarios_SelectedIndexChanged">
                            <Columns>
                                <asp:CommandField ShowSelectButton="True" ButtonType="Button" />
                                <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True" SortExpression="Id" />
                                <asp:BoundField DataField="UserName" HeaderText="UserName" SortExpression="UserName" />
                            </Columns>
                        </asp:GridView>

                        <asp:SqlDataSource ID="SqlDataSource2" runat="server"
                            ConnectionString='<%$ ConnectionStrings:DefaultConnection %>'
                            SelectCommand="SELECT Id, UserName FROM AspNetUsers" />
                    </div>
                </div>
            </div>
        </div>

        <!-- Paneles de confirmación para usuarios -->
        <div class="row mt-2">
            <div class="col-md-12">
                <asp:Panel ID="Panel3" runat="server" CssClass="alert alert-success alert-dismissible fade show" Visible="false">
                    <button type="button" class="close" data-dismiss="alert">&times;</button>
                    <strong>¡Éxito!</strong> Asignación creada correctamente.
                </asp:Panel>
                <asp:Panel ID="Panel4" runat="server" CssClass="alert alert-danger alert-dismissible fade show text-white" Visible="false">
                    <button type="button" class="close" data-dismiss="alert">&times;</button>
                    <strong>¡Fracaso!</strong> Asignación no creada.
                </asp:Panel>
            </div>
        </div>

        <!-- Asignación de Roles -->
        <div class="row mt-4">
            <div class="col-md-6">
                <div class="card bg-dark text-white">
                    <div class="card-header"><h5>Asignación de Roles</h5></div>
                    <div class="card-body">
                        <asp:Label ID="Label7" runat="server" Text="Usuario: " CssClass="text-white" />
                        <asp:Label ID="lblNomUser" runat="server" CssClass="text-white" />
                        <br />
                        <asp:Label ID="Label9" runat="server" Text="Rol:" CssClass="text-white" />
                        <asp:Label ID="lblNomRol" runat="server" CssClass="text-white" />
                        <br />
                        <asp:Button ID="btnRelacion" runat="server" Text="Asignar Rol" CssClass="btn btn-success" OnClick="btnRelacion_Click" />
                    </div>
                </div>
            </div>

            <div class="col-md-6">
                <asp:Panel ID="Panel2" runat="server" CssClass="alert alert-success alert-dismissible fade show" Visible="false">
                    <button type="button" class="close" data-dismiss="alert">&times;</button>
                    <strong>¡Éxito!</strong> Asignación creada correctamente.
                </asp:Panel>
                <asp:Panel ID="Panel5" runat="server" CssClass="alert alert-danger alert-dismissible fade show text-white" Visible="false">
                    <button type="button" class="close" data-dismiss="alert">&times;</button>
                    <strong>¡Fracaso!</strong> Asignación no creada.
                </asp:Panel>

                <asp:SqlDataSource ID="SqlDataSource3" runat="server"
                    ConnectionString='<%$ ConnectionStrings:DefaultConnection %>'
                    InsertCommand="INSERT INTO AspNetUserRoles(UserId, RoleId) VALUES (@UserId, @RoleId)"
                    SelectCommand="SELECT UserId, RoleId FROM AspNetUserRoles">
                    <InsertParameters>
                        <asp:Parameter Name="UserId" />
                        <asp:Parameter Name="RoleId" />
                    </InsertParameters>
                </asp:SqlDataSource>
            </div>
        </div>
    </div>
</asp:Content>

