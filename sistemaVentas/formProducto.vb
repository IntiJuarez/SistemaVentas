Imports capaDatos
Imports capaNegocio
Public Class formProducto

    Private servicioProducto As New servicioProducto()

    Private Sub cargarProducto()
        dgvProductos.DataSource = servicioProducto.obtenerTodo()
    End Sub
    Private Sub btnCrear_Click(sender As Object, e As EventArgs) Handles btnCrear.Click
        Try
            Dim nuevoProducto As New Productos() With {
            .Nombre = txtProducto.Text,
            .Precio = Convert.ToDouble(txtPrecio.Text),
            .Categoria = txtCategoría.Text
            }
            servicioProducto.guardar(nuevoProducto)
            MessageBox.Show("Guardado exitoso.")
            cargarProducto()
            txtProducto.Text = ""
            txtPrecio.Text = ""
            txtCategoría.Text = ""
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Try
            Dim filtro As String = txtBuscar.Text
            Dim listaProducto = servicioProducto.buscarProductos(filtro)
            dgvProductos.DataSource = listaProducto
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class