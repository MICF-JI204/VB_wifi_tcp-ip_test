Imports System.Net.Sockets
Imports System.Net
Module Module1

    'Dim listener As New TcpListener(14204)

    Sub Main()
        Dim localIP As IPAddress = IPAddress.Parse("127.0.0.1")
        Dim listener As New TcpListener(14204)
        listener.Start()
        Console.WriteLine("Listener OK!")
        If listener.Pending = True Then Console.WriteLine("Incoming connectiong")
        Dim client As TcpClient = listener.AcceptTcpClient()
        Dim datastream As NetworkStream = client.GetStream()
        Console.WriteLine("Incoming connection established")
        Dim bytes(1024) As Byte
        Dim data As String = Nothing
        Dim i As Integer
        While True
            If datastream.DataAvailable Then
                i = datastream.Read(bytes, 0, bytes.Length)
                ' Translate data bytes to a ASCII string.
                data = System.Text.Encoding.ASCII.GetString(bytes, 0, i)
                Console.WriteLine("Received: {0}", data)

                ' Process the data sent by the client.
                data = data.ToUpper()
                Dim msg As Byte() = System.Text.Encoding.ASCII.GetBytes(data)

                ' Send back a response.
                datastream.Write(msg, 0, msg.Length)
                Console.WriteLine("Sent: {0}", data)
            End If
        End While
    End Sub

End Module
