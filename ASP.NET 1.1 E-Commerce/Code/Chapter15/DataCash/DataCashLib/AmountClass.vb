Imports System.Xml.Serialization

Public Class AmountClass
  <XmlAttributeAttribute("currency")> _
  Public Currency As String

  <XmlText()> _
  Public Amount As String
End Class
