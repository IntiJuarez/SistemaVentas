﻿Imports System.Configuration
Imports System.Data.SqlClient

Public Class repoVentas
    'conexión a la bd'
    Private connectionString As String = ConfigurationManager.ConnectionStrings("conexionBD").ConnectionString
    Public Function obtenerVentas() As List(Of Ventas)
        Dim listaVentas As New List(Of Ventas)

        Using con As New SqlConnection(connectionString)

            Dim consulta As String = "SELECET * FROM ventas"
            Dim comando As New SqlCommand(consulta, con)
            'abro conexión'
            con.Open()
            Dim lector As SqlDataReader = comando.ExecuteReader()
            'bucle'
            While lector.Read()
                Dim venta As New Ventas() With {
                .ID = Convert.ToInt32(lector("ID")),
                .IDCliente = Convert.ToInt32(lector("IDCliente")),
                .Fecha = Convert.ToDateTime(lector("Fecha")),
                .Total = Convert.ToDouble(lector("Total"))
                }
                listaVentas.Add(venta)
            End While

            Return listaVentas
        End Using
    End Function

    Public Function buscarVentaPorCliente(nombreCliente As String) As List(Of Ventas)
        Dim listaVentas As New List(Of Ventas)
        Using con As New SqlConnection(connectionString)
            Dim consulta As String = "SELECT v.ID, v.IDCliente, v.Fecha, v.Total, c.Cliente " &
                "FROM ventas v " & "INNER JOIN clientes c ON v.IDCliente = c.ID WHERE c.Cliente LIKE @nombreCliente"
            Dim comando As New SqlCommand(consulta, con)
            comando.Parameters.AddWithValue("nombreCliente", "%" & nombreCliente & "%")
            con.Open()

            Dim lector As SqlDataReader = comando.ExecuteReader()
            While lector.Read()
                Dim venta As New Ventas() With {
                .ID = Convert.ToInt32(lector("ID")),
                .IDCliente = Convert.ToInt32(lector("IDCliente")),
                .Fecha = Convert.ToDateTime(lector("Fecha")),
                .Total = Convert.ToDouble(lector("Total"))
                }
                listaVentas.Add(venta)
            End While
        End Using
        Return listaVentas
    End Function

    Public Function insertarVenta(Venta As Ventas)
        Using con As New SqlConnection(connectionString)
            Dim consulta As String = "INSERT INTO ventas (IDCliente, Fecha, Total) OUTPUT INSERTED.ID VALUES (@IDCliente, @Fecha, @Total)"
            Dim comando As New SqlCommand(consulta, con)
            comando.Parameters.AddWithValue("@IDCliente", Venta.IDCliente)
            comando.Parameters.AddWithValue("@Fecha", Venta.Fecha)
            comando.Parameters.AddWithValue("@Total", Venta.Total)
            con.Open()
            Return Convert.ToInt32(comando.ExecuteScalar())
        End Using
    End Function


    'Public Sub insertarVenta(venta As Ventas)
    '    Using con As New SqlConnection(connectionString)
    '        Dim consulta As String = "INSERT INTO ventas (IDCliente, Fecha, Total) VALUES (@IDCliente, @Fecha, @Total)"
    '        Dim comando As New SqlCommand(consulta, con)
    '        comando.Parameters.AddWithValue("@IDCliente", venta.IDCliente)
    '        comando.Parameters.AddWithValue("@Fecha", venta.Fecha)
    '        comando.Parameters.AddWithValue("@Total", venta.Total)
    '        con.Open()
    '        comando.ExecuteNonQuery()
    '    End Using
    'End Sub

    Public Sub actualizarVenta(venta As Ventas)
        Using con As New SqlConnection(connectionString)
            Dim consulta As String = "UPDATE ventas SET IDCliente = @IDCliente, Fecha = @Fecha, Total = @Total WHERE ID = @ID"
            Dim comando As New SqlCommand(consulta, con)
            comando.Parameters.AddWithValue("@ID", venta.ID)
            comando.Parameters.AddWithValue("@IDCliente", venta.IDCliente)
            comando.Parameters.AddWithValue("@Fecha", venta.Fecha)
            comando.Parameters.AddWithValue("@Total", venta.Total)
            con.Open()
            comando.ExecuteNonQuery()
        End Using
    End Sub

    Public Sub eliminarVenta(id As Integer)
        Using con As New SqlConnection(connectionString)
            Dim consulta As String = "DELETE FROM ventas WHERE ID = @ID"
            Dim comando As New SqlCommand(consulta, con)
            comando.Parameters.AddWithValue("@ID", id)
            con.Open()
            comando.ExecuteNonQuery()
        End Using
    End Sub
End Class
