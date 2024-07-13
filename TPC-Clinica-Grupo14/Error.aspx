<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="TPC_Clinica_Grupo14.Error" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1></h1>
    

<div class="alert alert-danger" role="alert" >
  HUBO UN PROBLEMA! Debes loguearte para poder ingresar al sitio. <a href="Login.aspx" class="alert-link">Haz click aquí para INGRESAR </a>
</div>


    <asp:Label Text="" ID="lblMensaje" runat="server" />

</asp:Content>
