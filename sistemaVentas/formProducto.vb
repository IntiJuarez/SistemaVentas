Imports capaDatos
Imports capaNegocio
Public Class formProducto

    Private servicioProducto As New servicioProducto()

    Private Sub cargarProducto()
        'dgvProductos.DataSource = servicioProducto.obtenerTodo()
        Dim listaProductos As List(Of Productos) = servicioProducto.obtenerTodo()
        dgvProductos.Rows.Clear()

        For Each producto As Productos In listaProductos
            dgvProductos.Rows.Add(producto.ID, producto.Nombre, producto.Precio, producto.Categoria)
        Next
    End Sub

    Private Sub configuracionDgv()
        dgvProductos.ColumnCount = 4
        dgvProductos.Columns(0).Name = "ID"
        dgvProductos.Columns(1).Name = "Nombre"
        dgvProductos.Columns(2).Name = "Precio"
        dgvProductos.Columns(3).Name = "Categoria"

        'ancho de las columnas manual'
        dgvProductos.Columns(0).Width = 50
        dgvProductos.Columns(1).Width = 150
        dgvProductos.Columns(2).Width = 100
        dgvProductos.Columns(3).Width = 150

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

            dgvProductos.Columns.Clear()

            dgvProductos.Columns.Add("ID", "ID")
            dgvProductos.Columns("ID").DataPropertyName = "ID"

            dgvProductos.Columns.Add("Nombre", "Nombre")
            dgvProductos.Columns("Nombre").DataPropertyName = "Nombre"

            dgvProductos.Columns.Add("Precio", "Precio")
            dgvProductos.Columns("Precio").DataPropertyName = "Precio"

            dgvProductos.Columns.Add("Categoria", "Categoria")
            dgvProductos.Columns("Categoria").DataPropertyName = "Categoria"


            Dim filtro As String = txtBuscar.Text
            Dim listaProducto = servicioProducto.buscarProductos(filtro)
            dgvProductos.DataSource = listaProducto
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub formProducto_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        configuracionDgv()
        cargarProducto()
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        If dgvProductos.Rows.Count > 0 Then
            Dim idProducto As Integer = Convert.ToInt32(dgvProductos.SelectedRows(0).Cells("ID").Value)

            If MessageBox.Show("¿Esta seguro?", "Confirmar", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                servicioProducto.eliminar(idProducto)
                MessageBox.Show("Eliminado correctamente")
                cargarProducto()
            End If
        Else
            MessageBox.Show("Debe seleccionar un cliente para eliminar.")
        End If
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        Try
            Dim idProducto As Integer = Convert.ToInt32(dgvProductos.SelectedRows(0).Cells("ID").Value)
            Dim productoExistente As Productos = servicioProducto.obtenerProductoPorId(idProducto)
            Dim nuevoProducto As New Productos With {
                .ID = idProducto,
                .Nombre = If(String.IsNullOrEmpty(txtProducto.Text), productoExistente.Nombre, txtProducto.Text),
                .Precio = If(String.IsNullOrEmpty(txtPrecio.Text), productoExistente.Precio, Convert.ToDecimal(txtPrecio.Text)),
                .Categoria = If(String.IsNullOrEmpty(txtCategoría.Text), productoExistente.Categoria, txtCategoría.Text)
                }
            servicioProducto.modificar(nuevoProducto)
            MessageBox.Show("Modificado exitoso.")
            cargarProducto()
            txtProducto.Text = ""
            txtPrecio.Text = ""
            txtCategoría.Text = ""
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class