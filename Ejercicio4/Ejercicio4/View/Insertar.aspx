<%@ Page Title="" Language="C#" MasterPageFile="~/View/Page.Master" AutoEventWireup="true" CodeBehind="Insertar.aspx.cs" Inherits="Ejercicio4.Insertar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    
    
     <div class="container align-content-center tablanotas">

         <div class="row align-content-center" style="margin:10px;width:100%">
             <div class="col col-lg-3">
                 <span>Alumno</span>
             </div>
             <div class="col col-lg-3">
                 <span>Materia</span>
             </div>
             <div class="col col-lg-3">
                 <span>Perido</span>
             </div>
             <div class="col col-lg-3">
                 <span>Nota</span>
             </div>
         </div>

         <div class="row align-content-center" style="margin:10px;width:100%">
             <div class="col col-lg-3">                 
                 <asp:DropDownList ID="ddlAlumno" runat="server" CssClass="form-select" ></asp:DropDownList>
             </div>
             <div class="col col-lg-3">
                 <asp:DropDownList ID="ddlMateria" runat="server" CssClass="form-select"></asp:DropDownList>
             </div>
             <div class="col col-lg-3">
                 <asp:DropDownList ID="ddlPeriodo" runat="server" CssClass="form-select" ></asp:DropDownList>                 
             </div>
             <div class="col col-lg-3">
                 <asp:TextBox ID="txtNota" runat="server" CssClass="form-control"></asp:TextBox>
             </div>
         </div>

         <div class="row" style="width:100%">
             <asp:Button ID="btnIngresar" runat="server" Text="Insertar" CssClass="btn btn-success" Width="100%" OnClick="btnIngresar_Click"/>
         </div>
         
    </div>


</asp:Content>
