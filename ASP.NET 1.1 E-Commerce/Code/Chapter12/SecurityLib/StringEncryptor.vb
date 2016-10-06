Imports System.Security.Cryptography
Imports System.IO

Public Class StringEncryptor
  Private Sub New()
    ' do nothing, make class uncreatable
  End Sub

  Public Shared Function Encrypt(ByVal sourceData As String) As String
    ' set key and initialization vector values
    Dim key() As Byte = New Byte() {1, 2, 3, 4, 5, 6, 7, 8}
    Dim iv() As Byte = New Byte() {1, 2, 3, 4, 5, 6, 7, 8}
    Try
      ' convert data to byte array
      Dim sourceDataBytes() As Byte = _
         System.Text.ASCIIEncoding.ASCII.GetBytes(sourceData)

      ' get target memory stream
      Dim tempStream As MemoryStream = New MemoryStream

      ' get encryptor and encryption stream
      Dim encryptor As DESCryptoServiceProvider = _
         New DESCryptoServiceProvider
      Dim encryptionStream As CryptoStream = _
         New CryptoStream(tempStream, encryptor.CreateEncryptor(key, iv), _
                          CryptoStreamMode.Write)

      ' encrypt data
      encryptionStream.Write(sourceDataBytes, 0, sourceDataBytes.Length)
      encryptionStream.FlushFinalBlock()

      ' put data into byte array
      Dim encryptedDataBytes() As Byte = tempStream.GetBuffer()

      ' convert encrypted data into string
      Return Convert.ToBase64String(encryptedDataBytes, 0, tempStream.Length)
    Catch
      Throw New StringEncryptorException("Unable to encrypt data.")
    End Try
  End Function

  Public Shared Function Decrypt(ByVal sourceData As String) As String
    ' set key and initialization vector values
    Dim key() As Byte = New Byte() {1, 2, 3, 4, 5, 6, 7, 8}
    Dim iv() As Byte = New Byte() {1, 2, 3, 4, 5, 6, 7, 8}
    Try
      ' convert data to byte array
      Dim encryptedDataBytes() As Byte = Convert.FromBase64String(sourceData)

      ' get source memory stream and fill it 
      Dim tempStream As MemoryStream = _
         New MemoryStream(encryptedDataBytes, 0, encryptedDataBytes.Length)

      ' get decryptor and decryption stream 
      Dim decryptor As DESCryptoServiceProvider = _
         New DESCryptoServiceProvider
      Dim decryptionStream As CryptoStream = _
         New CryptoStream(tempStream, decryptor.CreateDecryptor(key, iv), _
                          CryptoStreamMode.Read)

      ' decrypt data 
      Dim allDataReader As StreamReader = New StreamReader(decryptionStream)
      Return allDataReader.ReadToEnd()
    Catch
      Throw New StringEncryptorException("Unable to decrypt data.")
    End Try
  End Function
End Class
