using BrainBattle.Process;

namespace BrainBattle.UI
{
    internal class GameRulePage
    {
        public static void ShowGameRules(string quit)
        {
            string goBack;
            LoginPage.GreetText();
            LoginPage.LoggedPlayerInformation();

            Console.WriteLine("----------------------------------------------".PadLeft(83));
            Console.WriteLine("GAME RULES".PadLeft(65));
            Console.WriteLine("----------------------------------------------".PadLeft(83));
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine(GameData.GameRules.rule1);
            Console.ResetColor();
            Console.WriteLine("----------------------------------------------".PadLeft(83));
            Console.WriteLine(GameData.GameRules.rule2);
            Console.WriteLine(GameData.GameRules.rule3);
            Console.WriteLine("----------------------------------------------".PadLeft(83));

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
                ShowGameRules(GameData.GameRules.quitToGameMenuPressed);
            }
        }
    }
}
