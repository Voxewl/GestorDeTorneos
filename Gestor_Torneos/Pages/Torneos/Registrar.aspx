 <%@ Page Title="Registrar Torneo" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Registrar.aspx.cs" Inherits="Gestor_Torneos.Pages.Torneos.Registrar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2 class="text-white mt-4">Registrar Torneo</h2>

    <div class="mb-4">
        <div class="form-inline d-flex">
            <asp:TextBox ID="txtNombreTorneo" runat="server" CssClass="form-control me-2" placeholder="Nombre del torneo" />
            
            <!-- Calendario de Bootstrap para Fecha de Inicio -->
            <input type="date" id="txtFechaInicio" runat="server" class="form-control me-2" />

            <!-- Calendario de Bootstrap para Fecha de Fin -->
            <input type="date" id="txtFechaFin" runat="server" class="form-control me-2" />
            
            <asp:TextBox ID="txtDescripcionTorneo" runat="server" CssClass="form-control me-2" placeholder="Descripción del torneo" />
            
            <!-- DropDownList con DataSourceID configurado -->
            <asp:DropDownList ID="ddlTipoTorneo" runat="server" CssClass="form-control me-2" DataSourceID="SqlDataSourceDDLTipoTorneo" DataTextField="Nombre" DataValueField="TipoId">
            </asp:DropDownList>

            <!-- SqlDataSource para el DropDownList -->
            <asp:SqlDataSource runat="server" ID="SqlDataSourceDDLTipoTorneo" ConnectionString='<%$ ConnectionStrings:DefaultConnection %>' 
                SelectCommand="SELECT TipoId, Nombre FROM TiposTorneo"></asp:SqlDataSource>

            <asp:Button ID="btnRegistrarTorneo" runat="server" CssClass="btn btn-outline-success" Text="Registrar Torneo" OnClick="btnRegistrarTorneo_Click" />
        </div>
    </div>

    <div class="table-responsive">
        <!-- GridView para mostrar los torneos registrados -->
        <asp:SqlDataSource ID="sdsTorneos" runat="server"
    ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"
    SelectCommand="SELECT t.ID_Torneo, t.Nombre, t.TipoId, tt.Nombre AS TipoTorneo, t.FechaInicio, t.FechaFin, t.Descripcion 
                  FROM Torneos t 
                  JOIN TiposTorneo tt ON t.TipoId = tt.TipoId"
    UpdateCommand="UPDATE Torneos SET 
                  Nombre = @Nombre, 
                  TipoId = @TipoId, 
                  FechaInicio = @FechaInicio, 
                  FechaFin = @FechaFin, 
                  Descripcion = @Descripcion 
                  WHERE ID_Torneo = @ID_Torneo"
    DeleteCommand="DELETE FROM Torneos WHERE ID_Torneo = @ID_Torneo">
    
    <UpdateParameters>
        <asp:Parameter Name="Nombre" Type="String" />
        <asp:Parameter Name="TipoId" Type="Int32" />
        <asp:Parameter Name="FechaInicio" Type="DateTime" />
        <asp:Parameter Name="FechaFin" Type="DateTime" />
        <asp:Parameter Name="Descripcion" Type="String" />
        <asp:Parameter Name="ID_Torneo" Type="Int32" />
    </UpdateParameters>

    <DeleteParameters>
        <asp:Parameter Name="ID_Torneo" Type="Int32" />
    </DeleteParameters>
</asp:SqlDataSource>
    
    <UpdateParameters>
        <asp:Parameter Name="Nombre" Type="String" />
        <asp:Parameter Name="TipoId" Type="Int32" />
        <asp:Parameter Name="FechaInicio" Type="DateTime" />
        <asp:Parameter Name="FechaFin" Type="DateTime" />
        <asp:Parameter Name="Descripcion" Type="String" />
        <asp:Parameter Name="ID_Torneo" Type="Int32" />
    </UpdateParameters>
</asp:SqlDataSource>

<asp:GridView ID="gvTorneos" runat="server"
    DataSourceID="sdsTorneos"
    DataKeyNames="ID_Torneo"
    AutoGenerateColumns="False"
    AllowPaging="True"
    PageSize="10"
    CssClass="table table-dark table-bordered"
    OnRowUpdating="gvTorneos_RowUpdating"
    OnRowCancelingEdit="gvTorneos_RowCancelingEdit"
    OnRowEditing="gvTorneos_RowEditing">
    
    <Columns>
        <asp:TemplateField HeaderText="Acciones">
            <ItemTemplate>
                <asp:LinkButton ID="lnkEdit" runat="server" 
                    CausesValidation="False" 
                    CommandName="Edit" 
                    Text="Editar" 
                    CssClass="btn btn-sm btn-primary" />
                <asp:LinkButton ID="lnkDelete" runat="server" 
                    CausesValidation="False" 
                    CommandName="Delete" 
                    Text="Eliminar" 
                    CssClass="btn btn-sm btn-danger" 
                    OnClientClick="return confirm('¿Está seguro de eliminar este torneo?');" />
            </ItemTemplate>
            <EditItemTemplate>
                <asp:LinkButton ID="lnkUpdate" runat="server" 
                    CausesValidation="True" 
                    CommandName="Update" 
                    Text="Guardar" 
                    CssClass="btn btn-sm btn-success" />
                <asp:LinkButton ID="lnkCancel" runat="server" 
                    CausesValidation="False" 
                    CommandName="Cancel" 
                    Text="Cancelar" 
                    CssClass="btn btn-sm btn-secondary" />
            </EditItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Nombre">
            <ItemTemplate>
                <%# Eval("Nombre") %>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="txtNombre" runat="server" 
                    Text='<%# Bind("Nombre") %>' 
                    CssClass="form-control" />
            </EditItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Tipo de Torneo">
            <ItemTemplate>
                <%# Eval("TipoTorneo") %>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:DropDownList ID="ddlTipos" runat="server"
                    SelectedValue='<%# Bind("TipoId") %>'
                    DataSourceID="sdsTiposTorneo"
                    DataTextField="Nombre"
                    DataValueField="TipoId"
                    CssClass="form-control" />
            </EditItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Fecha Inicio">
            <ItemTemplate>
                <%# Eval("FechaInicio", "{0:dd/MM/yyyy}") %>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="txtFechaInicio" runat="server" 
                    Text='<%# Bind("FechaInicio", "{0:yyyy-MM-dd}") %>' 
                    CssClass="form-control"
                    TextMode="Date" />
            </EditItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Fecha Fin">
            <ItemTemplate>
                <%# Eval("FechaFin", "{0:dd/MM/yyyy}") %>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="txtFechaFin" runat="server" 
                    Text='<%# Bind("FechaFin", "{0:yyyy-MM-dd}") %>' 
                    CssClass="form-control"
                    TextMode="Date" />
            </EditItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Descripción">
            <ItemTemplate>
                <%# Eval("Descripcion") %>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="txtDescripcion" runat="server" 
                    Text='<%# Bind("Descripcion") %>' 
                    CssClass="form-control"
                    TextMode="MultiLine"
                    Rows="3" />
            </EditItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>

<asp:SqlDataSource ID="sdsTiposTorneo" runat="server"
    ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"
    SelectCommand="SELECT TipoId, Nombre FROM TiposTorneo" />


   </div>
</asp:Content>