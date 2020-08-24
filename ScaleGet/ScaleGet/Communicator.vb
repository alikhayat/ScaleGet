Imports System.Net.Sockets
Imports System.Text
Public Class communicator
    Dim TCPClient As New System.Net.Sockets.TcpClient()
    Dim NetworkStream As NetworkStream
    Dim Address, Port As String
    Public Sub New(ByVal _Address As String, ByVal _Port As String)
        Address = _Address
        Port = _Port
    End Sub
    Public Function InializeComm(ByVal ScaleType As Main.ScaleType) As List(Of Byte())
        Try
            TCPClient.NoDelay = False
            TCPClient.Connect(System.Net.IPAddress.Parse(Address), Port)
            NetworkStream = TCPClient.GetStream

            Return RetrieveData(ScaleType)
        Catch ex As Exception
            TCPClient.Close()
            Return Nothing
        End Try
    End Function
    Private Function RetrieveData(ByVal ScaleType As Main.ScaleType) As List(Of Byte())
        Dim InStream(TCPClient.ReceiveBufferSize) As Byte
        Dim Datalist As New List(Of Byte())
        Dim Count As Integer = 0
        Dim Avery As New AveryRetrieve
        Dim StopByteSize As Integer = Avery.RetrieveStopByte
        Dim CMD As Byte()
        Dim ReadData As String = ""
        Try
            Do Until InStream.Length = StopByteSize
                If NetworkStream.CanWrite And NetworkStream.CanRead Then
                    CMD = Avery.RetrievePluByte(Count)
                    ReDim Preserve InStream(TCPClient.ReceiveBufferSize)
                    NetworkStream.Write(CMD, 0, CMD.Length)

                    NetworkStream.Read(InStream, 0, TCPClient.ReceiveBufferSize)

                    Count += 1
                    ReadData = Encoding.ASCII.GetString(InStream)
                    ReadData = ReadData.Replace(ChrW(0), "")
                    If ReadData.Length <> 0 Then
                        ReDim Preserve InStream(ReadData.Length)
                    Else
                        Return Datalist
                    End If
                    If InStream.Length <> StopByteSize Then
                        Datalist.Add(InStream)
                    End If
                End If
            Loop
            Return Datalist
        Catch ex As Exception
            Return Nothing
        Finally
            TCPClient.Close()
            NetworkStream.Close()
            NetworkStream.Dispose()
        End Try
    End Function
End Class
