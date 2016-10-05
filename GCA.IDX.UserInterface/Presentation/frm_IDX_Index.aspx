<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/frm_IDX_MasterPageIndex.Master" CodeBehind="frm_IDX_Index.aspx.vb" Inherits="GCA.IDX.UserInterface.frm_IDX_Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="titulo" runat="server">
    <h2>Inicio de sesión</h2>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Body" runat="server">
    <form class="form-horizontal">
        <div style="margin-left: 38%;">
            <div class="form-group">
                <label class="control-label col-xs-2 center-block" for="txtID">ID:</label>
                <div class="col-xs-9">
                    <asp:TextBox ID="txtID" TextMode="Number" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <label class="control-label col-xs-2" for="txtContrasenna">Contraseña:</label>
                <div class="col-xs-9">
                    <asp:TextBox ID="txtContrasenna" TextMode="Password" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
              <div class="col-sm-offset-2 col-sm-10">
                  <asp:Button ID="btnIngresar" runat="server" Text="Ingresar" />
              </div>
            </div>
        </div>
    </form>
</asp:Content>
