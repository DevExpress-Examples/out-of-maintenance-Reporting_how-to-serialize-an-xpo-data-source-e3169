Imports Microsoft.VisualBasic
Imports System
Namespace WindowsApplication54
	Partial Public Class Form1
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso (components IsNot Nothing) Then
				components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Windows Form Designer generated code"

		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.createReportWhithDataSourceButton = New System.Windows.Forms.Button()
			Me.createEmptyReportButton = New System.Windows.Forms.Button()
			Me.SuspendLayout()
			' 
			' createReportWhithDataSourceButton
			' 
			Me.createReportWhithDataSourceButton.Location = New System.Drawing.Point(12, 47)
			Me.createReportWhithDataSourceButton.Name = "createReportWhithDataSourceButton"
			Me.createReportWhithDataSourceButton.Size = New System.Drawing.Size(260, 42)
			Me.createReportWhithDataSourceButton.TabIndex = 0
			Me.createReportWhithDataSourceButton.Text = "Create a Data-Aware Report"
			Me.createReportWhithDataSourceButton.UseVisualStyleBackColor = True
'			Me.createReportWhithDataSourceButton.Click += New System.EventHandler(Me.createReportWhithDataSourceButton_Click);
			' 
			' createEmptyReportButton
			' 
			Me.createEmptyReportButton.Location = New System.Drawing.Point(12, 124)
			Me.createEmptyReportButton.Name = "createEmptyReportButton"
			Me.createEmptyReportButton.Size = New System.Drawing.Size(260, 42)
			Me.createEmptyReportButton.TabIndex = 0
			Me.createEmptyReportButton.Text = "Create a Blank Report"
			Me.createEmptyReportButton.UseVisualStyleBackColor = True
'			Me.createEmptyReportButton.Click += New System.EventHandler(Me.createEmptyReportButton_Click);
			' 
			' Form1
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(284, 262)
			Me.Controls.Add(Me.createEmptyReportButton)
			Me.Controls.Add(Me.createReportWhithDataSourceButton)
			Me.Name = "Form1"
			Me.Text = "Form1"
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Private WithEvents createReportWhithDataSourceButton As System.Windows.Forms.Button
		Private WithEvents createEmptyReportButton As System.Windows.Forms.Button
	End Class
End Namespace

