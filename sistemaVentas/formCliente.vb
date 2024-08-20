Imports capaNegocio
Imports capaDatos
Public Class formCliente

    Private servicioCliente As New servicioCliente()

    Private Sub cargaCliente()
        dgvCliente.DataSource = servicioCliente.obtenerDatos()
    End Sub
    Private Sub btnCrear_Click(sender As Object, e As EventArgs) Handles btnCrear.Click
        Try
            Dim nuevoCliente As New Cliente() With {
            .Nombre = txtCliente.Text,
            .Telefono = txtTelefono.Text,
            .Correo = txtCorreo.Text
            }
            servicioCliente.guardar(nuevoCliente)
            MessageBox.Show("Guardado exitoso.")
            cargaCliente()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class
