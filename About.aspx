<%@ Page Title="Productos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="proyect_one.About" EnableEventValidation="false" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Ingreso de Productos</h3>


    <asp:Label runat="server" ID="lblNotification"  Visible="false">
    </asp:Label>

    <div class="jumbotron">
    <div class="p-3">
        <section runat="server" id="divsec"  CssClass="p-5">
            <asp:TextBox ID="txtId" runat="server" CssClass="form-control" Visible="false"></asp:TextBox>
            <label class="form-label">Codigo</label>
            <asp:TextBox ID="txtCodigo" runat="server" CssClass="form-control"></asp:TextBox>
            <label class="form-label">Producto</label>
            <asp:TextBox ID="txtProducto" runat="server" CssClass="form-control"></asp:TextBox>
            <label class="form-label">Precio</label>
            <asp:TextBox ID="txtPrecio" runat="server" CssClass="form-control"></asp:TextBox>
            <br />
            <asp:Button runat="server" CssClass="btn btn-success" Text="Ingresar" ID="btnInsert" OnClick="btnInsert_Click" />
            <asp:Button runat="server" CssClass="btn btn-primary" Text="Editar" ID="btnUpdate" OnClick="btnUpdate_Click" />
            <asp:Button runat="server" CssClass="btn btn-danger" Text="Cancelar" ID="btnCancel" OnClick="btnCancel_Click" />
            </section>
    </div>
    </div>
    

    <asp:GridView ID="gridview1" CssClass="table table-striped" runat="server" AutoGenerateColumns="False" DataKeyNames="idProducto" 
        OnRowDeleting="gridview1_RowDeleting" OnSelectedIndexChanged="gridview1_SelectedIndexChanged" >
        <Columns>
            <asp:BoundField DataField="idProducto" HeaderText="Id" ReadOnly="true"  />
            <asp:BoundField DataField="Codigo" HeaderText="Codigo" />
            <asp:BoundField DataField="Producto" HeaderText="Producto" />
            <asp:BoundField DataField="Precio" HeaderText="Precio" />
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                <asp:LinkButton runat="server" ID="edit" CommandName="select" Text="Editar" CssClass="btn btn-warning"  ></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
            <ItemTemplate>
                <asp:LinkButton runat="server" Text="Eliminar" CommandName="delete" CssClass="btn btn-danger"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>


 
</asp:Content>
