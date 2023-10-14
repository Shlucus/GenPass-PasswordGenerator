using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;

namespace Solution_EDC
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Introduction();

            AskUserInput();
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

        public static void AskUserInput()
        {
            Console.Write("What is your first name: ");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            string firstName = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("What is your last name:");
            string lastName = Console.ReadLine();

            Console.WriteLine("What is your date of birth :");
        }


        public static string SelectVowel(string userInput) //return should be "ae";
        {
        
            string foundVowels = "";
            if (string.IsNullOrEmpty(userInput))
            {
                return "Please enter a valid input";
            }

            Console.WriteLine("MOUAHAHAHAHA");

            foreach (char character in userInput.ToUpper())
            {
                if (character == 'A' || character == 'E' || character == 'O')
                {
                    foundVowels += character;
                }
            }
            return foundVowels;
        }

    }
}