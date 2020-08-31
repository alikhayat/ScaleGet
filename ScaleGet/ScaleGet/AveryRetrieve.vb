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
    Public Sub RetrieveData(ByVal Address As System.Net.IPAddress, ByVal Port As String, ByVal ScaleNo As String, ByVal Directory As String)
        Dim Data As New Dictionary(Of UInt16, UInt32)
        Dim Plu As UInt16 = 0
        Dim Price As UInt32 = 0
        Dim HexPlu() As Byte = New Byte() {0, 0}
        Dim HexPrice() As Byte = New Byte() {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}
        Dim Comm As New communicator(Address, Port)
        Dim DataList As New List(Of Byte())
        Try
            'Attempt comunication with scale and retrieve Bytes
            DataList = Comm.InializeComm(Main.ScaleType.Avery)
            If IsNothing(DataList) = False Then
                If DataList.Count > 1 Then
                    For i As Integer = 0 To DataList.Count - 1

                        'Fill Byte Array's
                        HexPlu(0) = DataList.Item(i)(99)
                        HexPlu(1) = DataList.Item(i)(98)

                        HexPrice(0) = DataList.Item(i)(108)
                        HexPrice(1) = DataList.Item(i)(107)
                        HexPrice(2) = DataList.Item(i)(106)

                        'Convert Byte Arrays to thier decimal Value
                        Plu = Convert.ToUInt16(BitConverter.ToUInt16(HexPlu, 0))
                        Price = Convert.ToUInt32(BitConverter.ToUInt32(HexPrice, 0))

                        'Fill Dictionary
                        Data.Add(Plu, Price)
                    Next
                Else
                    MsgBox("Scale has no PLU'S")
                    Exit Sub
                End If
            Else
                MsgBox("Could not connect to scale, Check connection and try again")
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Exit Sub
        End Try

        'Produce excel sheet
        Dim Excel As New GenerateOutput
        Dim OutputString As String = Directory + "\" + ScaleNo + "-Avery.xlsx"
        Excel.GenerateExcel(Data, OutputString)
    End Sub
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
        Return 16
    End Function
    Public Function RequestStreamSize() As Integer
        Return RequestSize
    End Function
End Class
