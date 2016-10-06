Imports System.Text
Imports System.Web.Mail

' 3rd pipeline stage – used to send a notification email to
' the supplier, asking whether goods are available
Public Class PSCheckStock
  Implements IPipelineSection

  Private _processor As OrderProcessor
  Private _currentOrderDetails As OrderDetails

  Public Sub Process(ByVal processor As OrderProcessor) _
     Implements IPipelineSection.Process

    _processor = processor
    _processor.AddAudit("PSCheckStock started.", 20200)
    ' get order details
    _currentOrderDetails = _processor.CurrentOrderDetails
    Try
      ' Send mail to supplier
      SmtpMail.SmtpServer = _processor.Configuration.MailServer
      Dim notificationMail As MailMessage = New MailMessage
      notificationMail.To = _processor.Configuration.SupplierEmail
      notificationMail.From = _processor.Configuration.AdminEmail
      notificationMail.Subject = "Stock check."
      notificationMail.Body = GetMailBody()
      SmtpMail.Send(notificationMail)
      _processor.AddAudit("Notification e-mail sent to supplier.", 20202)

      _processor.UpdateOrderStatus(3)
    Catch
      ' mail sending failure
      Throw _
         New OrderProcessorException("Unable to send e-mail to supplier.", 2)
    End Try
    _processor.AddAudit("PSCheckStock finished.", 20201)
  End Sub

  Private Function GetMailBody() As String

    ' construct message body
    Dim bodyBuilder As StringBuilder = New StringBuilder
    bodyBuilder.Append("The following goods have been ordered:")
    bodyBuilder.Append(Chr(10))
    bodyBuilder.Append(Chr(10))
    bodyBuilder.Append(_currentOrderDetails.ListAsString)
    bodyBuilder.Append(Chr(10))
    bodyBuilder.Append(Chr(10))
    bodyBuilder.Append("Please check availability and confirm via " _
                       & "http://www.JokePoint.com/OrdersAdminPage.aspx")
    bodyBuilder.Append(Chr(10))
    bodyBuilder.Append(Chr(10))
    bodyBuilder.Append("Order reference number: ")
    bodyBuilder.Append(_processor.OrderID.ToString())
    Return bodyBuilder.ToString()
  End Function
End Class
