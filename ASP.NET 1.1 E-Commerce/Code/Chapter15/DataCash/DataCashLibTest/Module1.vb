Imports DataCashLib
Imports System.Xml.Serialization
Imports System.Text
Imports System.IO

Module Module1
  Sub Main()
    ' Initialize variables
    Dim request As DataCashRequest
    Dim requestSerializer As XmlSerializer = _
      New XmlSerializer(GetType(DataCashRequest))
    Dim response As DataCashResponse
    Dim responseSerializer As XmlSerializer = _
      New XmlSerializer(GetType(DataCashResponse))
    Dim xmlBuilder As StringBuilder
    Dim xmlWriter As StringWriter
    Dim dataCashUrl As String = "https://testserver.datacash.com/Transaction"
    Dim dataCashClient As String = "99216400"
    Dim dataCashPassword As String = "ZmEgbGr"

    ' Construct pre request
    request = New DataCashRequest
    request.Authentication.Client = dataCashClient
    request.Authentication.Password = dataCashPassword
    request.Transaction.TxnDetails.MerchantReference = "9999999"
    request.Transaction.TxnDetails.Amount.Amount = "49.99"
    request.Transaction.TxnDetails.Amount.Currency = "GBP"
    request.Transaction.CardTxn.Method = "pre"
    request.Transaction.CardTxn.Card.CardNumber = "4444333322221111"
    request.Transaction.CardTxn.Card.ExpiryDate = "10/04"

    ' Display pre request
    Console.WriteLine("Pre Request:")
    xmlBuilder = New StringBuilder
    xmlWriter = New StringWriter(xmlBuilder)
    requestSerializer.Serialize(xmlWriter, request)
    Console.WriteLine(xmlBuilder.ToString())
    Console.WriteLine()

    ' Get pre response
    response = request.GetResponse(dataCashUrl)

    ' Display pre response
    Console.WriteLine("Pre Response:")
    xmlBuilder = New StringBuilder
    xmlWriter = New StringWriter(xmlBuilder)
    responseSerializer.Serialize(xmlWriter, response)
    Console.WriteLine(xmlBuilder.ToString())
    Console.WriteLine()

    ' Construct fulfil request
    request = New DataCashRequest
    request.Authentication.Client = dataCashClient
    request.Authentication.Password = dataCashPassword
    request.Transaction.HistoricTxn.Method = "fulfill"
    request.Transaction.HistoricTxn.AuthCode = response.MerchantReference
    request.Transaction.HistoricTxn.Reference = response.DatacashReference

    ' Display fulfil request
    Console.WriteLine("Fulfil Request:")
    xmlBuilder = New StringBuilder
    xmlWriter = New StringWriter(xmlBuilder)
    requestSerializer.Serialize(xmlWriter, request)
    Console.WriteLine(xmlBuilder.ToString())
    Console.WriteLine()

    ' Get fulfil response
    response = request.GetResponse(dataCashUrl)

    ' Display fulfil response
    Console.WriteLine("Fulfil Response:")
    xmlBuilder = New StringBuilder
    xmlWriter = New StringWriter(xmlBuilder)
    responseSerializer.Serialize(xmlWriter, response)
    Console.WriteLine(xmlBuilder.ToString())
  End Sub
End Module
