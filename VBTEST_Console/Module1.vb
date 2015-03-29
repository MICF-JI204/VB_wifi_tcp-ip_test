Imports System.IO.Ports
Module Module1


    'Dim listener As New TcpListener(14204)

    Sub Main()

        Dim serialport As New SerialPort

        Console.WriteLine("Listing Available Serial Ports")
        Dim str As String
        For Each str In My.Computer.Ports.SerialPortNames
            Console.WriteLine(str)
        Next
        Console.WriteLine("Select Proper Port")
        Dim portname As String = Console.ReadLine()
        portname.Replace(vbLf, "")
        portname.Replace(vbCr, "") '去掉回车空格
        serialport.PortName = portname
        serialport.Parity = Parity.None
        serialport.BaudRate = 9600
        serialport.StopBits = StopBits.One
        serialport.DtrEnable = False
        Console.WriteLine("Opening Serial Port : " & portname & "Now")
        serialport.Open()
        While True
            Console.Write(serialport.ReadChar())
        End While

    End Sub


End Module
