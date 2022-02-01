                           
PigLatinProj
Access: 
60
            foreach (char character in text)
61
                if(character > 0 && character < 0)
62
                    return true;
63
            return false;
64
        }           
65
​
66
        static bool FirstIsCapital(char character) => Char.IsUpper(character);
67
        static string HerePiggy(string text)
68
        {
69
            
70
            string newWord = "";
71
            string specialSymbol = "";
72
            int endOfText = text.Length - 1;
73
            bool isDigitPresent = IsDigits(text);
74
            
75
            if (isDigitPresent)
76
                return text;
77
            if (IsSpecialChar(text[endOfText]))
78
            {
79
                specialSymbol = text[^1].ToString();
80
                text = text.Substring(0, endOfText);
81
            }
82
​
83
            if (IsVowel(text[0]))
84
                return text + $"way{specialSymbol}";
85
            else if (IsConsonant(text[0]) && IsVowel(text[1]))
86
                return (newWord.Length - 1 != 0) ? text[1..] + text[0].ToString() + $"ay{specialSymbol}" : text[0].ToString() + $"ay{specialSymbol}";
87
            else if (IsConsonant(text[1]))
88
                return text[2..] + text[0] + text[1] + $"ay{specialSymbol}";
89
            return text;
90
        }
91
​
92
        public static void Main()
93
        {
94
            string pigLatinText = "";
95
            string[] wordArr = textData.Split(' ');
96
            //Console.Write("Enter your test phrase or words to translate to pig latin > ");
97
            //string text = Console.ReadLine(); 
98
            //wordArr = text.Split(' ');
99
            CLog("\n\t:: Test strings ::");
100
            foreach (string word in wordArr)
101
            {
102
                bool firstIsCap = FirstIsCapital(word[0]);
103
                Console.Write($"\n{word} = ");
104
                string tempPigLatinText = (firstIsCap) ? HerePiggy(word.ToLower()) + " " : HerePiggy(word) + " ";
105
                if (firstIsCap)
106
                {
107
                    tempPigLatinText = ((tempPigLatinText.Length > 0) ? string.Concat(tempPigLatinText[0].ToString().ToUpper(), tempPigLatinText[1..]) : tempPigLatinText.ToUpper());
108
                    pigLatinText += tempPigLatinText;
109
                }
110
                else
111
                    pigLatinText += tempPigLatinText;
112
                Console.Write($" = {tempPigLatinText}");
113
                
114
                firstIsCap = false;
115
                tempPigLatinText = "";
116
            }
117
​
118
            CLog($"\n\n{pigLatinText}");
119
        }
120
    }
121
    
122
    /*
123
    Full Output:
124
​
125
                :: Test strings ::
126
​
127
            The =  = Ethay 
128
            ostriches =  = ostrichesway 
129
            are =  = areway 
130
            capable =  = apablecay 
131
            of =  = ofway 
132
            reading =  = eadingray 

    :: Test strings ::

The =  = Ethay 
ostriches =  = ostrichesway 
are =  = areway 
capable =  = apablecay 
of =  = ofway 
reading =  = eadingray 
and =  = andway 
writing =  = itingwray 
in =  = inway 
multiple =  = ultiplemay 
languages. =  = anguageslay. 
They =  = Eythay 
also =  = alsoway 
know =  = owknay 
how =  = owhay 
to =  = otay 
break =  = eakbray 
codes. =  = odescay. 
For =  = Orfay 
some =  = omesay 
reason =  = easonray 
however, =  = oweverhay, 
they =  = eythay 
can't =  = an'tcay 
understand =  = understandway 
pig-latin. =  = ig-latinpay. 
This =  = Isthay 
is =  = isway 
the =  = ethay 
only =  = onlyway 
known =  = ownknay 
way =  = ayway 
for =  = orfay 
we =  = eway 
at =  = atway 
the =  = ethay 
R.A.O. =  = R.a.o 
to =  = otay 
relay =  = elayray 
top-priority =  = op-prioritytay 
messages =  = essagesmay 
from =  = omfray 
operative =  = operativeway 
to =  = otay 
operative =  = operativeway 
without =  = ithoutway 
the =  = ethay 
ostriches =  = ostrichesway 
knowing. =  = owingknay. 
Check =  = Eckchay 
out: =  = outway: 
https://web.ics.purdue.edu/~morelanj/RAO/prepare2.html. =  = tps://web.ics.purdue.edu/~morelanj/RAO/prepare2.htmlhtay. 

Ethay ostrichesway areway apablecay ofway eadingray andway itingwray inway ultiplemay anguageslay. Eythay alsoway owknay owhay otay eakbray odescay. Orfay omesay easonray oweverhay, eythay an'tcay understandway ig-latinpay. Isthay isway ethay onlyway ownknay ayway orfay eway atway ethay R.a.o otay elayray op-prioritytay essagesmay omfray operativeway otay operativeway ithoutway ethay ostrichesway owingknay. Eckchay outway: tps://web.ics.purdue.edu/~morelanj/RAO/prepare2.htmlhtay. 
Last Run:	7:29:30 pm
Compile:	0.016s
Execute:	0.07s
Memory:	0b
CPU:	0.086s
 Entity Framework Extensions - Fastest Way of Inserting Entities
Over 3000 companies use EF Extensions to improve their application performance.
 Learn More
