Imports System.Configuration
Imports System.Data.SqlClient
Public Class repoClientes
    Private connectionString As String = ConfigurationManager.ConnectionStrings("conexionBD").ConnectionString

    Public Function obtenerClientes() As List(Of Clientes)

        Dim listaClientes As New List(Of Clientes)

        Using con As New SqlConnection(connectionString)
            Dim consulta As String = "SELECT * FROM clientes"
            Dim comando As New SqlCommand(consulta, con)
            con.Open()
            Dim lector As SqlDataReader = comando.ExecuteReader()

            While lector.Read()
                Dim cliente As New Clientes With {
                    .ID = Convert.ToInt32(lector("ID")),
                    .Cliente = lector("Cliente").ToString(),
                    .Telefono = lector("Telefono").ToString(),
                    .Correo = lector("Correo").ToString()
                }
                listaClientes.Add(cliente)
            End While
        End Using

        Return listaClientes
    End Function

    Public Function buscarClientes(filtro) As List(Of Clientes)
        Dim listaClientes As New List(Of Clientes)

        Using con As New SqlConnection(connectionString)
            Dim consulta As String = "SELECT * FROM clientes WHERE Cliente LIKE @filtro OR Telefono LIKE @filtro OR Correo LIKE @filtro"
            Dim comando As New SqlCommand(consulta, con)
            comando.Parameters.AddWithValue("@filtro", "%" & filtro & "%")

            con.Open()
            Dim lector As SqlDataReader = comando.ExecuteReader()

            While lector.Read()
                Dim cliente As New Clientes With {
                .ID = Convert.ToInt32(lector("ID")),
                .Cliente = lector("Cliente").ToString(),
                .Telefono = lector("Telefono").ToString(),
                .Correo = lector("Correo")
                }
                listaClientes.Add(cliente)
            End While
        End Using
        Return listaClientes
    End Function

    Public Function obtenerClientePorId(idCliente As Integer) As Clientes
        Dim cliente As New Clientes()

        Using con As New SqlConnection(connectionString)
            Dim consulta As String = "SELECT * FROM clientes WHERE ID = @ID"
            Dim comando As New SqlCommand(consulta, con)
            comando.Parameters.AddWithValue("@ID", idCliente)
            con.Open()
            Dim lector As SqlDataReader = comando.ExecuteReader()

            If lector.Read() Then
                cliente.ID = Convert.ToInt32(lector("ID"))
                cliente.Cliente = lector("Cliente").ToString()
                cliente.Telefono = lector("Telefono").ToString()
                cliente.Correo = lector("Correo").ToString()
            End If
        End Using

        Return cliente
    End Function



    Public Sub insertarCliente(cliente As Clientes)

        Using con As New SqlConnection(connectionString)
            Dim consulta As String = "INSERT INTO clientes (Cliente, Telefono, Correo) VALUES (@Nombre, @Telefono, @Correo)"
            Dim comando As New SqlCommand(consulta, con)
            comando.Parameters.AddWithValue("@Nombre", cliente.Cliente)
            comando.Parameters.AddWithValue("@Telefono", cliente.Telefono)
            comando.Parameters.AddWithValue("@Correo", cliente.Correo)
            con.Open()
            comando.ExecuteNonQuery()
        End Using
    End Sub

    Public Sub actualizarCliente(cliente As Clientes)
        Using con As New SqlConnection(connectionString)
            Dim consulta As String = "UPDATE clientes SET Cliente = @Nombre, Telefono = @Telefono, Correo = @Correo WHERE ID = @ID"
            Dim comando As New SqlCommand(consulta, con)
            comando.Parameters.AddWithValue("@ID", cliente.ID)
            comando.Parameters.AddWithValue("@Nombre", cliente.Cliente)
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
