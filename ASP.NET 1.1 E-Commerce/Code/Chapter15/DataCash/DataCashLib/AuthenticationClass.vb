Imports System.Xml.Serialization

Public Class AuthenticationClass
  <XmlElement("password")> _
  Public Password As String

  <XmlElement("client")> _
  Public Client As String
End Class
