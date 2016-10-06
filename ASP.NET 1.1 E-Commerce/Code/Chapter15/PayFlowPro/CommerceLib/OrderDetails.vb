Imports System.Collections
Imports System.Text
Imports System.Data.SqlClient

Public Class OrderDetails
  Inherits CollectionBase

  Public TotalCost As Double = 0
  Public ListAsString As String

  Public Sub New(ByVal reader As SqlDataReader)
    ' check for details
    If reader.Read = False Then
      Throw New OrderProcessorException("Unable to obtain order details.", 100)
    End If
    ' construct string for item list and calculate total cost
    Dim builder As StringBuilder = New StringBuilder
    Dim newOrderDetail As OrderDetail
    Dim productsRemaining As Boolean = True
    While productsRemaining
      newOrderDetail = _
         New OrderDetail(reader("ProductID"), reader("ProductName"), _
                         Convert.ToDouble(reader("Quantity")), _
                         Convert.ToDouble(reader("UnitCost")))
      List.Add(newOrderDetail)
      builder.Append(newOrderDetail.ItemAsString)
      TotalCost += newOrderDetail.Cost
      builder.Append(Chr(10))
      productsRemaining = reader.Read()
    End While
    builder.Append(Chr(10))
    builder.Append("Total order cost: $")
    builder.Append(TotalCost.ToString())
    ListAsString = builder.ToString()
  End Sub

  Default Public Property Item(ByVal index As Integer) As OrderDetail
    Get
      Return CType(List(index), OrderDetail)
    End Get
    Set(ByVal Value As OrderDetail)
      List(index) = Value
    End Set
  End Property
End Class
