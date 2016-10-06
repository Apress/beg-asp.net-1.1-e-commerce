Imports DataCashLib

' 5th pipeline stage – takes funds from customer
Public Class PSTakePayment
  Implements IPipelineSection

  Private _processor As OrderProcessor
  Private _authCode As String
  Private _reference As String

  Public Sub Process(ByVal processor As OrderProcessor) _
     Implements IPipelineSection.Process

    _processor = processor
    _processor.AddAudit("PSTakePayment started.", 20400)

    ' get authorization code and reference
    _authCode = _processor.AuthCode
    _reference = _processor.Reference

    Try
      ' take customer funds via datacash gateway
      ' configure Datacash XML request
      Dim request As DataCashRequest = New DataCashRequest
      request.Authentication.Client = _processor.Configuration.DataCashClient
      request.Authentication.Password = _
        _processor.Configuration.DataCashPassword
      request.Transaction.HistoricTxn.Method = "fulfill"
      request.Transaction.HistoricTxn.AuthCode = _authCode
      request.Transaction.HistoricTxn.Reference = _reference

      Dim response As DataCashResponse = _
        request.GetResponse(_processor.Configuration.DataCashUrl)
      If response.Status = "1" Then
        ' audit and continue
        _processor.AddAudit( _
          "Funds deducted from customer credit card account.", 20402)
        _processor.UpdateOrderStatus(5)
        _processor.ContinueNow = True
      Else
        _processor.AddAudit( _
          "Error taking funds from customer credit card account.", 20403)
        _processor.MailAdmin("Credit card fulfillment declined.", _
          "XML data exchanged:" & Chr(10) & request.Xml & Chr(10) & Chr(10) _
          & response.Xml, 1)
      End If
    Catch
      ' fund checking failure
      Throw _
         New OrderProcessorException("Error occured while taking payment.", 4)
    End Try
    _processor.AddAudit("PSTakePayment finished.", 20401)
  End Sub
End Class
