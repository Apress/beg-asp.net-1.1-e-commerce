' 7th pipeline stage - after confirmation that supplier has shipped goods
Public Class PSShipOK
  Implements IPipelineSection
  Private _processor As OrderProcessor

  Public Sub Process(ByVal processor As OrderProcessor) _
     Implements IPipelineSection.Process

    _processor = processor
    _processor.AddAudit("PSShipOK started.", 20600)
    ' set order shipment date
    _processor.SetDateShipped()
    _processor.AddAudit("Order dispatched by supplier.", 20602)
    _processor.UpdateOrderStatus(7)
    _processor.ContinueNow = True
    _processor.AddAudit("PSShipOK finished.", 20601)
  End Sub
End Class
