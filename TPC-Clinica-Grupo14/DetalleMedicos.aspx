<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="DetalleMedicos.aspx.cs" Inherits="TPC_Clinica_Grupo14.DetalleMedicos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-5">
        <!-- Título central -->
        <div class="row">
            <div class="col-md-12 text-center">
                <h2 class="fw-bold">Detalle de Profesional</h2>
            </div>
        </div>

        <div class="row mt-3">
            <!-- Columna izquierda con los TextBoxes y Labels -->
            <div class="col-md-6">
                <div class="form-group">
                    <asp:Label ID="lblNombreMedico" runat="server" AssociatedControlID="txtNombre" CssClass="form-label fw-bold">Nombre del Médico</asp:Label>
                    <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>

                    <asp:Label ID="lblApellidoMedico" runat="server" AssociatedControlID="txtApellido" CssClass="form-label fw-bold">Apellido del Médico</asp:Label>
                    <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control"></asp:TextBox>

                    <asp:Label ID="lblFechaNacimientoMedico" runat="server" AssociatedControlID="txtFechaNacimiento" CssClass="form-label fw-bold">Fecha de Nacimiento del Médico</asp:Label>
                    <asp:TextBox ID="txtFechaNacimiento" runat="server" CssClass="form-control"></asp:TextBox>

                    <asp:Label ID="lblEspecialidadMedico" runat="server" AssociatedControlID="ddlEspecialidad" CssClass="form-label fw-bold">Especialidad</asp:Label>
                    <asp:DropDownList ID="ddlEspecialidad" runat="server" CssClass="form-control">
                        <asp:ListItem Text="Seleccione una opción" Value="0"></asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>

            <!-- Columna derecha con los TextBoxes y Labels adicionales -->
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
                        <asp:ListItem Text="Sí" Value="1"></asp:ListItem>
                        <asp:ListItem Text="No" Value="2"></asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
        </div>

        <!-- Fila con los botones -->
        <div class="row mt-3">
            <div class="col-md-12">
                <div class="d-flex justify-content-between">
                    <asp:Button ID="btnAgregar" runat="server" CssClass="btn btn-success" Text="Agregar" OnClick="btnAgregar_Click" />
                    <asp:Button ID="btnModificar" runat="server" CssClass="btn btn-warning" Text="Modificar" OnClick="btnModificar_Click" />
                    <asp:Button ID="btnEliminar" runat="server" CssClass="btn btn-danger" Text="Eliminar" OnClick="btnEliminar_Click" />
                    <asp:Button ID="btnCancelar" runat="server" CssClass="btn btn-secondary" Text="Volver" OnClick="btnCancelar_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
