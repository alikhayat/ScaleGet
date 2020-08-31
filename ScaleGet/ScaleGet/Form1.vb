Imports System.Net
Public Class Main
    Public Enum ScaleType
        Avery
        ToledoBcom
        ToledoBPlus
    End Enum
    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label1.Text = "V" + My.Settings.Ver
        If My.Settings.DefaultDestination = String.Empty Then
            Label6.Text = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\ScaleGet"
        Else
            Label6.Text = My.Settings.DefaultDestination
        End If

        ComboBox1.Items.Add("Avery")
        'ComboBox1.Items.Add("Toledo bcom")
        'ComboBox1.Items.Add("Toledo bplus")
        IpTextBox1.Text = String.Empty
    End Sub
    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        If ValidateFields() Then
            If ComboBox1.SelectedIndex = 0 Then
                Dim Avery As New AveryRetrieve
                Avery.RetrieveData(System.Net.IPAddress.Parse(IpTextBox1.Text), TextBox2.Text, TextBox1.Text, Label6.Text)
            End If
        Else
            MsgBox("Fill required fields")
        End If
    End Sub
    Private Function ValidateIPv4(ByVal ipString As String) As Boolean
        If String.IsNullOrWhiteSpace(ipString) Then
            Return False
        End If

        Dim splitValues As String() = ipString.Split("."c)

        If splitValues.Length <> 4 Then
            Return False
        End If

        Dim tempForParsing As Byte
        Return splitValues.All(Function(r) Byte.TryParse(r, tempForParsing))
    End Function

    Private Sub MaskedTextBox1_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs)
        'If Not ValidateIPv4(MaskedTextBox1.Text) Then
        '    MaskedTextBox1.ForeColor = Color.Red
        'Else
        '    MaskedTextBox1.ForeColor = Color.Black
        'End If
    End Sub
    Private Function ValidateFields() As Boolean
        If ComboBox1.SelectedIndex = -1 Then
            Return False
        End If
        If TextBox1.Text = String.Empty Then
            Return False
        End If
        If TextBox2.Text = String.Empty Or TextBox2.Text.Length < 4 Then
            Return False
        End If
        'If MaskedTextBox1.Text <> String.Empty Then
        '    If Not ValidateIPv4(MaskedTextBox1.Text) Then
        '        Return False
        '    End If
        '    Dim ip As IPAddress
        '    If Not IPAddress.TryParse(MaskedTextBox1.Text, ip) Then
        '        Return False
        '    End If
        'Else
        '    Return False
        'End If

        Return True
    End Function

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub TextBox2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub
    Private Sub ClearForm()
        TextBox1.Text = String.Empty
        IpTextBox1.Text = String.Empty
        TextBox2.Text = String.Empty
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If (FolderBrowserDialog1.ShowDialog() = DialogResult.OK) Then
            Label6.Text = FolderBrowserDialog1.SelectedPath
            My.Settings.DefaultDestination = FolderBrowserDialog1.SelectedPath
        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.SelectedIndex = 0 Then
            TextBox2.Text = "3001"
        ElseIf ComboBox1.SelectedIndex = -1 Then
            TextBox2.Text = String.Empty
        End If
    End Sub
End Class
