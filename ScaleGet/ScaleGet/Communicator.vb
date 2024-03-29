﻿Imports System.Net.Sockets
Imports System.Text
Public Class communicator
    Dim TCPClient As New System.Net.Sockets.TcpClient()
    Dim NetworkStream As NetworkStream
    Dim Address As System.Net.IPAddress
    Dim Port As String
    Public Sub New(ByVal _Address As System.Net.IPAddress, ByVal _Port As String)
        Address = _Address
        Port = _Port
    End Sub
    Public Function InializeComm(ByVal ScaleType As Main.ScaleType) As List(Of Byte())
        Try
            TCPClient.NoDelay = False
            TCPClient.Connect(Address, Port)
            TCPClient.ReceiveBufferSize = 599
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
        Dim DataCount As Integer = 0
        Try
            Do Until DataCount = StopByteSize
                If NetworkStream.CanWrite And NetworkStream.CanRead Then
                    CMD = Avery.RetrievePluByte(Count)
                    Array.Clear(InStream, 0, TCPClient.ReceiveBufferSize)
                    NetworkStream.Write(CMD, 0, CMD.Length)

                    NetworkStream.Read(InStream, 0, TCPClient.ReceiveBufferSize)

                    Count += 1

                    ReadData = Encoding.ASCII.GetString(InStream)
                    ReadData = ReadData.Replace(ChrW(0), "")
                    DataCount = ReadData.Length
                   
                    If DataCount <> StopByteSize Then
                        Dim ActualData(599) As Byte
                        Array.Copy(InStream, ActualData, TCPClient.ReceiveBufferSize)
                        Datalist.Add(ActualData)
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
