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



    Private Shared ReadOnly Property connectionString() As String
        Get
            Return ConfigurationSettings.AppSettings("ConnectionString")
        End Get
    End Property
End Class
