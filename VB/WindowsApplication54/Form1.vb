Imports Microsoft.VisualBasic
Imports System
Imports System.IO
Imports System.Reflection
Imports System.Windows.Forms
Imports DevExpress.Xpo
Imports DevExpress.Xpo.DB
Imports DevExpress.Xpo.Metadata
Imports DevExpress.XtraReports.Extensions
Imports DevExpress.XtraReports.UI
' ...

Namespace WindowsApplication54
	Partial Public Class Form1
		Inherits Form
		Shared Sub New()
			ReportExtension.RegisterExtensionGlobal(New ReportExtension())
			ReportDesignExtension.RegisterExtension(New DesignExtension(), ExtensionName)
			Dim fileName As String = _ 
			    Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) & "\person.mdb"
			If (Not File.Exists(fileName)) Then
				Dim session As UnitOfWork = CreateSessionByName("person.mdb")
				If New XPCollection(Of Person)(session).Count < 6 Then
					Person.Create(session, "Name1")
					Person.Create(session, "Name2")
					Person.Create(session, "Name3")
					Person.Create(session, "Name4")
					Person.Create(session, "Name5")
					Person.Create(session, "Name6")
					session.CommitChanges()
				End If
			End If
		End Sub
		Private Shared Function CreateSessionByName(ByVal name As String) As UnitOfWork
			Dim connectionString As String = AccessConnectionProvider.GetConnectionString(name)
			Return CreateSession(connectionString)
		End Function
		Private Shared Function CreateDataSource(ByVal session As UnitOfWork) As XPCollection(Of Person)
			Return New XPCollection(Of Person)(session)
		End Function
		Public Shared Function CreateSession(ByVal connectionString As String) As UnitOfWork
			Dim result As New UnitOfWork()
			result.ConnectionString = connectionString
			Return result
		End Function

		Private Const ExtensionName As String = "Custom"

		Public Sub New()
			InitializeComponent()
		End Sub
		Private Sub createReportWhithDataSourceButton_Click(ByVal sender As Object, ByVal e As EventArgs) _ 
		    Handles createReportWhithDataSourceButton.Click
			Using session As UnitOfWork = CreateSessionByName("person.mdb")
				Dim report As New XtraReport()
				ReportDesignExtension.AssociateReportWithExtension(report, ExtensionName)
				report.DataSource = CreateDataSource(session)
				report.ShowDesignerDialog()
			End Using
		End Sub
		Private Sub createEmptyReportButton_Click(ByVal sender As Object, ByVal e As EventArgs) _ 
		    Handles createEmptyReportButton.Click
			CType(New XtraReport(), XtraReport).ShowDesignerDialog()
		End Sub
		Private Class ReportExtension
			Inherits ReportStorageExtension
			Public Overrides Sub SetData(ByVal report As XtraReport, ByVal stream As Stream)
				report.SaveLayoutToXml(stream)
			End Sub
			Public Overrides Sub SetData(ByVal report As XtraReport, ByVal url As String)
				report.SaveLayoutToXml(url)
			End Sub
		End Class
		Private Class DesignExtension
			Inherits ReportDesignExtension
			Protected Overrides Function CanSerialize(ByVal data As Object) As Boolean
				Return TypeOf data Is XPCollection(Of Person)
			End Function
			Protected Overrides Function SerializeData(ByVal data As Object, ByVal report As XtraReport) As String
				Dim collection As XPCollection(Of Person) = TryCast(data, XPCollection(Of Person))
				If collection IsNot Nothing Then
					Return collection.Session.ConnectionString
				End If
				Return MyBase.SerializeData(data, report)
			End Function
			Protected Overrides Function CanDeserialize(ByVal value As String, ByVal typeName As String) As Boolean
				Return GetType(XPCollection(Of Person)).FullName = typeName
			End Function
			Protected Overrides Function DeserializeData(ByVal value As String, _ 
			    ByVal typeName As String, ByVal report As XtraReport) As Object
				If GetType(XPCollection(Of Person)).FullName = typeName Then
					Dim result As New XPCollection(Of Person)()
					result.Session = Form1.CreateSession(value)
					Return result
				End If
				Return MyBase.DeserializeData(value, typeName, report)
			End Function
		End Class
	End Class
End Namespace