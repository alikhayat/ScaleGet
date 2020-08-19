Imports System.Net.Sockets
Public Class communicator
    Dim TCPClient As New System.Net.Sockets.TcpClient()
    Dim NetworkStream As NetworkStream
    Dim Address, Port As String
    Public Sub New(ByVal _Address As String, ByVal _Port As String)
        Address = _Address
        Port = _Port
    End Sub
    Public Function InializeComm(ByVal ScaleType As Main.ScaleType) As List(Of Byte())
        Dim dataList As New List(Of Byte())
        Try
            Dim TcpListener = New TcpListener(System.Net.IPAddress.Parse(Address), Port)
            TcpListener.Start()
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Private Function RetrieveData(ByVal CMD As Byte(), ByVal StopByte As Byte(), ByVal RequestSize As Integer) As List(Of Byte())
        Dim InStream(TCPClient.ReceiveBufferSize) As Byte
        Dim Datalist As New List(Of Byte())
        Try
            Do Until StopByte.SequenceEqual(InStream)
                If NetworkStream.CanWrite And NetworkStream.CanRead Then
                    TCPClient.NoDelay = False
                    NetworkStream.Write(CMD, 0, CMD.Length)
                    NetworkStream.Read(InStream, 0, CInt(TCPClient.ReceiveBufferSize))
                    'Might need some more work here
                    Datalist.Add(InStream)
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
