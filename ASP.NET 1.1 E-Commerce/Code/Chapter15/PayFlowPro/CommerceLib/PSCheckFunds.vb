Imports SecurityLib
Imports PayFlowPro

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
      ' configure PayFlowPro request
      Dim ParmList As String
      ParmList = "USER=" + _processor.Configuration.PayFlowProUser _
              + "&VENDOR=" + _processor.Configuration.PayFlowProVendor _
              + "&PARTNER=" + _processor.Configuration.PayFlowProPartner _
              + "&PWD=" + _processor.Configuration.PayFlowProPwd _
              + "&TRXTYPE=A" _
              + "&TENDER=C" _
              + "&ACCT=" + _currentCustomer.CreditCard.CardNumber _
              + "&EXPDATE=" + _currentCustomer.CreditCard.ExpiryDate.Replace("/", "") _
              + "&INVNUM=" + _processor.OrderID.ToString().PadLeft(6, "0"c).PadLeft(7, "5"c) _
              + "&AMT=" + _currentOrderDetails.TotalCost.ToString()

      ' create PayFlowPro context
      Dim pfpro As New PFPro
      Dim pCtlx As Integer
      pCtlx = pfpro.CreateContext(_processor.Configuration.PayFlowProHost, 443, 30, "", 0, "", "")

      ' get response
      Dim response As String
      response = pfpro.SubmitTransaction(pCtlx, ParmList)

      ' destroy context
      pfpro.DestroyContext(pCtlx)

      ' get response sections
      Dim reponseSections As String()
      reponseSections = response.Split("&")

      If reponseSections(0) = "RESULT=0" Then
        ' Get authorization code and reference
        Dim reference As String
        reference = reponseSections(3).Substring(9)
        Dim authCode As String
        authCode = reponseSections(1).Substring(6)

        ' update order authorization code and reference
        _processor.SetOrderAuthCodeAndReference(reference, _
                                                authCode)

        ' audit and continue
        _processor.AddAudit("Funds available for purchase.", 20102)
        _processor.UpdateOrderStatus(2)
        _processor.ContinueNow = True
      Else
        _processor.AddAudit("Funds not available for purchase.", 20103)
        _processor.MailAdmin("Credit card declined.", "Data exchanged:" _
          & Chr(10) & ParmList & Chr(10) & Chr(10) & response, 1)
      End If
    Catch
      ' fund checking failure
      Throw _
         New OrderProcessorException("Error occured while checking funds.", 1)
    End Try
    _processor.AddAudit("PSCheckFunds finished.", 20101)
  End Sub
End Class
