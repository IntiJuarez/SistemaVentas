Public Class formPrincipal

    Private Sub mostrarFormulario(formulario As Form)

        'Cierra el form actual si hay uno ya abierto'
        If Me.panelContenido.Controls.Count > 0 Then
            Me.panelContenido.Controls.RemoveAt(0)
        End If

        formulario.TopLevel = False
        formulario.FormBorderStyle = FormBorderStyle.None
        formulario.Dock = DockStyle.Fill

        'Agrego formulario al panelContenido'
        Me.panelContenido.Controls.Add(formulario)
        Me.panelContenido.Tag = formulario
        formulario.Show()

    End Sub

    Private Sub ClienteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClienteToolStripMenuItem.Click
        Dim formCliente As New formCliente()
        mostrarFormulario(formCliente)
    End Sub

    Private Sub ProductoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProductoToolStripMenuItem.Click
        Dim formProducto As New formProducto()
        mostrarFormulario(formProducto)
    End Sub

    Private Sub VentasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VentasToolStripMenuItem.Click
        Dim formVentas As New formVenta()
        mostrarFormulario(formVenta)
    End Sub

    Private Sub VentasItemsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VentasItemsToolStripMenuItem.Click
        Dim formVentaItems As New formVentaItems()
        mostrarFormulario(formVentaItems)
    End Sub
End Class