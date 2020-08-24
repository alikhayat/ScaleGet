Option Strict On
Public Class AveryRetrieve
    Dim GetP As Byte() = {&H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0,
                          &H0, &H0, &H0, &H0, &H0, &H0, &H1D, &HB0, &H0, &H3C, &H64, &HFE, &H20, &H49, &H0, &H0, &HD, &H51, &H0, &H0, &H1, &H1, &H4E,
                          &H0, &H0, &H2D, &HB0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H1, &H9, &H0, &H9, &H18, &H4E, &H72, &H9F, &HFF, &H0, &H0, &H0,
                          &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H63}
    Dim StopByte As Byte() = {&H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0,
                              &H0, &H0, &H0, &H0, &H1D, &HB0, &H0, &H3C, &H64, &HFE, &H20, &H49, &H0, &H0, &HD, &H51, &H0, &H0, &H1, &H1, &H4E, &H0, &H0,
                              &H55, &HC6, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H1, &H9, &H0, &H9, &H18, &H4E, &H72, &H9F, &HFF, &H0, &H0, &H0, &H0, &H0, &H0,
                              &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &HEF, &H0, &H0, &H0, &H0, &H0, &H63}
    Dim RequestSize As Integer = 24
    Public Function RetrievePluByte(ByVal Count As Integer) As Byte()
        If Count <= 255 Then
            GetP(86) = CByte("&H" + Hex(Count))
        ElseIf Count > 255 Then
            If Hex(Count).Length = 3 Then
                GetP(85) = CByte("&H" + Hex(Count).Substring(0, 1))
                GetP(86) = CByte("&H" + Hex(Count).Substring(1))
            ElseIf Hex(Count).Length = 4 Then
                GetP(85) = CByte("&H" + Hex(Count).Substring(0, 2))
                GetP(86) = CByte("&H" + Hex(Count).Substring(2))
            End If
        End If
        Return GetP
    End Function
    Public Function RetrieveStopByte() As Integer
        Return 25
    End Function
    Public Function RequestStreamSize() As Integer
        Return RequestSize
    End Function
    Public Sub RetrieveData(ByVal Address As String, ByVal Port As String, ByVal ScaleNo As Int16) As List(Of Int16)
        Dim Comm As New communicator(Address, Port)
        Dim DataList As List(Of Byte()) = Comm.InializeComm(Main.ScaleType.Avery)

    End Sub
End Class
