using System;
using System.Threading;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpClient client = new TcpClient();
            NetworkStream serverStream = default(NetworkStream);

            client.Connect("192.168.137.1", 8888); //Bağlantı
            Console.WriteLine("Bağlantı Kuruldu");
            serverStream = client.GetStream(); //Yayın Kanalına Bağlan

            while (true)
            {
                Console.WriteLine("Mesajı Gir:");
                string data = Console.ReadLine();

                byte[] outStream = System.Text.Encoding.ASCII.GetBytes(data + "$");
                serverStream.Write(outStream, 0, outStream.Length); //Bit Formatına çevir ve kanala yaz
                serverStream.Flush();

            }

        }
    }
}
