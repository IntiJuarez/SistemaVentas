<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class formProducto
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnCrear = New System.Windows.Forms.Button()
        Me.txtCategoría = New System.Windows.Forms.TextBox()
        Me.txtPrecio = New System.Windows.Forms.TextBox()
        Me.txtProducto = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Buscador = New System.Windows.Forms.GroupBox()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.txtBuscar = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dgvProductos = New System.Windows.Forms.DataGridView()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.btnEditar = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.Buscador.SuspendLayout()
        CType(Me.dgvProductos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnEditar)
        Me.GroupBox1.Controls.Add(Me.btnEliminar)
        Me.GroupBox1.Controls.Add(Me.btnCrear)
        Me.GroupBox1.Controls.Add(Me.txtCategoría)
        Me.GroupBox1.Controls.Add(Me.txtPrecio)
        Me.GroupBox1.Controls.Add(Me.txtProducto)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 28)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(485, 148)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Productos"
        '
        'btnCrear
        '
        Me.btnCrear.Location = New System.Drawing.Point(131, 113)
        Me.btnCrear.Name = "btnCrear"
        Me.btnCrear.Size = New System.Drawing.Size(70, 20)
        Me.btnCrear.TabIndex = 6
        Me.btnCrear.Text = "Crear"
        Me.btnCrear.UseVisualStyleBackColor = True
        '
        'txtCategoría
        '
        Me.txtCategoría.Location = New System.Drawing.Point(84, 72)
        Me.txtCategoría.Name = "txtCategoría"
        Me.txtCategoría.Size = New System.Drawing.Size(142, 20)
        Me.txtCategoría.TabIndex = 5
        '
        'txtPrecio
        '
        Me.txtPrecio.Location = New System.Drawing.Point(327, 29)
        Me.txtPrecio.Name = "txtPrecio"
        Me.txtPrecio.Size = New System.Drawing.Size(75, 20)
        Me.txtPrecio.TabIndex = 4
        '
        'txtProducto
        '
        Me.txtProducto.Location = New System.Drawing.Point(84, 29)
        Me.txtProducto.Name = "txtProducto"
        Me.txtProducto.Size = New System.Drawing.Size(142, 20)
        Me.txtProducto.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(24, 76)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Categoría"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(284, 32)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(37, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Precio"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(28, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Nombre"
        '
        'Buscador
        '
        Me.Buscador.Controls.Add(Me.btnBuscar)
        Me.Buscador.Controls.Add(Me.txtBuscar)
        Me.Buscador.Controls.Add(Me.Label4)
        Me.Buscador.Location = New System.Drawing.Point(12, 182)
        Me.Buscador.Name = "Buscador"
        Me.Buscador.Size = New System.Drawing.Size(485, 86)
        Me.Buscador.TabIndex = 5
        Me.Buscador.TabStop = False
        Me.Buscador.Text = "Buscador"
        '
        'btnBuscar
        '
        Me.btnBuscar.Location = New System.Drawing.Point(327, 28)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(75, 23)
        Me.btnBuscar.TabIndex = 2
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'txtBuscar
        '
        Me.txtBuscar.Location = New System.Drawing.Point(84, 32)
        Me.txtBuscar.Name = "txtBuscar"
        Me.txtBuscar.Size = New System.Drawing.Size(213, 20)
        Me.txtBuscar.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(31, 32)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(40, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Buscar"
        '
        'dgvProductos
        '
        Me.dgvProductos.AllowUserToAddRows = False
        Me.dgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvProductos.Location = New System.Drawing.Point(12, 274)
        Me.dgvProductos.Name = "dgvProductos"
        Me.dgvProductos.Size = New System.Drawing.Size(552, 199)
        Me.dgvProductos.TabIndex = 6
        '
        'btnEliminar
        '
        Me.btnEliminar.Location = New System.Drawing.Point(227, 113)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(70, 20)
        Me.btnEliminar.TabIndex = 8
        Me.btnEliminar.Text = "Eliminar"
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'btnEditar
        '
        Me.btnEditar.Location = New System.Drawing.Point(327, 113)
        Me.btnEditar.Name = "btnEditar"
        Me.btnEditar.Size = New System.Drawing.Size(70, 20)
        Me.btnEditar.TabIndex = 9
        Me.btnEditar.Text = "Modificar"
        Me.btnEditar.UseVisualStyleBackColor = True
        '
        'formProducto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(601, 525)
        Me.Controls.Add(Me.dgvProductos)
        Me.Controls.Add(Me.Buscador)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "formProducto"
        Me.Text = "formProducto"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Buscador.ResumeLayout(False)
        Me.Buscador.PerformLayout()
        CType(Me.dgvProductos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents btnCrear As Button
    Friend WithEvents txtCategoría As TextBox
    Friend WithEvents txtPrecio As TextBox
    Friend WithEvents txtProducto As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Buscador As GroupBox
    Friend WithEvents btnBuscar As Button
    Friend WithEvents txtBuscar As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents dgvProductos As DataGridView
    Friend WithEvents btnEliminar As Button
    Friend WithEvents btnEditar As Button
End Class
