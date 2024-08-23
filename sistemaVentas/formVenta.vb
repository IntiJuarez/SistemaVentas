Imports capaDatos
Imports capaNegocio

Public Class formVenta

    Private serivicioProducto As New servicioProducto()
    Private servicioCliente As New servicioCliente()
    Private servicioVenta As New servicioVenta()
    Private servicioVentaItem As New servicioVentaItem()

    Private Sub productosComboBox()
        Dim listaProductos As List(Of Productos) = serivicioProducto.obtenerTodo()
        cbxProducto.DataSource = listaProductos
        cbxProducto.DisplayMember = "Nombre"
        cbxProducto.ValueMember = "ID"
    End Sub
    Private Sub clientesComboBox()
        Dim listaClientes As List(Of Clientes) = servicioCliente.obtenerDatos()
        cbxCliente.DataSource = listaClientes
        cbxCliente.DisplayMember = "Cliente"
        cbxCliente.ValueMember = "ID"
    End Sub

    Private Sub columnasDgv()
        dvgProductos.Columns.Clear()

        dvgProductos.Columns.Add("IDProducto", "ID Producto")
        dvgProductos.Columns.Add("Nombre", "Producto")
        dvgProductos.Columns.Add("Cantidad", "Cantidad")
        dvgProductos.Columns.Add("precioUnitario", "Precio Unitario")
        dvgProductos.Columns.Add("precioTotal", "Precio Total")
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles agregarProducto.Click
        Dim productoSeleccionado As Productos = CType(cbxProducto.SelectedItem, Productos)
        Dim cantidad As Integer = Convert.ToInt32(txtCantidad.Text)
        Dim precioUnitario As Decimal = productoSeleccionado.Precio
        Dim precioTotal As Decimal = cantidad * precioUnitario

        dvgProductos.Rows.Add(productoSeleccionado.ID, productoSeleccionado.Nombre, cantidad, precioUnitario, precioTotal)

        valorTotalProductos()
    End Sub

    Private Sub valorTotalProductos()
        Dim valorTotal As Decimal = 0
        For Each row As DataGridViewRow In dvgProductos.Rows
            valorTotal += Convert.ToDecimal(row.Cells("precioTotal").Value)
        Next
        txtTotal.Text = valorTotal.ToString()
    End Sub

    Private Sub formVenta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        columnasDgv()
        productosComboBox()
        clientesComboBox()
    End Sub

    Private Sub btnVenta_Click(sender As Object, e As EventArgs) Handles btnVenta.Click
        Dim clienteSeleccionado As Clientes = CType(cbxCliente.SelectedItem, Clientes)
        Dim valorTotal As Decimal = Convert.ToDecimal(txtTotal.Text)

        Dim ventaNueva As New Ventas() With {
        .IDCliente = clienteSeleccionado.ID,
        .Fecha = DateTime.Now,
        .Total = valorTotal
        }

        Dim idVenta = servicioVenta.guardar(ventaNueva)

        For Each row As DataGridViewRow In dvgProductos.Rows
            Dim itemNuevo As New VentasItems With {
            .IDVenta = idVenta,
            .IDProducto = Convert.ToInt32(row.Cells("IDProducto").Value),
            .Cantidad = Convert.ToInt32(row.Cells("Cantidad").Value),
            .PrecioUnitario = Convert.ToDecimal(row.Cells("precioUnitario").Value),
            .PrecioTotal = Convert.ToDecimal(row.Cells("precioTotal").Value)
            }
            servicioVentaItem.guardar(itemNuevo)
        Next
        MessageBox.Show("Venta exitosa.")
        dvgProductos.Rows.Clear()
        txtTotal.Text = ""
        txtCantidad.Text = ""
    End Sub

End Class