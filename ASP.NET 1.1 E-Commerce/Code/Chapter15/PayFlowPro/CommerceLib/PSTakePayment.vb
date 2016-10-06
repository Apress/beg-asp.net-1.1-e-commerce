Imports PayFlowPro

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
      ' configure PayFlowPro request
      Dim ParmList As String
      ParmList = "USER=" + _processor.Configuration.PayFlowProUser _
              + "&VENDOR=" + _processor.Configuration.PayFlowProVendor _
              + "&PARTNER=" + _processor.Configuration.PayFlowProPartner _
              + "&PWD=" + _processor.Configuration.PayFlowProPwd _
              + "&TRXTYPE=D" _
              + "&TENDER=C" _
              + "&ORIGID=" + _reference

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
        ' audit and continue
        _processor.AddAudit( _
          "Funds deducted from customer credit card account.", 20402)
        _processor.UpdateOrderStatus(5)
        _processor.ContinueNow = True
      Else
        _processor.AddAudit( _
          "Error taking funds from customer credit card account.", 20403)
        _processor.MailAdmin("Credit card fulfillment declined.", _
          "Data exchanged:" & Chr(10) & ParmList & Chr(10) & Chr(10) _
          & response, 1)
      End If
    Catch
      ' fund checking failure
      Throw _
         New OrderProcessorException("Error occured while taking payment.", 4)
    End Try
    _processor.AddAudit("PSTakePayment finished.", 20401)
  End Sub
End Class
