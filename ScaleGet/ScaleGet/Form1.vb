Public Class Main
    Public Enum ScaleType
        Avery
        ToledoBcom
        ToledoBPlus
    End Enum
    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim Commu As communicator = New communicator("10.3.5.7", 3001)
        Dim Data As New List(Of Byte())
        Data = Commu.InializeComm(ScaleType.Avery)
    End Sub
End Class
