using System.Drawing;
using System.Reflection.Emit;
using System.Text;
using System.Text.RegularExpressions;

namespace Solution_EDC
{
    internal class Program
    {

        #region Main
        static void Main(string[] args)
        {
            List<string> userPrompts = new List<string>() { "firstName", "lastName", "birthDate", "passwordPurpose" }; //Create list with placeholders
            List<string> initialPrompts = new List<string>();
            string password;

            Introduction();  // Displays the introduction screen

            userPrompts = AskUserInputs(userPrompts);

            ScrambleKeywords(userPrompts);

            initialPrompts = GenerateList(userPrompts);

            userPrompts = ComplicateInputs(userPrompts);

            password = JoinString(userPrompts);

            PrintGeneratedPassword(password);

            ExplainPassword(initialPrompts, userPrompts);

        }
        #endregion 

        // Call all encryption functions:
        #region ComplicateInputs
        public static List<string> ComplicateInputs(List<string> inputList)
        {
            for (int i = 0; i < inputList.Count; i++)
            {
                //inputListComplicated.Add(inputList[i]);
                int myInt = 0;

                if (Int32.TryParse(inputList[i], out myInt) == true)
                {
                    inputList[i] = Convert.ToString(YearTwoChars(myInt));
                }
                else
                {
                    inputList[i] = ExtractFirstLettersOfSyllables(inputList[i]);

                    inputList[i] = LeetSpeechConvertor(inputList[i]);
                }
            }
            
            return inputList;
        }
        #endregion 

        //Encryption functions:
        #region LeetSpeechConvertor
        public static string LeetSpeechConvertor(string text)
        {
            Random rnd = new Random();                                                    //Initiate Random object              

            StringBuilder sb = new StringBuilder();                                       //Initiate StringBuilder object

            Dictionary<char, string[]> leetSpeechTable = new Dictionary<char, string[]>() //Initiate Dictionary with leetspeech conversions,
                {
                    { 'A', new string[]{ @"/\", "^", "4" } },
                    { 'B', new string[]{ "13", "|3", "8" } },
                    { 'b', new string[]{ "6"} },
                    { 'C', new string[]{ "(", "<" } }
                };

            // For every character in the passed string...
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

        #region YearsTwoChars
        public static int YearTwoChars(int number)
        {
            int lastTwoDigits = (int)(number % 100);
            return lastTwoDigits;

        }
        #endregion

        #region ScrambleKeyworlds
        public static void ScrambleKeywords(List<string> keywords)
        {
            Random rnd = new Random();

            for (int i = 0; i < keywords.Count; i++)
            {
                int k = rnd.Next(0, keywords.Count);

                // switch keywords[i] with keywords[k]
                string placeholder = keywords[i];
                keywords[i] = keywords[k];
                keywords[k] = placeholder;
            }
        }
        #endregion

        //Helper functions:
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

            Console.Write("What platform will this be used on? "); //done //output ytb or yt

            ChangeTextColor("green");
            list[0] = Console.ReadLine();
            ChangeTextColor("white");


            Console.Write("What is the current year?: "); //done // output 23 (2023) (year will change and is not a fix date ex: birthdate yr)

            ChangeTextColor("green");
            list[1] = Console.ReadLine();
            ChangeTextColor("white");

            Console.Write("What is your second favorite category of videos to watch?: "); //should be something only user knows are can relate/recall later

            ChangeTextColor("green");
            list[2] = Console.ReadLine();
            ChangeTextColor("white");

            Console.Write($"What language do you use on {list[0]}?: ");

            ChangeTextColor("green");
            list[3] = Console.ReadLine();
            ChangeTextColor("white");

            Console.Write("Would you like to add a keyword to include within the password? [Y]/[N]:");
            ConsoleKeyInfo info = Console.ReadKey(true);
            Console.WriteLine();


            if (info.Key == ConsoleKey.Y)
            {
                Console.Write("Please input keyword a memorable word: ");
                list.Add(Console.ReadLine());
            }

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
        public static void PrintGeneratedPassword(string pass)
        {
            ChangeTextColor("red");
            Console.WriteLine(@"
Here is your generated password: 
=================================
"); ChangeTextColor("white");
            Console.WriteLine(pass);


        }
        #endregion

        public static string JoinString(List<string> list)
        {
            StringBuilder builder = new StringBuilder();

            foreach (string prompt in list)
            {
                builder.Append(prompt);
            }

            
            string passsword = builder.ToString();
            Console.WriteLine(passsword);
            return passsword;
        }

        public static void ExplainPassword(List<string> inputPrompts, List<string> complexPrompts)
        {
            for (int i = 0; i < inputPrompts.Count; i++)
            {
                Console.WriteLine(inputPrompts[i] + " = " + complexPrompts[i] );
            }

            //int[,] test2D = new int[4,2] 
            
        }

        #region GenerateIntArray 
        public static List<string> GenerateList(List<string> oldList)
        {
            List<string> newList = new List<string>(oldList.Count);
            for (int i = 0; i < oldList.Count; i++)  //Iterate through each index of the List...
            {
                newList.Add(oldList[i]);
            }
            return newList;                       // Return the List.
        }
        #endregion


    }

}