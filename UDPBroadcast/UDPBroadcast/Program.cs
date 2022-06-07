using System;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading;

namespace UDPBroadcast {
    internal class Program {
        static void Main(string[] args) {

            using (UdpClient socket = new UdpClient()) {
                while (true){
                    WindDataGenerator testData = new WindDataGenerator();
                    testData.Direction = testData.NextDirection();
                    testData.Speed = testData.NextSpeed();


                    string serializedData = JsonSerializer.Serialize(testData);

                    byte[] data = Encoding.UTF8.GetBytes(serializedData);

                    socket.Send(data, data.Length, "255.255.255.255", 6000);

                    Console.WriteLine(serializedData);
                        
                    Thread.Sleep(1000);
                }
            }
        }
    }
}
