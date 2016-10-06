Imports System.Xml.Serialization

Public Class CardTxnResponseClass
  <XmlElement("card_scheme")> _
  Public CardScheme As String
  <XmlElement("country")> _
  Public Country As String

  <XmlElement("issuer")> _
  Public Issuer As String

  <XmlElement("authcode")> _
  Public AuthCode As String
End Class
