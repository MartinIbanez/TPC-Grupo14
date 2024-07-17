<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="TurnosAsignados.aspx.cs" Inherits="TPC_Clinica_Grupo14.TurnosAsignados" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <%--Necesario para el update panel--%>
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <div class="container">
                    <div class="row ">
                        <div class="col">
                            <asp:DropDownList runat="server" ID="DropDownListProfesionales" AutoPostBack="true" OnSelectedIndexChanged="DropDownListProfesionales_SelectedIndexChanged" CssClass="btn btn-secondary dropdown-toggle" role="button" data-bs-toggle="dropdown"></asp:DropDownList>
                            <br />
                            <asp:Label ID="lblProfNoDisp" Text="PROFESIONAL SIN TURNOS ASIGNADOS" Visible="false" runat="server" />
                            <br />
                            <br />
                        </div>
                        <div class="col">
                            <asp:Repeater ID="Repeater1" Visible="false" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td><%# Eval("Id") %></td>
                                        <td><%# Eval("FechaTurno") %></td>
                                        <td><%# Eval("HoraTurno") %> : 00 </td>
                                        <td><%# Eval("ProfesionalTurno.Nombre") %></td>
                                        <td><%# Eval("EspecialidadTurno.Nombre") %></td>
                                        <td><%#Eval("PacienteTurno.Nombre") %></td>
                                        <br />
                                        <%--<td>
                                            <div>
                                                <asp:Label Text='<%#Eval("Id") %>' runat="server" ID="Label0" class="display-8" />
                                                <br />
                                                <br />
                                                <asp:Label Text='<%#Eval("FechaTurno") %>' runat="server" ID="Label1" class="display-8" />
                                                <br />
                                                <br />
                                                <asp:Label Text='<%#Eval("ProfesionalTurno.Nombre") %>' runat="server" ID="Label2" class="display-8" />
                                                <br />
                                                <br />
                                                <asp:Label Text='<%#Eval("EspecialidadTurno.Nombre") %>' runat="server" ID="Label3" class="display-8" />
                                                <br />
                                                <br />
                                                <asp:Label Text='<%#Eval("PacienteTurno.Nombre") %>' runat="server" ID="Label4" class="display-8" />
                                            </div>
                                        </td>--%>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                    </div>
                </div>
                <%--aca terminan las 4 columnas--%>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
