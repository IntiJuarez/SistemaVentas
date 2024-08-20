Imports System.Configuration
Imports System.Data.SqlClient
Public Class repoCliente
    Private connectionString As String = ConfigurationManager.ConnectionStrings("conexionDB").ConnectionString

    Public Function obtenerClientes() As List(Of Cliente)

        Dim listaClientes As New List(Of Cliente)

        Using con As New SqlConnection(connectionString)
            Dim consulta As String = "SELECT * FROM clientes"
            Dim comando As New SqlCommand(consulta, con)
            con.Open()
            Dim lector As SqlDataReader = comando.ExecuteReader()

            While lector.Read()
                Dim cliente As New Cliente With {
                    .ID = Convert.ToInt32(lector("ID")),
                    .Nombre = lector("Cliente").ToString(),
                    .Telefono = lector("Telefono").ToString(),
                    .Correo = lector("Correo").ToString()
                }
                listaClientes.Add(cliente)
            End While
        End Using

        Return listaClientes
    End Function


    Public Sub insertarCliente(cliente As Cliente)

        Using con As New SqlConnection(connectionString)
            Dim consulta As String = "INSERT INTO clientes (Cliente, Telefono, Correo) VALUES (@Nombre, @Telefono, @Correo)"
            Dim comando As New SqlCommand(consulta, con)
            comando.Parameters.AddWithValue("@Nombre", cliente.Nombre)
            comando.Parameters.AddWithValue("@Telefono", cliente.Telefono)
            comando.Parameters.AddWithValue("@Correo", cliente.Correo)
            con.Open()
            comando.ExecuteNonQuery()
        End Using
    End Sub

    Public Sub actualizarCliente(cliente As Cliente)
        Using con As New SqlConnection(connectionString)
            Dim consulta As String = "UPDATE clientes SET Cliente = @Nombre, @Telefono = Telefono, @Correo = Correo WHERE ID = @ID"
            Dim comando As New SqlCommand(consulta, con)
            comando.Parameters.AddWithValue("@ID", cliente.ID)
            comando.Parameters.AddWithValue("@Nombre", cliente.Nombre)
            comando.Parameters.AddWithValue("@Telefono", cliente.Telefono)
            comando.Parameters.AddWithValue("@Correo", cliente.Correo)
            con.Open()
            comando.ExecuteNonQuery()
        End Using
    End Sub

    Public Sub eliminarCliente(id As Integer)
        Using con As New SqlConnection(connectionString)
            Dim consulta As String = "DELETE FROM clientes WHERE ID = @ID"
            Dim comando As New SqlCommand(consulta, con)
            comando.Parameters.AddWithValue("@ID", id)
            con.Open()
            comando.ExecuteNonQuery()
        End Using
    End Sub
End Class
