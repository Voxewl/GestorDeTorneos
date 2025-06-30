<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Gestor_Torneos._Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        /* Estilos generales */
        body {
            margin: 0;
            font-family: 'Segoe UI', sans-serif;
            background-color: #121212;
            color: #ffffff;
            display: flex;
            flex-direction: column;
            min-height: 100vh;
        }

        /* Hero section */
        .hero {
            position: relative;
            height: 60vh;
            min-height: 400px;
            color: white;
            text-align: center;
            display: flex;
            flex-direction: column;
            justify-content: center;
            padding: 0 20px;
            background: url('/Images/banner.jpg') no-repeat center center/cover;
            margin-bottom: 40px;
        }

        .hero::before {
            content: "";
            position: absolute;
            inset: 0;
            background: rgba(0, 0, 0, 0.5);
            z-index: 0;
        }

        .hero-content {
            position: relative;
            z-index: 1;
            max-width: 1200px;
            margin: 0 auto;
            width: 100%;
        }

        .hero h1 {
            font-size: 3rem;
            margin-bottom: 20px;
            text-shadow: 2px 2px 6px rgba(0,0,0,0.7);
        }

        .hero p {
            font-size: 1.5rem;
            max-width: 800px;
            margin: 0 auto 30px;
            text-shadow: 1px 1px 3px rgba(0,0,0,0.7);
        }

        /* Search bar */
        .search-bar {
            margin: 30px auto 0;
            background-color: rgba(255, 255, 255, 0.1);
            padding: 12px 25px;
            border-radius: 30px;
            display: flex;
            justify-content: space-between;
            align-items: center;
            max-width: 600px;
            width: 90%;
            backdrop-filter: blur(5px);
            border: 1px solid rgba(255, 255, 255, 0.1);
        }

        .search-bar input {
            border: none;
            background: transparent;
            color: white;
            flex-grow: 1;
            padding: 8px 15px;
            font-size: 1rem;
            outline: none;
        }

        .search-bar button {
            background: transparent;
            border: none;
            color: white;
            font-size: 1.3rem;
            cursor: pointer;
            transition: transform 0.3s ease;
        }

        .search-bar button:hover {
            transform: scale(1.1);
        }

        /* Benefits section */
        .benefits {
            display: flex;
            flex-wrap: wrap;
            justify-content: center;
            padding: 60px 20px;
            background-color: #1a1a1a;
        }

        .benefit {
            width: 300px;
            margin: 20px;
            text-align: center;
            padding: 30px 20px;
            background: rgba(255, 255, 255, 0.05);
            border-radius: 15px;
            transition: transform 0.3s ease, box-shadow 0.3s ease;
        }

        .benefit:hover {
            transform: translateY(-5px);
            box-shadow: 0 10px 20px rgba(0,0,0,0.3);
        }

        .benefit img {
            width: 80px;
            height: 80px;
            object-fit: contain;
            margin-bottom: 20px;
        }

        .benefit h3 {
            margin-bottom: 15px;
            font-size: 1.3rem;
            color: #f0f0f0;
        }

        .benefit p {
            color: #ccc;
            line-height: 1.5;
        }

        /* Story section */
        .story {
            background-color: #121212;
            color: white;
            padding: 80px 30px;
            text-align: center;
            border-top: 1px solid rgba(255,255,255,0.1);
            border-bottom: 1px solid rgba(255,255,255,0.1);
        }

        .story-container {
            max-width: 1200px;
            margin: 0 auto;
        }

        .story h2 {
            font-size: 2.5rem;
            margin-bottom: 30px;
            color: #ffffff;
        }

        .story p {
            max-width: 800px;
            margin: 0 auto 40px;
            color: #ccc;
            font-size: 1.2rem;
            line-height: 1.6;
        }

        .story img {
            max-width: 100%;
            height: auto;
            border-radius: 15px;
            box-shadow: 0 10px 30px rgba(0,0,0,0.5);
            max-height: 400px;
            object-fit: cover;
        }

        /* CTA section */
        .cta {
            padding: 80px 20px;
            text-align: center;
            background-color: #1a1a1a;
        }

        .cta h2 {
            font-size: 2.2rem;
            margin-bottom: 30px;
            color: #ffffff;
        }

        .cta-button {
            padding: 15px 40px;
            font-size: 1.2rem;
            background-color: #B8860B;
            color: white;
            border: none;
            border-radius: 30px;
            cursor: pointer;
            transition: all 0.3s ease;
            font-weight: bold;
            text-decoration: none;
            display: inline-block;
        }

        .cta-button:hover {
            background-color: #DAA520;
            box-shadow: 0 5px 15px rgba(218, 165, 32, 0.4);
            transform: translateY(-2px);
        }

        /* Responsive */
        @media (max-width: 768px) {
            .hero {
                height: 70vh;
            }
            
            .hero h1 {
                font-size: 2rem;
            }
            
            .hero p {
                font-size: 1.1rem;
            }
            
            .benefit {
                width: 100%;
                max-width: 350px;
            }
            
            .story h2 {
                font-size: 1.8rem;
            }
            
            .cta h2 {
                font-size: 1.8rem;
            }
        }
    </style>

    <!-- Hero Section -->
    <section class="hero">
        <div class="hero-content">
            <h1>Organiza tus torneos de fútbol como un profesional</h1>
            <p>Una plataforma simple, potente y gratuita para crear, gestionar y compartir tus ligas o campeonatos.</p>
            <div class="search-bar">
                <input type="text" placeholder="Buscar torneos, equipos..." />
                <button>🔍</button>
            </div>
        </div>
    </section>

    <!-- Benefits Section -->
    <section class="benefits">
        <div class="benefit">
            <img src="https://cdn-icons-png.flaticon.com/512/857/857681.png" alt="Torneo">
            <h3>Crea Torneos</h3>
            <p>Diseña tu torneo en segundos con equipos, reglas y formatos personalizables.</p>
        </div>
        <div class="benefit">
            <img src="https://cdn-icons-png.flaticon.com/512/3062/3062634.png" alt="Control">
            <h3>Gestiona Partidos</h3>
            <p>Organiza fechas, resultados, y mantén todo bajo control desde una sola app.</p>
        </div>
        <div class="benefit">
            <img src="https://cdn-icons-png.flaticon.com/512/2107/2107957.png" alt="Estadísticas">
            <h3>Consulta Estadísticas</h3>
            <p>Goleadores, posiciones, rendimiento... todo visualizado con claridad.</p>
        </div>
    </section>

    <!-- Story Section -->
    <section class="story">
        <div class="story-container">
            <h2>Más que una app: una comunidad</h2>
            <p>
                Conecta jugadores, entrenadores y organizadores. Haz que cada torneo cuente con seguimiento en tiempo real, diseño atractivo y participación activa.
            </p>
            <img src="/Images/imgcard1.jpg" alt="Jugadores celebrando">
        </div>
    </section>

    <!-- CTA Section -->
    <section class="cta">
        <h2>¿Listo para comenzar tu próximo torneo?</h2>
        <asp:HyperLink runat="server" NavigateUrl="~/Account/Register" CssClass="cta-button">¡Crea tu cuenta ahora!</asp:HyperLink>
    </section>
</asp:Content>