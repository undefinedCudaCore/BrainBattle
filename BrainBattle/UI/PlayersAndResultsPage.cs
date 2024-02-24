using BrainBattle.Process;

namespace BrainBattle.UI
{
    internal static class PlayersAndResultsPage
    {
        private static string choosePlayerOrResultList;

        public static void PlayerInformationPanel(string quit)
        {
            LoginPage.GreetText();
            Console.WriteLine();
            Console.WriteLine($"Player logged in: {GameProcess.MakeFirstLetterUpperCase(LoginPage.currentUser)}");
            Console.WriteLine();
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
            Console.WriteLine();
            Console.WriteLine($"Player logged in: {GameProcess.MakeFirstLetterUpperCase(LoginPage.currentUser)}");
            Console.WriteLine();
            Console.WriteLine("PLAYERS:");
            Console.WriteLine();

            foreach (var userPoinData in LoginPage.playerData)
            {
                ConsoleColor consoleColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), GameProcess.RandomPlayerColor(), true);
                Console.ForegroundColor = consoleColor;
                Console.WriteLine(GameProcess.MakeFirstLetterUpperCase(userPoinData.Key));
                Console.ResetColor();
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
                Console.Clear();
                GameData.PlayersAndResults.choosePlayersOrResults = GameData.PlayersAndResults.choosePlayersOrResultsPressed;
                PlayerList(GameData.GameRules.quitToGameMenuPressed);
            }
        }

        public static void PlayerResults(string quit)
        {
            LoginPage.GreetText();
            Console.WriteLine();
            Console.WriteLine($"Player logged in: {GameProcess.MakeFirstLetterUpperCase(LoginPage.currentUser)}");
            Console.WriteLine();

            Console.WriteLine("Result list");

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
                PlayerResults(GameData.GameRules.quitToGameMenuPressed);
            }
        }

        //public static void PlayerResults2()
        //{
        //    foreach (var userPoinData in LoginPage.playerData)
        //    {
        //        Console.WriteLine(userPoinData.Key);
        //        foreach (var category in userPoinData.Value)
        //        {
        //            Console.WriteLine(category.Key);
        //            foreach (var point in category.Value)
        //            {
        //                Console.WriteLine(point);

        //            }
        //        }
        //    }
        //}
    }
}
