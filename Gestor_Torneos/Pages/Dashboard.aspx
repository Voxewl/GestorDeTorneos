<%@ Page Title="Dashboard" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="Gestor_Torneos.Pages.Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5 text-light">
        <div class="text-center mb-5">
            <h1 class="display-5 fw-bold">🎮 Gestor de Torneos</h1>
            <p class="lead">Administra jugadores, equipos, torneos y estadísticas de forma sencilla.</p>
        </div>

        <div class="row row-cols-1 row-cols-md-3 g-4">
            <!-- Jugadores -->
            <div class="col">
                <div class="card text-white bg-dark border-secondary shadow-sm h-100">
                    <div class="card-body text-center">
                        <i class="bi bi-person-fill display-4 mb-3"></i>
                        <h5 class="card-title">Jugadores</h5>
                        <a href="Jugadores/Registrar.aspx" class="btn btn-primary btn-sm mt-2">Registrar</a>
                        <a href="Jugadores/RegistrarEquipo.aspx" class="btn btn-primary btn-sm mt-2">Asignar a Equipo</a>
                    </div>
                </div>
            </div>

            <!-- Equipos -->
            <div class="col">
                <div class="card text-white bg-dark border-secondary shadow-sm h-100">
                    <div class="card-body text-center">
                        <i class="bi bi-people-fill display-4 mb-3"></i>
                        <h5 class="card-title">Equipos</h5>
                        <a href="Equipos/Registrar.aspx" class="btn btn-primary btn-sm mt-2">Registrar</a>
                        <a href="Equipos/AsignarATorneo.aspx" class="btn btn-primary btn-sm mt-2">Asignar a Torneo</a>
                    </div>
                </div>
            </div>

            <!-- Torneos -->
            <div class="col">
                <div class="card text-white bg-dark border-secondary shadow-sm h-100">
                    <div class="card-body text-center">
                        <i class="bi bi-trophy-fill display-4 mb-3"></i>
                        <h5 class="card-title">Torneos</h5>
                        <a href="Torneos/Registrar.aspx" class="btn btn-primary btn-sm mt-2">Registrar</a>
                         <a href="Torneos/Tipos.aspx" class="btn btn-primary btn-sm mt-2">Tipos</a>
                    </div>
                </div>
            </div>

            <!-- Partidos -->
            <div class="col">
                <div class="card text-white bg-dark border-secondary shadow-sm h-100">
                    <div class="card-body text-center">
                        <i class="bi bi-controller display-4 mb-3"></i>
                        <h5 class="card-title">Partidos</h5>
                        <a href="Partidos/Registrar.aspx" class="btn btn-primary btn-sm mt-2">Registrar</a>
                    </div>
                </div>
            </div>

            <!-- Estadísticas -->
            <div class="col">
                <div class="card text-white bg-dark border-secondary shadow-sm h-100">
                    <div class="card-body text-center">
                        <i class="bi bi-bar-chart-fill display-4 mb-3"></i>
                        <h5 class="card-title">Estadísticas</h5>
                        <a href="Estadisticas/Consultar.aspx" class="btn btn-primary btn-sm mt-2">Consultar</a>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
