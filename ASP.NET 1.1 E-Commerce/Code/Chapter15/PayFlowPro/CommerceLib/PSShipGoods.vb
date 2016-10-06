Imports System.Text
Imports System.Web.Mail

' 6th pipeline stage – used to send a notification email to
' the supplier, stating that goods can be shipped
Public Class PSShipGoods
  Implements IPipelineSection

  Private _processor As OrderProcessor
  Private _currentCustomer As Customer
  Private _currentOrderDetails As OrderDetails

  Public Sub Process(ByVal processor As OrderProcessor) _
     Implements IPipelineSection.Process

    _processor = processor
    _processor.AddAudit("PSShipGoods started.", 20500)

    ' get customer details
    _currentCustomer = _processor.CurrentCustomer

    ' get order details
    _currentOrderDetails = _processor.CurrentOrderDetails
    Try
      ' Send mail to supplier
      SmtpMail.SmtpServer = _processor.Configuration.MailServer
      Dim notificationMail As MailMessage = New MailMessage
      notificationMail.To = _processor.Configuration.SupplierEmail
      notificationMail.From = _processor.Configuration.AdminEmail
      notificationMail.Subject = "Ship Goods."
      notificationMail.Body = GetMailBody()
      SmtpMail.Send(notificationMail)
      _processor.AddAudit("Ship goods e–mail sent to supplier.", 20502)
      _processor.UpdateOrderStatus(6)
    Catch
      ' mail sending failure
      Throw _
         New OrderProcessorException("Unable to send e-mail to supplier.", 5)
    End Try
    _processor.AddAudit("PSShipGoods finished.", 20501)
  End Sub

  Private Function GetMailBody() As String
    ' construct message body
    Dim bodyBuilder As StringBuilder = New StringBuilder
    bodyBuilder.Append("Payment has been received for the following goods:")
    bodyBuilder.Append(Chr(10))
    bodyBuilder.Append(Chr(10))
    bodyBuilder.Append(_currentOrderDetails.ListAsString)
    bodyBuilder.Append(Chr(10))
    bodyBuilder.Append(Chr(10))
    bodyBuilder.Append("Please ship to:")
    bodyBuilder.Append(Chr(10))
    bodyBuilder.Append(Chr(10))
    bodyBuilder.Append(_currentCustomer.AddressAsString)
    bodyBuilder.Append(Chr(10))
    bodyBuilder.Append(Chr(10))
    bodyBuilder.Append("When goods have been shipped, please confirm via " _
                       & "http://www.JokePoint.com/OrdersAdminPage.aspx")
    bodyBuilder.Append(Chr(10))
    bodyBuilder.Append(Chr(10))
    bodyBuilder.Append("Order reference number: ")
    bodyBuilder.Append(_processor.OrderID.ToString())
    Return bodyBuilder.ToString()
  End Function
End Class
