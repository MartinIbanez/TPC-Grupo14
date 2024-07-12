﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Pruebas.aspx.cs" Inherits="TPC_Clinica_Grupo14.Pruebas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <%--Necesario para el update panel--%>
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <h1>Arrancan las pruebas....</h1>
                <%--aca arrancan las 4 columnas--%>
                <div class="container">
                    <div class="row ">
                        <div class="col">
                            <asp:DropDownList runat="server" ID="DropDownListEspecialidades" AutoPostBack="true" OnSelectedIndexChanged="DropDownListEspecialidades_SelectedIndexChanged" CssClass="btn btn-secondary dropdown-toggle" role="button" data-bs-toggle="dropdown" ></asp:DropDownList>
                            <br />
                            <br />
                            <asp:DropDownList runat="server" ID="DropDownListProfesionales" AutoPostBack="true" OnSelectedIndexChanged="DropDownListProfesionales_SelectedIndexChanged" CssClass="btn btn-secondary dropdown-toggle" role="button" data-bs-toggle="dropdown"></asp:DropDownList>
                            <br />
                            <br />
                            <asp:DropDownList runat="server" ID="DropDownListHorariosDisponibles" Visible="false" AutoPostBack="true" OnSelectedIndexChanged="DropDownListHorariosDisponibles_SelectedIndexChanged" CssClass="btn btn-secondary dropdown-toggle" role="button" data-bs-toggle="dropdown"></asp:DropDownList>
                        </div>
                        <div class="col">
                        </div>
                            <%--<asp:DropDownList runat="server" ID="DropDownListDia" Visible="false" AutoPostBack="true" OnSelectedIndexChanged="DropDownListDia_SelectedIndexChanged"></asp:DropDownList>--%>
                        <div class="col">
                        </div>
                        <div class="col">
                            <h2>Prueba Calendario...    </h2>
                            <asp:Calendar runat="server" ID="CalendarioTurnos" Visible="false" AutoPostBack="true" OnDayRender="CalendarioTurnos_DayRender" OnSelectionChanged="CalendarioTurnos_SelectionChanged"></asp:Calendar>
                        </div>
                        <div class="col">
                            <asp:Label ID="LabelTurnoSeleccionado" Text="Prueba de texto turno!" CssClass="form-control" runat="server" />
                            <br />
                            <br />
                            <br />
                            <asp:Label ID="LabelInfoTurno" Text="Prueba de texto turno!" CssClass="form-control" runat="server" />
                            <br />
                            <br />
                            <br />
                            <asp:DropDownList ID="DropDownListPacientes" AutoPostBack="true" OnSelectedIndexChanged="DropDownListPacientes_SelectedIndexChanged" runat="server" CssClass="btn btn-secondary btn-lg dropdown-toggle" type="button" data-bs-toggle="dropdown" aria-expanded="false"></asp:DropDownList>
                            <br />
                            <br />
                            <br />
                            <asp:Button ID="btnCrearTurno" CssClass="btn btn-success" Text="CREAR TURNO" runat="server" OnClick="btnCrearTurno_Click" />
                            <br />
                            <br />
                            <br />
                            <br />
                            <asp:Label ID="LabelTurnoCreado" Visible="false" class="alert alert-success" Text="TURNO CREADO!" runat="server" />
                            <asp:Timer ID="TimerTurnoCreado" runat="server" Interval="4000" OnTick="TimerTurnoCreado_Tick" Enabled="false"></asp:Timer>
                        </div>
                        <div class="col">
                            <%--aca va una tarjeta con la info del turno--%>
                            <div class="card" style="width: 18rem;">
                                <p class="card-text">
                                    Numero identificador de turno
                                </p>
                                <asp:Label ID="CardIdTurno" Text="(id) XXXX" runat="server" />
                                <%--<img src="..." class="card-img-top" alt="...">--%>
                                <div class="card-body">
                                    <h5 class="card-title">
                                        <asp:Label ID="CardFechaTurno" Text="Martes 02/07/2024 ejemplo..." runat="server" />

                                    </h5>
                                    <p class="card-text">
                                        Presentarse con 15 min de anticipacion y estudios previos. blablabla
                                    </p>
                                </div>
                                <ul class="list-group list-group-flush">
                                    <li class="list-group-item">
                                        <asp:Label ID="CardPaciente" Text="Paciente Ejemplo" runat="server" />
                                    </li>
                                    <li class="list-group-item">
                                        <asp:Label ID="CardProfesional" Text="Profesional Ejemplo" runat="server" />
                                    </li>
                                    <li class="list-group-item">
                                        <asp:Label ID="CardEspecialidad" Text="Especialidad Ejemplo" runat="server" />
                                    </li>
                                </ul>
                                <%--Podriamos agregarle un link pero por ahora no es necesario....--%>
                                <%--<div class="card-body">
                                    <a href="#" class="card-link">Card link</a>
                                    <a href="#" class="card-link">Another link</a>
                                </div>--%>
                            </div>
                            <%--aca termina la tarjeta--%>
                        </div>

                    </div>
                </div>
                <%--aca terminan las 4 columnas--%>
                <br />
                <br />
                <asp:GridView runat="server" ID="GridPruebaTurnos"></asp:GridView>
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <%--<asp:GridView runat="server" ID="GridPruebaRoles"></asp:GridView>--%>
                <%--<asp:GridView runat="server" ID="GridPruebaPersonas"></asp:GridView>
                <asp:GridView runat="server" ID="GridPruebasEspecialidades"></asp:GridView>--%>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>





</asp:Content>
