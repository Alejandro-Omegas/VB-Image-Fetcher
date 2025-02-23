<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmFemales
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        btnClickme = New Button()
        pbxFemale = New PictureBox()
        cbxFemales = New ComboBox()
        Button1 = New Button()
        btnDeleteFemale = New Button()
        CType(pbxFemale, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' btnClickme
        ' 
        btnClickme.Font = New Font("Segoe UI", 14F)
        btnClickme.Location = New Point(223, 8)
        btnClickme.Name = "btnClickme"
        btnClickme.Size = New Size(104, 36)
        btnClickme.TabIndex = 0
        btnClickme.Text = "Click me"
        btnClickme.UseVisualStyleBackColor = True
        ' 
        ' pbxFemale
        ' 
        pbxFemale.Location = New Point(12, 50)
        pbxFemale.Name = "pbxFemale"
        pbxFemale.Size = New Size(188, 228)
        pbxFemale.SizeMode = PictureBoxSizeMode.StretchImage
        pbxFemale.TabIndex = 3
        pbxFemale.TabStop = False
        ' 
        ' cbxFemales
        ' 
        cbxFemales.Font = New Font("Segoe UI", 12F)
        cbxFemales.FormattingEnabled = True
        cbxFemales.Location = New Point(54, 12)
        cbxFemales.Name = "cbxFemales"
        cbxFemales.Size = New Size(161, 29)
        cbxFemales.TabIndex = 4
        ' 
        ' Button1
        ' 
        Button1.Font = New Font("Segoe UI Emoji", 14F)
        Button1.Location = New Point(331, 9)
        Button1.Name = "Button1"
        Button1.Size = New Size(36, 35)
        Button1.TabIndex = 5
        Button1.Text = "🖊️"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' btnDeleteFemale
        ' 
        btnDeleteFemale.Font = New Font("Segoe UI Emoji", 14F)
        btnDeleteFemale.Location = New Point(12, 10)
        btnDeleteFemale.Name = "btnDeleteFemale"
        btnDeleteFemale.Size = New Size(36, 35)
        btnDeleteFemale.TabIndex = 6
        btnDeleteFemale.Text = "❌ "
        btnDeleteFemale.UseVisualStyleBackColor = True
        ' 
        ' frmFemales
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        AutoSize = True
        AutoSizeMode = AutoSizeMode.GrowAndShrink
        ClientSize = New Size(397, 551)
        Controls.Add(btnDeleteFemale)
        Controls.Add(Button1)
        Controls.Add(cbxFemales)
        Controls.Add(pbxFemale)
        Controls.Add(btnClickme)
        Location = New Point(300, 0)
        Name = "frmFemales"
        StartPosition = FormStartPosition.Manual
        Text = "Females"
        CType(pbxFemale, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents btnClickme As Button
    Friend WithEvents pbxFemale As PictureBox
    Friend WithEvents cbxFemales As ComboBox
    Friend WithEvents Button1 As Button
    Friend WithEvents btnDeleteFemale As Button

End Class
