<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="MenuMedico.aspx.cs" Inherits="TPC_Clinica_Grupo14.Formulario_web1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  
        <<div style="display: flex; justify-content: center; align-items: center; height: 100vh;">
            <div style="display: flex; justify-content: space-around; width: 90%; max-width: 1600px;">



                <div class="card" style="width: 12rem;">
                    <img src="cita.png" class="card-img-top" alt="...">
                    <div class="card-body">
                        <h5 class="Consultas">TURNOS </h5>
                        <p class="card-text">Consultas de turnos y estados</p>
                    </div>
                    <ul class="list-group list-group-flush"></ul>
                    <div class="card-body">
                        <a href="Pruebas.aspx" class="card-link">TURNOS</a>
                    </div>
                </div>

                <div class="card" style="width: 12rem;">
                    <img src="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRAswJKNKcHG8dxDXOSnQ6cAdOeGRiIcZzkUg&s" class="card-img-top" alt="...">
                    <div class="card-body">
                        <h5 class="card-title">PACIENTES</h5>
                        <p class="card-text">Fichas personales de pacientes</p>
                    </div>
                    <ul class="list-group list-group-flush"></ul>
                    <div class="card-body">
                        <a href="Pacientes.aspx" class="card-link">PACIENTES</a>
                    </div>
                </div>



            </div>
        </div>

    </asp:Content>
