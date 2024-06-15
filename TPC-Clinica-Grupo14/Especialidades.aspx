<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Especialidades.aspx.cs" Inherits="TPC_Clinica_Grupo14.Especialidades" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Estilos.css" rel="stylesheet" />

    <style> 
        body {
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
        }

        .table-responsive {
            max-height: 600px;
            overflow-x: auto;
        }

            .table-responsive .grid-view {
                width: 100%;
            }
    </style>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="main">
        <div class="sidebar">
            <a class="nav-link" href="Especialidades.aspx">ESPECIALIDADES</a>
            <a class="nav-link" href="Turnos.aspx">TURNOS</a>
            <a class="nav-link" href="Pacientes.aspx">PACIENTES</a>
            <a class="nav-link" href="Medicos.aspx">MEDICOS</a>
        </div>

        <div class="content">
            <div class="table-responsive">
                <asp:GridView runat="server" ID="dgvEspecialidades" OnSelectedIndexChanged="dgvEspecialidades_SelectedIndexChanged" AutoGenerateColumns="False" DataKeyNames="Id" CssClass="table table-striped table-bordered table-dark grid-view">
                    <Columns>
                        <asp:BoundField DataField="Id" HeaderText="ID" Visible="true" />
                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                        <asp:CommandField ShowSelectButton="true" SelectText="Seleccionar" HeaderText="Acción" ControlStyle-CssClass="btn btn-sm btn-primary" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>

            <div class="col-md-4 mt-3 border">
            <asp:TextBox ID="txtId" runat="server" CssClass="form-control" ReadOnly="true" Visible="false"></asp:TextBox>
            <asp:Label ID="lblNombreEspecialidad" runat="server" AssociatedControlID="txtNombre" CssClass="form-label fw-bold">Especialidad Seleccionada</asp:Label>
            <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>

            <asp:Button ID="btnAgregar" runat="server" CssClass="btn btn-success" Text="Agregar" OnClick="btnAgregar_Click" />
            <asp:Button ID="btnModificar" runat="server" CssClass="btn btn-warning" Text="Modificar" OnClick="btnModificar_Click" />
            <asp:Button ID="btnEliminar" runat="server" CssClass="btn btn-danger" Text="Eliminar" OnClick="btnEliminar_Click" />
            <asp:Button ID="btnCancelar" runat="server" CssClass="btn btn-secondary" Text="Cancelar" OnClick="btnCancelar_Click" />


        </div>
    </div>
</asp:Content>