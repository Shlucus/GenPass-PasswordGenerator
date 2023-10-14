using System.Dynamic;

namespace Solution_EDC
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Introduction();                                 // Displays the introduction screen

            List<string> userPrompts = new List<string>() { "firstName", "lastName", "birthDate", "passwordPurpose" }; //Create list with placeholders

            userPrompts = AskUserInputs(userPrompts);

            foreach (string prompt in userPrompts)
            {
                Console.WriteLine(prompt);
            }

        }

        public static void Introduction()
        {
            ChangeTextColor("red");
            Console.WriteLine(@"
░█████╗░██╗░░░██╗██████╗░██████╗░░░░░░░███████╗███████╗██████╗░░█████╗░
██╔══██╗██║░░░██║██╔══██╗██╔══██╗░░░░░░╚════██║██╔════╝██╔══██╗██╔══██╗
██║░░╚═╝██║░░░██║██████╔╝██████╔╝█████╗░░███╔═╝█████╗░░██████╔╝██║░░██║
██║░░██╗██║░░░██║██╔═══╝░██╔═══╝░╚════╝██╔══╝░░██╔══╝░░██╔══██╗██║░░██║
╚█████╔╝╚██████╔╝██║░░░░░██║░░░░░░░░░░░███████╗███████╗██║░░██║╚█████╔╝
░╚════╝░░╚═════╝░╚═╝░░░░░╚═╝░░░░░░░░░░░╚══════╝╚══════╝╚═╝░░╚═╝░╚════╝░");
            ChangeTextColor("white");

            Console.Write(@"Welcome to Cupp-Zero.
Your best friend for generating complex yet memorable passwords.

Press any key to begin:");

            Console.ReadKey(true);
            Console.Clear();
        }

        public static List<string> AskUserInputs(List<string> list)
        {

            Console.Write("What is your first name?: ");

            ChangeTextColor("green");
            list[0] = Console.ReadLine();
            ChangeTextColor("white");


            Console.Write("What is your surname?: ");

            ChangeTextColor("green");
            list[1] = Console.ReadLine();
            ChangeTextColor("white");

            Console.Write("What is your date of birth? (Year/Month/Date): ");

            ChangeTextColor("green");
            list[2] = Console.ReadLine();
            ChangeTextColor("white");

            Console.Write("What platform will you use this password for?: ");

            ChangeTextColor("green");
            list[3] = Console.ReadLine();
            ChangeTextColor("white");

            Console.Write("Would you like to add a keyword Y/[N]:");
            ConsoleKeyInfo info = Console.ReadKey(true);
            Console.WriteLine();

            if (info.Key == ConsoleKey.Y)
            {
                Console.Write("Please input keyword (Favorite sport, movie, artist, etc.): ");
                list.Add(Console.ReadLine());
            }

            return list;
        }

        public static void ChangeTextColor(string color)
        {
            switch (color)
            {
                case "purple":
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    break;
                case "blue":
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
                case "green":
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case "yellow":
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case "orange":
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    break;
                case "red":
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case "white":
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case "black":
                    Console.ForegroundColor = ConsoleColor.Black;
                    break;
            }
        }
    }

}