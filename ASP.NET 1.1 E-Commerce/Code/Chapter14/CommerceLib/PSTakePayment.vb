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
      ' take customer funds 
      ' assume success for now

      ' audit and continue
      _processor.AddAudit("Funds deducted from customer credit card " _
                          & "account.", 20402)
      _processor.UpdateOrderStatus(5)
      _processor.ContinueNow = True
    Catch
      ' fund checking failure
      Throw _
         New OrderProcessorException("Error occured while taking payment.", 4)
    End Try
    _processor.AddAudit("PSTakePayment finished.", 20401)
  End Sub
End Class
