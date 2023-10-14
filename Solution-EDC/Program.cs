using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;

namespace Solution_EDC
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Introduction();
        }

        public static void Introduction()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(@"
░█████╗░██╗░░░██╗██████╗░██████╗░░░░░░░███████╗███████╗██████╗░░█████╗░
██╔══██╗██║░░░██║██╔══██╗██╔══██╗░░░░░░╚════██║██╔════╝██╔══██╗██╔══██╗
██║░░╚═╝██║░░░██║██████╔╝██████╔╝█████╗░░███╔═╝█████╗░░██████╔╝██║░░██║
██║░░██╗██║░░░██║██╔═══╝░██╔═══╝░╚════╝██╔══╝░░██╔══╝░░██╔══██╗██║░░██║
╚█████╔╝╚██████╔╝██║░░░░░██║░░░░░░░░░░░███████╗███████╗██║░░██║╚█████╔╝
░╚════╝░░╚═════╝░╚═╝░░░░░╚═╝░░░░░░░░░░░╚══════╝╚══════╝╚═╝░░╚═╝░╚════╝░");
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine(@"Welcome to Cupp-Zero.
Your best friend for generating complex yet memorable passwords.

Press any key to beggin:");

            Console.ReadKey(true);
            Console.Clear();
        }
    }
}