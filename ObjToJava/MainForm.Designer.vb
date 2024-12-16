<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.InputTextBox = New System.Windows.Forms.TextBox()
        Me.OutputTextBox = New System.Windows.Forms.TextBox()
        Me.InputBrowseButton = New System.Windows.Forms.Button()
        Me.OutputBrowseButton = New System.Windows.Forms.Button()
        Me.ConvertButton = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(32, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "OBJ File:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(29, 95)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Java File:"
        '
        'InputTextBox
        '
        Me.InputTextBox.Location = New System.Drawing.Point(87, 25)
        Me.InputTextBox.Name = "InputTextBox"
        Me.InputTextBox.Size = New System.Drawing.Size(597, 20)
        Me.InputTextBox.TabIndex = 2
        '
        'OutputTextBox
        '
        Me.OutputTextBox.Location = New System.Drawing.Point(87, 92)
        Me.OutputTextBox.Name = "OutputTextBox"
        Me.OutputTextBox.Size = New System.Drawing.Size(597, 20)
        Me.OutputTextBox.TabIndex = 3
        '
        'InputBrowseButton
        '
        Me.InputBrowseButton.Location = New System.Drawing.Point(609, 51)
        Me.InputBrowseButton.Name = "InputBrowseButton"
        Me.InputBrowseButton.Size = New System.Drawing.Size(75, 23)
        Me.InputBrowseButton.TabIndex = 4
        Me.InputBrowseButton.Text = "Browse"
        Me.InputBrowseButton.UseVisualStyleBackColor = True
        '
        'OutputBrowseButton
        '
        Me.OutputBrowseButton.Location = New System.Drawing.Point(609, 118)
        Me.OutputBrowseButton.Name = "OutputBrowseButton"
        Me.OutputBrowseButton.Size = New System.Drawing.Size(75, 23)
        Me.OutputBrowseButton.TabIndex = 5
        Me.OutputBrowseButton.Text = "Browse"
        Me.OutputBrowseButton.UseVisualStyleBackColor = True
        '
        'ConvertButton
        '
        Me.ConvertButton.Location = New System.Drawing.Point(313, 135)
        Me.ConvertButton.Name = "ConvertButton"
        Me.ConvertButton.Size = New System.Drawing.Size(75, 23)
        Me.ConvertButton.TabIndex = 6
        Me.ConvertButton.Text = "Convert"
        Me.ConvertButton.UseVisualStyleBackColor = True
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(696, 170)
        Me.Controls.Add(Me.ConvertButton)
        Me.Controls.Add(Me.OutputBrowseButton)
        Me.Controls.Add(Me.InputBrowseButton)
        Me.Controls.Add(Me.OutputTextBox)
        Me.Controls.Add(Me.InputTextBox)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "MainForm"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Obj To Java Class Converter"
        Me.ResumeLayout(False)
        Me.PerformLayout()

End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents InputTextBox As System.Windows.Forms.TextBox
    Friend WithEvents OutputTextBox As System.Windows.Forms.TextBox
    Friend WithEvents InputBrowseButton As System.Windows.Forms.Button
    Friend WithEvents OutputBrowseButton As System.Windows.Forms.Button
    Friend WithEvents ConvertButton As System.Windows.Forms.Button

End Class
