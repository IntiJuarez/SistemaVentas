Imports capaNegocio
Imports capaDatos
Public Class formCliente

    Private servicioCliente As New servicioCliente()

    Private Sub cargaCliente()
        dgvCliente.DataSource = servicioCliente.obtenerDatos()
    End Sub
    Private Sub btnCrear_Click(sender As Object, e As EventArgs) Handles btnCrear.Click
        Try
            Dim nuevoCliente As New Clientes() With {
            .Cliente = txtCliente.Text,
            .Telefono = txtTelefono.Text,
            .Correo = txtCorreo.Text
            }
            servicioCliente.guardar(nuevoCliente)
            MessageBox.Show("Guardado exitoso.")
            cargaCliente()
            txtCliente.Text = ""
            txtTelefono.Text = ""
            txtCorreo.Text = ""
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Try
            Dim filtro As String = txtBuscar.Text
            Dim listaClientes = servicioCliente.buscarClientes(filtro)
            dgvCliente.DataSource = listaClientes
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub
End Class
