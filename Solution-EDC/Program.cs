using System.Text;
using System.Text.RegularExpressions;

namespace Solution_EDC
{
    internal class Program
    {

        #region Main
        static void Main(string[] args)
        {
            Introduction();  // Displays the introduction screen

            List<string> userPrompts = new List<string>() { "firstName", "lastName", "birthDate", "passwordPurpose" }; //Create list with placeholders

            userPrompts = AskUserInputs(userPrompts);

            ComplicateInputs(userPrompts);

            PrintGeneratedPassword(userPrompts);

        }
        #endregion 

        // Call all encryption functions:
        #region ComplicateInputs
        public static List<string> ComplicateInputs(List<string> inputList)
        {



            for (int i = 0; i < inputList.Count; i++)
            {
                inputList[i] = ExtractFirstLettersOfSyllables(inputList[i]);

                inputList[i] = LeetSpeechConvertor(inputList[i]);

            }

            return inputList;
        }
        #endregion 

        //Encryption functions:
        #region LeetSpeechConvertor
        public static string LeetSpeechConvertor(string text)
        {

            Dictionary<char, string[]> leetSpeechTable = new Dictionary<char, string[]>()
                {
                    { 'A', new string[]{ @"/\", "^", "4" } },
                    { 'B', new string[]{ "13", "|3", "8" } },
                    { 'b', new string[]{ "6"} },
                    { 'C', new string[]{ "(", "<" } }
                };

            Random rnd = new Random();

            StringBuilder sb = new StringBuilder();

            foreach (char c in text)
            {
                if (leetSpeechTable.TryGetValue(c, out string[] leetSpeechCharacters))
                    sb.Append(leetSpeechCharacters[rnd.Next(0, leetSpeechCharacters.Length)]);
                else
                    sb.Append(c);
            }

            return sb.ToString();
        }
        #endregion

        #region ExtractFirstLetterOfSyllables
        public static string ExtractFirstLettersOfSyllables(string word)
        {
            // RETURNS STRING WITH ONLY FIRST LETTER OF EACH SYLLABLE

            word = Regex.Replace(word, "[^a-zA-Z]", "");

            if (word.Length == 0)
            {
                return string.Empty; // Empty string has no first letters
            }

            // Define a regular expression pattern to match vowel sequences
            // This pattern matches one or more consecutive vowels or 'y' (with word boundaries)
            Regex vowelPattern = new Regex(@"[aeiouy]+", RegexOptions.IgnoreCase);

            // Split the word into syllables
            string[] syllables = vowelPattern.Split(word);

            // Extract the first letter of each syllable, excluding the last character
            string firstLetters = string.Join("", syllables
                .Where(syllable => syllable.Length > 0 && syllable != syllables.Last())
                .Select(syllable => syllable[0]));

            return firstLetters;
        }
        #endregion


        //Helper functions
        #region Introduction
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
        #endregion

        #region AskUserInputs
        public static List<string> AskUserInputs(List<string> list)
        {

            Console.Write("What is your first name?: ");

            ChangeTextColor("green");
            list[0] = Console.ReadLine();
            ChangeTextColor("white");


            //Console.Write("What is your surname?: ");

            //ChangeTextColor("green");
            //list[1] = Console.ReadLine();
            //ChangeTextColor("white");

            //Console.Write("What is your date of birth? (Year/Month/Date): ");

            //ChangeTextColor("green");
            //list[2] = Console.ReadLine();
            //ChangeTextColor("white");

            //Console.Write("What platform will you use this password for?: ");

            //ChangeTextColor("green");
            //list[3] = Console.ReadLine();
            //ChangeTextColor("white");

            //Console.Write("Would you like to add a keyword Y/[N]:");
            //ConsoleKeyInfo info = Console.ReadKey(true);
            //Console.WriteLine();

            //if (info.Key == ConsoleKey.Y)
            //{
            //    Console.Write("Please input keyword (Favorite sport, movie, artist, etc.): ");
            //    list.Add(Console.ReadLine());
            //}

            return list;
        }
        #endregion

        #region ChangeTextColor
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
        #endregion

        #region PrintGeneratedPassword
        public static void PrintGeneratedPassword(List<string> generatedPasswords)
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
        #endregion
    }

}