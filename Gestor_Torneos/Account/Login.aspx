<%@ Page Title="Iniciar sesión" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Gestor_Torneos.Account.Login" Async="true" %>

<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <style>
        .login-page {
            display: flex;
            justify-content: center;
            align-items: center;
            min-height: 80vh;
            background: linear-gradient(135deg, #000000, #1a1a1a);
            padding: 20px 0;
        }
        
        .glass-container {
            background: rgba(255, 255, 255, 0.05);
            border-radius: 20px;
            padding: 40px;
            width: 100%;
            max-width: 400px;
            box-shadow: 0 8px 32px 0 rgba(0, 0, 0, 0.6);
            backdrop-filter: blur(12px);
            -webkit-backdrop-filter: blur(12px);
            border: 1px solid rgba(255, 255, 255, 0.1);
            color: white;
        }
        
        .login-title {
            text-align: center;
            margin-bottom: 30px;
            color: #fff;
        }
        
        .login-label {
            display: block;
            margin-bottom: 8px;
            color: #eee;
            font-weight: 500;
        }
        
        .login-input {
            width: 100%;
            padding: 12px;
            margin-bottom: 15px;
            border-radius: 8px;
            border: 1px solid rgba(255, 255, 255, 0.2);
            background: rgba(255, 255, 255, 0.05);
            color: white;
        }
        
        .login-button {
            width: 100%;
            padding: 12px;
            background-color: white;
            color: black;
            border: none;
            border-radius: 8px;
            cursor: pointer;
            font-weight: bold;
            margin-top: 20px;
        }
        
        .login-options {
            margin-top: 20px;
            text-align: center;
            color: #ccc;
        }
        
        .error-message {
            color: #ff6b6b;
            margin-top: 10px;
        }
    </style>

    <div class="login-page">
        <div class="glass-container">
            <h2 class="login-title"><%: Title %></h2>
            
            <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
                <p class="error-message">
                    <asp:Literal runat="server" ID="FailureText" />
                </p>
            </asp:PlaceHolder>
            
            <asp:Label runat="server" AssociatedControlID="Email" CssClass="login-label">Correo electrónico</asp:Label>
            <asp:TextBox runat="server" ID="Email" CssClass="login-input" TextMode="Email" placeholder="Tu correo electrónico" />
            <asp:RequiredFieldValidator runat="server" ControlToValidate="Email"
                CssClass="error-message" ErrorMessage="El campo de correo electrónico es obligatorio." Display="Dynamic" />
            
            <asp:Label runat="server" AssociatedControlID="Password" CssClass="login-label">Contraseña</asp:Label>
            <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="login-input" placeholder="Tu contraseña" />
            <asp:RequiredFieldValidator runat="server" ControlToValidate="Password" 
                CssClass="error-message" ErrorMessage="El campo de contraseña es obligatorio." Display="Dynamic" />
            
            <div style="display: flex; align-items: center; margin: 15px 0;">
                <asp:CheckBox runat="server" ID="RememberMe" />
                <asp:Label runat="server" AssociatedControlID="RememberMe" style="color: #eee; margin-left: 8px;">¿Recordar cuenta?</asp:Label>
            </div>
            
            <asp:Button runat="server" OnClick="LogIn" Text="Iniciar sesión" CssClass="login-button" />
            
            <div class="login-options">
                ¿No tienes cuenta? <asp:HyperLink runat="server" ID="RegisterHyperLink" ViewStateMode="Disabled">Regístrate</asp:HyperLink>
            </div>
            
            <div style="margin-top: 30px;">
                <uc:OpenAuthProviders runat="server" ID="OpenAuthLogin" />
            </div>
        </div>
    </div>
</asp:Content>