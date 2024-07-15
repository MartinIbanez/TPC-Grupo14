<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Medicos.aspx.cs" Inherits="TPC_Clinica_Grupo14.Medicos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="COlumnaLateral.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="COlumnaLateral.css" rel="stylesheet" />

    <div class="container mt-5">
        <!-- Título central -->
        <div class="row">
            <div class="col-md-12 text-center">
                <h2 class="fw-bold">Lista de Médicos</h2>
            </div>
        </div>

        <!-- Fila con la grilla -->
        <div class="row mt-5">
            <div class="col-md-12">
                <div class="table-responsive">
                    <asp:Button ID="btnAgregar" runat="server" CssClass="btn btn-success" Text="Agregar Nuevo Profesional" OnClick="btnAgregar_Click" />
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
    </div>
</asp:Content>
