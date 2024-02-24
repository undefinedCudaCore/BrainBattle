using BrainBattle.Process;

namespace BrainBattle.UI
{
    internal class StartGamePage
    {
        private static string goBack;

        public static void StartTheGame(string quit)
        {
            Console.WriteLine();
            Console.WriteLine(quit);
            goBack = Console.ReadLine();

            if (!String.IsNullOrEmpty(goBack.Trim()) && goBack.ToLower() == "q")
            {
                Console.Clear();
                MenuPage.Menu(LoginPage.isUserRegistered);
            }
            else
            {
                Console.Clear();
                StartTheGame(GameData.GameRules.quitToGameMenuPressed);
            }

        }
    }
}
