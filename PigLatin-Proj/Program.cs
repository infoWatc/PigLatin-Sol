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
		static readonly string textData = "Algorithm: Word used by programmers when they don’t want to explain what they did; Quote by Funny Notebooks.";
		
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

			if (text[1] == '.' && text[3] == '.' && endOfText >= 3) text = text.ToUpper();
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
					tempPigLatinText = ((tempPigLatinText.Length > 0) ? string.Concat(tempPigLatinText[0].ToString().ToUpper(), 
						tempPigLatinText.Substring(1)) : tempPigLatinText.ToUpper());
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
	Output:

			:: Test strings ::

	Algorithm: = Algorithmway:
	Word = Ordway
	used = usedway
	by = byay
	programmers = ogrammerspray
	when = enwhay
	they = eythay
	don't = on'tday
	want = antway
	to = otay
	explain = explainway
	what = atwhay
	they = eythay
	did; = idday;
	Quote = Uoteqay
	by = byay
	Funny = Unnyfay
	Notebooks. = Otebooksnay.

	Algorithmway: Ordway usedway byay ogrammerspray enwhay eythay on'tday antway otay explainway atwhay eythay idday; Uoteqay byay Unnyfay Otebooksnay.

	*/
}
