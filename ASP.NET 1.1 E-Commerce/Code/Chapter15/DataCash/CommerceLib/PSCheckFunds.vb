Imports SecurityLib
Imports DataCashLib

' 2nd pipeline stage - used to check that the customer
' has the required funds available for purchase
Public Class PSCheckFunds
  Implements IPipelineSection

  Private _processor As OrderProcessor
  Private _currentCustomer As Customer
  Private _currentOrderDetails As OrderDetails

  Public Sub Process(ByVal processor As OrderProcessor) _
     Implements IPipelineSection.Process

    _processor = processor
    _processor.AddAudit("PSCheckFunds started.", 20100)
    ' get customer details
    _currentCustomer = _processor.CurrentCustomer

    ' get order details
    _currentOrderDetails = _processor.CurrentOrderDetails

    Try
      ' check customer funds via datacash gateway
      ' configure Datacash XML request
      Dim request As DataCashRequest = New DataCashRequest
      request.Authentication.Client = _processor.Configuration.DataCashClient
      request.Authentication.Password = _
        _processor.Configuration.DataCashPassword
      request.Transaction.TxnDetails.MerchantReference = _
        _processor.OrderID.ToString().PadLeft(6, "0"c).PadLeft(7, "5"c)
      request.Transaction.TxnDetails.Amount.Amount = _
        _currentOrderDetails.TotalCost.ToString()
      request.Transaction.TxnDetails.Amount.Currency = "GBP"
      request.Transaction.CardTxn.Method = "pre"
      request.Transaction.CardTxn.Card.CardNumber = _
        _currentCustomer.CreditCard.CardNumber
      request.Transaction.CardTxn.Card.ExpiryDate = _
        _currentCustomer.CreditCard.ExpiryDate
      If _currentCustomer.CreditCard.IssueDate <> "" Then
        request.Transaction.CardTxn.Card.StartDate = _
          _currentCustomer.CreditCard.IssueDate
      End If
      If _currentCustomer.CreditCard.IssueNumber <> "" Then
        request.Transaction.CardTxn.Card.IssueNumber = _
          _currentCustomer.CreditCard.IssueNumber
      End If

      ' Get DataCash response
      Dim response As DataCashResponse = _
        request.GetResponse(_processor.Configuration.DataCashUrl)
      If response.Status = "1" Then
        ' update order authorization code and reference
        _processor.SetOrderAuthCodeAndReference(response.MerchantReference, _
                                                response.DatacashReference)

        ' audit and continue
        _processor.AddAudit("Funds available for purchase.", 20102)
        _processor.UpdateOrderStatus(2)
        _processor.ContinueNow = True
      Else
        _processor.AddAudit("Funds not available for purchase.", 20103)
        _processor.MailAdmin("Credit card declined.", "XML data exchanged:" _
          & Chr(10) & request.Xml & Chr(10) & Chr(10) & response.Xml, 1)
      End If
    Catch
      ' fund checking failure
      Throw _
         New OrderProcessorException("Error occured while checking funds.", 1)
    End Try
    _processor.AddAudit("PSCheckFunds finished.", 20101)
  End Sub
End Class
