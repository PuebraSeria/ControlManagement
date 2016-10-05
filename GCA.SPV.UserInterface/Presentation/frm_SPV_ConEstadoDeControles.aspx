<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/frm_SPV_MasterPageSupervisor.Master" CodeBehind="frm_SPV_ConEstadoDeControles.aspx.vb" Inherits="GCA.SPV.UserInterface.frm_SPV_ConEstadoDeControles" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="titulo" runat="server">
    <h2>Estado de los Controles</h2>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="menu" runat="server">
    <!-- /. NAV TOP  -->
    <nav class="navbar-default navbar-side" role="navigation">
        <div class="sidebar-collapse">
            <ul class="nav" id="main-menu">
                <li class="active-link">
                    <a href="frm_SPV_ConEstadoDeControles.aspx"><i class="fa fa-desktop "></i>Estado de los controles</a>
                </li>
                <li>
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
<asp:Content ID="Content4" ContentPlaceHolderID="Body" runat="server">
    <script src="../DESARROLLO/highCharts/jquery.js"></script>
    <script src="../DESARROLLO/highCharts/highcharts.js"></script>
    <script src="../DESARROLLO/highCharts/exporting.js"></script>    
    <div id="container" style="width: 100%;"></div>
    <script src="../DESARROLLO/Graficos/graficoEstadoControles.js"></script>
    

</asp:Content>
