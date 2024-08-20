Imports System.Configuration
Imports System.Data.SqlClient
Public Class repoVentaItems

    Private connectionString As String = ConfigurationManager.ConnectionStrings("conexionDB").ConnectionString

    Public Function obtenerItems() As List(Of VentasItems)
        Dim listaItems As New List(Of VentasItems)

        Using con As New SqlConnection(connectionString)

            Dim consulsta As String = "SELECT * FROM ventasitems"
            Dim comando As New SqlCommand(consulsta, con)
            con.Open()
            Dim lector As SqlDataReader = comando.ExecuteReader()

            While lector.Read()
                Dim item As New VentasItems() With {
                 .ID = Convert.ToInt32(lector("ID")),
                 .IDVenta = Convert.ToInt32(lector("IDVenta")),
                 .IDProducto = Convert.ToInt32(lector("IDProducto")),
                 .PrecioUnitario = Convert.ToDouble(lector("PrecioUnitario")),
                 .Cantidad = Convert.ToDouble(lector("Cantidad")),
                 .PrecioTotal = Convert.ToDouble(lector("PrecioTotal"))
                }
                listaItems.Add(item)
            End While
        End Using
        Return listaItems
    End Function

    Public Sub insertar(item As VentasItems)
        Using con As New SqlConnection(connectionString)
            Dim consulsta As String = "INSERT INTO ventasitems (IDVenta, IDProducto, PrecioUnitario, Cantidad, PrecioTotal) VALUES (@IDVenta, @IDProducto, @PrecioUnitario, @Cantidad, @PrecioTotal)"
            Dim comando As New SqlCommand(consulsta, con)
            comando.Parameters.AddWithValue("@IDVenta", item.IDVenta)
            comando.Parameters.AddWithValue("@IDProducto", item.IDProducto)
            comando.Parameters.AddWithValue("@PrecioUnitario", item.PrecioUnitario)
            comando.Parameters.AddWithValue("@Cantidad", item.Cantidad)
            comando.Parameters.AddWithValue("@PrecioTotal", item.PrecioTotal)
            con.Open()
            comando.ExecuteNonQuery()
        End Using
    End Sub
    Public Sub modificar(item As VentasItems)
        Using con As New SqlConnection(connectionString)
            Dim consulta As String = "UPDATE ventasitems SET IDVenta = @IDVenta, IDProducto = @IDProducto, PrecioUnitario = @PrecioUnitario, Cantidad = @Cantidad, PrecioTotal = @PrecioTotal WHERE ID = @ID"
            Dim comando As New SqlCommand(consulta, con)
            comando.Parameters.AddWithValue("@ID", item.ID)
            comando.Parameters.AddWithValue("@IDVenta", item.IDVenta)
            comando.Parameters.AddWithValue("@IDProducto", item.IDProducto)
            comando.Parameters.AddWithValue("@PrecioUnitario", item.PrecioUnitario)
            comando.Parameters.AddWithValue("@Cantidad", item.Cantidad)
            comando.Parameters.AddWithValue("@PrecioTotal", item.PrecioTotal)
            con.Open()
            comando.ExecuteNonQuery()
        End Using
    End Sub

    Public Sub eliminar(id As Integer)
        Using con As New SqlConnection(connectionString)
            Dim consulta As String = "DELETE FROM ventasitems WHERE ID = @ID"
            Dim comando As New SqlCommand(consulta, con)
            comando.Parameters.AddWithValue("@ID", id)
            con.Open()
            comando.ExecuteNonQuery()
        End Using
    End Sub
End Class
