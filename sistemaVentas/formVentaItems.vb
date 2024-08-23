Imports capaDatos
Imports capaNegocio
Public Class formVentaItems

    Private servicioVenta As New servicioVenta()

    Private Sub btnBuscarVenta_Click(sender As Object, e As EventArgs) Handles btnBuscarVenta.Click
        Dim nombreCliente As String = txtCliente.Text.Trim()

        If nombreCliente = String.Empty Then
            MessageBox.Show("Debe, ingresar un cliente")
            Return
        End If

        Dim venta As List(Of Ventas) = servicioVenta.listarVentasPorCliente(nombreCliente)

        dvgVentas.DataSource = venta
    End Sub

End Class