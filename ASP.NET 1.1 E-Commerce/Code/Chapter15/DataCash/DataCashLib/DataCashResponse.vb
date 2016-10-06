Imports System.IO
Imports System.Text
Imports System.Xml.Serialization

<XmlRoot("Response")> _
Public Class DataCashResponse
  <XmlElement("status")> _
  Public Status As String

  <XmlElement("reason")> _
  Public Reason As String

  <XmlElement("information")> _
  Public Information As String

  <XmlElement("merchantreference")> _
  Public MerchantReference As String

  <XmlElement("datacash_reference")> _
  Public DatacashReference As String

  <XmlElement("time")> _
  Public Time As String

  <XmlElement("mode")> _
  Public Mode As String

  <XmlElement("CardTxn")> _
  Public CardTxn As CardTxnResponseClass

  <XmlIgnore()> _
  Public ReadOnly Property Xml()
    Get
      ' Prepare XML serializer
      Dim serializer As XmlSerializer = _
        New XmlSerializer(GetType(DataCashResponse))
      ' Serialize into StringBuilder
      Dim bodyBuilder As StringBuilder = New StringBuilder
      Dim bodyWriter As StringWriter = New StringWriter(bodyBuilder)
      serializer.Serialize(bodyWriter, Me)

      ' Replace UTF-16 encoding with UTF-8 encoding
      Dim body As String = bodyBuilder.ToString()
      body = body.Replace("utf-16", "utf-8")
      Return body
    End Get
  End Property
End Class
