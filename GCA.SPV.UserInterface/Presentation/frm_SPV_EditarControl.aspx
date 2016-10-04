<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/frm_SPV_MasterPageSupervisor.Master" CodeBehind="frm_SPV_EditarControl.aspx.vb" Inherits="GCA.SPV.UserInterface.frm_SPV_EditarControl" %>
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
                <li>
                    <a href="frm_SPV_CrearControl.aspx"><i class="fa fa-table "></i>Crear control</a>
                </li>
                <li>
                    <a href="frm_SPV_AsignarControl.aspx"><i class="fa fa-edit "></i>Asignar control</a>
                </li>
                <li class="active-link">
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
<asp:Content ID="Content3" ContentPlaceHolderID="titulo" runat="server">Editar Control</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Body" runat="server">
    <form class="form-horizontal">
        <div class="form-group">
            <label class="control-label col-sm-2" for="txtLugar">Lugar:</label>
            <div class="col-sm-10">
                <asp:TextBox ID="txtLugar" TextMode="SingleLine" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="form-group">
            <label class="control-label col-sm-2" for="txtOficina">Oficina:</label>
            <div class="col-sm-10">
                <asp:TextBox ID="txtOficina" TextMode="SingleLine" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="form-group">
            <label class="control-label col-sm-2" for="txtControl">Control:</label>
            <div class="col-sm-10">
                <asp:TextBox ID="txtControl" TextMode="SingleLine" runat="server"></asp:TextBox>
            </div>
        </div>
    </form>
</asp:Content>
