<%@ Page Title="Agregar Torneo" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AgregarTorneo.aspx.cs" Inherits="Gestor_Torneos.Vistas.AgregarTorneo" %>

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
    input[type="date"],
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
      <h1>Agregar Torneo</h1>
      <div class="container">
        <asp:Label Text="Nombre del Torneo:" AssociatedControlID="txtNombre" runat="server" />
        <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" /><br />

        <asp:Label Text="Tipo de Torneo:" AssociatedControlID="ddlTipo" runat="server" />
        <asp:DropDownList ID="ddlTipo" runat="server" CssClass="form-control">
          <asp:ListItem Text="Deporte" Value="Deporte" />
          <asp:ListItem Text="Videojuego" Value="Videojuego" />
        </asp:DropDownList><br />

        <asp:Label Text="Fecha de Inicio:" AssociatedControlID="txtFechaInicio" runat="server" />
        <asp:TextBox ID="txtFechaInicio" runat="server" TextMode="Date" CssClass="form-control" /><br />

        <asp:Label Text="Fecha de Finalización:" AssociatedControlID="txtFechaFin" runat="server" />
        <asp:TextBox ID="txtFechaFin" runat="server" TextMode="Date" CssClass="form-control" /><br />

        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" CssClass="btn btn-success" />
        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" CssClass="btn btn-secondary" />
      </div>
    </main>

    <footer>
      © 2025 Gestor de Torneos
    </footer>
  </div>
</asp:Content>
