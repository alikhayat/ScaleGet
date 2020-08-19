Public Class AveryRetrieve
    Dim GetP As Byte() = {&H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0,
                          &H0, &H0, &H0, &H0, &H0, &H0, &H1D, &HB0, &H0, &H3C, &H64, &HFE, &H20, &H49, &H0, &H0, &HD, &H51, &H0, &H0, &H1, &H1, &H4E,
                          &H0, &H0, &H2D, &HB0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H1, &H9, &H0, &H9, &H18, &H4E, &H72, &H9F, &HFF, &H0, &H0, &H0,
                          &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H63}
    Dim StopByte As Byte() = {&H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0,
                              &H0, &H0, &H0, &H0, &H1D, &HB0, &H0, &H3C, &H64, &HFE, &H20, &H49, &H0, &H0, &HD, &H51, &H0, &H0, &H1, &H1, &H4E, &H0, &H0,
                              &H55, &HC6, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H1, &H9, &H0, &H9, &H18, &H4E, &H72, &H9F, &HFF, &H0, &H0, &H0, &H0, &H0, &H0,
                              &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &HEF, &H0, &H0, &H0, &H0, &H0, &H63}
    Public Function RetrievePluByte() As Byte()
        Return GetP
    End Function
    Public Function RetrieveStopByte() As Byte()
        Return StopByte
    End Function
End Class
