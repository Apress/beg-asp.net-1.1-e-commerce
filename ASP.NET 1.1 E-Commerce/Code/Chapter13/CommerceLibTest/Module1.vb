Imports System.Data.SqlClient
Imports CommerceLib

Module Module1

  Sub Main()
    ' Code for 1st try it out
    Dim customerID As Integer = 2
    Dim orderID As Integer = 3
    Dim Connection As SqlConnection = _
       New SqlConnection( _
          "server=(local);Integrated Security=SSPI;database=JokePoint")

    Dim customerCommand As SqlCommand = _
       New SqlCommand("GetCustomer", Connection)
    customerCommand.CommandType = CommandType.StoredProcedure
    customerCommand.Parameters.Add("@CustomerID", customerID)
    Connection.Open()
    Dim customerObj As Customer = New Customer(customerCommand.ExecuteReader)
    Connection.Close()
    Console.WriteLine("Customer found. Address:")
    Console.WriteLine(customerObj.AddressAsString)
    Console.WriteLine("Customer credit card number: {0}", _
                      customerObj.CreditCard.CardNumberX)
    Console.WriteLine()

    Dim orderCommand As SqlCommand = _
       New SqlCommand("GetOrderDetails", Connection)
    orderCommand.CommandType = CommandType.StoredProcedure
    orderCommand.Parameters.Add("@OrderID", orderID)
    Connection.Open()
    Dim orderObj As OrderDetails = New OrderDetails(orderCommand.ExecuteReader)
    Connection.Close()
    Console.WriteLine("Order found. Details:")
    Console.WriteLine(orderObj.ListAsString)
    Console.WriteLine()
    Console.WriteLine("List of item names:")
    Dim item As OrderDetail
    For Each item In orderObj
      Console.WriteLine(item.ProductName)
    Next

    '' Code for 2nd try it out
    'Dim configuration As OrderProcessorConfiguration = _
    '  New OrderProcessorConfiguration( _
    '    "Server=server=(local);Integrated Security=SSPI;database=JokePoint", _
    '    "MailServer", _
    '    "AdminEMail", _
    '    "customerservice@JokePoint.com", _
    '    "orderprocessor@JokePoint.com", _
    '    "SupplierEMail")
    'Dim processor As New OrderProcessor
    '' processor.Process(ByVal orderID As Integer, ByVal configuration As
    '' OrderProcessorConfiguration)
    'processor.Process(1, configuration)
  End Sub

End Module
