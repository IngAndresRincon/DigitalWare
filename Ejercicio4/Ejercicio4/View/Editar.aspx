<%@ Page Title="" Language="C#" MasterPageFile="~/View/Page.Master" AutoEventWireup="true" CodeBehind="Editar.aspx.cs" Inherits="Ejercicio4.View.Editar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    
     <div class="container align-content-center tablanotas">
         <div class="row align-content-center" style="margin:10px;width:100%">
             <div class="col col-lg-4">
                 <span>ALUMNO</span>
                 <asp:DropDownList ID="ddlAlumno" runat="server" CssClass="form-select" ></asp:DropDownList>
             </div>
             <div class="col col-lg-4"><span>PERIODO</span>
                 <asp:DropDownList ID="ddlPeriodo" runat="server" CssClass="form-select" ></asp:DropDownList>
             </div>
             <div class="col col-lg-4">
                 <p> <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btn btn-primary" OnClick="btnBuscar_Click"  AutoPostBack="true"/></p>
             </div>
         </div>
         <div class="row">

                <asp:GridView ID="GridViewNotas" runat="server" CssClass="align-content-center table table-dark table-hover" AutoGenerateColumns="False" OnRowDeleting="GridViewNotas_RowDeleting" OnRowCommand="GridViewNotas_RowCommand" >
                    <Columns>
                        <%--<asp:BoundField DataField="ALUMNO" HeaderText="ALUMNO" />--%>
                        <asp:BoundField DataField="MATERIA" HeaderText="MATERIA" />
                        <asp:BoundField DataField="NOTA" HeaderText="NOTA" />
                        <asp:BoundField DataField="PERIODO" HeaderText="PERIODO" />
                         <asp:TemplateField HeaderText="Nueva Nota">
                            <ItemTemplate>
                                <asp:TextBox ID="txtNuevaNota" runat="server"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Actualizar">
                            <ItemTemplate>
                                <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" CssClass=" btn btn-primary" CommandArgument='<%# Container.DataItemIndex  %>' CommandName="Actualizar"/>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:CommandField ButtonType="Button" ShowDeleteButton="True" ControlStyle-CssClass="btn btn-secondary" >
                        <ControlStyle CssClass="btn btn-secondary"></ControlStyle>
                        </asp:CommandField>
                       

                       
                    </Columns>
  
                </asp:GridView>
         </div>
        
    </div>




</asp:Content>
