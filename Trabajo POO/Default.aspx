<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Trabajo_POO._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label Text="" ID="modificaciones" runat="server" />
    <br />

    <div>
        <h3>Avión</h3>
        <asp:Label Text="Ingrese cantidad de pasajeros y seleccione el módo de transporte" runat="server" />
        <asp:TextBox ID="cantPasajeros" class="form-control" Width="300px" runat="server" />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                            ControlToValidate="cantPasajeros" class="text-danger" ErrorMessage="Debe ingresar un número."></asp:RequiredFieldValidator>
        <asp:RangeValidator ID="RangeValidator1" runat="server"
                            ControlToValidate="cantPasajeros" class="text-danger" ErrorMessage="Debe ser un entero mayor a 0." MaximumValue="999"
                            MinimumValue="1" Type="Integer"></asp:RangeValidator>
        <br />
        <asp:Button ID="btnAceptarAvion" onclick="btnAceptarAvion_Click" Text="Avión" runat="server" />
        <asp:Button ID="btnAceptarAuto" onclick="btnAceptarAuto_Click" Text="Automóvil" runat="server" />
    </div>
    <br />
    <div>
        <asp:Label Text="Aviones actuales: " id="lblAviones" runat="server" />
        <br />
        <asp:Label Text="Automóviles actuales: " ID="lblAutos" runat="server" />
    </div>

    <br />




    <section class="contenedor-general container">
        <div class="row justify-content-center">
            <div class="col-lg-4 col-md-3 col-12">
                <h4>Mostrar resumen de transportes</h4>
                <asp:Button Text="Visualizar vehículos" id="btnVisualizar" onclick="btnVisualizar_Click" runat="server" />
                
                <br />
                <br />

                <asp:ListBox id="listTransportes" Width="85px" Rows="10" SelectionMode="Single" runat="server"></asp:ListBox>
                <br />
                <asp:Button ID="btnSeleccionar"  Text="Mostrar todos los datos" OnClick="btnSeleccionar_Click" runat="server" />
            </div>
            <div class="col-lg-4 col-md-3 col-12">
                🚗 <asp:Label Text="" id="lblSeleccionAuto" runat="server" />
                <br />
                ✈ <asp:Label Text="" id="lblSeleccionAvion" runat="server" />
                <br />
                <asp:Label Text="Click para comenzar a mover el vehículo" runat="server" />
                <asp:Button Text="Arrancar vehículo!" ID="btnArrancar" OnClick="btnArrancar_Click" runat="server" />
                <asp:Button Text="Detener vehículo!" ID="btnDetener" OnClick="btnDetener_Click" runat="server" />
            </div>
        </div>
    </section>




</asp:Content>
