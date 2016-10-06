Imports System.Xml.Serialization

Public Class CardTxnRequestClass
  <XmlElement("method")> _
  Public Method As String

  <XmlElement("Card")> _
  Public Card As CardClass = New CardClass
End Class
