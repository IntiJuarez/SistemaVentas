<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class formVentaItems
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.dvgVentas = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtCliente = New System.Windows.Forms.TextBox()
        Me.btnBuscarVenta = New System.Windows.Forms.Button()
        CType(Me.dvgVentas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dvgVentas
        '
        Me.dvgVentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dvgVentas.Location = New System.Drawing.Point(12, 77)
        Me.dvgVentas.Name = "dvgVentas"
        Me.dvgVentas.Size = New System.Drawing.Size(476, 196)
        Me.dvgVentas.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(122, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Buscar venta por cliente"
        '
        'txtCliente
        '
        Me.txtCliente.Location = New System.Drawing.Point(141, 22)
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.Size = New System.Drawing.Size(196, 20)
        Me.txtCliente.TabIndex = 2
        '
        'btnBuscarVenta
        '
        Me.btnBuscarVenta.Location = New System.Drawing.Point(364, 18)
        Me.btnBuscarVenta.Name = "btnBuscarVenta"
        Me.btnBuscarVenta.Size = New System.Drawing.Size(65, 27)
        Me.btnBuscarVenta.TabIndex = 3
        Me.btnBuscarVenta.Text = "Buscar"
        Me.btnBuscarVenta.UseVisualStyleBackColor = True
        '
        'formVentaItems
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(520, 343)
        Me.Controls.Add(Me.btnBuscarVenta)
        Me.Controls.Add(Me.txtCliente)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dvgVentas)
        Me.Name = "formVentaItems"
        Me.Text = "formVentaItems"
        CType(Me.dvgVentas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dvgVentas As DataGridView
    Friend WithEvents Label1 As Label
    Friend WithEvents txtCliente As TextBox
    Friend WithEvents btnBuscarVenta As Button
End Class
