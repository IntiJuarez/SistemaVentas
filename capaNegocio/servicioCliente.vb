Imports capaDatos
Public Class servicioCliente

    Private repositorio As New repoClientes()

    Public Function obtenerDatos() As List(Of Clientes)
        Return repositorio.obtenerClientes
    End Function

    Public Function clienteExiste(nombreCliente As String) As Boolean
        Dim clientes As List(Of Clientes) = repositorio.obtenerClientes()
        Return clientes.Any(Function(c) c.Nombre = nombreCliente)
    End Function

    Public Sub guardar(cliente As Clientes)
        'validación'
        If clienteExiste(cliente.Nombre) Then
            Throw New Exception("Cliente existente")
        End If

        If cliente.ID = 0 Then
            repositorio.insertarCliente(cliente)
        Else
            repositorio.actualizarCliente(cliente)
        End If
    End Sub

    Public Sub eliminar(id As Integer)
        repositorio.eliminarCliente(id)
    End Sub

End Class
