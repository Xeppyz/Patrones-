<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Mediator._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

   <div id="form1" runat="server">
        <div>
            <asp:Label runat="server" AssociatedControlID="txtNombre">ID:</asp:Label>
            <asp:TextBox runat="server" ID="txtId"></asp:TextBox>
            <br />
            <asp:Label runat="server" AssociatedControlID="txtNombre">Nombre:</asp:Label>
            <asp:TextBox runat="server" ID="txtNombre"></asp:TextBox>
            <br />
            <asp:Label runat="server" AssociatedControlID="txtDireccion">Dirección:</asp:Label>
            <asp:TextBox runat="server" ID="txtDireccion"></asp:TextBox>
            <br />
            <asp:Label runat="server" AssociatedControlID="txtCorreo">Correo:</asp:Label>
            <asp:TextBox runat="server" ID="txtCorreo"></asp:TextBox>
            <br />
            <asp:Label runat="server" AssociatedControlID="txtTelefono">Teléfono:</asp:Label>
            <asp:TextBox runat="server" ID="txtTelefono"></asp:TextBox>
            <br />
            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
            <br />
            <asp:Button ID="Button1" runat="server" Text="Guardar" OnClick="Button1_Click" />
            <br />
            <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
            <br />
            <asp:Button ID="Button2" runat="server" Text="Limpiar campos" OnClick="Button2_Click" />
        </div>

        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:MediadorConnectionString %>" DeleteCommand="DELETE FROM [docente] WHERE [id] = @id" InsertCommand="INSERT INTO [docente] ([nombre], [direccion], [correo], [telefono]) VALUES (@nombre, @direccion, @correo, @telefono)" SelectCommand="SELECT * FROM [docente]" UpdateCommand="UPDATE [docente] SET [nombre] = @nombre, [direccion] = @direccion, [correo] = @correo, [telefono] = @telefono WHERE [id] = @id">
            <DeleteParameters>
                <asp:Parameter Name="id" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="nombre" Type="String" />
                <asp:Parameter Name="direccion" Type="String" />
                <asp:Parameter Name="correo" Type="String" />
                <asp:Parameter Name="telefono" Type="String" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="nombre" Type="String" />
                <asp:Parameter Name="direccion" Type="String" />
                <asp:Parameter Name="correo" Type="String" />
                <asp:Parameter Name="telefono" Type="String" />
                <asp:Parameter Name="id" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>

       <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" AllowPaging="True" AllowSorting="True" DataKeyNames="id" DataSourceID="SqlDataSource1" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
           <Columns>
               <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" ShowSelectButton="True" />
               <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id" />
               <asp:BoundField DataField="nombre" HeaderText="nombre" SortExpression="nombre" />
               <asp:BoundField DataField="direccion" HeaderText="direccion" SortExpression="direccion" />
               <asp:BoundField DataField="correo" HeaderText="correo" SortExpression="correo" />
               <asp:BoundField DataField="telefono" HeaderText="telefono" SortExpression="telefono" />
           </Columns>
       </asp:GridView>
    </div>

</asp:Content>
