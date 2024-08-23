Imports capaNegocio
Imports capaDatos
Public Class formCliente

    Private servicioCliente As New servicioCliente()

    Private Sub cargaCliente()
        'dgvCliente.DataSource = servicioCliente.obtenerDatos()
        Dim listaClientes As List(Of Clientes) = servicioCliente.obtenerDatos()

        dgvCliente.Rows.Clear()

        For Each cliente As Clientes In listaClientes
            dgvCliente.Rows.Add(cliente.ID, cliente.Cliente, cliente.Telefono, cliente.Correo)
        Next

    End Sub

    Private Sub configuracionDgv()
        dgvCliente.ColumnCount = 4
        dgvCliente.Columns(0).Name = "ID"
        dgvCliente.Columns(1).Name = "Nombre"
        dgvCliente.Columns(2).Name = "Teléfono"
        dgvCliente.Columns(3).Name = "Correo"

        'ancho de las columnas manual'
        dgvCliente.Columns(0).Width = 50
        dgvCliente.Columns(1).Width = 150
        dgvCliente.Columns(2).Width = 100
        dgvCliente.Columns(3).Width = 150

    End Sub

    Private Sub btnCrear_Click(sender As Object, e As EventArgs) Handles btnCrear.Click
        Try
            Dim nuevoCliente As New Clientes() With {
            .Cliente = txtCliente.Text,
            .Telefono = txtTelefono.Text,
            .Correo = txtCorreo.Text
            }
            servicioCliente.guardar(nuevoCliente)
            MessageBox.Show("Guardado exitoso.")
            cargaCliente()
            txtCliente.Text = ""
            txtTelefono.Text = ""
            txtCorreo.Text = ""
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Try
            dgvCliente.Columns.Clear()

            dgvCliente.Columns.Add("ID", "ID")
            dgvCliente.Columns("ID").DataPropertyName = "ID"

            dgvCliente.Columns.Add("Cliente", "Cliente")
            dgvCliente.Columns("Cliente").DataPropertyName = "Cliente"

            dgvCliente.Columns.Add("Telefono", "Telefono")
            dgvCliente.Columns("Telefono").DataPropertyName = "Telefono"

            dgvCliente.Columns.Add("Correo", "Correo")
            dgvCliente.Columns("Correo").DataPropertyName = "Correo"

            Dim filtro As String = txtBuscar.Text
            Dim listaClientes = servicioCliente.buscarClientes(filtro)

            dgvCliente.DataSource = listaClientes

            'dgvCliente.DataSource = listaClientes
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        If dgvCliente.SelectedRows.Count > 0 Then
            Dim idCliente As Integer = Convert.ToInt32(dgvCliente.SelectedRows(0).Cells("ID").Value)

            If MessageBox.Show("¿Esta seguro?", "Confirmar", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                servicioCliente.eliminar(idCliente)
                MessageBox.Show("Eliminado correctamente")
                cargaCliente()
            End If
        Else
            MessageBox.Show("Debe seleccionar un cliente para eliminar.")
        End If
    End Sub

    Private Sub formCliente_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        configuracionDgv()
        cargaCliente()
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        Try
            Dim idCliente As Integer = Convert.ToInt32(dgvCliente.SelectedRows(0).Cells("ID").Value)
            Dim clienteExistente As Clientes = servicioCliente.obtenerClientePorId(idCliente)

            Dim clienteNuevo As New Clientes() With {
                .ID = idCliente,
                .Cliente = If(String.IsNullOrEmpty(txtCliente.Text), clienteExistente.Cliente, txtCliente.Text),
                .Telefono = If(String.IsNullOrEmpty(txtTelefono.Text), clienteExistente.Telefono, txtTelefono.Text),
                .Correo = If(String.IsNullOrEmpty(txtCorreo.Text), clienteExistente.Correo, txtCorreo.Text)
                }
            servicioCliente.modificar(clienteNuevo)
            MessageBox.Show("Modificado exitoso.")
            cargaCliente()
            txtCliente.Text = ""
            txtTelefono.Text = ""
            txtCorreo.Text = ""

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub
End Class
