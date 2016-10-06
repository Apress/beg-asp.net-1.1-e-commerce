Public Class PSDummy
  Implements IPipelineSection

  Public Sub Process(ByVal processor As OrderProcessor) _
     Implements IPipelineSection.Process

    processor.AddAudit("PSDoNothing started.", 99999)
    processor.AddAudit("Customer: " & processor.CurrentCustomer.Name, 99999)
    processor.AddAudit("First item in order: " _
                     & processor.CurrentOrderDetails(0).ItemAsString, 99999)
    processor.MailAdmin("Test.", "Test mail from PSDummy.", 99999)
    processor.AddAudit("PSDoNothing finished.", 99999)
  End Sub
End Class

