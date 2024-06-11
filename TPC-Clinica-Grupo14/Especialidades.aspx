<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Especialidades.aspx.cs" Inherits="TPC_Clinica_Grupo14.Especialidades" %>

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
            margin-top: 60px; /* Ajusta esto según la altura de tu cabecera */
            padding-bottom: 60px; /* Espacio para el footer */
        }

        .sidebar {
            height: calc(100vh - 60px); /* Ajusta esto según la altura de tu cabecera */
            width: 250px; /* Ajusta esto según el ancho deseado */
            position: fixed;
            top: 60px; /* Ajusta esto según la altura de tu cabecera */
            left: 0;
            background-color: #343a40;
            padding-top: 20px;
            z-index: 999; /* Menor que la cabecera */
            overflow-y: auto; /* Para asegurarte de que el menú se pueda desplazar si es necesario */
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
            margin-left: 260px; /* Ajusta esto según el ancho de la sidebar */
            padding: 20px;
            flex-grow: 1;
            overflow: auto; /* Para manejar el desbordamiento del contenido */
            padding-bottom: 60px; /* Espacio para el footer */
        }
    </style>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="Estilos.css" rel="stylesheet" />

    <div class="main">
        <div class="sidebar">
            <a class="nav-link" href="Especialidades.aspx">ESPECIALIDADES </a>
            <a class="nav-link" href="Turnos.aspx">TURNOS</a>
            <a class="nav-link" href="Pacientes.aspx">PACIENTES</a>
            <a class="nav-link" href="Medicos.aspx">MEDICOS</a>
        </div>
    </div>



    <div class="content">

        <asp:GridView runat="server" ID="dgvEspecialidades"></asp:GridView>



        <!-- Aquí iría el contenido principal de la página -->

    </div>


</asp:Content>
