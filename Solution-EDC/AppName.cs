using System;
using System.Xml.Linq;

namespace test
{
    public class AppName
    {
        // variables
        private string[] _appNames = { "Youtube", "Discord" };
        private string[,] _questions = { { "What is the color of the logo?", "Who is your favorite content creator?" }, { "What is the logo representing?", "Who is the color of the logo?"} };
        public string _appName;
        private string[,] _fullOutput;


        public AppName(string appName)
        {
            _appName = AppNameVerificator(appName);
            _fullOutput = new string[2, 2];
        }

        public string[,] FullOutput
        {
            get
            {
                return _fullOutput;
            }
        }

        public string[] OutputAppName
        {
            get
            {
                return _appNames;
            }

        }

        public string OutputName
        {
            get
            {
                return _appName;
            }

        }


        public string[,] OutputQuestions
        {
            get
            {
                return _questions;
            }

        }

        public string AppNameVerificator(string value)
        {


            bool validiity = false;

            while (!validiity)
            {

                for (int i = 0; i < OutputAppName.Length; i++)
                {
                    if (OutputAppName[i] == value)
                    {
                        validiity = true;
                    }

                }

                if (!validiity)
                {
                    Console.WriteLine("Please enter a new platform");
                   value = Console.ReadLine();
                }


            }

            return value;



        }

        public string[] QuestionsForLogoId()
        {
            string[] output= new string[3];
            FindSyllables syllabs = new FindSyllables();
            output[0] = _appName;
            for (int i = 0; i < OutputQuestions.GetLength(1); i++)
            {
                
                if (_appName == OutputAppName[0])
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(OutputQuestions[0, i]);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    output[i+1] = Console.ReadLine();
                    

                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine(OutputQuestions[1, i]);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    output[i+1] =  Console.ReadLine();
                }

                
            }



            return output;
        }


    }
}

