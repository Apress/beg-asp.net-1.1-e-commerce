Imports System.Xml.Serialization

Public Class TransactionClass
  <XmlElement("TxnDetails")> _
  Public TxnDetails As TxnDetailsClass = New TxnDetailsClass
  Private _cardTxn As CardTxnRequestClass

  Private _historicTxn As HistoricTxnClass

  <XmlElement("CardTxn")> _
  Public Property CardTxn() As CardTxnRequestClass
    Get
      If _historicTxn Is Nothing Then
        If _cardTxn Is Nothing Then
          _cardTxn = New CardTxnRequestClass
        End If
        Return _cardTxn
      Else
        Return Nothing
      End If
    End Get
    Set(ByVal Value As CardTxnRequestClass)
      _cardTxn = Value
    End Set
  End Property

  <XmlElement("HistoricTxn")> _
  Public Property HistoricTxn() As HistoricTxnClass
    Get
      If _cardTxn Is Nothing Then
        If _historicTxn Is Nothing Then
          _historicTxn = New HistoricTxnClass
        End If
        Return _historicTxn
      Else
        Return Nothing
      End If
    End Get
    Set(ByVal Value As HistoricTxnClass)
      _historicTxn = Value
    End Set
  End Property
End Class
