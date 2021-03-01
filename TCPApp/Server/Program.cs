using System;
using System.Threading;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace TCP_Chat_App
{
    class Program
    {
        static void Main(string[] args)
        {

            TcpListener serverSocket = new TcpListener(IPAddress.Any, 8888);
            TcpClient clientSocket = default(TcpClient);
            serverSocket.Start();

             while (true)
            {
                Console.WriteLine("Waiting for a connection...");
                clientSocket = serverSocket.AcceptTcpClient(); //Bir bağlantı isteği olursa kabul et
                Console.WriteLine("Connected!");
            }
            

            while(true){
                byte[] bytesFrom = new byte[10025];
                string dataFromClient = null;

                NetworkStream networkStream = clientSocket.GetStream();
                networkStream.Read(bytesFrom, 0, 1024); //Mesajı oku
                dataFromClient = System.Text.Encoding.ASCII.GetString(bytesFrom); //Bit formatından metine çevir
                dataFromClient = dataFromClient.Substring(0, dataFromClient.IndexOf("$"));

                Console.WriteLine(dataFromClient);
            }


            Console.ReadKey();
        }
    }
}