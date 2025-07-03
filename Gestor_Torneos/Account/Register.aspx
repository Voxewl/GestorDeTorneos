<%@ Page Title="Registrarse" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Gestor_Torneos.Account.Register" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <style>
        .register-page {
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

        .register-title {
            text-align: center;
            margin-bottom: 30px;
            color: #fff;
        }

        .register-label {
            display: block;
            margin-bottom: 8px;
            color: #eee;
            font-weight: 500;
        }

        .register-input {
            width: 100%;
            padding: 12px;
            margin-bottom: 15px;
            border-radius: 8px;
            border: 1px solid rgba(255, 255, 255, 0.2);
            background: rgba(255, 255, 255, 0.05);
            color: white;
        }

        .register-button {
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

        .register-button:hover {
            background-color: #f0f0f0;
        }

        .login-link {
            margin-top: 20px;
            text-align: center;
            color: #ccc;
        }

        .login-link a {
            color: #4fc3f7;
            text-decoration: none;
        }

        .login-link a:hover {
            text-decoration: underline;
        }

        .error-message {
            color: #ff6b6b;
            margin-top: 10px;
        }
    </style>

    <div class="register-page">
        <div class="glass-container">
            <h2 class="register-title"><%: Title %></h2>

            <asp:Literal runat="server" ID="ErrorMessage" />
            <asp:ValidationSummary runat="server" CssClass="error-message" />

            <asp:Label runat="server" AssociatedControlID="Email" CssClass="register-label">Correo electrónico</asp:Label>
            <asp:TextBox runat="server" ID="Email" CssClass="register-input" TextMode="Email" placeholder="Tu correo electrónico" />
            <asp:RequiredFieldValidator runat="server" ControlToValidate="Email" CssClass="error-message" ErrorMessage="El correo es obligatorio." Display="Dynamic" />

            <asp:Label runat="server" AssociatedControlID="Password" CssClass="register-label">Contraseña</asp:Label>
            <asp:TextBox runat="server" ID="Password" CssClass="register-input" TextMode="Password" placeholder="Tu contraseña" />
            <asp:RequiredFieldValidator runat="server" ControlToValidate="Password" CssClass="error-message" ErrorMessage="La contraseña es obligatoria." Display="Dynamic" />

            <asp:Label runat="server" AssociatedControlID="ConfirmPassword" CssClass="register-label">Confirmar contraseña</asp:Label>
            <asp:TextBox runat="server" ID="ConfirmPassword" CssClass="register-input" TextMode="Password" placeholder="Confirma tu contraseña" />
            <asp:RequiredFieldValidator runat="server" ControlToValidate="ConfirmPassword" CssClass="error-message" ErrorMessage="La confirmación es obligatoria." Display="Dynamic" />
            <asp:CompareValidator runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword" CssClass="error-message" ErrorMessage="Las contraseñas no coinciden." Display="Dynamic" />

            <asp:Button runat="server" OnClick="CreateUser_Click" Text="Registrarse" CssClass="btn btn-primary w-100" />

            <div class="login-link">
                ¿Ya tienes cuenta? <a href="Login.aspx">Inicia sesión</a>
            </div>
        </div>
    </div>
</asp:Content>
