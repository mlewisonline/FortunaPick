namespace FortunaPick
{
    internal class Program
    {
        private static List<int> GetThunderLine()
        {
            List<int> thunderLine = [];
            List<int> mainBalls = [];
            List<int> tunderBalls = [];
            Random random = new();

            // Build main balls from 1 to 39.
            for (int i = 1; i < 40; i++)
            {
                mainBalls.Add(i);
            }

            // Build thunder balls from 1 to 14.
            for (int i = 1; i < 15; i++)
            {
                tunderBalls.Add(i);
            }

            // Shuffle the ball sets ordered by new GUID.
            mainBalls = [.. mainBalls.OrderBy(item => Guid.NewGuid())];
            tunderBalls = [.. tunderBalls.OrderBy(item => Guid.NewGuid())];

            // Pick 5 random main balls add to the line and remove from the picking pool.
            int mainIndex = -1;
            for (int i = 0; i < 5; i++)
            {
                mainIndex = random.Next(mainBalls.Count);
                thunderLine.Add(mainBalls[mainIndex]);
                mainBalls.RemoveAt(mainIndex);
            }

            // Pick 1 thunder ball add to the line. No need to remove from pool as only 1 is ever chosen.
            int thunderIndex = random.Next(tunderBalls.Count);
            thunderLine.Add(tunderBalls[thunderIndex]);

            return thunderLine;
        }

        private static List<int> GetLottoLine()
        {
            List<int> lottoLine = [];
            List<int> mainBalls = [];
            Random random = new();

            // Build main balls from 1 to 59.
            for (int i = 1; i < 60; i++)
            {
                mainBalls.Add(i);
            }
            // Shuffle the ball sets ordered by new GUID.
            mainBalls = [.. mainBalls.OrderBy(item => Guid.NewGuid())];

            // Pick 6 random main balls add to the line and remove from the picking pool.
            int indexLotto = -1;
            for (int i = 0; i < 6; i++)
            {
                indexLotto = random.Next(mainBalls.Count);
                lottoLine.Add(mainBalls[indexLotto]);
                mainBalls.RemoveAt(indexLotto);
            }
            return lottoLine;
        }

        private static List<int> GetEuroMillionsLine()
        {
            List<int> euroline = [];
            List<int> mainBalls = [];
            List<int> luckyStars = [];
            Random random = new();

            // Build main balls from 1 to 50.
            for (int i = 1; i < 51; i++)
            {
                mainBalls.Add(i);
            }
            // Build lucky stars from 1 to 12.
            for (int i = 1; i < 13; i++)
            {
                luckyStars.Add(i);
            }

            // Shuffle the ball sets ordered by new GUID.
            mainBalls = [.. mainBalls.OrderBy(item => Guid.NewGuid())];
            luckyStars = [.. luckyStars.OrderBy(item => Guid.NewGuid())];

            // Pick 5 random main balls add to the line and remove from the picking pool.
            int indexEuro = -1;
            for (int i = 0; i < 5; i++)
            {
                indexEuro = random.Next(mainBalls.Count);
                euroline.Add(mainBalls[indexEuro]);
                mainBalls.RemoveAt(indexEuro);
            }
            // Pick 2 random stars add to the line and remove from the picking pool.
            int starIndex = -1;
            for (int i = 0; i < 2; i++)
            {
                starIndex = random.Next(luckyStars.Count);
                euroline.Add(luckyStars[starIndex]);
                luckyStars.RemoveAt(starIndex);
            }
            return euroline;
        }

        private static List<int> GetSetforLifeLine()
        {
            List<int> lifeLine = [];
            List<int> mainBalls = [];
            List<int> lifeBalls = [];
            Random random = new();

            // Build main balls from 1 to 47.
            for (int i = 1; i < 48; i++)
            {
                mainBalls.Add(i);
            }

            // Build thunder balls from 1 to 10.
            for (int i = 1; i < 11; i++)
            {
                lifeBalls.Add(i);
            }

            // Shuffle the ball sets ordered by new GUID.
            mainBalls = [.. mainBalls.OrderBy(item => Guid.NewGuid())];
            lifeBalls = [.. lifeBalls.OrderBy(item => Guid.NewGuid())];

            // Pick 5 random main balls add to the line and remove from the picking pool.
            int mainIndex = -1;
            for (int i = 0; i < 5; i++)
            {
                mainIndex = random.Next(mainBalls.Count);
                lifeLine.Add(mainBalls[mainIndex]);
                mainBalls.RemoveAt(mainIndex);
            }

            // Pick 1 life ball add to the line. No need to remove from pool as only 1 is ever chosen.
            int lifeIndex = random.Next(lifeBalls.Count);
            lifeLine.Add(lifeBalls[lifeIndex]);

            return lifeLine;
        }

        private static void DisplayLottoLines(int numOfLines)
        {
            ConsoleColor OrginalConsoleColour = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nLotto:");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("---------------------------------------------------");
            for (int i = 1; i < numOfLines + 1; i++)
            {
                var lottoLine = GetLottoLine();
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($"Line{i}:\t");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"{lottoLine[0]}\t{lottoLine[1]}\t{lottoLine[2]}\t{lottoLine[3]}\t{lottoLine[4]}\t{lottoLine[5]}\r\n");
                Console.ForegroundColor = OrginalConsoleColour;
            }
        }

        private static void DisplayThunderLines(int numOfLines)
        {
            ConsoleColor OrginalConsoleColour = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\nTunderBall:");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("-----------------------------------------------[T]");
            for (int i = 1; i < numOfLines + 1; i++)
            {
                var thunderLine = GetThunderLine();
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($"Line{i}:\t");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($"{thunderLine[0]}\t{thunderLine[1]}\t{thunderLine[2]}\t{thunderLine[3]}\t{thunderLine[4]}\t");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write($"{thunderLine[5]}\r\n");
                Console.ForegroundColor = OrginalConsoleColour;
            }

        }

        private static void DisplayEuroMillionLines(int numOfLines)
        {
            ConsoleColor OrginalConsoleColour = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nEuroMillions:");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("-----------------------------------------------[Lucky Stars]");
            for (int i = 1; i < numOfLines + 1; i++)
            {
                var euroLine = GetEuroMillionsLine();
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($"Line{i}:\t");
                Console.Write($"{euroLine[0]}\t{euroLine[1]}\t{euroLine[2]}\t{euroLine[3]}\t{euroLine[4]}\t");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($"{euroLine[5]}\t {euroLine[6]}\r\n");
                Console.ForegroundColor = OrginalConsoleColour;
            }
        }

        private static void DisplaySetForLifeLines(int numOfLines)
        {
            ConsoleColor OrginalConsoleColour = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nSet For Life:");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("-----------------------------------------------[L]");
            for (int i = 1; i < numOfLines + 1; i++)
            {
                var lifeLine = GetSetforLifeLine();
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($"Line{i}:\t");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($"{lifeLine[0]}\t{lifeLine[1]}\t{lifeLine[2]}\t{lifeLine[3]}\t{lifeLine[4]}\t");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write($"{lifeLine[5]}\r\n");
                Console.ForegroundColor = OrginalConsoleColour;
            }
        }
        static void WelcomeMessage()
        {
            ConsoleColor OrginalConsoleColour = Console.ForegroundColor;
            var ProgramName = """
         /$$$$$$$$                    /$$                                   /$$$$$$$  /$$           /$$      
        | $$_____/                   | $$                                  | $$__  $$|__/          | $$      
        | $$     /$$$$$$   /$$$$$$  /$$$$$$   /$$   /$$ /$$$$$$$   /$$$$$$ | $$  \ $$ /$$  /$$$$$$$| $$   /$$
        | $$$$$ /$$__  $$ /$$__  $$|_  $$_/  | $$  | $$| $$__  $$ |____  $$| $$$$$$$/| $$ /$$_____/| $$  /$$/
        | $$__/| $$  \ $$| $$  \__/  | $$    | $$  | $$| $$  \ $$  /$$$$$$$| $$____/ | $$| $$      | $$$$$$/ 
        | $$   | $$  | $$| $$        | $$ /$$| $$  | $$| $$  | $$ /$$__  $$| $$      | $$| $$      | $$_  $$ 
        | $$   |  $$$$$$/| $$        |  $$$$/|  $$$$$$/| $$  | $$|  $$$$$$$| $$      | $$|  $$$$$$$| $$ \  $$
        |__/    \______/ |__/         \___/   \______/ |__/  |__/ \_______/|__/      |__/ \_______/|__/  \__/                                                                                               
        """;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(ProgramName);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\t\t\tNational Lottory Number Generator - Version 1.0.0 - Matthew Lewis 2024\r\n");
            Console.ForegroundColor = OrginalConsoleColour;
        }

        static void AboutScreen()
        {
            const string about = """
                FortunaPick: Your Lottery Number Ally

                Are you tired of staring at your lottery ticket, wondering which numbers to choose? Look no further—FortunaPick is here 
                to lend a hand! Whether you’re eyeing the UK Lotto, EuroMillions, or Thunderball, this nifty tool can help you make picks. 
                
                Here’s how:

                Smart Randomization:
                FortunaPick uses clever algorithms to generate random numbers. 
                It’s like having a lucky leprechaun whispering in your ear (minus the green hat).
               
                Remember, FortunaPick doesn’t guarantee a jackpot (if it did, I’d be on a tropical island right now). 
                But it adds a sprinkle of fun and strategy to your lottery adventures. 
                So go ahead, roll those digital dice, and may the odds be ever in your favour!

                Feel free to give FortunaPick a whirl—it’s like having a lucky rabbit’s foot without the fur! 
                Remeber me if you win the big prize $$$.
                """;
            Console.WriteLine(about);
        }

        static void ShowMenu()
        {
            ConsoleColor OrginalConsoleColour = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("""
                    ........................
                    : Press :    Option    :
                    :.......:..............:
                    : L     : Lottery      :
                    : T     : ThunderBall  :
                    : E     : EuroMillions :
                    : S     : Set for Life :
                    : A     : About        :
                    : Q     : Quit         :
                    :.......:..............:
                    """);
        }
        static void Main(string[] args)
        {
            DrawResults drawresults = new DrawResults();
            Statistics statistics = new Statistics();
            
            ConsoleColor OrginalConsoleColour = Console.ForegroundColor;
            WelcomeMessage();
            ShowMenu();
            
          


            char userInput;
            do
            {
               
                Console.Write("Enter your choice: ");
                userInput = Console.ReadKey().KeyChar;
                Console.WriteLine();
                int userNumberOfLines = 1;
                switch (userInput)
                {
                    case 'l':
                    case 'L':
                        Console.Clear();
                        WelcomeMessage();
                        Console.WriteLine($"\t\t\t\t\tTHE LASTEST DRAW RESULTS ARE ");
                        Console.WriteLine($"\t\t\t\t{drawresults.LottoResults[0]}\r\n");
                        Console.Write("How many Lottory lines do you want? -> ");
                        if (!int.TryParse(Console.ReadLine(), out userNumberOfLines))
                        {
                            Console.Clear();
                            WelcomeMessage();
                            ShowMenu();
                            break;
                        }
                        DisplayLottoLines(userNumberOfLines);
                        Console.Write("\nPress Enter to return to Menu");
                        Console.ReadLine();
                        Console.Clear();
                        WelcomeMessage();
                        ShowMenu();
                        break;
                    case 't':
                    case 'T':
                        Console.Clear();
                        WelcomeMessage();
                        Console.WriteLine($"\t\t\t\t\tTHE LASTEST DRAW RESULTS ARE ");
                        Console.WriteLine($"\t\t\t\t{drawresults.ThunderBallResults[0]}\r\n");
                        Console.Write("How many ThunderBall lines do you want? -> ");
                        if (!int.TryParse(Console.ReadLine(), out userNumberOfLines))
                        {
                            Console.Clear();
                            WelcomeMessage();
                            ShowMenu();
                            break;
                        }
                        DisplayThunderLines(userNumberOfLines);
                        Console.Write("\nPress Enter to return to Menu");
                        Console.ReadLine();
                        Console.Clear();
                        WelcomeMessage();
                        ShowMenu();
                        break;
                    case 'e':
                    case 'E':
                        Console.Clear();
                        WelcomeMessage();
                        Console.WriteLine($"\t\t\t\t\tTHE LASTEST DRAW RESULTS ARE ");
                        Console.WriteLine($"\t\t\t\t{drawresults.EuroMillionsResults[0]}\r\n");
                        Console.Write("How many EuroMillion lines do you want? -> ");
                        if (!int.TryParse(Console.ReadLine(), out userNumberOfLines))
                        {
                            Console.Clear();
                            WelcomeMessage();
                            ShowMenu();
                            break;
                        }
                        DisplayEuroMillionLines(userNumberOfLines);
                        Console.Write("\nPress Enter to return to Menu");
                        Console.ReadLine();
                        Console.Clear();
                        WelcomeMessage();
                        ShowMenu();
                        break;
                    case 's':
                    case 'S':
                        Console.Clear();
                        WelcomeMessage();
                        Console.WriteLine($"\t\t\t\t\tTHE LASTEST DRAW RESULTS ARE ");
                        Console.WriteLine($"\t\t\t\t{drawresults.SetForLifeResults[0]}\r\n");
                        Console.Write("How many Set for Life lines do you want? > ");
                        if (!int.TryParse(Console.ReadLine(), out userNumberOfLines))
                        {
                            Console.Clear();
                            WelcomeMessage();
                            ShowMenu();
                            break;
                        }
                        DisplaySetForLifeLines(userNumberOfLines);
                        Console.Write("\nPress Enter to return to Menu");
                        Console.ReadLine();
                        Console.Clear();
                        WelcomeMessage();
                        ShowMenu();
                        break;
                    case 'a':
                    case 'A':
                        Console.Clear();
                        WelcomeMessage();
                        AboutScreen();
                        Console.Write("\nPress Enter to return to Menu");
                        Console.ReadLine();
                        Console.Clear();
                        WelcomeMessage();
                        ShowMenu();
                        break;
                    case 'q':
                    case 'Q':
                        // Lets quit the program
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }
            } while (userInput != 'q' && userInput != 'Q');

            Console.WriteLine("Goodbye and Good Luck !!!");
            Console.ForegroundColor = OrginalConsoleColour;
        }
    }
}
