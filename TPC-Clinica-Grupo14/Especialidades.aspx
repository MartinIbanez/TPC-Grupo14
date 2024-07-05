<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Especialidades.aspx.cs" Inherits="TPC_Clinica_Grupo14.Especialidades" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="COlumnaLateral.css" rel="stylesheet" />

  

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="main">
        <div class="sidebar">
            <a class="nav-link" href="Especialidades.aspx">ESPECIALIDADES</a>
            <a class="nav-link" href="Turnos.aspx">TURNOS</a>
            <a class="nav-link" href="Pacientes.aspx">PACIENTES</a>
            <a class="nav-link" href="Medicos.aspx">MEDICOS</a>
            <%--ESTO DE ACA ARRIBA DEBERIA IR EN LA MASTER????--%>
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