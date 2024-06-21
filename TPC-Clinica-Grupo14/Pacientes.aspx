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
        <!--botones laterales-->
        <div class="sidebar">
            <a class="nav-link" href="Especialidades.aspx">ESPECIALIDADES </a>
            <a class="nav-link" href="">TURNOS</a>
            <a class="nav-link" href="Pacientes.aspx">PACIENTES</a>
            <a class="nav-link" href="Medicos.aspx">MEDICOS</a>
        </div>

        <div class="content">
            <!-- Estos son los textboxes, labels  -->
            <div class="row">
                <div class="col-md-6">
                    <div class="form-group">
                        <asp:TextBox ID="txtId" runat="server" CssClass="form-control" ReadOnly="true" Visible="false"></asp:TextBox>

                        <asp:Label ID="lblNombrePaciente" runat="server" AssociatedControlID="txtNombre" CssClass="form-label fw-bold">Nombre del Paciente</asp:Label>
                        <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>

                        <asp:Label ID="lblApellidoPaciente" runat="server" AssociatedControlID="txtApellido" CssClass="form-label fw-bold">Apellido del Paciente</asp:Label>
                        <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control"></asp:TextBox>

                        <asp:Label ID="lblFechaNacimientoPaciente" runat="server" AssociatedControlID="txtFechaNacimiento" CssClass="form-label fw-bold">Fecha de Nacimiento del Paciente</asp:Label>
                        <asp:TextBox ID="txtFechaNacimiento" runat="server" CssClass="form-control"></asp:TextBox>

                        <asp:Label ID="lblGeneroPaciente" runat="server" AssociatedControlID="txtGenero" CssClass="form-label fw-bold">Genero del Paciente</asp:Label>
                        <asp:TextBox ID="txtGenero" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>

                <div class="col-md-6">
                    <div class="form-group">
                        <asp:Label ID="lblDNIPaciente" runat="server" AssociatedControlID="txtDNI" CssClass="form-label fw-bold">DNI del Paciente</asp:Label>
                        <asp:TextBox ID="txtDNI" runat="server" CssClass="form-control"></asp:TextBox>

                        <asp:Label ID="lblCorreoPaciente" runat="server" AssociatedControlID="txtCorreo" CssClass="form-label fw-bold">Correo del Paciente</asp:Label>
                        <asp:TextBox ID="txtCorreo" runat="server" CssClass="form-control"></asp:TextBox>

                        <asp:Label ID="lblTelefonoPaciente" runat="server" AssociatedControlID="txtTelefono" CssClass="form-label fw-bold">Telefono del Paciente</asp:Label>
                        <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control"></asp:TextBox>

                        <asp:Label ID="lblActivoPaciente" runat="server" AssociatedControlID="txtActivo" CssClass="form-label fw-bold">Activo del Paciente</asp:Label>
                        <asp:TextBox ID="txtActivo" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
            </div>

            <div class="row">
                <div class="col-md-12">
                    <asp:Button ID="btnAgregar" runat="server" CssClass="btn btn-success" Text="Agregar" OnClick="btnAgregar_Click" />
                    <asp:Button ID="btnModificar" runat="server" CssClass="btn btn-warning" Text="Modificar" OnClick="btnModificar_Click" />
                    <asp:Button ID="btnEliminar" runat="server" CssClass="btn btn-danger" Text="Eliminar" OnClick="btnEliminar_Click" />
                    <asp:Button ID="btnCancelar" runat="server" CssClass="btn btn-secondary" Text="Cancelar" OnClick="btnCancelar_Click" />
                </div>
            </div>

            <!-- Aquí iría el contenido principal de la página -->
            <div class="table-responsive">
                <!-- Aquí va la GridView de pacientes que se levanta de una base de datos -->
                <asp:GridView runat="server" ID="dgvPacientes" OnSelectedIndexChanged="dgvPacientes_SelectedIndexChanged" AutoGenerateColumns="False" DataKeyNames="ID" CssClass="table table-striped table-bordered table-dark grid-view">
                    <Columns>
                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                        <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
                        <asp:BoundField DataField="FechaNacimiento" HeaderText="Fecha de Nacimiento" />
                        <asp:BoundField DataField="IdGenero" HeaderText="Genero" />
                        <asp:BoundField DataField="NumDoc" HeaderText="DNI" />
                        <asp:BoundField DataField="Correo" HeaderText="Correo" />
                        <asp:BoundField DataField="Telefono" HeaderText="Teléfono" />
                        <asp:CommandField ShowSelectButton="true" SelectText="Seleccionar" HeaderText="Acción" ControlStyle-CssClass="btn btn-sm btn-primary" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
