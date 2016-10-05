<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/frm_SPV_MasterPageSupervisor.Master" CodeBehind="frm_SPV_CrearControl.aspx.vb" Inherits="GCA.SPV.UserInterface.frm_SPV_CrearControl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="menu" runat="server">
    <!-- /. NAV TOP  -->
    <nav class="navbar-default navbar-side" role="navigation">
        <div class="sidebar-collapse">
            <ul class="nav" id="main-menu">
                <li>
                    <a href="frm_SPV_ConEstadoDeControles.aspx"><i class="fa fa-desktop"></i>Estado de los controles</a>
                </li>
                <li class="active-link">
                    <a href="frm_SPV_CrearControl.aspx"><i class="fa fa-table "></i>Crear control</a>
                </li>
                <li>
                    <a href="frm_SPV_AsignarControl.aspx"><i class="fa fa-edit "></i>Asignar control</a>
                </li>
                <li>
                    <a href="frm_SPV_EditarControl.aspx"><i class="fa fa-qrcode "></i>Editar control</a>
                </li>
                <li>
                    <a href="frm_SPV_ConGenerarReporte.aspx"><i class="fa fa-bar-chart-o"></i>Generar reportes</a>
                </li>
                <li>
                    <a href="#"><i class="fa fa-edit "></i>Ayuda</a>
                </li>
                <li>
                    <a href="#"><i class="fa fa-table "></i>Salir</a>
                </li>
            </ul>
        </div>
    </nav>
    <!-- /. NAV SIDE  -->
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="titulo" runat="server">Crear Control</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Body" runat="server">
    <form class="form-horizontal">
        <div class="form-group">
            <label class="control-label col-xs-3" for="txtCodigo">Código:</label>
            <div class="col-xs-9">
                <asp:TextBox ID="txtCodigo" TextMode="Number" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="form-group">
            <label class="control-label col-xs-3" for="txtNombreControl">Nombre:</label>
            <div class="col-xs-9">
                <asp:TextBox ID="txtNombreControl" TextMode="SingleLine" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="col-md-12">
            <h3>Períodicidad</h3>
        </div>
        <div class="form-group">
            <label class="control-label col-xs-3" for="ddlPeriodicidad">Días/Anual/Mensual:</label>
            <div class="col-xs-9">
                <asp:DropDownList ID="ddlPeriodicidad" runat="server">
                    <asp:ListItem Value="0">Seleccione</asp:ListItem>
                    <asp:ListItem>Diario</asp:ListItem>
                    <asp:ListItem>Semanal</asp:ListItem>
                    <asp:ListItem>Mensual</asp:ListItem>
                    <asp:ListItem>Anual</asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
        <div class="form-group" style="padding-top: 4%;">
            <label class="control-label col-xs-3">F. Inicial:</label>
            <div class="col-xs-3">
                <select class="form-control">
                    <option>Dia</option>
                </select>
            </div>
            <div class="col-xs-3">
                <select class="form-control">
                    <option>Mes</option>
                </select>
            </div>
            <div class="col-xs-3">
                <select class="form-control">
                    <option>Año</option>
                </select>
            </div>
        </div>
        <div class="form-group">
            <label class="control-label col-xs-3">F. Final:</label>
            <div class="col-xs-3">
                <select class="form-control">
                    <option>Dia</option>
                </select>
            </div>
            <div class="col-xs-3">
                <select class="form-control">
                    <option>Mes</option>
                </select>
            </div>
            <div class="col-xs-3">
                <select class="form-control">
                    <option>Año</option>
                </select>
            </div>
        </div>
    </form>
</asp:Content>