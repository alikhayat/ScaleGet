<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class IPTextBox
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.txtIP1 = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtIP2 = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtIP4 = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtIP3 = New System.Windows.Forms.TextBox
        Me.SuspendLayout()
        '
        'txtIP1
        '
        Me.txtIP1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtIP1.Location = New System.Drawing.Point(4, 3)
        Me.txtIP1.MaxLength = 3
        Me.txtIP1.Name = "txtIP1"
        Me.txtIP1.Size = New System.Drawing.Size(26, 13)
        Me.txtIP1.TabIndex = 0
        Me.txtIP1.Text = "255"
        Me.txtIP1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Window
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(29, 3)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(11, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "."
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.Window
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.Location = New System.Drawing.Point(0, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(136, 20)
        Me.Label3.TabIndex = 5
        '
        'txtIP2
        '
        Me.txtIP2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtIP2.Location = New System.Drawing.Point(37, 3)
        Me.txtIP2.MaxLength = 3
        Me.txtIP2.Name = "txtIP2"
        Me.txtIP2.Size = New System.Drawing.Size(26, 13)
        Me.txtIP2.TabIndex = 1
        Me.txtIP2.Text = "255"
        Me.txtIP2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Window
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(62, 3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(11, 13)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "."
        '
        'txtIP4
        '
        Me.txtIP4.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtIP4.Location = New System.Drawing.Point(101, 3)
        Me.txtIP4.MaxLength = 3
        Me.txtIP4.Name = "txtIP4"
        Me.txtIP4.Size = New System.Drawing.Size(26, 13)
        Me.txtIP4.TabIndex = 3
        Me.txtIP4.Text = "255"
        Me.txtIP4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.Window
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(94, 3)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(11, 13)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "."
        '
        'txtIP3
        '
        Me.txtIP3.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtIP3.Location = New System.Drawing.Point(68, 3)
        Me.txtIP3.MaxLength = 3
        Me.txtIP3.Name = "txtIP3"
        Me.txtIP3.Size = New System.Drawing.Size(26, 13)
        Me.txtIP3.TabIndex = 2
        Me.txtIP3.Text = "255"
        Me.txtIP3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'IPTextBox
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.txtIP4)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtIP3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtIP2)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtIP1)
        Me.Controls.Add(Me.Label3)
        Me.Name = "IPTextBox"
        Me.Size = New System.Drawing.Size(136, 20)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents txtIP1 As System.Windows.Forms.TextBox
    Private WithEvents Label2 As System.Windows.Forms.Label
    Private WithEvents Label3 As System.Windows.Forms.Label
    Private WithEvents txtIP2 As System.Windows.Forms.TextBox
    Private WithEvents Label1 As System.Windows.Forms.Label
    Private WithEvents txtIP4 As System.Windows.Forms.TextBox
    Private WithEvents Label5 As System.Windows.Forms.Label
    Private WithEvents txtIP3 As System.Windows.Forms.TextBox

End Class
