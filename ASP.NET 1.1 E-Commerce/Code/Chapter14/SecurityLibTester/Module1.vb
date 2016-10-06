Imports SecurityLib

Module Module1

  Sub Main()
    ' code for 1st Try it Out
    Console.WriteLine("Enter your password:")
    Dim password1 As String = Console.ReadLine()
    Dim hash1 As String = PasswordHasher.Hash(password1)
    Console.WriteLine("The hash of this password is: {0}", hash1)
    Console.WriteLine("Enter your password again:")
    Dim password2 As String = Console.ReadLine()
    Dim hash2 As String = PasswordHasher.Hash(password2)
    Console.WriteLine("The hash of this password is: {0}", hash2)
    If hash1 = hash2 Then
      Console.WriteLine("The passwords match! Welcome!")
    Else
      Console.WriteLine("Password invalid. Armed guards are on their way.")
    End If

    '' code for 2nd Try it Out
    'Console.WriteLine("Enter data to encrypt:")
    'Dim stringToEncrypt As String = Console.ReadLine()
    'Dim encryptedString = StringEncryptor.Encrypt(stringToEncrypt)
    'Console.WriteLine("Encrypted data: {0}", encryptedString)
    'Console.WriteLine( _
    '   "Enter data to decrypt (hit enter to decrypt above data):")
    'Dim stringToDecrypt As String = Console.ReadLine()
    'If stringToDecrypt = "" Then
    '  stringToDecrypt = encryptedString
    'End If
    'Dim decryptedString As String = StringEncryptor.Decrypt(stringToDecrypt)
    'Console.WriteLine("Decrypted data: {0}", decryptedString)

    '' code for 3rd Try it Out
    'Console.WriteLine("Enter data to encrypt:")
    'Console.WriteLine("Card Holder:")
    'Dim cardHolder As String = Console.ReadLine()
    'Console.WriteLine("Card Number:")
    'Dim expiryDate As String = Console.ReadLine()
    'Console.WriteLine("Issue Date:")
    'Dim cardNumber As String = Console.ReadLine()
    'Console.WriteLine("Expiry Date:")
    'Dim issueDate As String = Console.ReadLine()
    'Console.WriteLine("Issue Number:")
    'Dim issueNumber As String = Console.ReadLine()
    'Console.WriteLine("Card Type:")
    'Dim cardType As String = Console.ReadLine()

    'Dim encryptedCard As SecureCard = _
    '    New SecureCard(cardHolder, cardNumber, issueDate, expiryDate, _
    '    issueNumber, cardType)
    'Console.WriteLine("Encrypted data: {0}", encryptedCard.EncryptedData)

    'Console.WriteLine( _
    '    "Enter data to decrypt (hit enter to decrypt above data):")
    'Dim stringToDecrypt As String = Console.ReadLine()
    'If stringToDecrypt = "" Then
    '  stringToDecrypt = encryptedCard.EncryptedData
    'End If
    'Dim decryptedCard As SecureCard = New SecureCard(stringToDecrypt)
    'Console.WriteLine("Decrypted data: {0}, {1}, {2}, {3}, {4}, {5}", _
    '    decryptedCard.CardHolder, decryptedCard.CardNumber, _
    '    decryptedCard.IssueDate, decryptedCard.ExpiryDate, _
    '    decryptedCard.IssueNumber, decryptedCard.CardType)

  End Sub

End Module