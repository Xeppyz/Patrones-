<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WfBridgee.aspx.cs" Inherits="Mediator.WfBridgee" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">





    <br />
    <asp:TextBox ID="txtID" runat="server"></asp:TextBox>
    <br />
    <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
    <br />
    <asp:TextBox ID="txtEdad" runat="server"></asp:TextBox>
    <br />
    <asp:TextBox ID="txtMateria" runat="server"></asp:TextBox>
    <br />
    <asp:Button ID="BtnAgregar" runat="server" Text="Agregar" OnClick="BtnAgregar_Click1" />
    <asp:Button ID="BtnEliminar" runat="server" Text="Eliminar" />
    <asp:Button ID="BtnActualizar" runat="server" Text="Actualizar" />
    <asp:Button ID="BtnLimpiar" runat="server" Text="Limpiar" OnClick="BtnLimpiar_Click1" />
    <asp:Button ID="BtnMostrar" runat="server" Style="margin-top: 11px" Text="Mostrar" OnClick="BtnMostrar_Click1" />
    <br />
    <asp:Label ID="lblResultado" runat="server" ></asp:Label>
    <br />
    <asp:Label ID="LabelMensaje" runat="server" ></asp:Label>
    <br />
    <asp:Label ID="LabelExcel" runat="server" ></asp:Label>
    <br />
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:NeoTechPatronesConnectionString %>" SelectCommand="SELECT * FROM [persona]" DeleteCommand="DELETE FROM [persona] WHERE [id] = @id" InsertCommand="INSERT INTO [persona] ([nombre], [edad], [materia]) VALUES (@nombre, @edad, @materia)" UpdateCommand="UPDATE [persona] SET [nombre] = @nombre, [edad] = @edad, [materia] = @materia WHERE [id] = @id">
        <DeleteParameters>
            <asp:Parameter Name="id" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="nombre" Type="String" />
            <asp:Parameter Name="edad" Type="String" />
            <asp:Parameter Name="materia" Type="String" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="nombre" Type="String" />
            <asp:Parameter Name="edad" Type="String" />
            <asp:Parameter Name="materia" Type="String" />
            <asp:Parameter Name="id" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="SqlDataSource1" AllowPaging="True" AllowSorting="True" OnSelectedIndexChanged="GridView1_SelectedIndexChanged1">
        <Columns>
            <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" ShowSelectButton="True" />
            <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id" />
            <asp:BoundField DataField="nombre" HeaderText="nombre" SortExpression="nombre" />
            <asp:BoundField DataField="edad" HeaderText="edad" SortExpression="edad" />
            <asp:BoundField DataField="materia" HeaderText="materia" SortExpression="materia" />
        </Columns>
    </asp:GridView>






</asp:Content>
