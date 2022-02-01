/* PIG LATIN EXERCISE
 * 
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

namespace ConsoleApp
{
	class Program
	{
		static readonly string vowels = "aeiouAEIOU";
		static readonly string consonants = "bcdfghjklmnopqqrstuvwxyzBCDFGHJKLMNPQRSTVWXYZ";
		static readonly string specialChars = @"`~!@#$%^&*()_-+={}[]\|<>?,./:;";
		static readonly string textData = $"The ostriches are capable of reading and writing in multiple languages. They also know how to break codes. " + $"For some reason however, they can't understand pig-latin. This is the only known way for we at the R.A.O. " + $"to relay top-priority messages from operative to operative without the ostriches knowing. Check out: " + $"https://web.ics.purdue.edu/~morelanj/RAO/prepare2.html.";
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
				if (letter == character)
					return true;
			return false;
		}

		static bool IsConsonant(char character)
		{
			foreach (char letter in consonants)
				if (letter == character)
					return true;
			return false;
		}

		static bool IsVowel(char character)
		{
			foreach (char letter in vowels)
				if (letter == character)
					return true;
			return false;
		}
		static bool IsDigits(string text)
		{
			foreach (char character in text)
				if (character > 0 && character < 0)
					return true;
			return false;
		}

		static bool IsCapital(char character) => Char.IsUpper(character);
		static string HerePiggy(string text)
		{
			string newWord = "";
			string specialSymbol = "";
			int endOfText = text.Length - 1;
			bool isDigitPresent = IsDigits(text);

			if (text == "\n") return "\n";			
			else if (isDigitPresent)
				return text;
			if (IsSpecialChar(text[endOfText]))
			{
				specialSymbol = text.Substring(text.Length -1).ToString();
				text = text.Substring(0, endOfText);
			}
			if (IsVowel(text[0]))
				return text + $"way{specialSymbol}";
			else if (IsConsonant(text[0]) && IsVowel(text[1]))
				return (newWord.Length - 1 != 0) ? text.Substring(1) + text[0].ToString() + $"ay{specialSymbol}" : text[0].ToString() + $"ay{specialSymbol}";
			else if (IsConsonant(text[1]))
				return text.Substring(2) + text[0] + text[1] + $"ay{specialSymbol}";
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
				bool firstIsCap = IsCapital(word[0]);
				Console.Write($"\n{word}");
				string tempPigLatinText = (firstIsCap) ? HerePiggy(word.ToLower()) + " " : HerePiggy(word) + " ";
				if (firstIsCap)
				{
					tempPigLatinText = ((tempPigLatinText.Length > 0) ? string.Concat(tempPigLatinText[0].ToString().ToUpper(), tempPigLatinText.Substring(1)) : tempPigLatinText.ToUpper());
					pigLatinText += tempPigLatinText;
				}
				else
					pigLatinText += tempPigLatinText;
				Console.Write($" = {tempPigLatinText}");

				firstIsCap = false;
				tempPigLatinText = "";
			}

			CLog($"\n\n{pigLatinText}");
		}
	}

	/*
	Full Output:


        :: Test strings ::

	The = Ethay
	ostriches = ostrichesway
	are = areway
	capable = apablecay
	of = ofway
	reading = eadingray
	and = andway
	writing = itingwray
	in = inway
	multiple = ultiplemay
	languages. = anguageslay.
	They = Eythay
	also = alsoway
	know = owknay
	how = owhay
	to = otay
	break = eakbray
	codes. = odescay.
	For = Orfay
	some = omesay
	reason = easonray
	however, = oweverhay,
	they = eythay
	can't = an'tcay
	understand = understandway
	pig-latin. = ig-latinpay.
	This = Isthay
	is = isway
	the = ethay
	only = onlyway
	known = ownknay
	way = ayway
	for = orfay
	we = eway
	at = atway
	the = ethay
	R.A.O. = R.a.o
	to = otay
	relay = elayray
	top-priority = op-prioritytay
	messages = essagesmay
	from = omfray
	operative = operativeway
	to = otay
	operative = operativeway
	without = ithoutway
	the = ethay
	ostriches = ostrichesway
	knowing. = owingknay.
	Check = Eckchay
	out: = outway:
	https://web.ics.purdue.edu/~morelanj/RAO/prepare2.html. = tps://web.ics.purdue.edu/~morelanj/RAO/prepare2.htmlhtay.

	Ethay ostrichesway areway apablecay ofway eadingray andway itingwray inway ultiplemay anguageslay. Eythay alsoway owknay owhay otay eakbray odescay. Orfay omesay easonray oweverhay, eythay an'tcay understandway ig-latinpay. Isthay isway ethay onlyway ownknay ayway orfay eway atway ethay R.a.o otay elayray op-prioritytay essagesmay omfray operativeway otay operativeway ithoutway ethay ostrichesway owingknay. Eckchay outway: tps://web.ics.purdue.edu/~morelanj/RAO/prepare2.htmlhtay.

	*/
}
