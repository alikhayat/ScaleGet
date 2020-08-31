Imports System.Net.Mime.MediaTypeNames
Imports Microsoft.Office.Interop
Imports System.Reflection

Public Class GenerateOutput
    Public Sub GenerateExcel(ByVal Data As Dictionary(Of UInt16, UInt32), ByVal OutPutString As String)
        Dim Excel As New Microsoft.Office.Interop.Excel.Application
        Dim WB As Excel.Workbook
        Dim WS As Excel.Worksheet
        Dim row As Integer = 1
        Dim column As Integer = 1
        Try
            WB = Excel.Workbooks.Add(Missing.Value)
            WS = WB.ActiveSheet
            Excel.Visible = False

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
            WS.SaveAs(OutPutString)
            MsgBox("Excel saved")
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            WB.Close()
            Excel.Quit()
        End Try
    End Sub
End Class
