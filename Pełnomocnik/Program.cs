using System;

namespace Proxy
{

    public interface IClient
    {
        string GetData();
    }

    public class RealClient : IClient
    {
        public string Data { get; set; }

        public RealClient()
        {
            Console.WriteLine("RealClient: Initialized");
            Data = "WSEI data";
        }

        public string GetData() => Data;
        /* {
           return Data;
         }*/
    }


    public class ProxyClient : IClient
    {
        private bool _authenticated = false;
        private string _pass = "dobrehaslo";
        RealClient client = null;

        public ProxyClient(string password)
        {
            Console.WriteLine("ProxyClient: Initialized");
            if (password == _pass)
            {
                _authenticated = true;
                client = new RealClient();
                Console.WriteLine(GetData());
            }
            else
            {
                Console.WriteLine("RealClient: Failed Initialization");
                _authenticated = false;
            }
        }

        public string GetData()
        {
            if (_authenticated)
            {
                return "Data from Proxy Client = " + client.GetData();
            }
            return "Błedne hasło";
        }
    }


    class Program
    {
        static void Main(string[] args)
        {

            ProxyClient proxy1 = new ProxyClient("zlehaslo");


            ProxyClient proxy2 = new ProxyClient("dobrehaslo");


        }

    }
}