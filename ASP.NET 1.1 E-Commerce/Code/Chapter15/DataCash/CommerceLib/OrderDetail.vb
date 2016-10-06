Imports System.Text

Public Class OrderDetail
  Public ProductID As String
  Public ProductName As String
  Public Quantity As Double
  Public UnitCost As Double
  Public ItemAsString As String
  Public Cost As Double

  Public Sub New(ByVal newProductID As String, ByVal newProductName As String, _
                 ByVal newQuantity As Double, ByVal newUnitCost As Double)
    ' initialize data
    ProductID = newProductID
    ProductName = newProductName
    Quantity = newQuantity
    UnitCost = newUnitCost
    Cost = UnitCost * Quantity

    ' construct item string for use in e-mails etc.
    Dim builder As StringBuilder = New StringBuilder
    builder.Append(Quantity.ToString())
    builder.Append(" ")
    builder.Append(ProductName)
    builder.Append(", $")
    builder.Append(UnitCost.ToString())
    builder.Append(" each, total cost $")
    builder.Append(Cost.ToString())
    ItemAsString = builder.ToString()
  End Sub
End Class
