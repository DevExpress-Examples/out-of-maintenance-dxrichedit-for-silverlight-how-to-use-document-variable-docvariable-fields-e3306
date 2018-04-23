Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Net
Imports System.Web
Imports System.IO
Imports System.Text.RegularExpressions
Imports System.Xml
Imports System.Globalization
Imports DevExpress.Utils
Imports System.Windows.Browser
Imports System.Threading
Imports System.Xml.Linq
Imports System.Linq
Imports DevExpress.Xpf.Collections

Namespace DocumentVariablesExample
	Public Class GeoLocation
		Private Shared wbc As WebClient
		Private Shared coordinates As List(Of GeoLocation)

		Private _Latitude As Double
		Public Property Latitude() As Double
			Get
				Return _Latitude
			End Get
			Set(ByVal value As Double)
				_Latitude = value
			End Set
		End Property
		Private _Longitude As Double
		Public Property Longitude() As Double
			Get
				Return _Longitude
			End Get
			Set(ByVal value As Double)
				_Longitude = value
			End Set
		End Property
		Private _Address As String
		Public Property Address() As String
			Get
				Return _Address
			End Get
			Set(ByVal value As String)
				_Address = value
			End Set
		End Property

		Public Sub New(ByVal latitude As Double, ByVal longitude As Double, ByVal address As String)
			Me.Latitude = latitude
			Me.Longitude = longitude
			Me.Address = address
		End Sub


		Public Shared Function GeocodeAddress(ByVal address As String, ByVal _geolocationdata As ArrayList) As GeoLocation()
			coordinates = New List(Of GeoLocation)()

			Dim query = _
				From location As GeoLocation In _geolocationdata _
				Where location.Address = address _
				Select location

			For Each g As GeoLocation In query
				coordinates.Add(g)
			Next g
			Return coordinates.ToArray()
		End Function

	End Class
End Namespace
