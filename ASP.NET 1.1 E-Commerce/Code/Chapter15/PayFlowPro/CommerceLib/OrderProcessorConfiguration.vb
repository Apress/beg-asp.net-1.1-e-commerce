' Configuration details for order processor
Public Structure OrderProcessorConfiguration
  Public ConnectionString As String
  Public MailServer As String
  Public AdminEmail As String
  Public CustomerServiceEmail As String
  Public OrderProcessorEmail As String
  Public SupplierEmail As String
  Public PayFlowProUser As String
  Public PayFlowProVendor As String
  Public PayFlowProPartner As String
  Public PayFlowProPwd As String
  Public PayFlowProHost As String

  Public Sub New(ByVal newConnectionString As String, _
                 ByVal newMailServer As String, _
                 ByVal newAdminEmail As String, _
                 ByVal newCustomerServiceEmail As String, _
                 ByVal newOrderProcessorEmail As String, _
                 ByVal newSupplierEmail As String, _
                 ByVal newPayFlowProUser As String, _
                 ByVal newPayFlowProVendor As String, _
                 ByVal newPayFlowProPartner As String, _
                 ByVal newPayFlowProPwd As String, _
                 ByVal newPayFlowProHost As String)

    ConnectionString = newConnectionString
    MailServer = newMailServer
    AdminEmail = newAdminEmail
    CustomerServiceEmail = newCustomerServiceEmail
    OrderProcessorEmail = newOrderProcessorEmail
    SupplierEmail = newSupplierEmail
    PayFlowProUser = newPayFlowProUser
    PayFlowProVendor = newPayFlowProVendor
    PayFlowProPartner = newPayFlowProPartner
    PayFlowProPwd = newPayFlowProPwd
    PayFlowProHost = newPayFlowProHost
  End Sub
End Structure
