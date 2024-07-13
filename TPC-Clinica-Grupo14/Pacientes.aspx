<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Pacientes.aspx.cs" Inherits="TPC_Clinica_Grupo14.Pacientes" ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="ColumnaLateral.css" rel="stylesheet" />

</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   

    <div class="container mt-5">
        <div class="row">
           <!-- Columna izquierda con los TextBoxes y Labels -->
            <div class="col-md-6">
                <div class="form-group">
                    <asp:TextBox ID="txtId" runat="server" CssClass="form-control" ReadOnly="true" Visible="false"></asp:TextBox>

                    <asp:Label ID="lblNombrePaciente" runat="server" AssociatedControlID="txtNombre" CssClass="form-label fw-bold">Nombre del Paciente</asp:Label>
                    <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>

                    <asp:Label ID="lblApellidoPaciente" runat="server" AssociatedControlID="txtApellido" CssClass="form-label fw-bold">Apellido del Paciente</asp:Label>
                    <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control"></asp:TextBox>

                    <asp:Label ID="lblFechaNacimientoPaciente" runat="server" AssociatedControlID="txtFechaNacimiento" CssClass="form-label fw-bold">Fecha de Nacimiento del Paciente</asp:Label>
                    <asp:TextBox ID="txtFechaNacimiento" runat="server" CssClass="form-control"></asp:TextBox>

                    <asp:Label ID="lblGeneroPaciente" runat="server" AssociatedControlID="txtGenero" CssClass="form-label fw-bold">Género del Paciente</asp:Label>
                    <asp:DropDownList ID="txtGenero" runat="server" CssClass="form-control">
                        <asp:ListItem Text="Masculino" Value="1"></asp:ListItem>
                        <asp:ListItem Text="Femenino" Value="2"></asp:ListItem>
                        <asp:ListItem Text="Otro" Value="3"></asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>

            <!-- Columna derecha con los TextBoxes y Labels  -->
            
            <div class="col-md-6">
                <div class="form-group">
                    <asp:Label ID="lblDNIPaciente" runat="server" AssociatedControlID="txtDNI" CssClass="form-label fw-bold">DNI del Paciente</asp:Label>
                    <asp:TextBox ID="txtDNI" runat="server" CssClass="form-control"></asp:TextBox>

                    <asp:Label ID="lblCorreoPaciente" runat="server" AssociatedControlID="txtCorreo" CssClass="form-label fw-bold">Correo del Paciente</asp:Label>
                    <asp:TextBox ID="txtCorreo" runat="server" CssClass="form-control"></asp:TextBox>

                    <asp:Label ID="lblTelefonoPaciente" runat="server" AssociatedControlID="txtTelefono" CssClass="form-label fw-bold">Telefono del Paciente</asp:Label>
                    <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control"></asp:TextBox>

                    <asp:Label ID="lblActivoPaciente" runat="server" AssociatedControlID="txtActivo" CssClass="form-label fw-bold">Paciente Activo ?</asp:Label>
                    <asp:DropDownList ID="txtActivo" runat="server" CssClass="form-control">
                        <asp:ListItem Text="Sí" Value="true"></asp:ListItem>
                        <asp:ListItem Text="No" Value="false"></asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
        </div>

        
        <!-- Botones del ABM -->

        <div class="row mt-3">
            <div class="col-md-12">
                <div class="d-flex justify-content-between">
                    <asp:Button ID="btnAgregar" runat="server" CssClass="btn btn-success" Text="Agregar" OnClick="btnAgregar_Click" />
                    <asp:Button ID="btnModificar" runat="server" CssClass="btn btn-warning" Text="Modificar" OnClick="btnModificar_Click" />
                    <asp:Button ID="btnEliminar" runat="server" CssClass="btn btn-danger" Text="Eliminar" OnClick="btnEliminar_Click" />
                    <asp:Button ID="btnCancelar" runat="server" CssClass="btn btn-secondary" Text="Cancelar" OnClick="btnCancelar_Click" />
                </div>
            </div>
        </div>

        <!-- Grilla donde van los datos seleccionados -->

        <div class="row mt-5">
            <div class="col-md-12">
                <div class="table-responsive">
                    <asp:GridView runat="server" ID="dgvPacientes" OnSelectedIndexChanged="dgvPacientes_SelectedIndexChanged" AutoGenerateColumns="False" DataKeyNames="ID" CssClass="table table-striped table-bordered table-dark grid-view" OnRowDataBound="dgvPacientes_RowDataBound">
                        <Columns>
                            <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                            <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
                            <asp:BoundField DataField="FechaNacimiento" HeaderText="Fecha de Nacimiento" />
                            <asp:BoundField DataField="IdGenero" HeaderText="Género" />
                            <asp:BoundField DataField="NumDoc" HeaderText="DNI" />
                            <asp:BoundField DataField="Correo" HeaderText="Correo" />
                            <asp:BoundField DataField="Telefono" HeaderText="Teléfono" />
                            <asp:CommandField ShowSelectButton="true" SelectText="Seleccionar" HeaderText="Acción" ControlStyle-CssClass="btn btn-sm btn-primary" />
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
