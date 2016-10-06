Imports System.Data.SqlClient
Imports CommerceLib

Module Module1

  Sub Main()
    Dim configuration As OrderProcessorConfiguration = _
     New OrderProcessorConfiguration( _
       "server=(local);Integrated Security=SSPI;database=JokePoint", _
       "MAILSERVER", _
       "AdminEMail", _
       "customerservice@JokePoint.com", _
       "orderprocessor@JokePoint.com", _
       "SupplierEMail")
    Dim processor As New OrderProcessor
    ' 1st call to OrderProcessor, normally from Checkout.aspx
    processor.Process(1, configuration)
    Console.ReadLine()
    ' 2nd call to OrderProcessor, normally from OrdersAdminPage.aspx
    processor.Process(1, configuration)
    Console.ReadLine()
    ' 3rd call to OrderProcessor, normally from OrdersAdminPage.aspx
    processor.Process(1, configuration)
  End Sub

End Module
