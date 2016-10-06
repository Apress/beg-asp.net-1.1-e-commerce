Imports System.Xml.Serialization

Public Class TxnDetailsClass
  <XmlElement("merchantreference")> _
  Public MerchantReference As String

  <XmlElement("amount")> _
  Public Amount As AmountClass = New AmountClass
End Class
