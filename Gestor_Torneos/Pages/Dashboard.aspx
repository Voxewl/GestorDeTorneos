<%@ Page Title="Dashboard" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="Gestor_Torneos.Pages.Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5 text-light">
        <h2 class="mb-4">Panel de Control - Gestor de Torneos</h2>

        <div class="row row-cols-1 row-cols-md-2 g-4">
            <!-- Jugadores -->
            <div class="col">
                <div class="card bg-dark border-secondary h-100">
                    <div class="card-body">
                        <h5 class="card-title">Jugadores</h5>
                        <a href="Jugadores/Registrar.aspx" class="btn btn-outline-light btn-sm">Registrar Jugador</a>
                        <a href="Jugadores/AsignarAEquipo.aspx" class="btn btn-outline-light btn-sm">Asignar a Equipo</a>
                    </div>
                </div>
            </div>

            <!-- Equipos -->
            <div class="col">
                <div class="card bg-dark border-secondary h-100">
                    <div class="card-body">
                        <h5 class="card-title">Equipos</h5>
                        <a href="Equipos/Registrar.aspx" class="btn btn-outline-light btn-sm">Registrar Equipo</a>
                        <a href="Equipos/AsignarATorneo.aspx" class="btn btn-outline-light btn-sm">Asignar a Torneo</a>
                    </div>
                </div>
            </div>

            <!-- Torneos -->
            <div class="col">
                <div class="card bg-dark border-secondary h-100">
                    <div class="card-body">
                        <h5 class="card-title">Torneos</h5>
                        <a href="Torneos/Registrar.aspx" class="btn btn-outline-light btn-sm">Registrar Torneo</a>
                    </div>
                </div>
            </div>

            <!-- Partidos -->
            <div class="col">
                <div class="card bg-dark border-secondary h-100">
                    <div class="card-body">
                        <h5 class="card-title">Partidos</h5>
                        <a href="Partidos/Registrar.aspx" class="btn btn-outline-light btn-sm">Registrar Partido</a>
                    </div>
                </div>
            </div>

            <!-- Estadísticas -->
            <div class="col">
                <div class="card bg-dark border-secondary h-100">
                    <div class="card-body">
                        <h5 class="card-title">Estadísticas</h5>
                        <a href="Estadisticas/Consultar.aspx" class="btn btn-outline-light btn-sm">Consultar Estadísticas</a>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
