﻿<%@ Page Title="Contraseña cambiada" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ResetPasswordConfirmation.aspx.cs" Inherits="Gestor_Torneos.Account.ResetPasswordConfirmation" Async="true" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <main aria-labelledby="title">
        <h2 id="title"><%: Title %>.</h2>
        <div>
            <p>Se ha cambiado su contraseña. Haga clic en <asp:HyperLink ID="login" runat="server" NavigateUrl="~/Account/Login">aquí</asp:HyperLink> para iniciar sesión </p>
        </div>
    </main>
</asp:Content>
