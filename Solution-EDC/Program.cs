namespace Solution_EDC
{
    internal class Program
    {

        public static void Main(string[] args)
        {
         
        }

        public static string SelectVowel(string userInput) //return should be "ae";
        {
            string a = "a";
            string foundVowels = "";
            if (string.IsNullOrEmpty(userInput))
            {
                return "Please enter a valid input";
            }



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