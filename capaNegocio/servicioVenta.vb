Imports capaDatos
Public Class servicioVenta

    Private repositorio As New repoVentas()

    Public Function guardar(venta As Ventas)
        Return repositorio.insertarVenta(venta)
    End Function

End Class
