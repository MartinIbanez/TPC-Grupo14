<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Medicos.aspx.cs" Inherits="TPC_Clinica_Grupo14.Medicos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="COlumnaLateral.css" rel="stylesheet" />

  
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="COlumnaLateral.css" rel="stylesheet" />
   

        <div class="main">
            <div class="sidebar">
                <a class="nav-link" href="Especialidades.aspx">ESPECIALIDADES </a>
                <a class="nav-link" href="Turnos.aspx">TURNOS</a>
                <a class="nav-link" href="Pacientes.aspx">PACIENTES</a>
                <a class="nav-link" href="Medicos.aspx">MEDICOS</a>
            </div>

            <div class="content">

                <asp:GridView ID="dgvMedicos" runat="server"></asp:GridView>
               

            </div>
        </div>
   


</asp:Content>