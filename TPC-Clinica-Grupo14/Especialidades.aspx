<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Especialidades.aspx.cs" Inherits="TPC_Clinica_Grupo14.Especialidades" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

 <div class="container mt-5">
        <div class="row">
            <div class="col-md-8">
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

            <div class="col-md-4">
                <div class="card">
                    <div class="card-body">
                        <asp:TextBox ID="txtId" runat="server" CssClass="form-control" ReadOnly="true" Visible="false"></asp:TextBox>
                        <div class="form-group">
                            <asp:Label ID="lblNombreEspecialidad" runat="server" AssociatedControlID="txtNombre" CssClass="form-label fw-bold">Especialidad Seleccionada</asp:Label>
                            <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <asp:Button ID="btnAgregar" runat="server" CssClass="btn btn-success btn-block" Text="Agregar" OnClick="btnAgregar_Click" />
                        </div>
                        <div class="form-group">
                            <asp:Button ID="btnModificar" runat="server" CssClass="btn btn-warning btn-block" Text="Modificar" OnClick="btnModificar_Click" />
                        </div>
                        <div class="form-group">
                            <asp:Button ID="btnEliminar" runat="server" CssClass="btn btn-danger btn-block" Text="Eliminar" OnClick="btnEliminar_Click" />
                        </div>
                        <div class="form-group">
                            <asp:Button ID="btnCancelar" runat="server" CssClass="btn btn-secondary btn-block" Text="Cancelar" OnClick="btnCancelar_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>