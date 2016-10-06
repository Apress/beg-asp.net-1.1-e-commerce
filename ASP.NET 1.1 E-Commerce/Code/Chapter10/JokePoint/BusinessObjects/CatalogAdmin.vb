Imports System.Data.SqlClient

Public Class CatalogAdmin

#Region "  Departments  "
    Public Shared Function GetDepartmentsWithDescriptions() As SqlDataReader
        ' Create the connection object
        Dim connection As New SqlConnection(connectionString)
        ' Create and initialize the command object
        Dim command As New SqlCommand("GetDepartmentsWithDescriptions", connection)
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

    Public Shared Function UpdateDepartment(ByVal departmentId As String, ByVal departmentName As String, ByVal departmentDescription As String)
        ' Create the connection object
        Dim connection As New SqlConnection(connectionString)
        ' Create and initialize the command object
        Dim command As New SqlCommand("UpdateDepartment", connection)
        command.CommandType = CommandType.StoredProcedure
        ' Add an input parameter and supply a value for it
        command.Parameters.Add("@DepartmentID", SqlDbType.Int)
        command.Parameters("@DepartmentID").Value = departmentId
        ' Add an input parameter and supply a value for it
        command.Parameters.Add("@DepartmentName", SqlDbType.VarChar, 50)
        command.Parameters("@DepartmentName").Value = departmentName
        ' Add an input parameter and supply a value for it
        command.Parameters.Add("@DepartmentDescription", SqlDbType.VarChar, 200)
        command.Parameters("@DepartmentDescription").Value = departmentDescription
        ' Open the connection, execute the command, and close the connection
        Try
            connection.Open()
            command.ExecuteNonQuery()
        Finally
            connection.Close()
        End Try
    End Function

    Public Shared Function DeleteDepartment(ByVal departmentId As String)
        ' Create the connection object
        Dim connection As New SqlConnection(connectionString)
        ' Create and initialize the command object
        Dim command As New SqlCommand("DeleteDepartment", connection)
        command.CommandType = CommandType.StoredProcedure
        ' Add an input parameter and supply a value for it
        command.Parameters.Add("@DepartmentID", SqlDbType.Int)
        command.Parameters("@DepartmentID").Value = departmentId
        ' Open the connection, execute the command, and close the connection
        Try
            connection.Open()
            command.ExecuteNonQuery()
        Finally
            connection.Close()
        End Try
    End Function

    Public Shared Function AddDepartment(ByVal departmentName As String, ByVal departmentDescription As String)
        ' Create the connection object
        Dim connection As New SqlConnection(connectionString)
        ' Create and initialize the command object
        Dim command As New SqlCommand("AddDepartment", connection)
        command.CommandType = CommandType.StoredProcedure
        ' Add an input parameter and supply a value for it
        command.Parameters.Add("@DepartmentName", SqlDbType.VarChar, 50)
        command.Parameters("@DepartmentName").Value = departmentName
        ' Add an input parameter and supply a value for it
        command.Parameters.Add("@DepartmentDescription", SqlDbType.VarChar, 200)
        command.Parameters("@DepartmentDescription").Value = departmentDescription
        ' Open the connection, execute the command, and close the connection
        Try
            connection.Open()
            command.ExecuteNonQuery()
        Finally
            connection.Close()
        End Try
    End Function
#End Region

#Region "  Categories  "
    Public Shared Function GetCategoriesWithDescriptions( _
                           ByVal departmentId As String) As SqlDataReader
        ' Create the connection object
        Dim connection As New SqlConnection(connectionString)
        ' Create and initialize the command object
        Dim command As New SqlCommand("GetCategoriesWithDescriptions", connection)
        command.CommandType = CommandType.StoredProcedure
        ' Add an input parameter and supply a value for it
        command.Parameters.Add("@DepartmentID", SqlDbType.Int)
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

    Public Shared Function UpdateCategory(ByVal categoryId As String, _
              ByVal categoryName As String, ByVal categoryDescription As String)
        ' Create the connection object
        Dim connection As New SqlConnection(connectionString)
        ' Create and initialize the command object
        Dim command As New SqlCommand("UpdateCategory", connection)
        command.CommandType = CommandType.StoredProcedure
        ' Add an input parameter and supply a value for it
        command.Parameters.Add("@CategoryID", SqlDbType.Int)
        command.Parameters("@CategoryID").Value = categoryId
        ' Add an input parameter and supply a value for it
        command.Parameters.Add("@CategoryName", SqlDbType.VarChar, 50)
        command.Parameters("@CategoryName").Value = categoryName
        ' Add an input parameter and supply a value for it
        command.Parameters.Add("@CategoryDescription", SqlDbType.VarChar, 200)
        command.Parameters("@CategoryDescription").Value = categoryDescription
        ' Open the connection, execute the command, and close the connection
        Try
            connection.Open()
            command.ExecuteNonQuery()
        Finally
            connection.Close()
        End Try
    End Function

    Public Shared Function DeleteCategory(ByVal categoryId As String)
        ' Create the connection object
        Dim connection As New SqlConnection(connectionString)
        ' Create and initialize the command object
        Dim command As New SqlCommand("DeleteCategory", connection)
        command.CommandType = CommandType.StoredProcedure
        ' Add an input parameter and supply a value for it
        command.Parameters.Add("@CategoryID", SqlDbType.Int)
        command.Parameters("@CategoryID").Value = categoryId
        ' Open the connection, execute the command, and close the connection
        Try
            connection.Open()
            command.ExecuteNonQuery()
        Finally
            connection.Close()
        End Try
    End Function

    Public Shared Function AddCategory(ByVal departmentID As String, _
      ByVal categoryName As String, ByVal categoryDescription As String)
        ' Create the connection object
        Dim connection As New SqlConnection(connectionString)
        ' Create and initialize the command object
        Dim command As New SqlCommand("AddCategory", connection)
        command.CommandType = CommandType.StoredProcedure
        ' Add an input parameter and supply a value for it
        command.Parameters.Add("@DepartmentID", SqlDbType.Int)
        command.Parameters("@DepartmentID").Value = departmentID
        ' Add an input parameter and supply a value for it
        command.Parameters.Add("@CategoryName", SqlDbType.VarChar, 50)
        command.Parameters("@CategoryName").Value = categoryName
        ' Add an input parameter and supply a value for it
        command.Parameters.Add("@CategoryDescription", SqlDbType.VarChar, 200)
        command.Parameters("@CategoryDescription").Value = categoryDescription
        ' Open the connection, execute the command, and close the connection
        Try
            connection.Open()
            command.ExecuteNonQuery()
        Finally
            connection.Close()
        End Try
    End Function
#End Region

#Region "  Products  "
    Public Shared Function CreateProductToCategory(ByVal categoryId As String, _
           ByVal productName As String, ByVal productDescription As String, _
           ByVal productPrice As String, ByVal productImage As String, _
           ByVal onDepartmentPromotion As String, _
           ByVal onCatalogPromotion As String)
        ' Create the connection object
        Dim connection As New SqlConnection(connectionString)
        ' Create and initialize the command object
        Dim command As New SqlCommand("CreateProductToCategory", connection)
        command.CommandType = CommandType.StoredProcedure
        ' Add an input parameter and supply a value for it
        command.Parameters.Add("@CategoryID", SqlDbType.Int)
        command.Parameters("@CategoryID").Value = categoryId
        ' Add an input parameter and supply a value for it
        command.Parameters.Add("@ProductName", SqlDbType.VarChar, 50)
        command.Parameters("@ProductName").Value = productName
        ' Add an input parameter and supply a value for it
        command.Parameters.Add("@ProductDescription", SqlDbType.VarChar, 1000)
        command.Parameters("@ProductDescription").Value = productDescription
        ' Add an input parameter and supply a value for it
        command.Parameters.Add("@ProductPrice", SqlDbType.Money, 8)
        command.Parameters("@ProductPrice").Value = productPrice
        ' Add an input parameter and supply a value for it
        command.Parameters.Add("@ProductImage", SqlDbType.VarChar, 50)
        command.Parameters("@ProductImage").Value = productImage
        ' Add an input parameter and supply a value for it
        If onDepartmentPromotion.ToUpper = "TRUE" Or onDepartmentPromotion = "1" Then
            ' If we receive "True" or "1" for onDepartmentPromotion ...
            command.Parameters.Add("@OnDepartmentPromotion", SqlDbType.Bit, 1)
            command.Parameters("@OnDepartmentPromotion").Value = 1
        Else
            ' For all the other values we assume the product is not on promotion
            command.Parameters.Add("@OnDepartmentPromotion", SqlDbType.Bit, 1)
            command.Parameters("@OnDepartmentPromotion").Value = 0
        End If
        ' Add an input parameter and supply a value for it
        If onCatalogPromotion.ToUpper = "TRUE" Or onCatalogPromotion = "1" Then
            ' If we receive "True" or "1" for onCatalogPromotion ...
            command.Parameters.Add("@OnCatalogPromotion", SqlDbType.Bit, 1)
            command.Parameters("@OnCatalogPromotion").Value = 1
        Else
            ' For all the other values we assume the product is not on promotion
            command.Parameters.Add("@OnCatalogPromotion", SqlDbType.Bit, 1)
            command.Parameters("@OnCatalogPromotion").Value = 0
        End If
        ' Open the connection, execute the command, and close the connection
        Try
            connection.Open()
            command.ExecuteNonQuery()
        Finally
            connection.Close()
        End Try
    End Function

    ' This is identical to CreateProductToCategory, except that we call
    ' the UpdateProduct stored procedure instead of CreateProductToCategory
    Public Shared Function UpdateProduct(ByVal productId As String, _
           ByVal productName As String, ByVal productDescription As String, _
           ByVal productPrice As String, ByVal productImage As String, _
           ByVal onDepartmentPromotion As String, _
           ByVal onCatalogPromotion As String)
        ' Create the connection object
        Dim connection As New SqlConnection(connectionString)
        ' Create and initialize the command object
        Dim command As New SqlCommand("UpdateProduct", connection)
        command.CommandType = CommandType.StoredProcedure
        ' Add an input parameter and supply a value for it
        command.Parameters.Add("@ProductID", SqlDbType.Int)
        command.Parameters("@ProductID").Value = productId
        ' Add an input parameter and supply a value for it
        command.Parameters.Add("@ProductName", SqlDbType.VarChar, 50)
        command.Parameters("@ProductName").Value = productName
        ' Add an input parameter and supply a value for it
        command.Parameters.Add("@ProductDescription", SqlDbType.VarChar, 1000)
        command.Parameters("@ProductDescription").Value = productDescription
        ' Add an input parameter and supply a value for it
        command.Parameters.Add("@ProductPrice", SqlDbType.Money, 8)
        command.Parameters("@ProductPrice").Value = productPrice
        ' Add an input parameter and supply a value for it
        command.Parameters.Add("@ProductImage", SqlDbType.VarChar, 50)
        command.Parameters("@ProductImage").Value = productImage
        If onDepartmentPromotion.ToUpper = "TRUE" Or onDepartmentPromotion = "1" Then
            ' If we receive "True" or "1" for onDepartmentPromotion ...
            command.Parameters.Add("@OnDepartmentPromotion", SqlDbType.Bit, 1)
            command.Parameters("@OnDepartmentPromotion").Value = 1
        Else
            ' For all the other values we assume the product is not on promotion
            command.Parameters.Add("@OnDepartmentPromotion", SqlDbType.Bit, 1)
            command.Parameters("@OnDepartmentPromotion").Value = 0
        End If
        If onCatalogPromotion.ToUpper = "TRUE" Or onCatalogPromotion = "1" Then
            ' If we receive "True" or "1" for onCatalogPromotion ...
            command.Parameters.Add("@OnCatalogPromotion", SqlDbType.Bit, 1)
            command.Parameters("@OnCatalogPromotion").Value = 1
        Else
            ' For all the other values we assume the product is not on promotion
            command.Parameters.Add("@OnCatalogPromotion", SqlDbType.Bit, 1)
            command.Parameters("@OnCatalogPromotion").Value = 0
        End If
        ' Open the connection, execute the command, and close the connection
        Try
            connection.Open()
            command.ExecuteNonQuery()
        Finally
            connection.Close()
        End Try
    End Function
#End Region

#Region "  Product Details  "
    Public Shared Function RemoveFromCategoryOrDeleteProduct(ByVal productId As String, ByVal categoryId As String)
        ' Create the connection object
        Dim connection As New SqlConnection(connectionString)
        ' Create and initialize the command object
        Dim command As New SqlCommand("RemoveFromCategoryOrDeleteProduct", connection)
        command.CommandType = CommandType.StoredProcedure
        ' Add an input parameter and supply a value for it
        command.Parameters.Add("@ProductID", SqlDbType.Int)
        command.Parameters("@ProductID").Value = productId
        ' Add an input parameter and supply a value for it
        command.Parameters.Add("@CategoryID", SqlDbType.Int)
        command.Parameters("@CategoryID").Value = categoryId
        ' Open the connection, execute the command, and close the connection
        Try
            connection.Open()
            command.ExecuteNonQuery()
        Finally
            connection.Close()
        End Try
    End Function

    Public Shared Function GetCategoriesForProduct(ByVal productId As String) As SqlDataReader
        ' Create the connection object
        Dim connection As New SqlConnection(connectionString)
        ' Create and initialize the command object
        Dim command As New SqlCommand("GetCategoriesForProduct", connection)
        command.CommandType = CommandType.StoredProcedure
        ' Add an input parameter and supply a value for it
        command.Parameters.Add("@ProductID", SqlDbType.Int)
        command.Parameters("@ProductID").Value = productId
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

    Public Shared Function GetCategoriesForNotProduct(ByVal productId As String) As SqlDataReader
        ' Create the connection object
        Dim connection As New SqlConnection(connectionString)
        ' Create and initialize the command object
        Dim command As New SqlCommand("GetCategoriesForNotProduct", connection)
        command.CommandType = CommandType.StoredProcedure
        ' Add an input parameter and supply a value for it
        command.Parameters.Add("@ProductID", SqlDbType.Int)
        command.Parameters("@ProductID").Value = productId
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

    Public Shared Function AssignProductToCategory(ByVal productId As String, ByVal categoryId As String)
        ' Create the connection object
        Dim connection As New SqlConnection(connectionString)
        ' Create and initialize the command object
        Dim command As New SqlCommand("AssignProductToCategory", connection)
        command.CommandType = CommandType.StoredProcedure
        ' Add an input parameter and supply a value for it
        command.Parameters.Add("@ProductID", SqlDbType.Int, 4)
        command.Parameters("@ProductID").Value = productId
        ' Add an input parameter and supply a value for it
        command.Parameters.Add("@CategoryID", SqlDbType.Int, 4)
        command.Parameters("@CategoryID").Value = categoryId
        ' Open the connection, execute the command, and close the connection
        Try
            connection.Open()
            command.ExecuteNonQuery()
        Finally
            connection.Close()
        End Try
    End Function

    Public Shared Function MoveProductToCategory(ByVal productId As String, ByVal oldCategoryId As String, ByVal newCategoryID As String)
        ' Create the connection object
        Dim connection As New SqlConnection(connectionString)
        ' Create and initialize the command object
        Dim command As New SqlCommand("MoveProductToCategory", connection)
        command.CommandType = CommandType.StoredProcedure
        ' Add an input parameter and supply a value for it
        command.Parameters.Add("@ProductID", SqlDbType.Int, 4)
        command.Parameters("@ProductID").Value = productId
        ' Add an input parameter and supply a value for it
        command.Parameters.Add("@OldCategoryID", SqlDbType.Int, 4)
        command.Parameters("@OldCategoryID").Value = oldCategoryId
        ' Add an input parameter and supply a value for it
        command.Parameters.Add("@NewCategoryID", SqlDbType.Int, 4)
        command.Parameters("@NewCategoryID").Value = newCategoryID
        ' Open the connection, execute the command, and close the connection
        Try
            connection.Open()
            command.ExecuteNonQuery()
        Finally
            connection.Close()
        End Try
    End Function

    Public Shared Function UpdateProductPicture(ByVal productId As String, ByVal imageFileName As String)
        ' Create the connection object
        Dim connection As New SqlConnection(connectionString)
        ' Create and initialize the command object
        Dim command As New SqlCommand("UpdateProductPicture", connection)
        command.CommandType = CommandType.StoredProcedure
        ' Add an input parameter and supply a value for it
        command.Parameters.Add("@ProductID", SqlDbType.Int)
        command.Parameters("@ProductID").Value = productId
        ' Add an input parameter and supply a value for it
        command.Parameters.Add("@ImageFileName", SqlDbType.VarChar, 50)
        command.Parameters("@ImageFileName").Value = imageFileName
        ' Open the connection, execute the command, and close the connection
        Try
            connection.Open()
            command.ExecuteNonQuery()
        Finally
            connection.Close()
        End Try
    End Function
#End Region

    Private Shared ReadOnly Property connectionString() As String
        Get
            Return ConfigurationSettings.AppSettings("ConnectionString")
        End Get
    End Property
End Class
