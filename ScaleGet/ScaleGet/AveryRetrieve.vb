Option Strict Off

Imports System.Net.Mime.MediaTypeNames
Imports Microsoft.Office.Interop
Imports System.Reflection

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
        Return 16
    End Function
    Public Function RequestStreamSize() As Integer
        Return RequestSize
    End Function
    Public Sub RetrieveData(ByVal Address As String, ByVal Port As String, ByVal ScaleNo As Int16)
        Dim Data As New Dictionary(Of UInt16, UInt32)
        Dim Plu As UInt16 = 0
        Dim Price As UInt32 = 0
        Dim HexPlu() As Byte = New Byte() {0, 0}
        Dim HexPrice() As Byte = New Byte() {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}
        Dim Comm As New communicator(Address, Port)
        Dim DataList As New List(Of Byte())
        Try
            DataList = Comm.InializeComm(Main.ScaleType.Avery)
            If IsNothing(DataList) = False Then
                For i As Integer = 0 To DataList.Count - 1
                    'Fill Byte Array's
                    HexPlu(0) = DataList.Item(i)(99)
                    HexPlu(1) = DataList.Item(i)(98)

                    HexPrice(0) = DataList.Item(i)(108)
                    HexPrice(1) = DataList.Item(i)(107)
                    HexPrice(2) = DataList.Item(i)(106)

                    'Convert Byte Arrays to their decimal Value
                    Plu = Convert.ToUInt16(BitConverter.ToUInt16(HexPlu, 0))
                    Price = Convert.ToUInt32(BitConverter.ToUInt32(HexPrice, 0))

                    'Fill Dictionary
                    Data.Add(Plu, Price)
                Next
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        'Produce excel sheet

        Dim excelapp As New Excel.Application
        Dim WB As Excel.Workbook
        Dim WS As Excel.Worksheet
        Dim column As Integer = 1

        WB = excelapp.Workbooks.Add(Missing.Value)
        'WB = WB.Sheets()
        WS = WB.ActiveSheet

        excelapp.Visible = True
        'excelapp.UserControl = True
        Dim row As Integer = 1
        For Each key As UInt16 In Data.Keys
            WS.Cells(row, column).Value = key
            row += 1
        Next
        column = 2
        row = 1
        For Each value As UInt32 In Data.Values
            WS.Cells(row, column).Value = value
            row += 1
        Next
        WS.SaveAs("Test")
    End Sub
    Private Sub SurroundingSub()

    End Sub
End Class
