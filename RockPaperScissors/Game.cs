using System;
using System.Diagnostics;

namespace RockPaperScissors
{
    class Game
    {

        static string userInput;
        static bool userInputCorrect = true;
        static Random random = new Random();
        static bool computerDecisionCompareRock = false;
        static bool computerDecisionComparePaper = false;
        static bool computerDecisionCompareScissors = false;
        static string computerResponseRock = "kamen";
        static string computerResponsePaper = "papir";
        static string computerResponseScissors = "skarje";
        static int computerWon = 0;
        static int userWon = 0;
        static int draw = 0;
        static int totalRounds = 0;

        static void Main(string[] args)
        {
            SetInformation();
            GameLoop();

        }

        private static void GameLoop()
        {
            do
            {

                do //loop to check for correct input and if correct displays your input.
                {


                    Console.Write("\nVasa izbira: ");
                    userInput = Console.ReadLine();
                    SetInformation();

                    if ((userInput == "papir") || (userInput == "kamen") || (userInput == "skarje"))
                    {
                        Console.WriteLine("___________________________________________________________________________");
                        Console.WriteLine("\nIzbrali ste: " + userInput);
                        break;
                    }
                    else
                    {
                        SetInformation();
                        Console.BackgroundColor = ConsoleColor.DarkRed;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("\nProsim vnesite pravilno izbiro in pazite na crkovanje. [kamen, papir ali skarje]");
                        Console.ResetColor();
                        userInputCorrect = false;
                    }
                } while (userInputCorrect == false);

                ResetForNextRound();
                ComputerResponse();
                CompareDecisionAndRespond();

            } while (true);
        }

        private static void CompareDecisionAndRespond()
        {
            if ((userInput == "kamen" && computerDecisionCompareRock == true)
                                || (userInput == "papir" && computerDecisionComparePaper == true)
                                || (userInput == "skarje" && computerDecisionCompareScissors == true))
            {
                Console.WriteLine("Izbrala sta isto! Ni zmagovalca.");
                draw++;
                totalRounds++;
            }
            else if (userInput == "kamen" && computerDecisionComparePaper == true)
            {
                Console.WriteLine("Racunalnik zmaga! Papir premaga kamen.");
                computerWon++;
                totalRounds++;
            }
            else if (userInput == "papir" && computerDecisionCompareScissors == true)
            {
                Console.WriteLine("Racunalnik zmaga! Skarje premagajo papir.");
                computerWon++;
                totalRounds++;
            }
            else if (userInput == "skarje" && computerDecisionCompareRock == true)
            {
                Console.WriteLine("Racunalnik zmaga! Kamen premaga skarje.");
                computerWon++;
                totalRounds++;
            }
            else if (userInput == "kamen" && computerDecisionCompareScissors == true)
            {
                Console.WriteLine("Ti zmagas! Kamen premaga skarje.");
                userWon++;
                totalRounds++;
            }
            else if (userInput == "papir" && computerDecisionCompareRock == true)
            {
                Console.WriteLine("Ti zmagas! Papir premaga kamen.");
                userWon++;
                totalRounds++;
            }
            else if (userInput == "skarje" && computerDecisionComparePaper == true)
            {
                Console.WriteLine("Ti zmagas! Skarje premagajo papir.");
                userWon++;
                totalRounds++;
            }
            Console.WriteLine("___________________________________________________________________________");
            Console.Write("Racunalnik zmagal: " + computerWon + " | ");
            Console.Write("Igralec zmagal: " + userWon + " | ");
            Console.Write("Izenaceno: " + draw + " | ");
            Console.WriteLine("Stevilo iger: " + totalRounds);
        }

        public static void ComputerResponse()
        {
            int computerChoice = random.Next(1, 7);
            Debug.WriteLine(computerChoice);
            switch (computerChoice) //switch statement for a random computer choice, several cases for more randomness
            {
                case 1: computerDecisionCompareRock = true; break;
                case 2: computerDecisionComparePaper = true; break;
                case 3: computerDecisionCompareScissors = true; break;
                case 4: computerDecisionCompareRock = true; break;
                case 5: computerDecisionComparePaper = true; break;
                case 6: computerDecisionCompareScissors = true; break;
            }
            if(computerDecisionCompareRock == true)
            {
                Console.WriteLine("Racunalnik je izbral: " + computerResponseRock);
            }else if(computerDecisionComparePaper == true)
            {
                Console.WriteLine("Racunalnik je izbral: " + computerResponsePaper);
            }else if(computerDecisionCompareScissors == true)
            {
                Console.WriteLine("Racunalnik je izbral: " + computerResponseScissors);
            }
        }

        public static void SetInformation()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("|----------------------|");
            Console.WriteLine("|KAMEN - PAPIR - SKARJE|");
            Console.WriteLine("|----------------------|");
            Console.ResetColor();
            Console.WriteLine("\nIgrate proti racunalniku, vtipkajte svojo izbiro [kamen, papir ali skarje] \n" +
                "pazite da jo pravilno vtipkate. Veliko srece!");
        }

        public static void ResetForNextRound()
        {
            computerDecisionCompareRock = false;
            computerDecisionComparePaper = false;
            computerDecisionCompareScissors = false;
        }

        
    }
}
