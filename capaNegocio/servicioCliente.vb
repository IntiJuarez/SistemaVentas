Imports capaDatos
Public Class servicioCliente

    Private repositorio As New repoClientes()

    Public Function obtenerDatos() As List(Of Clientes)
        Return repositorio.obtenerClientes
    End Function

    Public Function clienteExiste(nombreCliente As String) As Boolean
        Dim clientes As List(Of Clientes) = repositorio.obtenerClientes()
        Return clientes.Any(Function(c) c.Cliente = nombreCliente)
    End Function



    Public Sub guardar(cliente As Clientes)
        'validación'
        If clienteExiste(cliente.Cliente) Then
            Throw New Exception("Cliente existente")
        End If

        If cliente.ID = 0 Then
            repositorio.insertarCliente(cliente)
        End If
    End Sub

    Public Function obtenerClientePorId(idCliente As Integer) As Clientes
        Return repositorio.obtenerClientePorId(idCliente)
    End Function

    Public Sub modificar(cliente As Clientes)
        'validar id'
        If cliente.ID <= 0 Then
            Throw New ArgumentException("El ID no es válido.")
        Else
            repositorio.actualizarCliente(cliente)
        End If

    End Sub


    Public Function buscarClientes(filtro As String) As List(Of Clientes)
        If String.IsNullOrEmpty(filtro) Then
            Throw New ArgumentException("Error. Filtro de búsqueda vacío.")
        End If

        Return repositorio.buscarClientes(filtro)
    End Function

    Public Sub eliminar(id As Integer)
        repositorio.eliminarCliente(id)
    End Sub

End Class
