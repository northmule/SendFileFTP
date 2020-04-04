using System;

namespace ftpNodAntivirus
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Client ftpClient = new Client();

            ftpClient.Upload();
        }
    }
}
