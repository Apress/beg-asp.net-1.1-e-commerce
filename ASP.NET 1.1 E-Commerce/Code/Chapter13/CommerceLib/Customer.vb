Imports SecurityLib
Imports System.Text
Imports System.Data.SqlClient

Public Class Customer
  Public CustomerID As Integer
  Public Name As String
  Public Email As String
  Public CreditCard As SecureCard
  Public Address1 As String
  Public Address2 As String
  Public City As String
  Public Region As String
  Public PostalCode As String
  Public Country As String
  Public Phone As String
  Public AddressAsString As String

  Public Sub New(ByVal reader As SqlDataReader)
    ' check for customer
    If reader.Read = False Then
      Throw New OrderProcessorException( _
         "Unable to obtain customer information.", 100)
    End If

    ' initialize data
    CustomerID = reader("CustomerID")
    Name = reader("Name")
    Email = reader("Email")
    Address1 = reader("Address1")
    Address2 = reader("Address2")
    City = reader("City")
    Region = reader("Region")
    PostalCode = reader("PostalCode")
    Country = reader("Country")
    Phone = reader("Phone")

    ' get credit card details
    Try
      CreditCard = New SecureCard(reader("CreditCard"))
    Catch
      Throw New OrderProcessorException( _
         "Unable to retrieve credit card details.", 100)
    End Try

    ' construct address string
    Dim builder As StringBuilder = New StringBuilder
    builder.Append(Name)
    builder.Append(Chr(10))
    builder.Append(Address1)
    builder.Append(Chr(10))
    If Address2 <> "" Then
      builder.Append(Address2)
      builder.Append(Chr(10))
    End If
    builder.Append(City)
    builder.Append(Chr(10))
    builder.Append(Region)
    builder.Append(Chr(10))
    builder.Append(PostalCode)
    builder.Append(Chr(10))
    builder.Append(Country)
    AddressAsString = builder.ToString()
  End Sub
End Class

