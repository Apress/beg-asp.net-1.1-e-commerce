Imports System.Data.SqlClient
Public Class OrderManager
    Private Shared ReadOnly Property connectionString() As String
        Get
            Return ConfigurationSettings.AppSettings("ConnectionString")
        End Get
    End Property

    Public Shared Function GetOrderDetails(ByVal orderId As String) As SqlDataReader
        ' Create the Connection object
        Dim connection As New SqlConnection(connectionString)
        ' Create and initialize the Command object
        Dim command As New SqlCommand("GetOrderDetails", connection)
        command.CommandType = CommandType.StoredProcedure
        ' Add an input parameter and set a value for it
        command.Parameters.Add("@OrderID", SqlDbType.Int)
        command.Parameters("@OrderID").Value = orderId
        ' Get the results
        Try
            ' Open the connection
            connection.Open()
            ' Return an SqlDataReader to the calling function
            Return command.ExecuteReader(CommandBehavior.CloseConnection)
        Catch e As Exception
            ' Close the connection and throw the exception
            connection.Close()
            Throw e
        End Try
    End Function

   Public Function GetStatuses() As SqlDataReader
      ' Create the connection object
      Dim connection As New SqlConnection(connectionString)

      ' Create and initialize the command object
      Dim command As New SqlCommand("GetStatuses", connection)
      command.CommandType = CommandType.StoredProcedure

      ' Return the results
      connection.Open()
      Return command.ExecuteReader(CommandBehavior.CloseConnection)
   End Function

   Public Function GetOrder(ByVal orderID As Integer) As SqlDataReader
      ' Create the connection object
      Dim connection As New SqlConnection(connectionString)

      ' Create and initialize the command object
      Dim command As New SqlCommand("GetOrder", connection)
      command.CommandType = CommandType.StoredProcedure

      ' Add an input parameter and supply a value for it
      command.Parameters.Add("@OrderID", SqlDbType.Int, 4)
      command.Parameters("@OrderID").Value = orderID

      ' Return the results
      connection.Open()
      Return command.ExecuteReader(CommandBehavior.CloseConnection)
   End Function

   Public Function GetOrders() As SqlDataReader
      ' Create the connection object
      Dim connection As New SqlConnection(connectionString)

      ' Create and initialize the command object
      Dim command As New SqlCommand("GetOrders", connection)
      command.CommandType = CommandType.StoredProcedure

      ' Return the results
      connection.Open()
      Return command.ExecuteReader(CommandBehavior.CloseConnection)
   End Function

   Public Function GetOrdersByRecent(ByVal count As Integer) As SqlDataReader
      ' Create the connection object
      Dim connection As New SqlConnection(connectionString)

      ' Create and initialize the command object
      Dim command As New SqlCommand("GetOrdersByRecent", connection)
      command.CommandType = CommandType.StoredProcedure

      ' Add an input parameter and supply a value for it
      command.Parameters.Add("@Count", SqlDbType.Int, 4)
      command.Parameters("@Count").Value = count

      ' Return the results
      connection.Open()
      Return command.ExecuteReader(CommandBehavior.CloseConnection)
   End Function

   Public Function GetOrdersByCustomer(ByVal customerID As Integer) _
         As SqlDataReader
      ' Create the connection object
      Dim connection As New SqlConnection(connectionString)

      ' Create and initialize the command object
      Dim command As New SqlCommand("GetOrdersByCustomer", connection)
      command.CommandType = CommandType.StoredProcedure

      ' Add an input parameter and supply a value for it
      command.Parameters.Add("@CustomerID", SqlDbType.Int, 4)
      command.Parameters("@CustomerID").Value = customerID

      ' Return the results
      connection.Open()
      Return command.ExecuteReader(CommandBehavior.CloseConnection)
   End Function

   Public Function GetOrdersByDate(ByVal startDate As String, _
         ByVal endDate As String) As SqlDataReader
      ' Create the connection object
      Dim connection As New SqlConnection(connectionString)

      ' Create and initialize the command object
      Dim command As New SqlCommand("GetOrdersByDate", connection)
      command.CommandType = CommandType.StoredProcedure

      ' Add an input parameter and supply a value for it
      command.Parameters.Add("@StartDate", SqlDbType.SmallDateTime)
      command.Parameters("@StartDate").Value = startDate

      ' Add an input parameter and supply a value for it
      command.Parameters.Add("@EndDate", SqlDbType.SmallDateTime)
      command.Parameters("@EndDate").Value = endDate

      ' Return the results
      connection.Open()
      Return command.ExecuteReader(CommandBehavior.CloseConnection)
   End Function

   Public Function GetOrdersByStatus(ByVal status As Integer) As SqlDataReader
      ' Create the connection object
      Dim connection As New SqlConnection(connectionString)

      ' Create and initialize the command object
      Dim command As New SqlCommand("GetOrdersByStatus", connection)
      command.CommandType = CommandType.StoredProcedure

      ' Add an input parameter and supply a value for it
      command.Parameters.Add("@Status", SqlDbType.Int, 4)
      command.Parameters("@Status").Value = status

      ' Return the results
      connection.Open()
      Return command.ExecuteReader(CommandBehavior.CloseConnection)
   End Function

   Public Function GetAuditTrail(ByVal orderID As Integer) As SqlDataReader
      ' Create the connection object
      Dim connection As New SqlConnection(connectionString)

      ' Create and initialize the command object
      Dim command As New SqlCommand("GetAuditTrail", connection)
      command.CommandType = CommandType.StoredProcedure

      ' Add an input parameter and supply a value for it
      command.Parameters.Add("@OrderID", SqlDbType.Int, 4)
      command.Parameters("@OrderID").Value = orderID

      ' Return the results
      connection.Open()
      Return command.ExecuteReader(CommandBehavior.CloseConnection)
   End Function

   Public Function GetCustomerByOrderID(ByVal orderId As String) As SqlDataReader
      ' Create the Connection object
      Dim connection As New SqlConnection(connectionString)

      ' Create and initialize the Command object
      Dim command As New SqlCommand("GetCustomerByOrderID", connection)
      command.CommandType = CommandType.StoredProcedure

      ' Add an input parameter and set a value for it
      command.Parameters.Add("@OrderID", SqlDbType.Int)
      command.Parameters("@OrderID").Value = orderId

      ' Get the command results as a SqlDataReader
      connection.Open()
      Return command.ExecuteReader(CommandBehavior.CloseConnection)
   End Function
End Class
