Imports System.Xml.Serialization

Public Class CardClass
  <XmlElement("pan")> _
  Public CardNumber As String

  <XmlElement("expirydate")> _
  Public ExpiryDate As String

  <XmlElement("startdate")> _
  Public StartDate As String

  <XmlElement("issuenumber")> _
  Public IssueNumber As String
End Class
