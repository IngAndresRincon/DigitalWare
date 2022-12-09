<%@ Page Title="" Language="C#" MasterPageFile="~/View/Page.Master" AutoEventWireup="true" CodeBehind="Consultar.aspx.cs" Inherits="Ejercicio4.View.Consultar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <div class="container align-content-center tablanotas">
         <div class="row align-content-center" style="margin:10px;width:50%">
             <div class="col col-lg-6"><span>Alumnos</span></div>
             <div class="col col-lg-6">
                 <asp:DropDownList ID="ddlAlumno" runat="server" CssClass="form-select" OnSelectedIndexChanged="ddlAlumno_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
             </div>
         </div>
         <div class="row">

                <asp:GridView ID="GridViewNotas" runat="server" CssClass="align-content-center table table-dark table-hover" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField DataField="ALUMNO" HeaderText="ALUMNO" />
                        <asp:BoundField DataField="MATERIA" HeaderText="MATERIA" />
                        <asp:BoundField DataField="NOTA" HeaderText="NOTA" />
                        <asp:BoundField DataField="PERIODO" HeaderText="PERIODO" />
                    </Columns>
                </asp:GridView>
         </div>
        
    </div>


</asp:Content>
