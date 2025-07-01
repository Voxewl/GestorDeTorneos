<%@ Page Title="Agregar Torneo" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AgregarTorneo.aspx.cs" Inherits="Gestor_Torneos.Vistas.AgregarTorneo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="form-wrapper">
        <h1>Agregar Torneo</h1>

        <div class="form-box">
            <asp:Label Text="Nombre del Torneo:" AssociatedControlID="txtNombre" runat="server" CssClass="label-white" />
            <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" /><br />

            <asp:Label Text="Tipo de Torneo:" AssociatedControlID="ddlTipo" runat="server" CssClass="label-white" />
            <asp:DropDownList ID="ddlTipo" runat="server" CssClass="form-control">
                <asp:ListItem Text="Deporte" Value="Deporte" />
                <asp:ListItem Text="Videojuego" Value="Videojuego" />
            </asp:DropDownList><br />

            <asp:Label Text="Fecha de Inicio:" AssociatedControlID="txtFechaInicio" runat="server" CssClass="label-white" />
            <asp:TextBox ID="txtFechaInicio" runat="server" TextMode="Date" CssClass="form-control" /><br />

            <asp:Label Text="Fecha de Finalización:" AssociatedControlID="txtFechaFin" runat="server" CssClass="label-white" />
            <asp:TextBox ID="txtFechaFin" runat="server" TextMode="Date" CssClass="form-control" /><br />

            <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" CssClass="btn btn-success" />
            <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" CssClass="btn btn-secondary" />
        </div>
    </div>

    <style>
        body {
            background-color: #111;
            margin: 0;
            font-family: Arial, sans-serif;
        }

        .form-wrapper {
            display: flex;
            justify-content: center;
            align-items: center;
            flex-direction: column;
            min-height: 100vh;
            padding: 20px;
        }

        h1 {
            color: white;
            margin-bottom: 30px;
        }

        .form-box {
            width: 100%;
            max-width: 400px;
            background-color: #222;
            padding: 30px;
            border-radius: 10px;
            box-shadow: 0 0 10px rgba(255, 255, 255, 0.1);
        }

        .label-white {
            color: white;
            display: block;
            margin-top: 15px;
            font-weight: bold;
        }

        .form-control {
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
    </style>
</asp:Content>
