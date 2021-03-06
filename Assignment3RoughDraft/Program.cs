using System;
namespace Assignment3RoughDraft
{
    class Program
    {
        static void Main(string[] args)
        {
            int credits = 50;
            string userInput = GetMenuChoice();
            while(userInput != "4" && credits > 0 && credits < 300)
            {
                Route(userInput, ref credits);
                userInput = GetMenuChoice();
            }
            GoodbyeMessage(ref credits);
        }
        static void Route(string userInput, ref int credits)
        {
            if(userInput == "1")
            {
                TheForce(ref credits);
            }
            else if(userInput == "2")
            {
                if(BlastersWagerCheck(ref credits))
                {
                    Console.Clear();
                    BlastersGame(ref credits);
                }
                else if(!BlastersWagerCheck(ref credits))
                {
                    Console.WriteLine("You do not have enough credits to play this game! This game requires 20 credits to be wagered. Press any key to return to the Main Menu");
                    Console.ReadKey();
                }
            }
            else if(userInput == "3")
            {
                CheckScoreboard(ref credits);
            }
        }
        static bool ValidMenuChoice(string userInput)
        {
            if(userInput == "1" || userInput == "2" || userInput == "3" || userInput == "4")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        static string GetMenuChoice()
        {
            DisplayMenu();
            string userInput = Console.ReadLine();
            while(!ValidMenuChoice(userInput))
            {
                Console.WriteLine("Invalid menu choice.  Please Enter a Valid Menu Choice");
                Console.WriteLine("Press any key to continue....");
                Console.ReadKey();
                DisplayMenu();
                userInput = Console.ReadLine();
            }
            return userInput;
        }
        static void DisplayMenu()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nWelcome to the Intergalactic Gaming System!");
            Console.WriteLine("Please enter a number to . . .\n1) Play The Force\n2) Play Blasters Game\n3) View Current Scoreboard\n4) Exit Program");
        }
        static void BlastersGame(ref int credits)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            int points = 15;
            BlastersMessage();
            int blasterswager = GetBlastersWager(ref credits);
            Console.Clear();
            Console.WriteLine($"You have wagered {blasterswager} credits\n");
            credits -= blasterswager;
            Console.WriteLine($"You now have {credits} credits. Best of luck Skywalker! Press any key to continue");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Laser from Yoda Incoming!\nInput and press enter to....\n1) Dodge\n2) Deflect\n3) Exit game (wagered credits will be lost)");
            string move = Console.ReadLine();
            while(move != "3" && points > 0 && points < 40)
            {
                if(move == "1")
                {
                    Random dodge = new Random();
                    int a = dodge.Next(0,2);
                    if(a == 0)
                    {
                        points -= 5;
                        Console.Clear();
                        Console.WriteLine($"Dodge unsuccessful. You have been hit! You have lost 5 points.\nAmount of points: {points} \nPress any key to continue. . .");
                        Console.ReadKey();
                    }
                    if(a == 1)
                    {
                        points += 5;
                        Console.Clear();
                        Console.WriteLine($"Nice dodge! You have gained 5 points.\nAmount of points: {points} \nPress any key to continue. . .");
                        Console.ReadKey();
                    }
                } 
                else if(move == "2")
                {
                    Random deflect = new Random();
                    int b = deflect.Next(0,9);
                    if(b >= 3)
                    {
                        points -= 5;
                        Console.Clear();
                        Console.WriteLine($"Deflection unsuccessful. You have been hit! You have lost 5 points.\nAmount of points: {points} \nPress any key to continue. . .");
                        Console.ReadKey();
                    }
                    if(b < 3)
                    {
                        points += 10;
                        Console.Clear();
                        Console.WriteLine($"Wow, great deflection! You have gained 10 points.\nAmount of points: {points} \nPress any key to continue. . .");
                        Console.ReadKey();
                    }
                }   
                else if(move == "3")
                {
                    Console.WriteLine("You have left the Blasters game. Thank you for playing!");
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("You have entered an invalid selection. Please try again!\n");
                }
                if(BlastersPointsCheck(ref points))
                {    
                    Console.Clear();
                    Console.WriteLine("Laser from Yoda Incoming!\nInput and press enter to:\n1) Dodge\n2) Deflect\n3) Exit game (wagered credits will be lost)");
                    move = Console.ReadLine();
                }
            }
            if(points >= 40)
            {
                credits += (2 * blasterswager);
                Console.Clear();
                Console.WriteLine($"Nice work out there Luke! You dodged and deflected all Blasters! You won {blasterswager * 2} credits!\nUpdated credit balance: {credits} \nWould you like to play Blasters again?\n1) Play Again!\n2) Back to Main Menu");
                string postBlastersInput = Console.ReadLine();
                PostBlastersSelectionCheck(postBlastersInput);
                if(postBlastersInput == "1")
                {
                    if(BlastersWagerCheck(ref credits))
                    {
                        Console.Clear();
                        BlastersGame(ref credits);
                    }
                    else if(!BlastersWagerCheck(ref credits))
                    {
                        Console.WriteLine("You do not have enough credits to play this game! This game requires 20 credits to be wagered. Press any key to return to the Main Menu");
                        Console.ReadKey();
                    }
                }
                else if(postBlastersInput == "2")
                {
                    Console.WriteLine("Thank you for playing Blasters! Press any key to return to the Main Menu");
                    Console.ReadKey();
                }
            }
            if(points <= 0)
            {
                Console.Clear();
                Console.WriteLine($"You lost the battle! You lost {blasterswager} credits.\nCredit balance: {credits} \nWould you like to play Blasters again?\n1) Play Again!\n2) Back to Main Menu");
                string postBlastersInput = Console.ReadLine();
                PostBlastersSelectionCheck(postBlastersInput);
                if(postBlastersInput == "1")
                {
                    if(BlastersWagerCheck(ref credits))
                    {
                        Console.Clear();
                        BlastersGame(ref credits);
                    }
                    else if(!BlastersWagerCheck(ref credits))
                    {
                        Console.WriteLine("You do not have enough credits to play this game! This game requires 20 credits to be wagered. Press any key to return to the Main Menu");
                        Console.ReadKey();
                    }
                }
                else if(postBlastersInput == "2")
                {
                    Console.WriteLine("Thank you for playing Blasters! Press any key to return to the Main Menu");
                    Console.ReadKey();
                }
            }
        }
        static void TheForce(ref int credits)
        {
           int guesscount = 0;
           int correct = 0;
           int incorrect = 0;
           string[] randomCards = new string[11];
           int[] randomValues = new int[11];
           GetAllCards(randomCards, randomValues);
           ForceMessage();
           Console.ReadKey();
           int forcewager = GetForceWager(ref credits);
           credits -= forcewager;
           Console.WriteLine($"First card: {randomCards[guesscount]} \nIs the next card higher or lower?  {correct}/10 guesses to win\n1) Higher\n2) Lower");
           string forceMove = Console.ReadLine();
           if(forceMove == "1")
           {
               if(randomValues[guesscount] < randomValues[guesscount + 1])
               {
                   guesscount++;
                   correct++;
                   Console.WriteLine($"You answered correctly! The next card was {randomCards[guesscount]}");
               }
               else
               {
                   guesscount++;
                   incorrect++;
                   Console.WriteLine($"Incorrect guess! The correct guess was Lower. The next card was {randomCards[guesscount]}");
               }
           }
           else if(forceMove == "2")
           {
               if(randomValues[guesscount] > randomValues[guesscount + 1])
               {
                   guesscount++;
                   correct++;
                   Console.WriteLine($"You answered correctly! The next card was {randomCards[guesscount]}");
               }
               else
               {
                   guesscount++;
                   incorrect++;
                   Console.WriteLine($"Incorrect guess! The correct guess was Higher. The next card was {randomCards[guesscount]}");
               }
           }
           while(guesscount < 11 && incorrect == 0)
           {
                Console.WriteLine($"Current card: {randomCards[guesscount]} \nIs the next card higher or lower?  {correct}/10 guesses to win\n1) Higher\n2) Lower");
                forceMove = Console.ReadLine();
                if(forceMove == "1")
                {
                    if(randomValues[guesscount] < randomValues[guesscount + 1])
                    {    
                        guesscount++;
                        correct++;
                        Console.WriteLine($"You answered correctly! The next card was {randomCards[guesscount]}");
                    }
                    else
                    {
                        guesscount++;
                        incorrect++;
                        Console.WriteLine($"Incorrect Guess! The correct guess was Lower. The next card was {randomCards[guesscount]}");
                    }
                }
                else if(forceMove == "2")
                {
                    if(randomValues[guesscount] > randomValues[guesscount + 1])
                    {
                        guesscount++;
                        correct++;
                        Console.WriteLine($"You answered correctly! The next card was {randomCards[guesscount]}");
                    }
                    else
                    {
                        guesscount++;
                        incorrect++;
                        Console.WriteLine($"Incorrect guess! The correct guess was Higher. The next card was {randomCards[guesscount]}");
                    }
                }
            }
            if(guesscount == 10)
            {
                credits += forcewager * 3;
                Console.WriteLine($"You have won THE FORCE! You guessed all 10 cards correctly! You have won {forcewager * 3} credits!\nNew credit balance: {credits}");
            }
            else if(guesscount >= 7 && guesscount < 10)
            {
                credits += forcewager * 2;
                Console.WriteLine($"You answered {guesscount} cards correctly. That earned you {forcewager * 2} credits!\nNew credit balance: {credits}");
            }
            else if(guesscount < 7 && guesscount >= 5)
            {
                credits += forcewager;
                Console.WriteLine($"It's a push! You answered {guesscount} cards correctly. That earned you the {forcewager} credit wager back.\nCurrent credit balance: {credits}");
            }
            else
            {
                Console.WriteLine($"You lost! You did not at least guess 5 cards right. You answered {guesscount} cards correctly. You lost {forcewager} credits.\nNew credit balance: {credits}");
            }
        }
        static void BlastersMessage()
        {
            Console.WriteLine("Welcome to Blasters!\n\nIn this game, Yoda will fire at you with a blaster. It is up to your discretion to dodge or deflect the shot with your lightsaber.\nIf you dodge successfully, you gain 5 points.\nIf you deflect successfully, you gain 10 points.\nIf you do not dodge or deflect successfully, you get hit! You will lose 5 points.\nTo win the game, you must get over 40 points (you start out at 15 points).\nYou lose the game if you reach 0 points, as a loss will result in losing your wagered credits.\n\nRequired amount of credits wagered: 20 credits");
        }
        static void ForceMessage()
        {
            Console.WriteLine("Welcome to The Force!\n\nWithin this game Yoda will show 1 random card and lay out 10 other cards (face down)\nThe object of the game is to correctly guess if the current card's number is higher or lower than the next card's number.\nIf guessed correctly, you will move onto the next card out of 10, until the last card has been guessed.\n\nIf you guess all 10 correctly, you will win 3 times the amount you wagered\nIf you guess at least 7 correctly, you will win 2 times the amount you wagered\nIf you guess at least 5 correctly you will break even and receive your wager back\nUnder 5 correct guesses will result in a loss, giving Yoda the amount you wagered.\n\nPress any key to continue to THE FORCE");
        }
        static int GetBlastersWager(ref int credits)
        {
            Console.WriteLine($"\nPlease type how much you want to wager (You have {credits} credits):");
            int blasterswager = int.Parse(Console.ReadLine());
            while(blasterswager > credits)
            {
                Console.Clear();
                Console.WriteLine("You do not have that many credits! Please enter again.\nPlease type how much you want to wager:");
                blasterswager = int.Parse(Console.ReadLine());
            }
            while(blasterswager < 20)
            {
                Console.Clear();
                Console.WriteLine("You must wager at least 20 credits! Please enter a wager greater than or equal to 20 credits.");
                blasterswager = int.Parse(Console.ReadLine());
            }
            return blasterswager;
        }
        static bool BlastersWagerCheck(ref int credits)
        {
            if(credits >= 20)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        static bool BlastersPointsCheck(ref int points)
        {
            if(points < 40 && points > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        static string PostBlastersSelectionCheck(string postBlastersInput)
        {
            while(postBlastersInput != "1" && postBlastersInput != "2")
            {
                Console.WriteLine("You have entered an invalid selection. Please try again!\n");
                Console.WriteLine("Would you like to play Blasters again?\n1) Play Again!\n2) Back to Main Menu");
                postBlastersInput = Console.ReadLine();
            }
            return postBlastersInput;
        }
        static void CheckScoreboard(ref int credits)
        {
            Console.Clear();
            Console.WriteLine("Amount of Credits: " + credits);
            Console.WriteLine("Press any key to return to the Main Menu");
            Console.ReadKey();
        }
        static void GetAllCards(string[] randomCards, int[] randomValues)
        {
            int count = 0;
            string[] deck = new string[52];
            int[] value = new int[52];
            string[] suit = {"Hearts", "Spades", "Clubs", "Diamonds"};
            string[] face = {"Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King"};
            for(int i = 0; i < 4; i++)
            {
                for(int j = 0; j < 13; j++)
                {
                    deck[count] = face[j] + " of " + suit[i];
                    value[count] = j+1;
                    count++;
                }
            }
            Random rnd = new Random();
            for(int k = 0; k < 11; k++)
            {
                int num = rnd.Next(52);
                randomCards[k] = deck[num];
                randomValues[k] = value[num];
            }
        }
        static int GetForceWager(ref int credits)
        {
            System.Console.WriteLine("Please enter how many credits you want to wager:");
            int forcewager = int.Parse(Console.ReadLine());
            while(forcewager > credits)
            {
                Console.Clear();
                Console.WriteLine("You do not have that many credits! Please enter again.\nPlease type how much you want to wager:");
                forcewager = int.Parse(Console.ReadLine());
            }
            Console.WriteLine($"You have wagered {forcewager} credits. Best of luck Skywalker! May THE FORCE be with you!");
            return forcewager;
        }
        static void GoodbyeMessage(ref int credits)
        {
            System.Console.WriteLine("Thank you for using the Intergalactic Gaming System! Before you leave, do you want to look at the scoreboard one last time?\n1) Yes\n2) No");
            string userInput = Console.ReadLine();
            if(userInput == "1")
            {
                CheckScoreboard(ref credits);
                Console.WriteLine("May the force be with you! Goodbye Skywalker!");
            }
            else if(userInput == "2")
            {
                Console.WriteLine("May the force be with you! Goodbye Skywalker!");
            }
        }
    }
}
