using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace GameDesignPatterns_Task1
{
    class Program
    {
        public static void Main()
        {
         
         var macAddr =
        (
        from nic in NetworkInterface.GetAllNetworkInterfaces()
        where nic.OperationalStatus == OperationalStatus.Up
        select nic.GetPhysicalAddress().ToString()
         ).FirstOrDefault();        
         long ayhaga =   Convert.ToInt64(macAddr,16);

            NetworkInterface[] interfaces = NetworkInterface.GetAllNetworkInterfaces();

            foreach (NetworkInterface adapter in interfaces)
            {
                if (adapter.Name.ToLower() == "ethernet" || adapter.Name.ToLower() == "wi-fi")
                {
                    string initial = adapter.Description;
                    string output = initial.Substring(0, initial.IndexOf("("));

                    CardType cardt;
                    if ((Enum.TryParse<CardType>(adapter.Name, out cardt)))
                    {
                        var x = NCI.GetNCI(output, ayhaga, cardt);
                        Console.WriteLine(x.ToString());
                    }
                }
            } 
            Console.ReadLine();
        }
    }
}
