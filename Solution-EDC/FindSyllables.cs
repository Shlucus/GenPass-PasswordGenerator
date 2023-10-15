using System;
using System.Text;
using System.Text.RegularExpressions;

namespace test
{
	public class FindSyllables
	{

		


        public string ExtractFirstLettersOfSyllables(string word)
        {
            // RETURNS STRING WITH ONLY FIRST LETTER OF EACH SYLLABLE

            string[] bigraphs = new string[] { "bl", "br", "ch", "ck", "cl", "cr", "dr", "fl", "fr", "gh", "gl", "gr", "ng", "ph", "pl", "pr", "qu", "sc", "sh", "sk", "sl", "sm", "sn", "sp", "st", "sw", "th", "tr", "tw", "wh", "wr" };
            string[] trigraphs = new string[] { "nth", "sch", "scr", "shr", "spl", "spr", "squ", "str", "thr" };

            word = word.Trim();

            if (word.Length == 0)
                return string.Empty; // Empty string has no first letters

            // Define a regular expression pattern to match vowel sequences
            // This pattern matches one or more consecutive vowels or 'y' (with word boundaries)
            Regex vowelPattern = new Regex(@"[aeiou]+", RegexOptions.IgnoreCase);

            // Split the word into syllables
            string[] syllables = vowelPattern.Split(word);

            StringBuilder sb = new StringBuilder();

            // Extract the first letter of each syllable, excluding the last character
            for (int i = 0; i < syllables.Length - 1; i++)
            {
                if (syllables[i].Length != 0)
                {
                    string subStr;

                    if (syllables[i].Length >= 3 && bigraphs.Contains(subStr = syllables[i].Substring(0, 3)))
                        sb.Append(subStr);
                    else if (syllables[i].Length >= 2 && bigraphs.Contains(subStr = syllables[i].Substring(0, 2)))
                        sb.Append(subStr);
                    else
                        sb.Append(syllables[i][0]);
                }
            }

            return sb.ToString();
        }

    }
}

