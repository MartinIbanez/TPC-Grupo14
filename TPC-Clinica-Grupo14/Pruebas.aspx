<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Pruebas.aspx.cs" Inherits="TPC_Clinica_Grupo14.Pruebas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container mt-4">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                
              
                <div class="row">
                    <div class="col-md-3">
                        <asp:DropDownList runat="server" ID="DropDownListEspecialidades" AutoPostBack="true" 
                                          OnSelectedIndexChanged="DropDownListEspecialidades_SelectedIndexChanged" 
                                          CssClass="form-select mb-3"></asp:DropDownList>
                        
                        <asp:DropDownList runat="server" ID="DropDownListProfesionales" AutoPostBack="true" 
                                          OnSelectedIndexChanged="DropDownListProfesionales_SelectedIndexChanged" 
                                          CssClass="form-select mb-3"></asp:DropDownList>
                        
                        <asp:DropDownList runat="server" ID="DropDownListPacientes" AutoPostBack="true" 
                                          OnSelectedIndexChanged="DropDownListPacientes_SelectedIndexChanged" 
                                          CssClass="form-select mb-3"></asp:DropDownList>
                        
                        <asp:GridView runat="server" ID="dgvHorariosDisponibles" Visible="false" 
                                      OnSelectedIndexChanged="dgvHorariosDisponibles_SelectedIndexChanged" 
                                      AutoGenerateColumns="False" DataKeyNames="ID" 
                                      CssClass="table table-striped table-bordered mt-3">
                            <Columns>
                                <asp:BoundField DataField="Dia" HeaderText="Día de atención" />
                                <asp:BoundField DataField="HoraInicio" HeaderText="Hora de inicio turno" />
                                <asp:BoundField DataField="HoraFin" HeaderText="Hora de fin turno" />
                                <asp:CommandField ShowSelectButton="true" SelectText="Seleccionar horario" 
                                                  HeaderText="Acción" 
                                                  ControlStyle-CssClass="btn btn-sm btn-primary" />
                            </Columns>
                        </asp:GridView>
                    </div>
                    
                    <div class="col-md-3">
                        
                    </div>
                    
                    <div class="col-md-3">
                        <h2>Días Disponibles:</h2>
                        <asp:Calendar runat="server" ID="CalendarioTurnos" AutoPostBack="true" 
                                      OnDayRender="CalendarioTurnos_DayRender" 
                                      OnSelectionChanged="CalendarioTurnos_SelectionChanged" 
                                      CssClass="mt-3"></asp:Calendar>
                    </div>
                    
                    <div class="col-md-3">
                        <asp:Button ID="btnCrearTurno" CssClass="btn btn-success mt-4" Text="CREAR TURNO" runat="server" OnClick="btnCrearTurno_Click" />
                        
                        <asp:Label ID="LabelTurnoCreado" Visible="false" CssClass="alert alert-success mt-4" Text="¡TURNO CREADO!" runat="server" />
                        <asp:Timer ID="TimerTurnoCreado" runat="server" Interval="4000" OnTick="TimerTurnoCreado_Tick" Enabled="false"></asp:Timer>
                        
                        <div class="card mt-4" style="width: 18rem;">
                            <div class="card-body">
                                <h5 class="card-title">Detalles del Turno</h5>
                                <p class="card-text">
                                    Número identificador de turno: <asp:Label ID="CardIdTurno" Text="(id) XXXX" runat="server" />
                                </p>
                                <p class="card-text">
                                    Fecha Turno: <asp:Label ID="CardFechaTurno" Text="Fecha Turno: " runat="server" />
                                </p>
                                <p class="card-text">Presentarse con 15 min de anticipación y estudios previos.</p>
                            </div>
                            <ul class="list-group list-group-flush">
                                <li class="list-group-item">Paciente: <asp:Label ID="CardPaciente" Text="Paciente: " runat="server" /></li>
                                <li class="list-group-item">Profesional: <asp:Label ID="CardProfesional" Text="Profesional: " runat="server" /></li>
                                <li class="list-group-item">Especialidad: <asp:Label ID="CardEspecialidad" Text="Especialidad: " runat="server" /></li>
                            </ul>
                        </div>
                    </div>
                </div>
                
                <asp:GridView runat="server" ID="GridPruebaTurnos" CssClass="table table-striped table-bordered mt-4"></asp:GridView>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>