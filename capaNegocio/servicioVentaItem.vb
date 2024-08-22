Imports capaDatos
Public Class servicioVentaItem

    Private repositorio As New repoVentaItems()

    Public Sub guardar(nuevoItem As VentasItems)
        repositorio.insertar(nuevoItem)
    End Sub

End Class
