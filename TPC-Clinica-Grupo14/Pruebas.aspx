<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Pruebas.aspx.cs" Inherits="TPC_Clinica_Grupo14.Pruebas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <%--Necesario para el update panel--%>
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <%--<h1>Arrancan las pruebas....</h1>--%>
                <%--aca arrancan las 4 columnas--%>
                <div class="container">
                    <div class="row ">
                        <div class="col">
                            <asp:DropDownList runat="server" ID="DropDownListEspecialidades" AutoPostBack="true" OnSelectedIndexChanged="DropDownListEspecialidades_SelectedIndexChanged" CssClass="btn btn-secondary dropdown-toggle" role="button" data-bs-toggle="dropdown"></asp:DropDownList>
                            <br />
                            <br />
                            <asp:DropDownList runat="server" ID="DropDownListProfesionales" AutoPostBack="true" OnSelectedIndexChanged="DropDownListProfesionales_SelectedIndexChanged" CssClass="btn btn-secondary dropdown-toggle" role="button" data-bs-toggle="dropdown"></asp:DropDownList>
                            <br />
                            <br />
                            <asp:DropDownList runat="server" ID="DropDownListPacientes" AutoPostBack="true" OnSelectedIndexChanged="DropDownListPacientes_SelectedIndexChanged" CssClass="btn btn-secondary btn-lg dropdown-toggle" type="button" data-bs-toggle="dropdown" aria-expanded="false"></asp:DropDownList>
                            <br />
                            <br />
                            <asp:GridView runat="server" ID="dgvHorariosDisponibles" Visible="false" OnSelectedIndexChanged="dgvHorariosDisponibles_SelectedIndexChanged" AutoGenerateColumns="False" DataKeyNames="ID" CssClass="table table-striped table-bordered table-dark grid-view">
                                <Columns>
                                    <asp:BoundField DataField="Dia" HeaderText="Dia de atencion" />
                                    <asp:BoundField DataField="HoraInicio" HeaderText="Hora de inicio turno" />
                                    <asp:BoundField DataField="HoraFin" HeaderText="Hora de fin turno" />
                                    <asp:CommandField ShowSelectButton="true" SelectText="Seleccionar horario" HeaderText="Acción" ControlStyle-CssClass="btn btn-sm btn-primary" />
                                </Columns>
                            </asp:GridView>
                            <br />
                            <br />
                        </div>
                        <div class="col">
                        </div>
                        <div class="col">
                        </div>
                        <div class="col">
                            <h2>Dias Disponibles: </h2>
                            <asp:Calendar runat="server" ID="CalendarioTurnos" AutoPostBack="true" OnDayRender="CalendarioTurnos_DayRender" OnSelectionChanged="CalendarioTurnos_SelectionChanged"></asp:Calendar>
                        </div>
                        <div class="col">
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
                                        <asp:Label ID="CardFechaTurno" AutoPostBack="true" Text="Fecha Turno: " runat="server" />
                                    </h5>
                                    <p class="card-text">
                                        Presentarse con 15 min de anticipacion y estudios previos.
                                    </p>
                                </div>
                                <ul class="list-group list-group-flush">
                                    <li class="list-group-item">
                                        <asp:Label ID="CardPaciente" Text="Paciente: " runat="server" />
                                    </li>
                                    <li class="list-group-item">
                                        <asp:Label ID="CardProfesional" Text="Profesional: " runat="server" />
                                    </li>
                                    <li class="list-group-item">
                                        <asp:Label ID="CardEspecialidad" Text="Especialidad: " runat="server" />
                                    </li>
                                </ul>
                            </div>
                            <%--aca termina la tarjeta--%>
                        </div>
                    </div>
                </div>
                <%--aca terminan las 4 columnas--%>
                <br />
                <br />
                <asp:GridView runat="server" ID="GridPruebaTurnos" Visible="false"></asp:GridView>
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>

</asp:Content>
