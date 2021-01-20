using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorGraphical
{
    class Doctor
    {
        static string[] hedges = {"Please tell me more.",
          "Many of my patients tell me the same thing.",
          "Please coninue." };

        static string[] qualifiers = {"Why do you say that ",
              "You seem to think that ",
              "Can you explain why " };

        static Dictionary<string, string> replacements = new Dictionary<string, string>()
        {
            {"i", "you" },
            {"me", "you" },
            {"we", "you" },
            {"us", "you" },
            {"mine", "yours"},
            {"my", "your" },
            {"am", "are" },
        };

        

        /*
         * Reply
         * Returns a string based on the users input or 
         * something to prompt them to write some more.
         */
        public static string Reply(string sentence)
        {
            Random rand = new Random();
            int probability = rand.Next(1, 5);
            int choice;

            if (probability == 1)
            {
                choice = rand.Next(0, hedges.Length);
                return hedges[choice];

            }
            else
            {
                choice = rand.Next(0, qualifiers.Length);
                return qualifiers[choice] + ChangePerson(sentence);
            }
        }
        /*
         * ChangePerson
         * Goes through th inputed sentence and changes pronouns from 
         * first person to second person
         * 
         */
        private static string ChangePerson(string sentence)
        {
            List<string> replyWords = new List<string>();
            string[] words = sentence.Split(' '); //creating array of substrings split apart where the original string has spaces


            foreach (string word in words)
            {

                /*
                 * Checking to see if our key is in the dictionary and saving value to the reply if if it is
                 * else we use the key as part of the reply 
                 */
                if (replacements.TryGetValue(word.ToLower(), out string wordValue))
                {
                    replyWords.Add(wordValue);
                }
                else
                {
                    replyWords.Add(word.ToLower());
                }

            }

            return string.Join(" ", replyWords);
        }
    }
}
