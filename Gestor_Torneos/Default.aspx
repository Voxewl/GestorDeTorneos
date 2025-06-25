<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Gestor_Torneos._Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        /* Fondo global */
        body {
            background-color: #1e1e1e;
            color: #ffffff;
            overflow-x: hidden; /* evita scroll horizontal */
        }

        .container.body-content {
            background-color: transparent !important;
        }

        /* Banner responsive que no sobrepasa el ancho */
        .banner-section {
            width: 100%;
            background-color: #000;
            text-align: center;
            color: white;
            position: relative;
        }

        .banner-section img {
            width: 100%;
            height: auto;
            display: block;
        }

        .banner-overlay {
            position: absolute;
            top: 0;
            left: 0;
            width: 100%;
            height: 100%;
            display: flex;
            flex-direction: column;
            justify-content: center;
            align-items: center;
            padding: 20px;
            background: rgba(0, 0, 0, 0.4);
        }

        .banner-overlay h1 {
            font-size: 2.5rem;
            font-weight: bold;
            text-shadow: 2px 2px 5px rgba(0,0,0,0.6);
        }

        .banner-overlay p {
            font-size: 1.2rem;
            font-style: italic;
            color: #f0f0f0;
            margin-top: 10px;
        }

        .search-bar {
            margin-top: 20px;
            background-color: rgba(255, 255, 255, 0.1);
            padding: 10px 20px;
            border-radius: 30px;
            display: flex;
            justify-content: space-between;
            align-items: center;
            max-width: 500px;
            width: 90%;
        }

        .search-bar input {
            border: none;
            background: transparent;
            color: white;
            flex-grow: 1;
            padding: 5px;
            font-size: 1rem;
            outline: none;
        }

        .search-bar button {
            background: transparent;
            border: none;
            color: white;
            font-size: 1.3rem;
            cursor: pointer;
        }

        .welcome-text {
            padding: 40px 20px;
            text-align: center;
            font-size: 1.1rem;
            max-width: 900px;
            margin: 0 auto;
            color: #ffffff;
        }

        .info-card {
            display: flex;
            flex-wrap: wrap;
            background-color: #111;
            color: white;
            border-radius: 12px;
            overflow: hidden;
            max-width: 900px;
            margin: 30px auto;
            box-shadow: 0 4px 12px rgba(0,0,0,0.3);
        }

        .info-card img {
            width: 100%;
            max-width: 300px;
            object-fit: cover;
        }

        .info-card .info-text {
            flex-grow: 1;
            padding: 20px;
        }

        .info-card h4 {
            margin-bottom: 15px;
            font-size: 1.3rem;
        }

        .info-card ul {
            padding-left: 20px;
        }

        .info-card li {
            margin-bottom: 10px;
        }

        @media (max-width: 768px) {
            .banner-overlay h1 {
                font-size: 1.8rem;
            }

            .search-bar {
                flex-direction: column;
                gap: 10px;
            }

            .info-card {
                flex-direction: column;
                text-align: center;
            }

            .info-card img {
                max-width: 100%;
            }
        }
    </style>

    <!-- Banner con overlay -->
    <div class="banner-section">
        <img src="/Images/banner.jpg" alt="Banner deportivo" />
        <div class="banner-overlay">
            <h1>¡WELCOME TO SPORTFIT X!</h1>
            <p>"El mejor aliado para organizar tus torneos."</p>
            <div class="search-bar">
                <input type="text" placeholder="Buscar torneos, equipos..." />
                <button>🔍</button>
            </div>
        </div>
    </div>

    <!-- Texto de bienvenida -->
    <div class="welcome-text">
        <p>
            Te damos la bienvenida a nuestra plataforma, diseñada para simplificar la organización y gestión de tus competencias deportivas.
            Desde la creación de calendarios hasta el seguimiento de resultados, aquí encontrarás todo lo que necesitas para llevar tu torneo al siguiente nivel.
        </p>
    </div>

    <!-- Tarjeta informativa -->
    <div class="info-card">
        <img src="/Images/imgcard1.jpg" alt="Equipamiento deportivo" />
        <div class="info-text">
            <h4>¿Qué puedes hacer aquí?</h4>
            <ul>
                <li>✅ Registrar equipos o jugadores fácilmente.</li>
                <li>✅ Generar calendarios y tablas de posiciones automáticas.</li>
                <li>✅ Ingresar y visualizar estadísticas en tiempo real.</li>
                <li>✅ Compartir resultados y noticias con un solo clic.</li>
            </ul>
        </div>
    </div>
</asp:Content>


