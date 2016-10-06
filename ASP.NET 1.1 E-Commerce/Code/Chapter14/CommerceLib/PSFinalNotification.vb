Imports System.Text
Imports System.Web.Mail

' 8th pipeline stage - used to send a notification email to
' the customer, confirming that the order has been shipped
Public Class PSFinalNotification
  Implements IPipelineSection

  Private _processor As OrderProcessor
  Private _currentCustomer As Customer
  Private _currentOrderDetails As OrderDetails

  Public Sub Process(ByVal processor As OrderProcessor) _
     Implements IPipelineSection.Process

    _processor = processor
    _processor.AddAudit("PSFinalNotification started.", 20700)

    ' get customer details
    _currentCustomer = _processor.CurrentCustomer

    ' get order details
    _currentOrderDetails = _processor.CurrentOrderDetails

    Try
      ' Send mail to customer
      SmtpMail.SmtpServer = _processor.Configuration.MailServer
      Dim notificationMail As MailMessage = New MailMessage
      notificationMail.To = _currentCustomer.Email
      notificationMail.From = _processor.Configuration.CustomerServiceEmail
      notificationMail.Subject = "Order dispatched."
      notificationMail.Body = GetMailBody()
      SmtpMail.Send(notificationMail)
      _processor.AddAudit("Dispatch e-mail sent to customer.", 20702)

      _processor.UpdateOrderStatus(8)
    Catch
      ' mail sending failure
      Throw _
         New OrderProcessorException("Unable to send e-mail to customer.", 7)
    End Try
    _processor.AddAudit("PSFinalNotification finished.", 20701)
  End Sub

  Private Function GetMailBody() As String
    ' construct message body
    Dim bodyBuilder As StringBuilder = New StringBuilder
    bodyBuilder.Append("Your order has now been dispatched! The following " _
                       & "products have been shipped:")
    bodyBuilder.Append(Chr(10))
    bodyBuilder.Append(Chr(10))
    bodyBuilder.Append(_currentOrderDetails.ListAsString)
    bodyBuilder.Append(Chr(10))
    bodyBuilder.Append(Chr(10))
    bodyBuilder.Append("Your order has beenshipped to: ")
    bodyBuilder.Append(Chr(10))
    bodyBuilder.Append(Chr(10))
    bodyBuilder.Append(_currentCustomer.AddressAsString)
    bodyBuilder.Append(Chr(10))
    bodyBuilder.Append(Chr(10))
    bodyBuilder.Append("Order reference number: ")
    bodyBuilder.Append(_processor.OrderID.ToString())
    bodyBuilder.Append(Chr(10))
    bodyBuilder.Append(Chr(10))
    bodyBuilder.Append("Thank you for shopping at JokePoint.com!")
    Return bodyBuilder.ToString()
  End Function
End Class
