Imports PayFlowPro

Module Module1

  Sub Main()
    Dim pfpro As New PFPro
    Dim Response As String
    Dim pCtlx As Integer

    Dim User As String
    Dim Vendor As String
    Dim Partner As String
    Dim Password As String

    Dim HostAddress As String
    Dim HostPort As Integer
    Dim ParmList As String
    Dim Timeout As Integer
    Dim ProxyAddress As String
    Dim ProxyPort As Integer
    Dim ProxyLogon As String
    Dim ProxyPassword As String

    Dim UserAuth As String

    User = "apresskarli"
    Vendor = "apresskarli"
    Partner = "VeriSign"
    Password = "loop99"

    HostAddress = "test-payflow.verisign.com"
    HostPort = 443
    ParmList = "&TRXTYPE=D&TENDER=C&ORIGID=V53A36838661"
    Timeout = 30
    ProxyAddress = ""
    ProxyPort = 0
    ProxyLogon = ""
    ProxyPassword = ""

    UserAuth = "USER=" + User + "&VENDOR=" + Vendor + "&PARTNER=" + Partner + "&PWD=" + Password

    ParmList = UserAuth + ParmList

    Console.WriteLine("Running PFProdotNETExample using VB...")
    Console.WriteLine("")

    pCtlx = pfpro.CreateContext(HostAddress, HostPort, Timeout, ProxyAddress, ProxyPort, ProxyLogon, ProxyPassword)

    Response = pfpro.SubmitTransaction(pCtlx, ParmList)

    pfpro.DestroyContext(pCtlx)

    Console.WriteLine(Response)
  End Sub

End Module
