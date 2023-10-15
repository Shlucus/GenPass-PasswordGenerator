using System.Text;
using System.Text.RegularExpressions;
using test;

namespace Solution_EDC
{
    internal class Program
    {

        #region Constants

        const string WARNING_COLOR = "red";
        const string INPUT_COLOR = "green";
        const string OUTPUT_COLOR = "gray";
        const string MEDIUM_COLOR = "yellow";

        #endregion

        static void Main(string[] args)
        {
            List<string> userPrompts = new List<string>(); //Create list with placeholders

            List<string> initialPrompts = new List<string>();
            string password;

            DisplayMenu();  // Displays the introduction screen

            GetUserInputs(userPrompts);

            ShuffleListItems(userPrompts);

            initialPrompts = CopyStringList(userPrompts);

            userPrompts = ComplicateInputs(userPrompts);

            password = JoinString(userPrompts);

            PrintGeneratedPassword(password);

            DisplayPasswordTransformation(initialPrompts, userPrompts);

        }

        public static List<string> ComplicateInputs(List<string> inputList)
        {
            string complexityChoice = GetUserComplexity();
            for (int i = 0; i < inputList.Count; i++)
            {
                if (complexityChoice == "1")
                {
                    if (Int32.TryParse(inputList[i], out int myInt))
                        inputList[i] = GetYearLastTwoDigits(myInt).ToString();
                    else
                    {
                        inputList[i] = GetWordAbbreviation(inputList[i]);
                    }
                }
                else if (complexityChoice == "2")
                {
                    if (Int32.TryParse(inputList[i], out int myInt))
                        inputList[i] = GetYearLastTwoDigits(myInt).ToString();
                    else
                    {
                        inputList[i] = GetWordAbbreviation(inputList[i]);
                        inputList[i] = LeetSpeechConvertor(inputList[i]);
                    }
                }
                else if (complexityChoice == "3")
                {
                    if (Int32.TryParse(inputList[i], out int myInt))
                        inputList[i] = GetYearLastTwoDigits(myInt).ToString();
                    else
                    {
                        inputList[i] = GetWordAbbreviation(inputList[i]);
                        inputList[i] = CaesarCipher(inputList[i], 1, true);
                        //inputList[i] = LeetSpeechConvertor(inputList[i]);

                    }
                }

            }

            return inputList;
        }

        #region Encryption functions

        public static string LeetSpeechConvertor(string text)
        {
            Random rnd = new Random();                                                    //Initiate Random object              

            StringBuilder sb = new StringBuilder();                                       //Initiate StringBuilder object

            Dictionary<char, string[]> leetSpeechTable = new Dictionary<char, string[]>() //Initiate Dictionary with leetspeech conversions,
                {
                    { 'A', new string[]{ @"/-", "^", "4" } },
                    { 'B', new string[]{ "13", "|3", "8" } },
                    { 'C', new string[]{ "(", "<" } },
                    { 'D', new string[]{ "|)", "[)", "|>" } },
                    { 'J', new string[]{ "|", "/" } },
                    { 'M', new string[]{ @"|/|", "^^" } },
                    { 'I', new string[]{ "!", "|", "1" } },
                    { 'b', new string[]{ "6"} },
                    { 'c', new string[]{ "(", "<" } },
                    { 'e', new string[]{ "3" } },
                    { 's', new string[]{ "5", "$" } },
                    { 'i', new string[]{ "!", "|", "1" } },
                    { 't', new string[]{ "+", "7" } }

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

        public static string GetWordAbbreviation(string word)
        {
            word = word.ToLower();

            string[] bigraphs = new string[] { "bl", "br", "ch", "ck", "cl", "cr", "dr", "fl", "fr", "gh", "gl", "gr", "ng", "ph", "pl", "pr", "qu", "sc", "sh", "sk", "sl", "sm", "sn", "sp", "st", "sw", "th", "tr", "tw", "wh", "wr" };
            string[] trigraphs = new string[] { "nth", "sch", "scr", "shr", "spl", "spr", "squ", "str", "thr" };

            word = word.Trim();

            if (word.Length == 0)
                return string.Empty;

            Regex vowelPattern = new Regex(@"[aeiou]+", RegexOptions.IgnoreCase);

            string[] syllables = vowelPattern.Split(word);

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < syllables.Length - 1; i++)
            {
                if (syllables[i].Length != 0)
                {
                    string subStr;

                    if (syllables[i].Length >= 3 && bigraphs.Contains(subStr = syllables[i].Substring(0, 3)))
                        sb.Append(UppercaseFirstLetter(subStr));
                    else if (syllables[i].Length >= 2 && bigraphs.Contains(subStr = syllables[i].Substring(0, 2)))
                        sb.Append(UppercaseFirstLetter(subStr));
                    else
                        sb.Append(syllables[i][0]);
                }
            }

            return sb.ToString();
        }

        public static string UppercaseFirstLetter(string word)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(word[0].ToString().ToUpper());

            for (int i = 1; i < word.Length; i++)
                sb.Append(word[i]);

            return sb.ToString();
        }

        public static int GetYearLastTwoDigits(int number)
        {
            return number % 100;
        }

        public static string CaesarCipher(string text, uint uintKey, bool cipher = true)
        {
            int key = (int)uintKey;

            const int MIN_CHAR_INDEX = (int)Char.MinValue;
            const int MAX_CHAR_INDEX = (int)Char.MaxValue;

            if (!cipher)
                key = -key;

            StringBuilder sb = new StringBuilder();

            foreach (char c in text)
            {
                int index = (int)c;

                index += key;

                if (index > MAX_CHAR_INDEX)
                    index -= MAX_CHAR_INDEX;
                else if (index < MIN_CHAR_INDEX)
                    index += MAX_CHAR_INDEX;

                sb.Append((char)index);
            }

            return sb.ToString();
        }

        public static void ShuffleListItems(List<string> list)
        {
            Random rnd = new Random();

            for (int i = 0; i < list.Count; i++)
            {
                int k = rnd.Next(0, list.Count);

                // switch list[0] with list[k]
                string j = list[0];
                list[0] = list[k];
                list[k] = j;
            }
        }

        #endregion

        #region Helper functions

        public static void DisplayMenu()
        {
            string s = @"Welcome to";
            Console.SetCursorPosition((Console.WindowWidth - s.Length) / 2, Console.CursorTop + 7);
            Console.WriteLine(s);

            ChangeForegroundColor("blue");
            Console.WriteLine(@"                                                                                                   .-""""-.
                                                                                                  / .--. \
                        .g8""""""bgd                      `7MM""""""Mq.                                / /    \ \
                      .dP'     `M                        MM   `MM.                               | |    | |
                      dM'       `   .gP""Ya `7MMpMMMb.    MM   ,M9 ,6""Yb.  ,pP""Ybd ,pP""Ybd        | |.-""""-.|
                      MM           ,M'   Yb  MM    MM    MMmmdM9 8)   MM  8I   `"" 8I   `""       ///`.::::.`\
                      MM.    `7MMF'8M""""""""""""  MM    MM    MM       ,pm9MM  `YMMMa. `YMMMa.      ||| ::/  \:: ;
                      `Mb.     MM  YM.    ,  MM    MM    MM      8M   MM  L.   I8 L.   I8      ||; ::\__/:: ;
                        `""bmmmdPY   `Mbmmd'.JMML  JMML..JMML.    `Moo9^Yo.M9mmmP' M9mmmP'       \\\ '::::' /
                                                                                                 `=':-..-'`
                                                                                              ");
            ChangeForegroundColor(OUTPUT_COLOR);


            string description = "Your best friend for generating complex yet memorable passwords.";
            Console.SetCursorPosition((Console.WindowWidth - description.Length) / 2, Console.CursorTop);
            Console.WriteLine(description);


            //Press any key to begin ");

            ChangeForegroundColor("grey");
            description = "Press any key to continue...";
            Console.SetCursorPosition((Console.WindowWidth - description.Length) / 2, Console.CursorTop);
            Console.WriteLine(description);

            Console.ReadKey(true);
            Console.Clear();
        }

        public static void GetUserInputs(List<string> list)
        {
            const ConsoleKey CONFIRM_KEY = ConsoleKey.Y;
            const int PAUSE_LENGTH = 200; // length of Thread.Sleep() in milliseconds

            string[] questions = new string[]
            {
                "What platform will this be used on? ", //done //output ytb or yt
                "What is the current year?: ", //done // output 23 (2023) (year will change and is not a fix date ex: birthdate yr)
            };

            for (int i = 0; i < questions.Length; i++)
            {
                string[] plateformInformation;
                ChangeForegroundColor(INPUT_COLOR);
                Console.Write(questions[i]);
                ChangeForegroundColor(OUTPUT_COLOR);

                if (i == 0)
                {
                    AppName platform = new AppName(Console.ReadLine());
                    plateformInformation = platform.QuestionsForLogoId();

                    for (int j = 0; j < plateformInformation.Length; j++)
                    {
                        list.Add(plateformInformation[j]);
                    }


                }
                else
                {
                    list.Add(Console.ReadLine());
                }
            }

                Console.Write($"What language do you use on {list[0]}?: ");
                ChangeForegroundColor(INPUT_COLOR);
                list.Add(Console.ReadLine());
                ChangeForegroundColor(OUTPUT_COLOR);

                Console.Write("Would you like to add a keyword to include within the password? Press [Y]/[N]");
                ConsoleKeyInfo info = Console.ReadKey(true);
                Console.WriteLine();

                if (info.Key == CONFIRM_KEY)
                {
                    // The purpose of Sleep and ReadKey here is to create a buffer between the previous and next questions
                    // If the user presses Y and Enter in quick succession for the previous question, this buffer will prevent
                    // the next question( with ReadLine command) to take "Enter" as the user input
                    Thread.Sleep(PAUSE_LENGTH);

                    if (Console.KeyAvailable)
                        Console.ReadKey(true);

                    Console.Write("Please input keyword a memorable word: ");

                    ChangeForegroundColor(INPUT_COLOR);
                    list.Add(Console.ReadLine());
                    ChangeForegroundColor(OUTPUT_COLOR);
                }
            
        }

        static void ChangeForegroundColor(string color)
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
                case "gray":
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;
                case "black":
                    Console.ForegroundColor = ConsoleColor.Black;
                    break;

            }
        }

        static void PrintGeneratedPassword(string password)
        {
            Console.Clear();

            ChangeForegroundColor(WARNING_COLOR);
            Console.WriteLine("Here is your generated password:\n=================================");
            ChangeForegroundColor(OUTPUT_COLOR);

            Console.WriteLine(password);
        }

        public static string JoinString(List<string> list)
        {
            StringBuilder builder = new StringBuilder();

            foreach (string str in list)
                builder.Append(str);

            string result = builder.ToString();

            return result;
        }

        public static void DisplayPasswordTransformation(List<string> inputPrompts, List<string> complexPrompts)
        {
            for (int i = 0; i < inputPrompts.Count; i++)
                Console.WriteLine(inputPrompts[i] + " = " + complexPrompts[i]);

            //int[,] test2D = new int[4,2] 
        }

        public static List<string> CopyStringList(List<string> oldList)
        {
            List<string> newList = new List<string>(oldList.Count);

            for (int i = 0; i < oldList.Count; i++)
                newList.Add(oldList[i]);

            return newList;
        }

        public static string GetUserComplexity()
        {
            string choice;
            Console.WriteLine(@"Please select a password complexity:
");
            ChangeForegroundColor("black");
            Console.BackgroundColor
            = ConsoleColor.Green;
            Console.Write("[    1. Simple     ]");

            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.Write("[    2. Medium     ]");

            Console.BackgroundColor = ConsoleColor.Red;
            Console.Write("[    3. Complex    ]");
            Console.WriteLine(@"
");

            Console.BackgroundColor = ConsoleColor.Black;

            ChangeForegroundColor("white");
            Console.WriteLine("Choice: ");

            choice = Console.ReadLine();

            return choice;
        }

        #endregion

    }
}