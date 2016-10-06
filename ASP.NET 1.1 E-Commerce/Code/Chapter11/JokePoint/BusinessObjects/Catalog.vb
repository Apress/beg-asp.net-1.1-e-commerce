Imports System.Data.SqlClient

Public Class DepartmentDetails
    Public Name As String
    Public Description As String
End Class

Public Class CategoryDetails
    Public Name As String
    Public Description As String
End Class

Public Class Catalog
    Public Shared Function GetDepartments() As SqlDataReader
        ' Create the connection object
        Dim connection As New SqlConnection(connectionString)
        ' Create and initialize the command object
        Dim command As New SqlCommand("GetDepartments", connection)
        command.CommandType = CommandType.StoredProcedure
        ' Open the connection
        connection.Open()
        ' Return a SqlDataReader to the calling function
        Return command.ExecuteReader(CommandBehavior.CloseConnection)
    End Function

    Public Shared Function GetDepartmentDetails(ByVal departmentId As String) As DepartmentDetails
        ' Create the connection object
        Dim connection As New SqlConnection(connectionString)
        ' Create and initialize the command object
        Dim command As New SqlCommand("GetDepartmentDetails", connection)
        command.CommandType = CommandType.StoredProcedure
        ' Add an input parameter and supply a value for it
        command.Parameters.Add("@DepartmentID", SqlDbType.Int, 4)
        command.Parameters("@DepartmentID").Value = departmentId
        ' Add an output parameter
        command.Parameters.Add("@DepartmentName", SqlDbType.VarChar, 50)
        command.Parameters("@DepartmentName").Direction = ParameterDirection.Output
        ' Add an output parameter
        command.Parameters.Add("@DepartmentDescription", SqlDbType.VarChar, 200)
        command.Parameters("@DepartmentDescription").Direction = ParameterDirection.Output
        ' Open the connection, execute the command, and close the connection
        Try
            connection.Open()
            command.ExecuteNonQuery()
        Finally
            connection.Close()
        End Try
        ' Populate a DepartmentDetails object with data from output parameters
        Dim details As New DepartmentDetails
        details.Name = command.Parameters("@DepartmentName").Value.ToString()
        details.Description = command.Parameters("@DepartmentDescription").Value.ToString()
        ' Return the DepartmentDetails object to the calling function
        Return details
    End Function

    Public Shared Function GetCategoriesInDepartment(ByVal departmentId As String) As SqlDataReader
        ' Create the connection object
        Dim connection As New SqlConnection(connectionString)
        ' Create and initialize the command object
        Dim command As New SqlCommand("GetCategoriesInDepartment", connection)
        command.CommandType = CommandType.StoredProcedure
        ' Add an input parameter and supply a value for it
        command.Parameters.Add("@DepartmentID", SqlDbType.Int, 4)
        command.Parameters("@DepartmentID").Value = departmentId
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

    Public Shared Function GetCategoryDetails(ByVal categoryId As String) As CategoryDetails
        ' Create the connection object
        Dim connection As New SqlConnection(connectionString)
        ' Create and initialize the command object
        Dim command As New SqlCommand("GetCategoryDetails", connection)
        command.CommandType = CommandType.StoredProcedure
        ' Add an input parameter and supply a value for it
        command.Parameters.Add("@CategoryID", SqlDbType.Int, 4)
        command.Parameters("@CategoryID").Value = categoryId
        ' Add an output parameter
        command.Parameters.Add("@CategoryName", SqlDbType.VarChar, 50)
        command.Parameters("@CategoryName").Direction = ParameterDirection.Output
        ' Add an output parameter
        command.Parameters.Add("@CategoryDescription", SqlDbType.VarChar, 200)
        command.Parameters("@CategoryDescription").Direction = ParameterDirection.Output
        ' Open the connection, execute the command, and close the connection
        Try
            connection.Open()
            command.ExecuteNonQuery()
        Finally
            connection.Close()
        End Try
        ' Populate a CategoryDetails object with data from output parameters
        Dim details As New CategoryDetails
        details.Name = command.Parameters("@CategoryName").Value.ToString()
        details.Description = command.Parameters("@CategoryDescription").Value.ToString()
        ' Return the CategoryDetails object to the calling function
        Return details
    End Function

    Public Shared Function GetProductsInCategory(ByVal categoryId As String) As SqlDataReader
        ' Create the connection object
        Dim connection As New SqlConnection(connectionString)
        ' Create and initialize the command object
        Dim command As New SqlCommand("GetProductsInCategory", connection)
        command.CommandType = CommandType.StoredProcedure
        ' Add an input parameter and supply a value for it
        command.Parameters.Add("@CategoryID", SqlDbType.Int, 4)
        command.Parameters("@CategoryID").Value = categoryId
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

    Public Shared Function GetProductsOnDepartmentPromotion(ByVal departmentId As String) As SqlDataReader
        ' Create the connection object
        Dim connection As New SqlConnection(connectionString)
        ' Create and initialize the command object
        Dim command As New SqlCommand("GetProductsOnDepartmentPromotion", connection)
        command.CommandType = CommandType.StoredProcedure
        ' Add an input parameter and supply a value for it
        command.Parameters.Add("@DepartmentID", SqlDbType.Int, 4)
        command.Parameters("@DepartmentID").Value = departmentId
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

    Public Shared Function GetProductsOnCatalogPromotion() As SqlDataReader
        ' Create the connection object
        Dim connection As New SqlConnection(connectionString)
        ' Create and initialize the command object
        Dim command As New SqlCommand("GetProductsOnCatalogPromotion", connection)
        command.CommandType = CommandType.StoredProcedure

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

    Public Shared Function SearchCatalog(ByVal searchString As String, _
                   ByVal pageNumber As String, _
                   ByVal productsOnPage As String, _
                   ByVal allWords As String) _
                   As Integer
        ' Create the connection object
        Dim connection As New SqlConnection(connectionString)

        ' Create and initialize the command object
        Dim command As New SqlCommand("SearchCatalog", connection)
        command.CommandType = CommandType.StoredProcedure

        ' Add the @AllWords parameter
        ' Guard against bogus values here - if you receive anything
        ' different than "TRUE" assume it's "FALSE"
        If allWords.ToUpper = "TRUE" Then
            ' only do an "all words" search
            command.Parameters.Add("@AllWords", SqlDbType.Bit)
            command.Parameters("@AllWords").Value = 1
        Else
            ' only do an "any words" search
            command.Parameters.Add("@AllWords", SqlDbType.Bit)
            command.Parameters("@AllWords").Value = 0
        End If

        ' Add the @PageNumber parameter
        command.Parameters.Add("@PageNumber", SqlDbType.TinyInt)
        command.Parameters("@PageNumber").Value = pageNumber

        ' Add the @ProductsOnPage parameter
        command.Parameters.Add("@ProductsOnPage", SqlDbType.TinyInt)
        command.Parameters("@ProductsOnPage").Value = productsOnPage

        ' Add the @HowManyResults output parameter
        command.Parameters.Add("@HowManyResults", SqlDbType.SmallInt)
        command.Parameters("@HowManyResults").Direction = ParameterDirection.Output

        ' Eliminate separation characters
        searchString = searchString.Replace(",", " ")
        searchString = searchString.Replace(";", " ")
        searchString = searchString.Replace(".", " ")
        searchString = searchString.Replace("!", " ")
        searchString = searchString.Replace("?", " ")
        searchString = searchString.Replace("-", " ")

        ' Create an array that contains the words
        Dim words() As String = Split(searchString, " ")
        ' wordsCount contains the total number of words in the array
        Dim wordsCount As Integer = words.Length
        ' index is used to parse the list of words
        Dim index As Integer = 0
        ' this will store the total number of added words 
        Dim addedWords As Integer = 0

        ' Allow a maximum of five words
        While addedWords < 5 And index < wordsCount
            ' Add the @WordN parameters here
            ' Only add words having more than two letters
            If Len(words(index)) > 2 Then
                addedWords += 1
                ' Add an input parameter and supply a value for it
                command.Parameters.Add("@Word" + addedWords.ToString, words(index))
            End If
            index += 1
        End While

        ' Time to execute the command
        Try
            ' Open the connection
            connection.Open()
            ' Create and initialize an SqlDataReader object
            Dim reader As SqlDataReader
            reader = command.ExecuteReader(CommandBehavior.CloseConnection)
            ' Store the search results to a DataTable
            Dim table As New DataTable
            ' Copy column information from the SqlDataReader to the DataTable
            Dim fieldCount As Integer = reader.FieldCount
            Dim fieldIndex As Integer
            For fieldIndex = 0 To fieldCount - 1
                table.Columns.Add(reader.GetName(fieldIndex), reader.GetFieldType(fieldIndex))
            Next
            ' Copy data from the SqlDataReader to the DataTable
            Dim row As DataRow
            While reader.Read()
                row = table.NewRow()
                For fieldIndex = 0 To fieldCount - 1
                    row(fieldIndex) = reader(fieldIndex)
                Next
                table.Rows.Add(row)
            End While
            ' Close the reader and return the number of results
            reader.Close()

            ' Save the search results to the current session
            HttpContext.Current.Session("SearchTable") = table

            ' return the total number of matching products
            Return command.Parameters("@HowManyResults").Value
        Catch e As Exception
            ' Close the connection and throw the exception
            connection.Close()
            Throw e
        End Try
    End Function



    Private Shared ReadOnly Property connectionString() As String
        Get
            Return ConfigurationSettings.AppSettings("ConnectionString")
        End Get
    End Property
End Class
