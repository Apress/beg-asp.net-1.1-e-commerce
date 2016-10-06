Imports SecurityLib

' 2nd pipeline stage - used to check that the customer
' has the required funds available for purchase
Public Class PSCheckFunds
  Implements IPipelineSection

  Private _processor As OrderProcessor

  Public Sub Process(ByVal processor As OrderProcessor) _
     Implements IPipelineSection.Process

    _processor = processor
    _processor.AddAudit("PSCheckFunds started.", 20100)
    Try
      ' check customer funds
      ' assume they exist for now

      ' set order authorization code and reference
      _processor.SetOrderAuthCodeAndReference("AuthCode", "Reference")
      ' audit and continue
      _processor.AddAudit("Funds available for purchase.", 20102)
      _processor.UpdateOrderStatus(2)
      _processor.ContinueNow = True
    Catch
      ' fund checking failure
      Throw _
         New OrderProcessorException("Error occured while checking funds.", 1)
    End Try
    _processor.AddAudit("PSCheckFunds finished.", 20101)
  End Sub
End Class
