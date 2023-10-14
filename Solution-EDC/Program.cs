using System.Dynamic;

namespace Solution_EDC
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Introduction();  // Displays the introduction screen

            List<string> userPrompts = new List<string>() { "firstName", "lastName", "birthDate", "passwordPurpose" }; //Create list with placeholders

            userPrompts = AskUserInputs(userPrompts);

            complicateInputs(userPrompts);

            printGeneratedPassword(userPrompts);

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

        public static List<string> complicateInputs(List<string> inputList)
        {
            for (int i = 0; i < inputList.Count; i++)
            {
                inputList[i] = LeetSpeakConverter(inputList[i]);

            }

            return inputList;
        }

        public static string LeetSpeakConverter(string text)
        {
            //String text = @"\/\/4573Fu|_";
            Dictionary<string, string> leetRules = new Dictionary<string, string>();


            leetRules.Add("A", "4");
            //leetRules.Add("A", @"/\");
            leetRules.Add("a", "@");
            //leetRules.Add("A", "^");

            leetRules.Add("B", "13");
            //leetRules.Add("/3", "B");
            /*leetRules.Add("B", "|3");
            leetRules.Add("B", "8");*/

            leetRules.Add("X", "><");

            //leetRules.Add("<", "C");
            leetRules.Add("C", "(");

            //leetRules.Add("|)", "D");
            //leetRules.Add("|>", "D");

            //leetRules.Add("3", "E");

            //leetRules.Add("6", "G");

            //leetRules.Add("/-/", "H");
            //leetRules.Add("[-]", "H");
            //leetRules.Add("]-[", "H");

            //leetRules.Add("!", "I");

            //leetRules.Add("|_", "L");

            //leetRules.Add("_/", "J");
            //leetRules.Add("_|", "J");

            //leetRules.Add("1", "L");

            //leetRules.Add("0", "O");

            leetRules.Add("S", "5");
            //leetRules.Add("S", "$");
            leetRules.Add("s", "S");
            //leetRules.Add("7", "T");

            //leetRules.Add(@"\/\/", "W");
            //leetRules.Add(@"\/", "V");

            //leetRules.Add("2", "Z");

            foreach (KeyValuePair<string, string> x in leetRules)
            {
                text = text.Replace(x.Key, x.Value);
            }

            return text;
        }

        public static void printGeneratedPassword(List<string> generatedPasswords)
        {
            ChangeTextColor("red");
            Console.WriteLine(@"Here are the generated passwords: 
===========================================================
"); ChangeTextColor("white");
            foreach (string password in generatedPasswords)
            {
                Console.WriteLine(password);
            }
        }
    }

}