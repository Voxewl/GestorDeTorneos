<%@ Page Title="Registrarse" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Gestor_Torneos.Account.Register" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">

    <style>
        .page-dark {
            background-color: #2b2b2b;
            min-height: 90vh;
            display: flex;
            align-items: center;
            justify-content: center;
            padding: 40px 15px;
        }

        .card-dark {
            background-color: #2b2b2b;
            color: white;
            border-radius: 12px;
            box-shadow: 0 0 20px rgba(0, 0, 0, 0.4);
        }

        .card-dark .form-control {
            background-color: #3b3b3b;
            border: none;
            color: white;
        }

        .card-dark .form-control::placeholder {
            color: #aaa;
        }

        .btn-register {
            background-color: #ffffff;
            color: #000000;
            font-weight: bold;
        }

        .btn-register:hover {
            background-color: #f0f0f0;
        }

        .login-link {
            margin-top: 15px;
            text-align: center;
        }

        .login-link a {
            color: #4fc3f7;
            text-decoration: none;
        }

        .login-link a:hover {
            text-decoration: underline;
        }
    </style>

    <div class="page-dark">
        <div class="card card-dark p-4 w-100" style="max-width: 400px;">
            <h3 class="text-center mb-4">Crear cuenta</h3>

            <asp:Literal runat="server" ID="ErrorMessage" />
            <asp:ValidationSummary runat="server" CssClass="text-danger mb-3" />

            <div class="mb-3">
                <label for="Email" class="form-label">Correo electrónico</label>
                <asp:TextBox runat="server" ID="Email" CssClass="form-control" TextMode="Email" placeholder="Ingresa tu correo" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Email" CssClass="text-danger" ErrorMessage="El correo es obligatorio." />
            </div>

            <div class="mb-3">
                <label for="Password" class="form-label">Contraseña</label>
                <asp:TextBox runat="server" ID="Password" CssClass="form-control" TextMode="Password" placeholder="Ingresa una contraseña" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Password" CssClass="text-danger" ErrorMessage="La contraseña es obligatoria." />
            </div>

            <div class="mb-3">
                <label for="ConfirmPassword" class="form-label">Confirmar contraseña</label>
                <asp:TextBox runat="server" ID="ConfirmPassword" CssClass="form-control" TextMode="Password" placeholder="Confirma tu contraseña" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ConfirmPassword" CssClass="text-danger" ErrorMessage="La confirmación es obligatoria." />
                <asp:CompareValidator runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword" CssClass="text-danger" ErrorMessage="Las contraseñas no coinciden." />
            </div>

            <asp:Button runat="server" OnClick="CreateUser_Click" Text="Registrarse" CssClass="btn btn-register w-100 mt-2" />

            <div class="login-link">
                ¿Ya tienes cuenta? <a href="Login.aspx">Inicia sesión</a>
            </div>
        </div>
    </div>

</asp:Content>

