using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = new Host();

            host.Start();

            Console.WriteLine("Press enter to stop.");
            Console.ReadLine();
        }
    }
}
