Imports capaDatos
Public Class servicioProducto

    Private repositorio As New repoProductos()
    Public Function obtenerTodo() As List(Of Productos)
        Return repositorio.obtenerProductos
    End Function

    Public Function buscarProductos(filtro As String) As List(Of Productos)
        If String.IsNullOrEmpty(filtro) Then
            Throw New ArgumentException("Error. Filtro de búsqueda vacío.")
        End If
        Return repositorio.buscarProductos(filtro)
    End Function

    Public Function productoExistente(productoNombre As String) As Boolean
        Dim productos As List(Of Productos) = obtenerTodo()
        Return productos.Any(Function(p) p.Nombre = productoNombre)
    End Function

    Public Sub guardar(productos As Productos)
        'validación'
        If productoExistente(productos.Nombre) Then
            Throw New Exception("Producto existente")
        End If

        If productos.ID = 0 Then
            repositorio.insertarProducto(productos)
        Else
            repositorio.actualizarProducto(productos)
        End If
    End Sub

    Public Sub eliminar(id As Integer)
        repositorio.eliminarProducto(id)
    End Sub

End Class
