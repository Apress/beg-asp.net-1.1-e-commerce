' Configuration details for order processor
Public Structure OrderProcessorConfiguration
  Public ConnectionString As String
  Public MailServer As String
  Public AdminEmail As String
  Public CustomerServiceEmail As String
  Public OrderProcessorEmail As String
  Public SupplierEmail As String

  Public Sub New(ByVal newConnectionString As String, _
                 ByVal newMailServer As String, _
                 ByVal newAdminEmail As String, _
                 ByVal newCustomerServiceEmail As String, _
                 ByVal newOrderProcessorEmail As String, _
                 ByVal newSupplierEmail As String)
    ConnectionString = newConnectionString
    MailServer = newMailServer
    AdminEmail = newAdminEmail
    CustomerServiceEmail = newCustomerServiceEmail
    OrderProcessorEmail = newOrderProcessorEmail
    SupplierEmail = newSupplierEmail
  End Sub
End Structure
