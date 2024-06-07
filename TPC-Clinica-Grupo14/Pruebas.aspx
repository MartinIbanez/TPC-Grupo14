<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Pruebas.aspx.cs" Inherits="TPC_Clinica_Grupo14.Pruebas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h1>Arrancan las pruebas....</h1>
        <asp:GridView runat="server" ID="GridPruebaRoles"></asp:GridView>
        <asp:GridView runat="server" ID="GridPruebaPersonas"></asp:GridView>
    </div>





</asp:Content>
