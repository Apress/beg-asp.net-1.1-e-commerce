Imports System.Net
Imports System.IO
Imports System.Text
Imports System.Xml.Serialization

<XmlRoot("Request")> _
Public Class DataCashRequest
  <XmlElement("Authentication")> _
  Public Authentication As AuthenticationClass = New AuthenticationClass

  <XmlElement("Transaction")> _
  Public Transaction As TransactionClass = New TransactionClass
  Public Function GetResponse(ByVal url As String) As DataCashResponse
    ' Configure HTTP Request
    Dim httpRequest As HttpWebRequest
    httpRequest = WebRequest.Create(url)
    httpRequest.Method = "POST"

    ' Prepare correct encoding for XML serialization
    Dim encoding As UTF8Encoding = New UTF8Encoding

    ' Use Xml property to obtain serialized XML data
    ' Convert into bytes using encoding specified above and get length
    Dim bodyBytes() As Byte = encoding.GetBytes(Xml)
    httpRequest.ContentLength = bodyBytes.Length

    ' Get HTTP Request stream for putting XML data into
    Dim httpRequestBodyStream As Stream = _
      httpRequest.GetRequestStream()

    ' Fill stream with serialized XML data
    httpRequestBodyStream.Write(bodyBytes, 0, bodyBytes.Length)
    httpRequestBodyStream.Close()

    ' Get HTTP Response
    Dim httpResponseStream As StreamReader
    Dim httpResponse As HttpWebResponse = httpRequest.GetResponse()
    httpResponseStream = _
      New StreamReader(httpResponse.GetResponseStream(), _
                       System.Text.Encoding.ASCII)

    Dim httpResponseBody As String

    ' Extract XML from response
    httpResponseBody = httpResponseStream.ReadToEnd()
    httpResponseStream.Close()

    ' Ignore everyhthing that isn't XML by removing headers
    httpResponseBody = _
      httpResponseBody.Substring(httpResponseBody.IndexOf("<?xml"))

    ' Deserialize XML into DataCashResponse
    Dim serializer As XmlSerializer = _
      New XmlSerializer(GetType(DataCashResponse))
    Dim responseReader As StringReader = New StringReader(httpResponseBody)

    ' Return DataCashResponse result
    Return CType(serializer.Deserialize(responseReader), DataCashResponse)
  End Function

  <XmlIgnore()> _
  Public ReadOnly Property Xml()
    Get
      ' Prepare XML serializer
      Dim serializer As XmlSerializer = _
        New XmlSerializer(GetType(DataCashRequest))

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
