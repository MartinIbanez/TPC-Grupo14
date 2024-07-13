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
            <div class="row">
                <div class="col-md-6">
                    <div class="form-group">
                        <asp:Label ID="lblNombreMedico" runat="server" AssociatedControlID="txtNombre" CssClass="form-label fw-bold">Nombre del Médico</asp:Label>
                        <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>

                        <asp:Label ID="lblApellidoMedico" runat="server" AssociatedControlID="txtApellido" CssClass="form-label fw-bold">Apellido del Médico</asp:Label>
                        <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control"></asp:TextBox>

                        <asp:Label ID="lblFechaNacimientoMedico" runat="server" AssociatedControlID="txtFechaNacimiento" CssClass="form-label fw-bold">Fecha de Nacimiento del Médico</asp:Label>
                        <asp:TextBox ID="txtFechaNacimiento" runat="server" CssClass="form-control"></asp:TextBox>

                        <!-- DropDownList para Especialidades -->
                        <asp:Label ID="lblEspecialidadMedico" runat="server" AssociatedControlID="ddlEspecialidad" CssClass="form-label fw-bold"> Especialidad</asp:Label>
                        <asp:DropDownList ID="ddlEspecialidad" runat="server" CssClass="form-control">
                            <asp:ListItem Text="Seleccione una opción" Value="0"></asp:ListItem>

                        </asp:DropDownList>
                    </div>
                </div>

                <div class="col-md-6">
                    <div class="form-group">
                        <asp:Label ID="lblDNIMedico" runat="server" AssociatedControlID="txtDNI" CssClass="form-label fw-bold">DNI del Médico</asp:Label>
                        <asp:TextBox ID="txtDNI" runat="server" CssClass="form-control"></asp:TextBox>

                        <asp:Label ID="lblCorreoMedico" runat="server" AssociatedControlID="txtCorreo" CssClass="form-label fw-bold">Correo del Médico</asp:Label>
                        <asp:TextBox ID="txtCorreo" runat="server" CssClass="form-control"></asp:TextBox>

                        <asp:Label ID="lblTelefonoMedico" runat="server" AssociatedControlID="txtTelefono" CssClass="form-label fw-bold">Teléfono del Médico</asp:Label>
                        <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control"></asp:TextBox>

                        <asp:Label ID="lblActivoMedico" runat="server" AssociatedControlID="txtActivo" CssClass="form-label fw-bold">Médico Activo?</asp:Label>
                        <asp:DropDownList ID="txtActivo" runat="server" CssClass="form-control">
                            <asp:ListItem Text="Seleccione una opción" Value="0"></asp:ListItem>
                            <asp:ListItem Text="si" Value="1"></asp:ListItem>
                            <asp:ListItem Text="no" Value="2"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
            </div>

            <div class="row">
                <div class="col-md-12">
                    <asp:Button ID="btnAgregar" runat="server" CssClass="btn btn-success" Text="Agregar" OnClick="btnAgregar_Click" />
                    <asp:Button ID="btnModificar" runat="server" CssClass="btn btn-warning" Text="Modificar" OnClick="btnModificar_Click" />
                    <asp:Button ID="btnEliminar" runat="server" CssClass="btn btn-danger" Text="Eliminar" OnClick="btnEliminar_Click" />
                    <asp:Button ID="btnCancelar" runat="server" CssClass="btn btn-secondary" Text="Cancelar" />
                </div>
            </div>

            <!-- Aquí iría el contenido principal de la página -->
            <div class="table-responsive">
                <!-- Aquí va la GridView de médicos que se levanta de una base de datos -->
                <asp:GridView runat="server" ID="dgvMedicos" OnSelectedIndexChanged="dgvMedicos_SelectedIndexChanged" AutoGenerateColumns="False" DataKeyNames="ID" CssClass="table table-striped table-bordered table-dark grid-view">
                    <Columns>
                        <asp:BoundField DataField="IdProfesional" HeaderText="ID Profesional" />
                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                        <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
                        <asp:BoundField DataField="FechaNacimiento" HeaderText="Fecha de Nacimiento" DataFormatString="{0:dd/MM/yyyy}" HtmlEncode="false" />
                        <asp:BoundField DataField="NumDoc" HeaderText="DNI" />
                        <asp:BoundField DataField="Correo" HeaderText="Correo" />
                        <asp:BoundField DataField="Telefono" HeaderText="Teléfono" />
                        <asp:BoundField DataField="Activo" HeaderText="Activo" />
                        <asp:CommandField ShowSelectButton="true" SelectText="Seleccionar" HeaderText="Acción" ControlStyle-CssClass="btn btn-sm btn-primary" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
