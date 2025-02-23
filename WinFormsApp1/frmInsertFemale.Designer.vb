<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInsertFemale
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
        lblName = New Label()
        lblImageURL = New Label()
        txtName = New TextBox()
        txtImageURL = New TextBox()
        btnInsertFemale = New Button()
        SuspendLayout()
        ' 
        ' lblName
        ' 
        lblName.AutoSize = True
        lblName.Font = New Font("Segoe UI", 12F)
        lblName.Location = New Point(13, 11)
        lblName.Name = "lblName"
        lblName.Size = New Size(55, 21)
        lblName.TabIndex = 0
        lblName.Text = "Name:"
        ' 
        ' lblImageURL
        ' 
        lblImageURL.AutoSize = True
        lblImageURL.Font = New Font("Segoe UI", 12F)
        lblImageURL.Location = New Point(12, 80)
        lblImageURL.Name = "lblImageURL"
        lblImageURL.Size = New Size(89, 21)
        lblImageURL.TabIndex = 1
        lblImageURL.Text = "Image URL:"
        ' 
        ' txtName
        ' 
        txtName.Font = New Font("Segoe UI", 12F)
        txtName.Location = New Point(12, 35)
        txtName.MaxLength = 100
        txtName.Name = "txtName"
        txtName.Size = New Size(261, 29)
        txtName.TabIndex = 2
        ' 
        ' txtImageURL
        ' 
        txtImageURL.Font = New Font("Segoe UI", 12F)
        txtImageURL.Location = New Point(13, 104)
        txtImageURL.MaxLength = 4096
        txtImageURL.Name = "txtImageURL"
        txtImageURL.Size = New Size(260, 29)
        txtImageURL.TabIndex = 3
        ' 
        ' btnInsertFemale
        ' 
        btnInsertFemale.Font = New Font("Segoe UI", 14F)
        btnInsertFemale.Location = New Point(194, 154)
        btnInsertFemale.Name = "btnInsertFemale"
        btnInsertFemale.Size = New Size(79, 34)
        btnInsertFemale.TabIndex = 4
        btnInsertFemale.Text = "Insert"
        btnInsertFemale.UseVisualStyleBackColor = True
        ' 
        ' frmInsertFemale
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        AutoSize = True
        AutoSizeMode = AutoSizeMode.GrowAndShrink
        ClientSize = New Size(286, 212)
        Controls.Add(btnInsertFemale)
        Controls.Add(txtImageURL)
        Controls.Add(txtName)
        Controls.Add(lblImageURL)
        Controls.Add(lblName)
        Name = "frmInsertFemale"
        Text = "Insert Female"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents lblName As Label
    Friend WithEvents lblImageURL As Label
    Friend WithEvents txtName As TextBox
    Friend WithEvents txtImageURL As TextBox
    Friend WithEvents btnInsertFemale As Button
End Class
