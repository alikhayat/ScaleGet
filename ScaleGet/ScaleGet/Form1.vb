Public Class Main
    Public Enum ScaleType
        Avery
        ToledoBcom
        ToledoBPlus
    End Enum
    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim b() As Byte = New Byte() {&H1, &H2, 3, 4}
        ' MsgBox(BitconverterExt.ToDecimal(b).ToString)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim Avery As New AveryRetrieve
        Avery.RetrieveData("10.3.5.3", "3001", 3)
    End Sub
End Class
