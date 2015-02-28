<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmKeyboard
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmKeyboard))
        Me.btnSave = New System.Windows.Forms.Button()
        Me.dgvKeyboard = New System.Windows.Forms.DataGridView()
        Me.dgvTxtSections = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvCmbActions = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.dgvTxtBefore = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvTxtAfter = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtKey = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtKeyboard = New System.Windows.Forms.TextBox()
        Me.btnConfig = New System.Windows.Forms.Button()
        Me.txtButtonName = New System.Windows.Forms.TextBox()
        Me.picBoxButton = New System.Windows.Forms.PictureBox()
        CType(Me.dgvKeyboard, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picBoxButton, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(1206, 175)
        Me.btnSave.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(112, 38)
        Me.btnSave.TabIndex = 0
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'dgvKeyboard
        '
        Me.dgvKeyboard.AllowUserToAddRows = False
        Me.dgvKeyboard.AllowUserToDeleteRows = False
        Me.dgvKeyboard.AllowUserToResizeRows = False
        Me.dgvKeyboard.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvKeyboard.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgvTxtSections, Me.dgvCmbActions, Me.dgvTxtBefore, Me.dgvTxtAfter})
        Me.dgvKeyboard.Dock = System.Windows.Forms.DockStyle.Left
        Me.dgvKeyboard.Location = New System.Drawing.Point(0, 0)
        Me.dgvKeyboard.Margin = New System.Windows.Forms.Padding(4)
        Me.dgvKeyboard.Name = "dgvKeyboard"
        Me.dgvKeyboard.RowHeadersVisible = False
        Me.dgvKeyboard.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvKeyboard.Size = New System.Drawing.Size(1171, 755)
        Me.dgvKeyboard.TabIndex = 0
        '
        'dgvTxtSections
        '
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Consolas", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvTxtSections.DefaultCellStyle = DataGridViewCellStyle1
        Me.dgvTxtSections.HeaderText = "Sections"
        Me.dgvTxtSections.Name = "dgvTxtSections"
        Me.dgvTxtSections.ReadOnly = True
        Me.dgvTxtSections.Width = 200
        '
        'dgvCmbActions
        '
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Consolas", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvCmbActions.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvCmbActions.HeaderText = "Actions"
        Me.dgvCmbActions.Name = "dgvCmbActions"
        Me.dgvCmbActions.Width = 250
        '
        'dgvTxtBefore
        '
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Consolas", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvTxtBefore.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvTxtBefore.HeaderText = "Before"
        Me.dgvTxtBefore.Name = "dgvTxtBefore"
        Me.dgvTxtBefore.ReadOnly = True
        Me.dgvTxtBefore.Width = 350
        '
        'dgvTxtAfter
        '
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Consolas", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvTxtAfter.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgvTxtAfter.HeaderText = "After"
        Me.dgvTxtAfter.Name = "dgvTxtAfter"
        Me.dgvTxtAfter.ReadOnly = True
        Me.dgvTxtAfter.Width = 350
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(1206, 235)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(4)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(112, 38)
        Me.btnCancel.TabIndex = 1
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(1202, 97)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(217, 21)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "You are configurating the key:"
        '
        'txtKey
        '
        Me.txtKey.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.txtKey.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtKey.Location = New System.Drawing.Point(1534, 124)
        Me.txtKey.Name = "txtKey"
        Me.txtKey.ReadOnly = True
        Me.txtKey.Size = New System.Drawing.Size(246, 29)
        Me.txtKey.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(1202, 30)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(138, 21)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "keyboard.xml path"
        '
        'txtKeyboard
        '
        Me.txtKeyboard.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.txtKeyboard.Location = New System.Drawing.Point(1206, 54)
        Me.txtKeyboard.Name = "txtKeyboard"
        Me.txtKeyboard.ReadOnly = True
        Me.txtKeyboard.Size = New System.Drawing.Size(574, 29)
        Me.txtKeyboard.TabIndex = 6
        '
        'btnConfig
        '
        Me.btnConfig.Location = New System.Drawing.Point(1343, 175)
        Me.btnConfig.Name = "btnConfig"
        Me.btnConfig.Size = New System.Drawing.Size(122, 38)
        Me.btnConfig.TabIndex = 7
        Me.btnConfig.Text = "Edit config file"
        Me.btnConfig.UseVisualStyleBackColor = True
        '
        'txtButtonName
        '
        Me.txtButtonName.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.txtButtonName.Location = New System.Drawing.Point(1206, 124)
        Me.txtButtonName.Name = "txtButtonName"
        Me.txtButtonName.ReadOnly = True
        Me.txtButtonName.Size = New System.Drawing.Size(268, 29)
        Me.txtButtonName.TabIndex = 8
        '
        'picBoxButton
        '
        Me.picBoxButton.Location = New System.Drawing.Point(1480, 124)
        Me.picBoxButton.Name = "picBoxButton"
        Me.picBoxButton.Size = New System.Drawing.Size(48, 29)
        Me.picBoxButton.TabIndex = 9
        Me.picBoxButton.TabStop = False
        '
        'frmKeyboard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 21.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1789, 755)
        Me.Controls.Add(Me.picBoxButton)
        Me.Controls.Add(Me.txtButtonName)
        Me.Controls.Add(Me.btnConfig)
        Me.Controls.Add(Me.txtKeyboard)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtKey)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.dgvKeyboard)
        Me.Controls.Add(Me.btnSave)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frmKeyboard"
        Me.ShowInTaskbar = False
        Me.Text = "set Kodi Keyboard by CPVprogrammer"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.dgvKeyboard, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picBoxButton, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents dgvKeyboard As System.Windows.Forms.DataGridView
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtKey As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtKeyboard As System.Windows.Forms.TextBox
    Friend WithEvents btnConfig As System.Windows.Forms.Button
    Friend WithEvents dgvTxtSections As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgvCmbActions As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents dgvTxtBefore As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgvTxtAfter As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtButtonName As System.Windows.Forms.TextBox
    Friend WithEvents picBoxButton As System.Windows.Forms.PictureBox
End Class
