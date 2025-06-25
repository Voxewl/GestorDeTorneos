<%@ Page Title="Agregar Equipo" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AgregarEquipo.aspx.cs" Inherits="Gestor_Torneos.Vistas.AgregarEquipo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
  <style>
    header a {
      color: white;
      text-decoration: none;
      margin: 0 10px;
    }

    header a:hover {
      text-decoration: underline;
      color: #ccc;
    }

    html, body {
      height: 100%;
      margin: 0;
      font-family: Arial, sans-serif;
      background-color: #fff;
    }

    .wrapper {
      min-height: 100%;
      display: flex;
      flex-direction: column;
    }

    header, footer {
      background-color: #000;
      color: white;
      padding: 10px 20px;
      display: flex;
      justify-content: space-between;
      align-items: center;
    }

    footer {
      text-align: center;
    }

    .content {
      flex: 1;
      padding: 20px 0;
    }

    .container {
      width: 400px;
      margin: 40px auto;
    }

    label {
      display: block;
      margin-top: 15px;
      font-weight: bold;
    }

    input[type="text"],
    select {
      width: 100%;
      padding: 10px;
      margin-top: 5px;
      background-color: #eee;
      border: none;
      border-radius: 8px;
    }

    .btn {
      display: block;
      width: 100%;
      padding: 12px;
      margin-top: 20px;
      border: none;
      border-radius: 8px;
      font-weight: bold;
      cursor: pointer;
    }

    .btn-success {
      background-color: black;
      color: white;
    }

    .btn-secondary {
      background-color: gray;
      color: white;
    }

    .btn-back {
      font-size: 20px;
      background: none;
      color: white;
      border: none;
      cursor: pointer;
    }

    h1 {
      text-align: center;
      margin-top: 20px;
    }
  </style>

  <div class="wrapper">
    <header>
      <button class="btn-back" onclick="window.location.href='Default.aspx'">←</button>
      <nav>
        <a href="#">Ver</a>
        <a href="#">Crear</a>
        <a href="#">Perfil</a>
      </nav>
    </header>

    <main class="content">
      <h1>Agregar Equipo</h1>
      <div class="container">
        <asp:Label Text="Nombre del Equipo:" AssociatedControlID="txtNombre" runat="server" />
        <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" /><br />

        <asp:Label Text="Seleccionar Torneo:" AssociatedControlID="ddlTorneo" runat="server" />
        <asp:DropDownList ID="ddlTorneo" runat="server" CssClass="form-control">
            <!-- Los valores reales deben venir del backend -->
            <asp:ListItem Text="Seleccione un torneo" Value="" />
            <asp:ListItem Text="Torneo 1" Value="torneo1" />
            <asp:ListItem Text="Torneo 2" Value="torneo2" />
        </asp:DropDownList><br />

        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" CssClass="btn btn-success" />
        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" CssClass="btn btn-secondary" />
      </div>
    </main>

    <footer>
      © 2025 Gestor de Torneos
    </footer>
  </div>
</asp:Content>
