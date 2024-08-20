Imports System.Configuration
Imports System.Data.SqlClient
Public Class repoProductos

    Private connectionString As String = ConfigurationManager.ConnectionStrings("conexionDB").ConnectionString

    Public Function obtenerProductos() As List(Of Producto)
        Dim listaProductos As New List(Of Producto)

        Using con As New SqlConnection(connectionString)
            Dim consulta As String = "SELECT * FROM productos"
            Dim comando As New SqlCommand(consulta, con)
            con.Open()
            Dim lector As SqlDataReader = comando.ExecuteReader()

            'bucle'
            While lector.Read()
                Dim producto As New Producto With {
                .ID = Convert.ToInt32(lector("ID")),
                .Nombre = lector("Nombre").ToString(),
                .Precio = Convert.ToDouble(lector("Precio")),
                .Categoria = lector("Categoria").ToString()
                }
                listaProductos.Add(producto)
            End While
        End Using

        Return listaProductos
    End Function

    Public Sub insertarProducto(producto As Producto)
        Using con As New SqlConnection(connectionString)
            Dim consulta As String = "INSERT INTO productos (Nombre, Precio, Categoria) VALUES (@Nombre, @Precio, @Categoria)"
            Dim comando As New SqlCommand(consulta, con)
            comando.Parameters.AddWithValue("@Nombre", producto.Nombre)
            comando.Parameters.AddWithValue("@Precio", producto.Precio)
            comando.Parameters.AddWithValue("@Categoria", producto.Categoria)
            con.Open()
            comando.ExecuteNonQuery()
        End Using
    End Sub

    Public Sub actualizarProducto(producto As Producto)
        Using con As New SqlConnection(connectionString)
            Dim consulta As String = "UPDATE producto SET Nombre = @Nombre, Precio = @Precio, Categoria = @Categoria WHERE ID=@ID"
            Dim comando As New SqlCommand(consulta, con)
            comando.Parameters.AddWithValue("@ID", producto.ID)
            comando.Parameters.AddWithValue("@Nombre", producto.Nombre)
            comando.Parameters.AddWithValue("@Precio", producto.Precio)
            comando.Parameters.AddWithValue("@Categoria", producto.Categoria)
            con.Open()
            comando.ExecuteNonQuery()
        End Using
    End Sub

    Public Sub eliminarProducto(id As Integer)
        Using con As New SqlConnection(connectionString)
            Dim consulta As String = "DELETE FROM productos WHERE ID=@ID"
            Dim comando As New SqlCommand(consulta, con)
            comando.Parameters.AddWithValue("@ID", id)
            con.Open()
            comando.ExecuteNonQuery()
        End Using
    End Sub

End Class
