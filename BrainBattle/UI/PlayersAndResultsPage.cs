using BrainBattle.Process;

namespace BrainBattle.UI
{
    internal static class PlayersAndResultsPage
    {
        private static string choosePlayerOrResultList;
        private static ConsoleColor consoleColor;

        public static void PlayerInformationPanel(string quit)
        {
            LoginPage.GreetText();
            LoginPage.LoggedPlayerInformation();

            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine(GameData.PlayersAndResults.choosePlayersOrResults);
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine(GameData.PlayersAndResults.choosePlayers.PadLeft(10));
            Console.WriteLine(GameData.PlayersAndResults.chooseResults.PadLeft(5));
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine(quit);
            Console.WriteLine();
            choosePlayerOrResultList = Console.ReadLine();

            if (!String.IsNullOrEmpty(choosePlayerOrResultList.Trim())
                && choosePlayerOrResultList.ToLower() == "p")
            {
                Console.Clear();
                PlayerList(GameData.GameRules.quitToGameMenu);
            }
            else if (!String.IsNullOrEmpty(choosePlayerOrResultList.Trim())
                && choosePlayerOrResultList.ToLower() == "r")
            {
                Console.Clear();
                PlayerResults(GameData.GameRules.quitToGameMenu);
            }
            else if (!String.IsNullOrEmpty(choosePlayerOrResultList.Trim())
                && choosePlayerOrResultList.ToLower() == "q")
            {
                Console.Clear();
                GameData.PlayersAndResults.choosePlayersOrResults = "Choose what you want to see:";
                MenuPage.Menu(LoginPage.isUserRegistered);
            }
            else
            {
                Console.Clear();
                GameData.PlayersAndResults.choosePlayersOrResults = GameData.PlayersAndResults.choosePlayersOrResultsPressed;
                PlayerInformationPanel(GameData.GameRules.quitToGameMenuPressed);
            }
        }

        public static void PlayerList(string quit)
        {
            LoginPage.GreetText();
            LoginPage.LoggedPlayerInformation();

            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine("PLAYERS:");
            Console.WriteLine();

            foreach (var userPoinData in LoginPage.playerData)
            {
                consoleColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), GameProcess.RandomPlayerColor(), true);
                Console.ForegroundColor = consoleColor;
                Console.WriteLine(GameProcess.MakeFirstLetterUpperCase(userPoinData.Key));
                Console.ResetColor();
            }

            Console.WriteLine();
            Console.WriteLine(quit);
            Console.WriteLine();
            choosePlayerOrResultList = Console.ReadLine();

            if (!String.IsNullOrEmpty(choosePlayerOrResultList.Trim())
                && choosePlayerOrResultList.ToLower() == "q")
            {
                Console.Clear();
                PlayersAndResultsPage.PlayerInformationPanel(GameData.GameRules.quitToGameMenu);
            }
            else
            {
                Console.Clear();
                GameData.PlayersAndResults.choosePlayersOrResults = GameData.PlayersAndResults.choosePlayersOrResultsPressed;
                PlayerList(GameData.GameRules.quitToGameMenuPressed);
            }
        }

        public static void PlayerResults(string quit)
        {
            Dictionary<string, int> playerResult;
            int count1 = 0;
            int count2 = 0;
            string top = "";
            string star = "";

            LoginPage.GreetText();
            LoginPage.LoggedPlayerInformation();

            Console.WriteLine("------------------------------------------------------");
            playerResult = PlayerResults2().OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

            foreach (var item in playerResult)
            {
                count1++;
                count2++;

                if (count1 <= 3)
                {
                    top = "TOP " + count1 + "_";
                    star = "*";
                }
                if (count1 > 3)
                {
                    top = "TOP " + count1 + "_";
                    star = "";
                }
                if (count1 > 10)
                {
                    top = "TOP " + count1 + "_";
                    top = "";
                }

                consoleColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), GameProcess.RandomPlayerColor(), true);
                Console.ForegroundColor = consoleColor;
                Console.Write(top + GameProcess.MakeFirstLetterUpperCase(item.Key + star));
                Console.Write($" points in total: {item.Value}");
                Console.ResetColor();

                Console.WriteLine();
                Console.WriteLine();
            }

            Console.WriteLine(quit);
            Console.WriteLine();
            choosePlayerOrResultList = Console.ReadLine();

            if (!String.IsNullOrEmpty(choosePlayerOrResultList.Trim())
                && choosePlayerOrResultList.ToLower() == "q")
            {
                Console.Clear();
                PlayersAndResultsPage.PlayerInformationPanel(GameData.GameRules.quitToGameMenu);
            }
            else
            {
                GameData.PlayersAndResults.choosePlayersOrResults = GameData.PlayersAndResults.choosePlayersOrResultsPressed;
                Console.Clear();
                PlayerResults(GameData.GameRules.quitToGameMenuPressed);
            }
        }

        public static Dictionary<string, int> PlayerResults2()
        {
            Dictionary<string, int> result = new Dictionary<string, int>();
            int pointSum = 0;

            foreach (var userPoinData in LoginPage.playerData)
            {
                foreach (var category in userPoinData.Value)
                {
                    foreach (var point in category.Value)
                    {
                        pointSum += point;
                    }
                }
                result.Add(userPoinData.Key, pointSum);
                pointSum = 0;
            }
            return result;
        }
    }
}
