/* PIG LATIN EXERCISE
 * 
 C# .NET CORE 3.1 LTS
     1. If a word starts with a consonant and a vowel, put the first letter of 
        the word at the end of the word and add "ay."
            Example: Happy = appyh + ay = appyhay

    2. If a word starts with two consonants move the two consonants to the end 
       of the word and add "ay."
        Example: Child = Ildch + ay = Ildchay

    3. If a word starts with a vowel add the word "way" at the end of the word.
        Example: Awesome = Awesome +way = Awesomeway.

    *Honor first captial letter and ending symbols. 
*/
using System;
using System.Linq;

namespace ConsoleApp
{
    class Program
    {
        static readonly string vowels = "aeiouAEIOU";
        static readonly string consonants = "bcdfghjklmnopqqrstuvwxyzBCDFGHJKLMNPQRSTVWXYZ";
        static readonly string specialChars = @"`~!@#$%^&*()_-+={}[]\|<>?,./:;";
        static readonly string textData = $"The ostriches are capable of reading and writing in multiple languages. They also know how to break codes. "
                                + $"For some reason however, they can't understand pig-latin. This is the only known way for we at the R.A.O. "
                                + $"to relay top-priority messages from operative to operative without the ostriches knowing. Check out: "
                                + $"https://web.ics.purdue.edu/~morelanj/RAO/prepare2.html.";
        /*
            OUTPUT:
            Ethay ostrichesway areway apablecay ofway eadingray andway itingwray inway ultiplemay anguageslay. 
            Eythay alsoway owknay owhay otay eakbray odescay. Orfay omesay easonray oweverhay, eythay an'tcay 
            understandway ig-latinpay. Isthay isway ethay onlyway ownknay ayway orfay eway atway ethay R.a.o 
            otay elayray op-prioritytay essagesmay omfray operativeway otay operativeway ithoutway ethay ostrichesway 
            owingknay. Eckchay outway: tps://web.ics.purdue.edu/~morelanj/RAO/prepare2.htmlhtay.    
        */

        static void CLog(string text) => Console.WriteLine(text);
        static bool IsSpecialChar(char character)
        {
            foreach (char letter in specialChars)
                if (letter == character) return true;
            return false;
        
        }
        static bool IsConsonant(char character)
        {
            foreach (char letter in consonants)
                if (letter == character) return true;
            return false;
        }
        static bool IsVowel(char character)
        {
            foreach (char letter in vowels)
                if (letter == character) return true;
            return false;
        }
        static bool FirstIsCapital(char character) => Char.IsUpper(character);
        static string HerePiggy(string text)
        {
            Console.Write($"\n{text}");
            string newWord = "";
            string specialSymbol = "";
            int endOfText = text.Length - 1;
            bool isDigitPresent = text.All(c => char.IsDigit(c));
            
            if (isDigitPresent) return text;
           
            if (IsSpecialChar(text[endOfText]))
            {
                specialSymbol = text[^1].ToString();
                text = text.Substring(0, endOfText);
            }
            
            if (IsVowel(text[0])) return text + $"way{specialSymbol}";

            else if (IsConsonant(text[0]) && IsVowel(text[1])) return (newWord.Length - 1 != 0) ? text[1..] + 
                    text[0].ToString() + $"ay{specialSymbol}" : text[0].ToString() + $"ay{specialSymbol}";

            else if (IsConsonant(text[1])) return text[2..] +
                text[0] + text[1] + $"ay{specialSymbol}";

            return text;
        }        
        public static void Main()
        {
            string pigLatinText = "";
            string[] wordArr = textData.Split(' ');

            //Console.Write("Enter your test phrase or words to translate to pig latin > ");
            //string text = Console.ReadLine(); 
            //wordArr = text.Split(' ');

            CLog("\n\t:: Test strings ::");
            

            foreach (string word in wordArr)
            {
                bool firstIsCap = FirstIsCapital(word[0]);
              
                string tempPigLatinText = (firstIsCap) ? HerePiggy(word.ToLower()) + " "
                    : HerePiggy(word) + " ";
                if (firstIsCap) 
                {
                    tempPigLatinText = ((tempPigLatinText.Length > 0) ? 
                        string.Concat(tempPigLatinText[0].ToString().ToUpper(),tempPigLatinText[1..]) 
                        : tempPigLatinText.ToUpper());
                    pigLatinText += tempPigLatinText;
                } 
                else pigLatinText += tempPigLatinText;
                
                Console.Write($" = {tempPigLatinText}");
                firstIsCap = false;
                tempPigLatinText = "";                
            }
            CLog($"\n\n{pigLatinText}");
           
        }
    }
}
