<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TPC_Clinica_Grupo14.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="mb-3">
        <label for="txtEmail" class="form-label">Email / Usuario</label>
        <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" />
    </div>


    <div class="mb-3">
        <label for="txtPassword" class="form-label">Contraseña</label>
        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control" />
    </div>

    <div class="mb-3 form-check">
        <asp:CheckBox ID="chkNotRobot" runat="server" CssClass="form-check-input" />
        <label class="form-check-label" for="chkNotRobot">No soy robot</label>
    </div>


    <asp:Button ID="btnLogin" runat="server" Text="Entrar" CssClass="btn btn-primary" OnClick="btnLogin_Click" />


    <asp:Label ID="lblMessage" runat="server" CssClass="form-text"></asp:Label>
 
</asp:Content>
