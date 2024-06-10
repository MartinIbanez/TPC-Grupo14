<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Pruebas.aspx.cs" Inherits="TPC_Clinica_Grupo14.Pruebas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h1>Arrancan las pruebas....</h1>
        <asp:DropDownList runat="server" ID="DropDownListEspecialidades" AutoPostBack="true" OnSelectedIndexChanged="DropDownListEspecialidades_SelectedIndexChanged"></asp:DropDownList>
        <asp:DropDownList runat="server" ID="DropDownListProfesionales"></asp:DropDownList>
        <br />
        <br />
        <asp:GridView runat="server" ID="GridPruebaRoles"></asp:GridView>
        <%--<asp:GridView runat="server" ID="GridPruebaPersonas"></asp:GridView>
        <asp:GridView runat="server" ID="GridPruebasEspecialidades"></asp:GridView>--%>
    </div>





</asp:Content>
