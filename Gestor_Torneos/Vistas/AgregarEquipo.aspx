<%@ Page Title="Agregar Equipo" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AgregarEquipo.aspx.cs" Inherits="Gestor_Torneos.Vistas.AgregarEquipo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="form-wrapper">
        <h1>Agregar Equipo</h1>

        <div class="form-box">
            <asp:Label Text="Nombre del Equipo:" AssociatedControlID="txtNombre" runat="server" CssClass="label-white" />
            <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" /><br />

            <asp:Label Text="Seleccionar Torneo:" AssociatedControlID="ddlTorneo" runat="server" CssClass="label-white" />
            <asp:DropDownList ID="ddlTorneo" runat="server" CssClass="form-control">
                <asp:ListItem Text="Seleccione un torneo" Value="" />
                <asp:ListItem Text="Torneo 1" Value="torneo1" />
                <asp:ListItem Text="Torneo 2" Value="torneo2" />
            </asp:DropDownList><br />

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
