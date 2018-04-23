Imports Microsoft.VisualBasic
Imports System
Imports System.Text
Imports DevExpress.Xpf.Collections
Imports System.Collections.Generic

Namespace DocumentVariablesExample
	Friend Class SampleData
		Inherits ArrayList
		Public Sub New()
			Add(New AddresseeRecord("Maria", "Alfreds Futterkiste", "Obere Str. 57, Berlin", "Berlin"))
			Add(New AddresseeRecord("Laurence", "Bon app'", "12, rue des Bouchers, Marseille", "Marseille"))
			Add(New AddresseeRecord("Patricio", "Cactus Comidas para llevar", "Cerrito 333, Buenos Aires", "Buenos Aires"))
			Add(New AddresseeRecord("Thomas", "Around the Horn", "120 Hanover Sq., London", "London"))
			Add(New AddresseeRecord("Boris", "Express Developers", "Krasnoarmeiskiy prospect 25, Tula", "Tula"))
		End Sub
	End Class

	Public Class AddresseeRecord
		Private _Name As String
		Private _Company As String
		Private _Address As String
		Private _City As String

		Public Property Name() As String
			Get
				Return _Name
			End Get
			Set(ByVal value As String)
				_Name = value
			End Set
		End Property
		Public Property Company() As String
			Get
				Return _Company
			End Get
			Set(ByVal value As String)
				_Company = value
			End Set
		End Property
		Public Property Address() As String
			Get
				Return _Address
			End Get
			Set(ByVal value As String)
				_Address = value
			End Set
		End Property
		Public Property City() As String
			Get
				Return _City
			End Get
			Set(ByVal value As String)
				_City = value
			End Set
		End Property

		Public Sub New(ByVal _Name As String, ByVal _Company As String, ByVal _Address As String, ByVal _City As String)
			Me._Name = _Name
			Me._Company = _Company
			Me._Address = _Address
			Me._City = _City
		End Sub
	End Class

	Friend Class GeoLocationData
		Inherits ArrayList
		Public Sub New()
			Add(New GeoLocation(51.5001524, -0.126236, "London"))
			Add(New GeoLocation(54.1444253, 37.4897691, "Tula"))
			Add(New GeoLocation(52.5234051, 13.4113999, "Berlin"))
			Add(New GeoLocation(43.1664080, 5.1136612, "Marseille"))
			Add(New GeoLocation(-34.6084175, -58.3731613, "Buenos Aires"))
		End Sub
	End Class

	Friend Class ConditionsData
		Inherits ArrayList
		Public Sub New()
			Add(New Conditions("London","Chance of Rain"))
			Add(New Conditions("Tula","Partly Cloudy"))
			Add(New Conditions("Berlin","Chance of Storm"))
			Add(New Conditions("Marseille", "Sunny"))
			Add(New Conditions("Buenos Aires","Overcast"))
		End Sub

	End Class
End Namespace
