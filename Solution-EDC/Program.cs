using System.Dynamic;
using static System.Console;

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
                WriteLine(prompt);
            }

        }

        public static void Introduction()
        {
            ChangeTextColor("red");
            WriteLine(@"
░█████╗░██╗░░░██╗██████╗░██████╗░░░░░░░███████╗███████╗██████╗░░█████╗░
██╔══██╗██║░░░██║██╔══██╗██╔══██╗░░░░░░╚════██║██╔════╝██╔══██╗██╔══██╗
██║░░╚═╝██║░░░██║██████╔╝██████╔╝█████╗░░███╔═╝█████╗░░██████╔╝██║░░██║
██║░░██╗██║░░░██║██╔═══╝░██╔═══╝░╚════╝██╔══╝░░██╔══╝░░██╔══██╗██║░░██║
╚█████╔╝╚██████╔╝██║░░░░░██║░░░░░░░░░░░███████╗███████╗██║░░██║╚█████╔╝
░╚════╝░░╚═════╝░╚═╝░░░░░╚═╝░░░░░░░░░░░╚══════╝╚══════╝╚═╝░░╚═╝░╚════╝░");
            ChangeTextColor("white");

            Write(@"Welcome to Cupp-Zero.
Your best friend for generating complex yet memorable passwords.

Press any key to begin:");

            ReadKey(true);
            Clear();
        }

        public static List<string> AskUserInputs(List<string> list)
        {

            Write("What is your first name?: ");

            ChangeTextColor("green");
            list[0] = ReadLine();
            ChangeTextColor("white");


            Write("What is your surname?: ");

            ChangeTextColor("green");
            list[1] = ReadLine();
            ChangeTextColor("white");

            Write("What is your date of birth? (Year/Month/Date): ");

            ChangeTextColor("green");
            list[2] = ReadLine();
            ChangeTextColor("white");

            Write("What platform will you use this password for?: ");

            ChangeTextColor("green");
            list[3] = ReadLine();
            ChangeTextColor("white");

            Write("Would you like to add a keyword Y/[N]:");
            ConsoleKeyInfo info = ReadKey(true);
            WriteLine();

            if (info.Key == ConsoleKey.Y)
            {
                Write("Please input keyword (Favorite sport, movie, artist, etc.): ");
                list.Add(ReadLine());
            }

            return list;
        }

        public static void ChangeTextColor(string color)
        {
            switch (color)
            {
                case "purple":
                    ForegroundColor = ConsoleColor.DarkMagenta;
                    break;
                case "blue":
                    ForegroundColor = ConsoleColor.Blue;
                    break;
                case "green":
                    ForegroundColor = ConsoleColor.Green;
                    break;
                case "yellow":
                    ForegroundColor = ConsoleColor.Yellow;
                    break;
                case "orange":
                    ForegroundColor = ConsoleColor.DarkYellow;
                    break;
                case "red":
                    ForegroundColor = ConsoleColor.Red;
                    break;
                case "white":
                    ForegroundColor = ConsoleColor.White;
                    break;
                case "black":
                    ForegroundColor = ConsoleColor.Black;
                    break;
            }
        }
    }

}