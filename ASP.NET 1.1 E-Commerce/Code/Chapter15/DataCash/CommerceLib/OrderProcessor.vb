Imports System.Data.SqlClient
Imports System.Web.Mail

' Main class, used to obtain order information, run pipeline sections, audit
' orders, etc.
Public Class OrderProcessor
  Friend OrderID As Integer
  Friend OrderStatus As Integer
  Friend Connection As SqlConnection
  Friend Configuration As OrderProcessorConfiguration
  Friend CurrentPipelineSection As IPipelineSection
  Friend ContinueNow As Boolean
  Private _currentCustomer As Customer
  Private _currentOrderDetails As OrderDetails
  Private _authCode As String
  Private _reference As String

  Public Sub Process(ByVal newOrderID As Integer, _
                     ByVal newConfiguration As OrderProcessorConfiguration)
    ' set order ID
    OrderID = newOrderID

    ' configure processor
    Configuration = newConfiguration
    ContinueNow = True

    ' open connection, to be shared by all data access code
    Connection = New SqlConnection(Configuration.ConnectionString)
    Connection.Open()

    ' log start of execution
    AddAudit("Order Processor started.", 10000)

    ' obtain status of order
    Dim command As SqlCommand = New SqlCommand("GetOrderStatus", Connection)
    command.CommandType = CommandType.StoredProcedure
    command.Parameters.Add("@OrderID", OrderID)
    OrderStatus = CType(command.ExecuteScalar(), Integer)

    ' process pipeline section
    Try
      While ContinueNow
        ContinueNow = False
        GetCurrentPipelineSection()
        CurrentPipelineSection.Process(Me)
      End While
    Catch e As OrderProcessorException
      MailAdmin("Order Processing error occured.", e.Message, e.SourceStage)
      AddAudit("Order Processing error occured.", 10002)
      Throw New OrderProcessorException( _
      "Error occured, order aborted. Details mailed to administrator.", 100)
    Catch e As Exception
      MailAdmin("Order Processing error occured.", e.Message, 100)
      AddAudit("Order Processing error occured.", 10002)
      Throw New OrderProcessorException( _
      "Unknown error, order aborted. Details mailed to administrator.", 100)
    Finally
      AddAudit("Order Processor finished.", 10001)
      Connection.Close()
    End Try
  End Sub

  Private Function GetCurrentPipelineSection() As IPipelineSection
    ' select pipeline section to execute based on order status
    Select Case OrderStatus
      Case 0
        CurrentPipelineSection = New PSInitialNotification
      Case 1
        CurrentPipelineSection = New PSCheckFunds
      Case 2
        CurrentPipelineSection = New PSCheckStock
      Case 3
        CurrentPipelineSection = New PSStockOK
      Case 4
        CurrentPipelineSection = New PSTakePayment
      Case 5
        CurrentPipelineSection = New PSShipGoods
      Case 6
        CurrentPipelineSection = New PSShipOK
      Case 7
        CurrentPipelineSection = New PSFinalNotification
      Case 8
        Throw New OrderProcessorException( _
           "Order has already been completed.", 100)
      Case Else
        Throw New OrderProcessorException( _
           "Unknown pipeline section requested.", 100)
    End Select
  End Function

  Friend Sub MailAdmin(ByVal subject As String, ByVal message As String, _
                       ByVal sourceStage As Integer)
    ' Send mail to administrator
    SmtpMail.SmtpServer = Configuration.MailServer
    Dim notificationMail As MailMessage = New MailMessage
    notificationMail.To = Configuration.AdminEmail
    notificationMail.From = Configuration.OrderProcessorEmail
    notificationMail.Subject = subject
    notificationMail.Body = "Message: " & message & Chr(10) & "Source: " _
                         & sourceStage.ToString() & Chr(10) & "Order ID: " _
                            & OrderID.ToString()
    SmtpMail.Send(notificationMail)
  End Sub

  Friend Sub AddAudit(ByVal message As String, ByVal messageNumber As Integer)
    ' add audit to database
    Dim command As SqlCommand = New SqlCommand("AddAudit", Connection)
    command.CommandType = CommandType.StoredProcedure
    command.Parameters.Add("@OrderID", OrderID)
    command.Parameters.Add("@Message", message)
    command.Parameters.Add("@MessageNumber", messageNumber)
    command.ExecuteNonQuery()
  End Sub

  Friend ReadOnly Property CurrentCustomer() As Customer
    Get
      If _currentCustomer Is Nothing Then
        ' Use ID of order to obtain customer information
        Dim command As SqlCommand = _
           New SqlCommand("GetCustomerByOrderID", Connection)
        command.CommandType = CommandType.StoredProcedure
        command.Parameters.Add("@OrderID", OrderID)
        Dim reader As SqlDataReader = command.ExecuteReader()
        Try
          _currentCustomer = New Customer(reader)
        Catch
          Throw
        Finally
          reader.Close()
        End Try
      End If
      Return _currentCustomer
    End Get
  End Property

  Friend ReadOnly Property CurrentOrderDetails() As OrderDetails
    Get
      If _currentOrderDetails Is Nothing Then
        ' Get list of items in order
        Dim command As SqlCommand = _
           New SqlCommand("GetOrderDetails", Connection)
        command.CommandType = CommandType.StoredProcedure
        command.Parameters.Add("@OrderID", OrderID)
        Dim reader As SqlDataReader = command.ExecuteReader()
        Try
          _currentOrderDetails = New OrderDetails(reader)
        Catch
          Throw
        Finally
          reader.Close()
        End Try
      End If
      Return _currentOrderDetails
    End Get
  End Property

  Friend Sub UpdateOrderStatus(ByVal newStatus As Integer)
    ' change status of order, called by pipeline sections
    Dim command As SqlCommand = New SqlCommand("UpdateOrderStatus", Connection)
    command.CommandType = CommandType.StoredProcedure
    command.Parameters.Add("@OrderID", OrderID)
    command.Parameters.Add("@Status", newStatus)
    command.ExecuteNonQuery()
    OrderStatus = newStatus
  End Sub

  Friend Sub SetOrderAuthCodeAndReference(ByVal newAuthCode As String, _
                                        ByVal newReference As String)
    ' update order authorization code and reference
    Dim command As SqlCommand = New SqlCommand("SetOrderAuthCode", Connection)
    command.CommandType = CommandType.StoredProcedure
    command.Parameters.Add("@OrderID", OrderID)
    command.Parameters.Add("@AuthCode", newAuthCode)
    command.Parameters.Add("@Reference", newReference)
    command.ExecuteNonQuery()
    _authCode = newAuthCode
    _reference = newReference
  End Sub

  Private Sub GetOrderAuthCodeAndReference()
    ' get order authorization code and reference
    Dim command As SqlCommand = New SqlCommand("GetOrderAuthCode", Connection)
    command.CommandType = CommandType.StoredProcedure
    command.Parameters.Add("@OrderID", OrderID)
    Dim reader As SqlDataReader = command.ExecuteReader()
    Try
      reader.Read()
      _authCode = reader("AuthCode")
      _reference = reader("Reference")
    Catch
      Throw
    Finally
      reader.Close()
    End Try
  End Sub

  Friend ReadOnly Property AuthCode()
    Get
      If _authCode Is Nothing Then
        GetOrderAuthCodeAndReference()
      End If
      Return _authCode
    End Get
  End Property

  Friend ReadOnly Property Reference()
    Get
      If _reference Is Nothing Then
        GetOrderAuthCodeAndReference()
      End If
      Return _reference
    End Get
  End Property

  Friend Sub SetDateShipped()
    ' set the shipment date of the order
    Dim command As SqlCommand = New SqlCommand("SetDateShipped", Connection)
    command.CommandType = CommandType.StoredProcedure
    command.Parameters.Add("@OrderID", OrderID)
    command.ExecuteNonQuery()
  End Sub

End Class