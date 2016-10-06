Imports System.Xml.Serialization

Public Class HistoricTxnClass
  <XmlElement("reference")> _
  Public Reference As String

  <XmlElement("authcode")> _
  Public AuthCode As String

  <XmlElement("method")> _
  Public Method As String

  <XmlElement("tran_code")> _
  Public TranCode As String

  <XmlElement("duedate")> _
  Public DueDate As String
End Class
