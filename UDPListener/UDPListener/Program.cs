using System;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading.Channels;

namespace UDPListener {
    internal class Program {
        static void Main(string[] args){
            string URL = "https://localhost:44318/api/WindDatas";

            using (UdpClient socket = new UdpClient()) {

                socket.Client.Bind(new IPEndPoint(IPAddress.Any, 6000));

                using (HttpClient client = new HttpClient()){

                    IPEndPoint clientEndPoint = null;
                    while (true){
                        IPEndPoint from = null;
                        byte[] data = socket.Receive(ref clientEndPoint);

                        string message = Encoding.UTF8.GetString(data);

                        WindDataGenerator generatorData = JsonSerializer.Deserialize<WindDataGenerator>(message);

                        string serializedData = JsonSerializer.Serialize(generatorData);

                        HttpContent content = new StringContent(serializedData, Encoding.UTF8, "text/json");
                        Console.WriteLine("Direction: " + generatorData.Direction);
                        Console.WriteLine("Speed: " + generatorData.Speed);
                        socket.Send(data, data.Length, clientEndPoint);
                        client.PostAsync(URL, content);
                    }
                }

            }
        }
    }
}
