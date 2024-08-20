Imports capaDatos
Public Class servicioProducto

    Private repositorio As New repoProductos()
    Public Function obtenerTodo() As List(Of Producto)
        Return repositorio.obtenerProductos
    End Function

    Public Function productoExistente(productoNombre As String) As Boolean
        Dim productos As List(Of Producto) = obtenerTodo()
        Return productos.Any(Function(p) p.Nombre = productoNombre)
    End Function

    Public Sub guardar(productos As Producto)
        'validación'
        If productoExistente(productos.Nombre) Then
            Throw New Exception("Producto existente")
        End If

        If productos.ID = 0 Then
            repositorio.insertarProducto(productos)
        Else
            repositorio.insertarProducto(productos)
        End If
    End Sub

    Public Sub eliminar(id As Integer)
        repositorio.eliminarProducto(id)
    End Sub

End Class
