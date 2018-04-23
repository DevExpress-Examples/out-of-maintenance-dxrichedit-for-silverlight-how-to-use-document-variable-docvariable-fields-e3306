Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Xml
Imports System.Net
Imports System.Web
Imports DevExpress.Utils
Imports System.Windows.Browser
Imports DevExpress.Xpf.Collections

Namespace DocumentVariablesExample
	Friend Class Weather

		Public Shared Function GetCurrentConditions(ByVal _city As String, ByVal _conditionsdata As ArrayList) As Conditions
			Dim weather_conditions As New List(Of Conditions)()

			Dim query = _
				From conds As Conditions In _conditionsdata _
				Where conds.City = _city _
				Select conds

			For Each c As Conditions In query
				weather_conditions.Add(c)
			Next c

			Return weather_conditions(0)
		End Function


	End Class
	Public Class Conditions
		Private city_Renamed As String = "No Data"
		Private dayOfWeek As String = DateTime.Now.DayOfWeek.ToString()
		Private condition_Renamed As String = "No Data"

		Public Property City() As String
			Get
				Return city_Renamed
			End Get
			Set(ByVal value As String)
				city_Renamed = value
			End Set
		End Property

		Public Property Condition() As String
			Get
				Return condition_Renamed
			End Get
			Set(ByVal value As String)
				condition_Renamed = value
			End Set
		End Property

		Public Sub New(ByVal city As String, ByVal condition As String)
			Me.City = city
			Me.Condition = condition
		End Sub
	End Class
End Namespace
