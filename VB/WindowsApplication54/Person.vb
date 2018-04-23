Imports Microsoft.VisualBasic
Imports System
Imports System.Text
Imports System.Collections.Generic
Imports DevExpress.Xpo
' ...

Namespace WindowsApplication54
	Public Class Person
		Inherits XPObject
		Public Shared Function Create(ByVal session As Session, ByVal name As String) As Person
			Dim person As New Person(session)
			person.Name = name
			Return person
		End Function
		Private name_Renamed As String

		Public Sub New(ByVal session As Session)
			MyBase.New(session)
		End Sub

		Public Property Name() As String
			Get
				Return name_Renamed
			End Get
			Set(ByVal value As String)
				name_Renamed = value
			End Set
		End Property
	End Class

End Namespace
