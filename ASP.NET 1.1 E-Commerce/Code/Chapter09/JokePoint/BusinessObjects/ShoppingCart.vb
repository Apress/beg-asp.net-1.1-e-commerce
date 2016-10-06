Imports System.Data.SqlClient

Public Class ShoppingCart
    Private Shared ReadOnly Property shoppingCartId()
        Get
            Dim context As HttpContext = HttpContext.Current

            ' If the JokePoint_CartID cookie doesn't exit
            ' on client machine we create it with a new GUID
            If context.Request.Cookies("JokePoint_CartID") Is Nothing Then
                ' Generate a new GUID
                Dim cartId As Guid = Guid.NewGuid()
                ' Create the cookie and set its value
                Dim cookie As New HttpCookie("JokePoint_CartID", cartId.ToString)
                ' Current Date
                Dim currentDate As DateTime = DateTime.Now()
                ' Set the time span to 10 days
                Dim ts As New TimeSpan(10, 0, 0, 0)
                ' Expiration Date
                Dim expirationDate As DateTime = currentDate.Add(ts)
                ' Set the Expiration Date to the cookie
                cookie.Expires = expirationDate
                ' Set the cookie on client's browser
                context.Response.Cookies.Add(cookie)
                ' return the Cart ID
                Return cartId.ToString()
            Else
                ' return the value stored in JokePoint_CartID
                Return context.Request.Cookies("JokePoint_CartID").Value
            End If
        End Get
    End Property

    Private Shared ReadOnly Property connectionString() As String
        Get
            Return ConfigurationSettings.AppSettings("ConnectionString")
        End Get
    End Property

    Public Shared Function AddProduct(ByVal productId As String)
        ' Create the connection object
        Dim connection As New SqlConnection(connectionString)
        ' Create and initialize the command object
        Dim command As New SqlCommand("AddProductToCart", connection)
        command.CommandType = CommandType.StoredProcedure
        ' Add an input parameter and supply a value for it
        command.Parameters.Add("@CartID", SqlDbType.Char, 36)
        command.Parameters("@CartID").Value = shoppingCartId
        ' Add an input parameter and supply a value for it
        command.Parameters.Add("@ProductID", SqlDbType.Int)
        command.Parameters("@ProductID").Value = productId
        ' Open the connection, execute the command, and close the connection
        Try
            connection.Open()
            command.ExecuteNonQuery()
        Finally
            connection.Close()
        End Try
    End Function

    Public Shared Function UpdateProductQuantity(ByVal productId As String, ByVal quantity As Integer)
        ' Create the connection object
        Dim connection As New SqlConnection(connectionString)
        ' Create and initialize the command object
        Dim command As New SqlCommand("UpdateCartItem", connection)
        command.CommandType = CommandType.StoredProcedure
        ' Add an input parameter and supply a value for it
        command.Parameters.Add("@CartID", SqlDbType.Char, 36)
        command.Parameters("@CartID").Value = shoppingCartId
        ' Add an input parameter and supply a value for it
        command.Parameters.Add("@ProductID", SqlDbType.Int)
        command.Parameters("@ProductID").Value = productId
        ' Add an input parameter and supply a value for it
        command.Parameters.Add("@Quantity", SqlDbType.Int)
        command.Parameters("@Quantity").Value = quantity
        ' Open the connection, execute the command, and close the connection
        Try
            connection.Open()
            command.ExecuteNonQuery()
        Finally
            connection.Close()
        End Try
    End Function

    Public Shared Function RemoveProduct(ByVal productId As String)
        ' Create the connection object
        Dim connection As New SqlConnection(connectionString)
        ' Create and initialize the command object
        Dim command As New SqlCommand("RemoveProductFromCart", connection)
        command.CommandType = CommandType.StoredProcedure
        ' Add an input parameter and supply a value for it
        command.Parameters.Add("@CartID", SqlDbType.Char, 36)
        command.Parameters("@CartID").Value = shoppingCartId
        ' Add an input parameter and supply a value for it
        command.Parameters.Add("@ProductID", SqlDbType.Int)
        command.Parameters("@ProductID").Value = productId
        ' Open the connection, execute the command, and close the connection
        Try
            connection.Open()
            command.ExecuteNonQuery()
        Finally
            connection.Close()
        End Try
    End Function

    Public Shared Function GetProducts() As SqlDataReader
        ' Create the connection object
        Dim connection As New SqlConnection(connectionString)
        ' Create and initialize the command object
        Dim command As New SqlCommand("GetShoppingCartProducts", connection)
        command.CommandType = CommandType.StoredProcedure
        ' Add an input parameter and supply a value for it
        command.Parameters.Add("@CartID", SqlDbType.Char, 36)
        command.Parameters("@CartID").Value = shoppingCartId
        Try
            ' Open the connection and return the results
            connection.Open()
            Return command.ExecuteReader(CommandBehavior.CloseConnection)
        Catch e As Exception
            ' Close the connection and throw the exception
            connection.Close()
            Throw e
        End Try
    End Function

    Public Shared Function GetTotalAmount() As Decimal
        ' Create the connection object
        Dim connection As New SqlConnection(connectionString)
        ' Create and initialize the command object
        Dim command As SqlCommand = New SqlCommand("GetTotalAmount", connection)
        command.CommandType = CommandType.StoredProcedure
        ' Add an input parameter and supply a value for it
        command.Parameters.Add("@CartID", SqlDbType.Char, 36)
        command.Parameters("@CartID").Value = shoppingCartId
        ' The amount has a default value of 0
        Dim amount As Decimal = 0
        Try
            ' Try to get the amount from the database
            connection.Open()
            amount = command.ExecuteScalar()
        Finally
            ' Close the connection
            connection.Close()
        End Try
        ' Return the amount
        Return amount
    End Function

    ' Removes ViewCart parameters from the query string
    Public Shared Function RemoveCartFromQueryString() As String
        ' Will contain the query string without the ViewCart parameters
        Dim newQueryString As String = String.Empty
        Try
            ' query stores the current query string
            Dim query As System.Collections.Specialized.NameValueCollection
            query = HttpContext.Current.Request.QueryString
            ' Will hold the name of each query string parameter
            Dim paramName As String
            ' Will host the value of each query string parameter
            Dim paramValue As String
            ' Used to parse the query string
            Dim i As Integer
            ' Parse every element of the query string
            For i = 0 To query.Count - 1
                ' We guard against null (Nothing) parameters
                If Not query.AllKeys(i) Is Nothing Then
                    ' Get the parameter name 
                    paramName = query.AllKeys(i).ToString()
                    ' Test to see if the parameter is not ViewCart
                    If paramName.ToUpper <> "VIEWCART" Then
                        ' Get the value of the parameter
                        paramValue = query.Item(i)
                        ' Append the parameter to the page
                        newQueryString = newQueryString + paramName + "=" + paramValue + "&"
                    End If
                End If
            Next
        Catch ex As Exception
            ' If something goes wrong we redirect to the main page
            Return String.Empty
        End Try
        Return newQueryString
    End Function

    Public Shared Function CleanShoppingCart(ByVal days As Integer)
        ' Create the connection object
        Dim connection As New SqlConnection(connectionString)
        ' Create and initialize the command object
        Dim command As New SqlCommand("CleanShoppingCart", connection)
        command.CommandType = CommandType.StoredProcedure
        ' Add an input parameter and supply a value for it
        command.Parameters.Add("@Days", SqlDbType.SmallInt)
        command.Parameters("@Days").Value = days
        ' Open the connection, execute the command, close the connection
        Try
            connection.Open()
            command.ExecuteNonQuery()
        Finally
            connection.Close()
        End Try
    End Function

    Public Shared Function CountOldShoppingCartElements(ByVal days As Integer) As Integer
        ' Create the connection object
        Dim connection As New SqlConnection(connectionString)
        ' Create and initialize the command object
        Dim command As New SqlCommand("CountOldShoppingCartElements", connection)
        command.CommandType = CommandType.StoredProcedure
        ' Add an input parameter and supply a value for it
        command.Parameters.Add("@Days", SqlDbType.SmallInt)
        command.Parameters("@Days").Value = days
        ' Execute the command and return the result
        Dim count As Integer = 0
        Try
            ' Execute the command and get the result
            connection.Open()
            count = command.ExecuteScalar()
        Finally
            ' Close the connection
            connection.Close()
        End Try
        ' Return the count value
        Return count
    End Function

End Class
