' Configuration details for order processor
Public Structure OrderProcessorConfiguration
  Public ConnectionString As String
  Public MailServer As String
  Public AdminEmail As String
  Public CustomerServiceEmail As String
  Public OrderProcessorEmail As String
  Public SupplierEmail As String
  Public DataCashClient As String
  Public DataCashPassword As String
  Public DataCashUrl As String

  Public Sub New(ByVal newConnectionString As String, _
                 ByVal newMailServer As String, _
                 ByVal newAdminEmail As String, _
                 ByVal newCustomerServiceEmail As String, _
                 ByVal newOrderProcessorEmail As String, _
                 ByVal newSupplierEmail As String, _
                 ByVal newDataCashClient As String, _
                 ByVal newDataCashPassword As String, _
                 ByVal newDataCashUrl As String)

    ConnectionString = newConnectionString
    MailServer = newMailServer
    AdminEmail = newAdminEmail
    CustomerServiceEmail = newCustomerServiceEmail
    OrderProcessorEmail = newOrderProcessorEmail
    SupplierEmail = newSupplierEmail
    DataCashClient = newDataCashClient
    DataCashPassword = newDataCashPassword
    DataCashUrl = newDataCashUrl
  End Sub
End Structure
