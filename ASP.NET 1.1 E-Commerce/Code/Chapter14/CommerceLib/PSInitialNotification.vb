Imports System.Text
Imports System.Web.Mail

' 1st pipeline stage - used to send a notification email to
' the customer, confirming that the order has been received
Public Class PSInitialNotification
  Implements IPipelineSection

  Private _processor As OrderProcessor
  Private _currentCustomer As Customer
  Private _currentOrderDetails As OrderDetails

  Public Sub Process(ByVal processor As OrderProcessor) _
     Implements IPipelineSection.Process

    _processor = processor
    _processor.AddAudit("PSInitialNotification started.", 20000)
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
      notificationMail.Subject = "Order received."
      notificationMail.Body = GetMailBody()
      SmtpMail.Send(notificationMail)
      _processor.AddAudit("Notification e-mail sent to customer.", 20002)

      _processor.UpdateOrderStatus(1)
      _processor.ContinueNow = True
    Catch
      ' mail sending failure
      Throw _
         New OrderProcessorException("Unable to send e-mail to customer.", 0)
    End Try
    _processor.AddAudit("PSInitialNotification finished.", 20001)
  End Sub

  Private Function GetMailBody() As String
    ' construct message body
    Dim bodyBuilder As StringBuilder = New StringBuilder
    bodyBuilder.Append("Thank you for your order! The products you have " _
                       & "ordered are as follows:")
    bodyBuilder.Append(Chr(10))
    bodyBuilder.Append(Chr(10))
    bodyBuilder.Append(_currentOrderDetails.ListAsString)
    bodyBuilder.Append(Chr(10))
    bodyBuilder.Append(Chr(10))
    bodyBuilder.Append("Your order will be shipped to: ")
    bodyBuilder.Append(Chr(10))
    bodyBuilder.Append(Chr(10))
    bodyBuilder.Append(_currentCustomer.AddressAsString)
    bodyBuilder.Append(Chr(10))
    bodyBuilder.Append(Chr(10))
    bodyBuilder.Append("Order reference number: ")
    bodyBuilder.Append(_processor.OrderID.ToString())
    bodyBuilder.Append(Chr(10))
    bodyBuilder.Append(Chr(10))
    bodyBuilder.Append("You will receive a confirmation e-mail when this " _
                       & "order has been dispatched. Thank you for shopping " _
                       & "at JokePoint.com!")
    Return bodyBuilder.ToString()
  End Function
End Class
