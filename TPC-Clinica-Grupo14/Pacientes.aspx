<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Pacientes.aspx.cs" Inherits="TPC_Clinica_Grupo14.Pacientes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Estilos.css" rel="stylesheet" />
    <style>
        body {
            display: flex;
            flex-direction: column;
            margin: 0;
        }

        .header {
            width: 100%;
            position: fixed;
            top: 0;
            z-index: 1000;
            background-color: #343a40;
            color: white;
            padding: 10px;
            text-align: center;
        }

        .main {
            display: flex;
            margin-top: 60px; 
            padding-bottom: 60px; 
        }

        .sidebar {
            height: calc(100vh - 60px); 
            width: 250px;
            position: fixed;
            top: 60px; 
            left: 0;
            background-color: #343a40;
            padding-top: 20px;
            z-index: 999; 
            overflow-y: auto;
        }

            .sidebar a {
                padding: 10px 15px;
                text-decoration: none;
                font-size: 18px;
                color: white;
                display: block;
            }

                .sidebar a:hover {
                    background-color: #575d63;
                }

        .content {
            margin-left: 260px; 
            padding: 20px;
            flex-grow: 1;
            overflow: auto; 
            padding-bottom: 60px; 
        }
    </style>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="Estilos.css" rel="stylesheet" />
   

        <div class="main">
            <div class="sidebar">
                <a class="nav-link" href="Especialidades.aspx">ESPECIALIDADES </a>
                <a class="nav-link" href="">TURNOS</a>
                <a class="nav-link" href="Pacientes.aspx">PACIENTES</a>
                <a class="nav-link" href="Medicos.aspx">MEDICOS</a>
            </div>

            <div class="content">
                <!-- Aquí iría el contenido principal de la página -->
            </div>
        </div>
   

</asp:Content>