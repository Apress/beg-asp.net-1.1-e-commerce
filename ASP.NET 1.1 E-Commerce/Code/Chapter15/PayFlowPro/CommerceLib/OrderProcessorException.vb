Public Class OrderProcessorException
  Inherits Exception

  Public Sub New(ByVal message As String, ByVal sourceStage As Integer)
    MyBase.New(message)
    _sourceStage = sourceStage
  End Sub

  Private _sourceStage As Integer

  Public ReadOnly Property SourceStage() As Integer
    Get
      Return _sourceStage
    End Get
  End Property
End Class