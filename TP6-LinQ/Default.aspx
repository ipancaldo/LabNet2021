<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TP6_LinQ._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <table class="table">
        <thead>
            <tr>
                <th scope="col">#</th>
                <th scope="col">Ejercicio</th>
                <th scope="col">Botón</th>
            </tr>
          </thead>
          <tbody>
            <tr>
                <td>1</td>
                <td>
                  <asp:Label Text="Objeto customer" runat="server" />
                </td>
                <td>
                    <asp:Button Text="Ejecutar" ID="btnObjetoCustomer" OnClick="btnObjetoCustomer_Click" runat="server" />
                </td>
            </tr>
            <tr>
                <td>2</td>
                <td>Todos los productos sin stock</td>
                <td>
                    <asp:Button Text="Ejecutar" ID="btnProductosSinStock" OnClick="btnProductosSinStock_Click" runat="server" />
                </td>
            </tr>
            <tr>
                <td>3</td>
                <td>Productos que tienen stock y que cuestan más de 3 por unidad</td>
                <td>
                    <asp:Button Text="Ejecutar" ID="btnStockMasTresUnidad" OnClick="btnStockMasTresUnidad_Click" runat="server" />
                </td>
            </tr>            
            <tr>
                <td>4</td>
                <td>Customers de Washington</td>
                <td>
                    <asp:Button Text="Ejecutar" ID="btnCustomersWashington" OnClick="btnCustomersWashington_Click" runat="server" />
                </td>
            </tr>            
            <tr>
                <td>5</td>
                <td>Primer elemento o nulo de una lista de productos donde el ID de producto sea igual a 789.</td>
                <td>
                    <asp:Button Text="Ejecutar" ID="btnPrimerONulo789" OnClick="btnPrimerONulo789_Click" runat="server" />   
                </td>
            </tr>            
            <tr>
                <td>6</td>
                <td>Nombre de los Customers. Mostrarlos en Mayuscula y en Minuscula.</td>
                <td>
                    <asp:Button Text="Ejecutar" ID="btnNombresMayMin" OnClick="btnNombresMayMin_Click" runat="server" /> 
                </td>
            </tr>            
            <tr>
                <td>7</td>
                <td>Customers y Orders donde los customers sean de Washington y la fecha de orden sea mayor a 1/1/1997.</td>
                <td>
                    <asp:Button Text="Ejecutar" ID="Button1" OnClick="btnCustomersOrderW1197_Click" runat="server" />
                </td>
            </tr>            
            <tr>
                <td>8</td>
                <td>Primeros 3 Customers de Washington.</td>
                <td>
                    <asp:Button Text="Ejecutar" ID="btnFirst3WA" OnClick="btnFirst3WA_Click" runat="server" />
                </td>
            </tr>            
            <tr>
                <td>9</td>
                <td>Productos ordenados por nombre.</td>
                <td>
                    <asp:Button Text="Ejecutar" ID="btnProductosOrd" OnClick="btnProductosOrd_Click" runat="server" />
                </td>
            </tr>           
            <tr>
                <td>10</td>
                <td>Productos ordenados por unit in stock de mayor a menor.</td>
                <td>
                    <asp:Button Text="Ejecutar" ID="btnStockMayorMenor" OnClick="btnStockMayorMenor_Click" runat="server" />
                </td>
            </tr>            
            <tr>
                <td>11</td>
                <td>Distintas categorías asociadas a los productos.</td>
                <td>
                    <asp:Button Text="Ejecutar" ID="btnCategoriasProductos" OnClick="btnCategoriasProductos_Click" runat="server" />  
                </td>
            </tr>            
            <tr>
                <td>12</td>
                <td>Primer elemento de una lista de productos.</td>
                <td>
                    <asp:Button Text="Ejecutar" ID="btnPrimerProducto" OnClick="btnPrimerProducto_Click" runat="server" />
                </td>
            </tr>            
              <tr>
                <td>13</td>
                <td>Customer con la cantidad de ordenes asociadas.</td>
                <td>
                    <asp:Button Text="Ejecutar" ID="btnCustomerOrders" OnClick="btnCustomerOrders_Click" runat="server" />
                </td>
            </tr>
          </tbody>
        </table>


    <br />
    <asp:Label Text="" ID="lblError" class="text-danger" runat="server" />

    <%-- Products GRID --%>
    <div class="row">
        <div class="col-md-12">
            <asp:GridView Id="gridProductList" runat="server" HorizontalAlign="Center"
                CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="false">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />

                <Columns>
                    <asp:BoundField DataField="ProductID" HeaderText="ID" ItemStyle-Width="5%"/>
                    <asp:BoundField DataField="ProductName" HeaderText="Nombre producto" ItemStyle-Width="40%"/>
                    <asp:BoundField DataField="QuantityPerUnit" HeaderText="Cantidad por unidad" ItemStyle-Width="30%"/>
                    <asp:BoundField DataField="UnitsInStock" HeaderText="Unidades stock" />
                    <asp:BoundField DataField="UnitPrice" HeaderText="Precio" DataFormatString="{0:n2}" ItemStyle-Width="10%"/>
                </Columns>

                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"/>
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"/>
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center"/>
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333"/>
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="False" ForeColor="#333333"/>
                <SortedAscendingCellStyle BackColor="#E9E7E2"/>
                <SortedAscendingHeaderStyle BackColor="#506C8C"/>
                <SortedDescendingCellStyle BackColor="#FFFDF8"/>
                <SortedDescendingHeaderStyle BackColor="#6F8DAE"/>
            </asp:GridView>
        </div>
    </div>
    

    <%-- Customers GRID --%>
    <div>
        <asp:GridView ID="gridCustomerList" runat="server"  HorizontalAlign="Center"
            CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="false">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />

            <Columns>
                <asp:BoundField DataField="CustomerID" HeaderText="ID" ItemStyle-Width="10%"/>
                <asp:BoundField DataField="CompanyName" HeaderText="Compañia"/>
                <asp:BoundField DataField="ContactName" HeaderText="Nombre" ItemStyle-Width="30%"/>
                <asp:BoundField DataField="Phone" HeaderText="Telefono" ItemStyle-Width="10%"/>
            </Columns>

            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"/>
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"/>
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center"/>
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333"/>
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="False" ForeColor="#333333"/>
            <SortedAscendingCellStyle BackColor="#E9E7E2"/>
            <SortedAscendingHeaderStyle BackColor="#506C8C"/>
            <SortedDescendingCellStyle BackColor="#FFFDF8"/>
            <SortedDescendingHeaderStyle BackColor="#6F8DAE"/>
        </asp:GridView>
    </div>

    <%-- Customers GRID NAMES --%>

    <div class="row">
        <div class="col-md-4">
            <asp:GridView Id="gridCustomerListNames1" runat="server"  HorizontalAlign="Center"
                CellPadding="4" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="WhiteSmoke" ForeColor="#284775" />
            </asp:GridView>
        </div>

        <div class="col-md-4">
            <asp:GridView Id="gridCustomerListNames2" runat="server"  HorizontalAlign="Center"
                CellPadding="4" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="WhiteSmoke" ForeColor="#284775" />
            </asp:GridView>
        </div>
    </div>




    <%--Join COSTUMER and ORDER--%>
    <div>
        <asp:GridView Id="gridJoinCustomerOrders" runat="server"  HorizontalAlign="Center"
            CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="false">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />

            <Columns>
                <asp:BoundField DataField="CustomerID" HeaderText="ID" ItemStyle-Width="10%"/>
                <asp:BoundField DataField="ContactName" HeaderText="Nombre" ItemStyle-Width="10%"/>
                <asp:BoundField DataField="City" HeaderText="Ciudad" ItemStyle-Width="10%"/>
                <asp:BoundField DataField="OrderID" HeaderText="Orden" ItemStyle-Width="10%"/>
                <asp:BoundField DataField="OrderDate" HeaderText="Fecha" DataFormatString="{0:d}" ItemStyle-Width="10%"/>
            </Columns>            
           
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"/>
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"/>
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center"/>
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333"/>
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="False" ForeColor="#333333"/>
            <SortedAscendingCellStyle BackColor="#E9E7E2"/>
            <SortedAscendingHeaderStyle BackColor="#506C8C"/>
            <SortedDescendingCellStyle BackColor="#FFFDF8"/>
            <SortedDescendingHeaderStyle BackColor="#6F8DAE"/>
        </asp:GridView>
    </div>


    <%--Join CATEGORIES and PRODUCTS--%>
    <div>
        <asp:GridView Id="gridCategoriasProductos" runat="server"  HorizontalAlign="Center"
            CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="false">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />

            <Columns>
                <asp:BoundField DataField="CategoryID" HeaderText="ID" ItemStyle-Width="1%"/>
                <asp:BoundField DataField="CategoryName" HeaderText="Categoría" ItemStyle-Width="5%"/>
                <asp:BoundField DataField="Description" HeaderText="Descripción" ItemStyle-Width="15%"/>
                <asp:BoundField DataField="ProductID" HeaderText="ID Producto" ItemStyle-Width="3%"/>
                <asp:BoundField DataField="ProductName" HeaderText="Nombre producto" ItemStyle-Width="10%"/>
            </Columns>            
           
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"/>
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"/>
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center"/>
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333"/>
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="False" ForeColor="#333333"/>
            <SortedAscendingCellStyle BackColor="#E9E7E2"/>
            <SortedAscendingHeaderStyle BackColor="#506C8C"/>
            <SortedDescendingCellStyle BackColor="#FFFDF8"/>
            <SortedDescendingHeaderStyle BackColor="#6F8DAE"/>
        </asp:GridView>
    </div>

    <%--Join CUSTOMERS and ORDERS--%>
    <div>
        <asp:GridView Id="gridCustomersOrders" runat="server"  HorizontalAlign="Center"
            CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="false">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />

            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" ItemStyle-Width="2%"/>
                <asp:BoundField DataField="ContactName" HeaderText="Nombre" ItemStyle-Width="2%"/>
                <asp:BoundField DataField="Contador" HeaderText="Cantidad ordenes" ItemStyle-Width="5%"/>
            </Columns>            
           
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"/>
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"/>
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center"/>
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333"/>
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="False" ForeColor="#333333"/>
            <SortedAscendingCellStyle BackColor="#E9E7E2"/>
            <SortedAscendingHeaderStyle BackColor="#506C8C"/>
            <SortedDescendingCellStyle BackColor="#FFFDF8"/>
            <SortedDescendingHeaderStyle BackColor="#6F8DAE"/>
        </asp:GridView>
    </div>


</asp:Content>
