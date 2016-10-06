' 4th pipeline stage – after confirmation that supplier has goods available
Public Class PSStockOK
  Implements IPipelineSection
  Private _processor As OrderProcessor

  Public Sub Process(ByVal processor As OrderProcessor) _
     Implements IPipelineSection.Process

    _processor = processor
    _processor.AddAudit("PSStockOK started.", 20300)

    ' the method is called when the supplier confirms that stock is available, 
    ' so we don't have to do anything else here.
    _processor.AddAudit("Stock confirmed by supplier.", 20302)
    _processor.UpdateOrderStatus(4)
    _processor.ContinueNow = True
    _processor.AddAudit("PSStockOK finished.", 20301)
  End Sub
End Class
