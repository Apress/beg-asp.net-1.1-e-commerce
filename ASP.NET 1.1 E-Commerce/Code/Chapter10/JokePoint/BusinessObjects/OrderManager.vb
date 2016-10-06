Imports System.Data.SqlClient

Public Class OrderInfo
    Public OrderID As String
    Public TotalAmount As Decimal
    Public DateCreated As String
    Public DateShipped As String
    Public Verified As Boolean
    Public Completed As Boolean
    Public Canceled As Boolean
    Public Comments As String
    Public CustomerName As String
    Public ShippingAddress As String
    Public CustomerEmail As String
End Class

Public Class OrderManager
    Private Shared ReadOnly Property connectionString() As String
        Get
            Return ConfigurationSettings.AppSettings("ConnectionString")
        End Get
    End Property

    Public Shared Function GetMostRecentOrders(ByVal count As Integer) As SqlDataReader
        ' Create the connection object
        Dim connection As New SqlConnection(connectionString)
        ' Create and initialize the command object
        Dim command As New SqlCommand("GetMostRecentOrders", connection)
        command.CommandType = CommandType.StoredProcedure
        ' Add an input parameter and supply a value for it
        command.Parameters.Add("@Count", SqlDbType.SmallInt)
        command.Parameters("@Count").Value = count
        ' Return the results
        Try
            ' Open the connection
            connection.Open()
            ' Return an SqlDataReader to the calling function
            Return command.ExecuteReader(CommandBehavior.CloseConnection)
        Catch e As Exception
            ' Close the connection and rethrow the exception
            connection.Close()
            Throw e
        End Try
    End Function

    Public Shared Function GetOrdersBetweenDates(ByVal startDate As String, ByVal endDate As String) As SqlDataReader
        ' Create the connection object
        Dim connection As New SqlConnection(connectionString)
        ' Create and initialize the command object
        Dim command As New SqlCommand("GetOrdersBetweenDates", connection)
        command.CommandType = CommandType.StoredProcedure
        ' Add an input parameter and supply a value for it
        command.Parameters.Add("@StartDate", SqlDbType.SmallDateTime)
        command.Parameters("@StartDate").Value = startDate
        ' Add an input parameter and supply a value for it
        command.Parameters.Add("@EndDate", SqlDbType.SmallDateTime)
        command.Parameters("@EndDate").Value = endDate
        ' Return the results
        Try
            ' Open the connection
            connection.Open()
            ' Return an SqlDataReader to the calling function
            Return command.ExecuteReader(CommandBehavior.CloseConnection)
        Catch e As Exception
            ' Close the connection and rethrow the exception
            connection.Close()
            Throw e
        End Try
    End Function

    Public Shared Function GetUnverifiedUncanceledOrders() As SqlDataReader
        ' Create the connection object
        Dim connection As New SqlConnection(connectionString)
        ' Create and initialize the command object
        Dim command As New SqlCommand("GetUnverifiedUncanceledOrders", connection)
        command.CommandType = CommandType.StoredProcedure
        ' Return the results
        Try
            ' Open the connection
            connection.Open()
            ' Return an SqlDataReader to the calling function
            Return command.ExecuteReader(CommandBehavior.CloseConnection)
        Catch e As Exception
            ' Close the connection and rethrow the exception
            connection.Close()
            Throw e
        End Try
    End Function

    Public Shared Function GetVerifiedUncompletedOrders() As SqlDataReader
        ' Create the connection object
        Dim connection As New SqlConnection(connectionString)
        ' Create and initialize the command object
        Dim command As New SqlCommand("GetVerifiedUncompletedOrders", connection)
        command.CommandType = CommandType.StoredProcedure
        ' Return the results
        Try
            ' Open the connection
            connection.Open()
            ' Return an SqlDataReader to the calling function
            Return command.ExecuteReader(CommandBehavior.CloseConnection)
        Catch e As Exception
            ' Close the connection and rethrow the exception
            connection.Close()
            Throw e
        End Try
    End Function

    Public Shared Function GetOrderInfo(ByVal orderId As String) As OrderInfo
        ' Create the Connection object
        Dim connection As New SqlConnection(connectionString)
        ' Create and initialize the Command object
        Dim command As New SqlCommand("GetOrderInfo", connection)
        command.CommandType = CommandType.StoredProcedure
        ' Add an input parameter and set a value for it
        command.Parameters.Add("@OrderID", SqlDbType.Int)
        command.Parameters("@OrderID").Value = orderId
        ' The SqlDataReader object used to get the results
        Dim reader As SqlDataReader
        ' Get the results
        Try
            ' Open the connection
            connection.Open()
            ' Return an SqlDataReader to the calling function
            reader = command.ExecuteReader(CommandBehavior.CloseConnection)
        Catch e As Exception
            ' Close the connection and throw the exception
            connection.Close()
            Throw e
        End Try
        ' We move to the first (and only) record in the reader object
        ' and store the information in an OrderInfo object. 
        Dim orderInfo As New OrderInfo
        If reader.Read() Then ' returns true if there are records 
            orderInfo.OrderID = reader("OrderID").ToString()
            orderInfo.TotalAmount = reader("TotalAmount").ToString()
            orderInfo.DateCreated = reader("DateCreated").ToString()
            orderInfo.DateShipped = reader("DateShipped").ToString()
            orderInfo.Verified = Boolean.Parse(reader("Verified").ToString())
            orderInfo.Completed = Boolean.Parse(reader("Completed").ToString())
            orderInfo.Canceled = Boolean.Parse(reader("Canceled").ToString())
            orderInfo.Comments = reader("Comments").ToString()
            orderInfo.CustomerName = reader("CustomerName").ToString()
            orderInfo.ShippingAddress = reader("ShippingAddress").ToString()
            orderInfo.CustomerEmail = reader("CustomerEmail").ToString()
            ' Close the reader and its connection
            reader.Close()
            connection.Close()
        End If
        ' Return the information in the form of an OrderInfo object
        Return orderInfo
    End Function

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

    Public Shared Sub UpdateOrder(ByVal orderInfo As OrderInfo)
        ' Create the Connection object
        Dim connection As New SqlConnection(connectionString)
        ' Create and initialize the Command object
        Dim command As New SqlCommand("UpdateOrder", connection)
        command.CommandType = CommandType.StoredProcedure
        ' Add the @Verified parameter
        command.Parameters.Add("@Verified", SqlDbType.Bit)
        If orderInfo.Verified Then
            command.Parameters("@Verified").Value = 1
        Else
            command.Parameters("@Verified").Value = 0
        End If
        ' Add the @Completed parameter
        command.Parameters.Add("@Completed", SqlDbType.Bit)
        If orderInfo.Completed Then
            command.Parameters("@Completed").Value = 1
        Else
            command.Parameters("@Completed").Value = 0
        End If
        ' Add the @Canceled parameter
        command.Parameters.Add("@Canceled", SqlDbType.Bit)
        If orderInfo.Canceled Then
            command.Parameters("@Canceled").Value = 1
        Else
            command.Parameters("@Canceled").Value = 0
        End If
        ' Add the @OrderID parameter and set its value
        command.Parameters.Add("@OrderID", SqlDbType.Int)
        command.Parameters("@OrderID").Value = orderInfo.OrderID
        ' Add the @DateCreated parameter and set its value
        command.Parameters.Add("@DateCreated", SqlDbType.SmallDateTime)
        command.Parameters("@DateCreated").Value = orderInfo.DateCreated
        ' @DateShipped will be sent only if the user typed a date in that
        ' text box; otherwise we don't send this parameter, as its default
        ' value in the stored procedure is NULL
        If orderInfo.DateShipped.Trim <> "" Then
            command.Parameters.Add("@DateShipped", SqlDbType.SmallDateTime)
            command.Parameters("@DateShipped").Value = orderInfo.DateShipped
        End If
        ' Add the @Comments parameter and set its value
        command.Parameters.Add("@Comments", SqlDbType.VarChar, 200)
        command.Parameters("@Comments").Value = orderInfo.Comments
        ' Add the @CustomerName parameter and set its value
        command.Parameters.Add("@CustomerName", SqlDbType.VarChar, 50)
        command.Parameters("@CustomerName").Value = orderInfo.CustomerName
        ' Add the @ShippingAddress parameter and set its value
        command.Parameters.Add("@ShippingAddress", SqlDbType.VarChar, 200)
        command.Parameters("@ShippingAddress").Value = orderInfo.ShippingAddress
        ' Add the @CustomerEmail parameter and set its value
        command.Parameters.Add("@CustomerEmail", SqlDbType.VarChar, 50)
        command.Parameters("@CustomerEmail").Value = orderInfo.CustomerEmail
        ' Execute the command, making sure the connection gets closed
        Try
            connection.Open()
            command.ExecuteNonQuery()
        Finally
            connection.Close()
        End Try
    End Sub

    Public Shared Sub MarkOrderAsVerified(ByVal orderId As String)
        ' Create the Connection object
        Dim connection As New SqlConnection(connectionString)
        ' Create and initialize the Command object
        Dim command As New SqlCommand("MarkOrderAsVerified", connection)
        command.CommandType = CommandType.StoredProcedure
        ' Add an input parameter and set a value for it
        command.Parameters.Add("@OrderID", SqlDbType.Int)
        command.Parameters("@OrderID").Value = orderId
        ' Execute the command, making sure the connection gets closed
        Try
            connection.Open()
            command.ExecuteNonQuery()
        Finally
            connection.Close()
        End Try
    End Sub

    Public Shared Sub MarkOrderAsCompleted(ByVal orderId As String)
        ' Create the Connection object
        Dim connection As New SqlConnection(connectionString)
        ' Create and initialize the Command object
        Dim command As New SqlCommand("MarkOrderAsCompleted", connection)
        command.CommandType = CommandType.StoredProcedure
        ' Add an input parameter and set a value for it
        command.Parameters.Add("@OrderID", SqlDbType.Int)
        command.Parameters("@OrderID").Value = orderId
        ' Execute the command, making sure the connection gets closed
        Try
            connection.Open()
            command.ExecuteNonQuery()
        Finally
            connection.Close()
        End Try
    End Sub

    Public Shared Sub MarkOrderAsCanceled(ByVal orderId As String)
        ' Create the Connection object
        Dim connection As New SqlConnection(connectionString)
        ' Create and initialize the Command object
        Dim command As New SqlCommand("MarkOrderAsCanceled", connection)
        command.CommandType = CommandType.StoredProcedure
        ' Add an input parameter and set a value for it
        command.Parameters.Add("@OrderID", SqlDbType.Int)
        command.Parameters("@OrderID").Value = orderId
        ' Execute the command, making sure the connection gets closed
        Try
            connection.Open()
            command.ExecuteNonQuery()
        Finally
            connection.Close()
        End Try
    End Sub

End Class
