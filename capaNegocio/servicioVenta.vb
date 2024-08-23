Imports capaDatos
Public Class servicioVenta

    Private repositorio As New repoVentas()

    Public Function guardar(venta As Ventas)
        Return repositorio.insertarVenta(venta)
    End Function

    Public Function listarVentasPorCliente(nombreCliente As String) As List(Of Ventas)
        Return repositorio.buscarVentaPorCliente(nombreCliente)
    End Function

End Class
