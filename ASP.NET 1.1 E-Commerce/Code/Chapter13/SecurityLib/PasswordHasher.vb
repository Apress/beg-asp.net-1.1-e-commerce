Imports System.Security.Cryptography

Public Class PasswordHasher
  Private Shared hasher As SHA1Managed = New SHA1Managed

  Private Sub New()
    ' do nothing, make class uncreatable
  End Sub

  Public Shared Function Hash(ByVal password As String) As String
    ' convert password to byte array
    Dim passwordBytes() As Byte = _
        System.Text.ASCIIEncoding.ASCII.GetBytes(password)

    ' generate hash from byte array of password
    Dim passwordHash() As Byte = hasher.ComputeHash(passwordBytes)

    ' convert hash to string
    Return Convert.ToBase64String(passwordHash, 0, passwordHash.Length)
  End Function
End Class




