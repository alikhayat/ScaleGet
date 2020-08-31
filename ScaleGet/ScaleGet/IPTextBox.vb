'9/27/2006
'KLEINMA
'www.vbforums.com
'
'THIS USER CONTROL MIMICS THE IP ENTRY BOX IN WINDOWS TCP/IP SETTINGS
'AS MUCH AS POSSIBLE, PLEASE FEEL FREE TO MODIFY IT BUT LET ME KNOW
'OF ANYTHING YOU DO TO MAKE IT BETTER, OR BUG FIXES

Public Class IPTextBox

    Private _CurrentEntry As String = String.Empty

    Private Sub txtIP_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtIP1.GotFocus, txtIP2.GotFocus, txtIP3.GotFocus, txtIP4.GotFocus
        'STORE THE CURRENT ENTRY VALUE IN A PRIVATE STRING
        _CurrentEntry = DirectCast(sender, TextBox).Text
    End Sub

    Private Sub txtIP_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtIP1.KeyPress, txtIP2.KeyPress, txtIP3.KeyPress, txtIP4.KeyPress
        Dim txtBox As TextBox = DirectCast(sender, TextBox)
        'ONLY ALLOW CONTROL CHARS (LIKE BACKSPACE) AND NUMBERS TO BE ENTERED
        Select Case Char.GetUnicodeCategory(e.KeyChar)
            Case Globalization.UnicodeCategory.Control, Globalization.UnicodeCategory.DecimalDigitNumber
            Case Else
                e.Handled = True
        End Select
        Debug.Print(e.KeyChar.ToString)

        If e.KeyChar = "." Then
            Me.SelectNextControl(txtBox, True, True, False, False)
        End If
    End Sub

    Private Sub txtIP_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtIP1.LostFocus, txtIP2.LostFocus, txtIP3.LostFocus, txtIP4.LostFocus
        Dim txtBox As TextBox = DirectCast(sender, TextBox)

        'IF ITS EMPTY, DO NOTHING
        If txtBox.Text = String.Empty Then Return

        'SINCE ITS NOT EMPTY, AND CAN ONLY BE A NUMBER, CONVERT TO INTEGER TO CHECK VALUE
        If Convert.ToInt32(txtBox.Text) > 255 Then
            txtBox.Text = _CurrentEntry
            MessageBox.Show("Value can not be higher than 255", "Invalid Value", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtBox.Focus()
        End If
    End Sub

    Private Sub txtIP_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtIP1.TextChanged, txtIP2.TextChanged, txtIP3.TextChanged, txtIP4.TextChanged
        Dim txtBox As TextBox = DirectCast(sender, TextBox)

        'THIS SHOULD HANDLE A BAD COPY/PASTE
        If Not Integer.TryParse(txtBox.Text, Nothing) Then
            txtBox.Text = _CurrentEntry
            Return
        End If

        'IF WE TYPED IN 3 DIGITS, SELECT THE NEXT CONTROL
        If txtBox.SelectionStart = 3 Then
            Me.SelectNextControl(txtBox, True, True, False, False)
        End If
    End Sub

    Public Overrides Property Text() As String
        Get
            'RETURN A FORMATTED IP ADDRESS
            Return String.Format("{0}.{1}.{2}.{3}", New String() {txtIP1.Text, txtIP2.Text, txtIP3.Text, txtIP4.Text})
        End Get
        Set(ByVal value As String)
            'SET THE IP ADDRESS
            If value = String.Empty Then
                txtIP1.Text = String.Empty
                txtIP2.Text = String.Empty
                txtIP3.Text = String.Empty
                txtIP4.Text = String.Empty
            ElseIf System.Text.RegularExpressions.Regex.IsMatch(value, "((2[0-4]\d|25[0-5]|[01]?\d\d?)\.){3}(2[0-4]\d|25[0-5]|[01]?\d\d?)") Then
                Dim Octets() As String = value.Split("."c)
                txtIP1.Text = Octets(0)
                txtIP2.Text = Octets(1)
                txtIP3.Text = Octets(2)
                txtIP4.Text = Octets(3)
            Else
                Throw New FormatException("Invalid IP format.")
            End If
        End Set
    End Property

End Class

