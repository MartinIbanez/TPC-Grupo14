<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Pruebas.aspx.cs" Inherits="TPC_Clinica_Grupo14.Pruebas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <%--Necesario para el update panel--%>
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <h1>Arrancan las pruebas....</h1>
                <%--CADA DDL TIENE 2 EVENTOS: ONSELECTEDINDEXCHANGED y ONDATABOUND, este ultimo lo usamos para precargar los valores en las transiciones--%>
                <asp:DropDownList runat="server" ID="DropDownListEspecialidades" AutoPostBack="true" OnSelectedIndexChanged="DropDownListEspecialidades_SelectedIndexChanged" OnDataBound="DropDownListEspecialidades_DataBound"></asp:DropDownList>
                <asp:DropDownList runat="server" ID="DropDownListProfesionales" AutoPostBack="true" OnSelectedIndexChanged="DropDownListProfesionales_SelectedIndexChanged" OnDataBound="DropDownListProfesionales_DataBound"></asp:DropDownList>
                <asp:DropDownList runat="server" ID="DropDownListDia" AutoPostBack="true" OnSelectedIndexChanged="DropDownListDia_SelectedIndexChanged" OnDataBound="DropDownListEspecialidades_DataBound"></asp:DropDownList>
                <asp:DropDownList runat="server" ID="DropDownListHorariosDisponibles" AutoPostBack="true" OnSelectedIndexChanged="DropDownListHorariosDisponibles_SelectedIndexChanged" OnDataBound="DropDownListHorariosDisponibles_DataBound"></asp:DropDownList>
                <br />
                <br />
                <asp:GridView runat="server" ID="GridPruebaRoles"></asp:GridView>
                <%--<asp:GridView runat="server" ID="GridPruebaPersonas"></asp:GridView>
                <asp:GridView runat="server" ID="GridPruebasEspecialidades"></asp:GridView>--%>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>





</asp:Content>
