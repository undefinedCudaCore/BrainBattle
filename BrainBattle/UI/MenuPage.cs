using BrainBattle.Process;

namespace BrainBattle.UI
{
    internal static class MenuPage
    {
        private static bool selection;
        private static string choise;
        private static string menuIemSelectionInformationalString = "Select your choice and press ENTER: ";

        public static void PrintMenuItems(string registration)
        {
            Console.WriteLine();
            Console.Write($"Welcome ");
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.Write($"{GameProcess.MakeFirstLetterUpperCase(LoginPage.currentUser)}");
            Console.ResetColor();
            Console.WriteLine($". {registration} ");
            Console.WriteLine();
            Console.WriteLine("----------------------------------------------".PadLeft(83));
            Console.WriteLine("GAME MENU".PadLeft(65));
            Console.WriteLine("----------------------------------------------".PadLeft(83));
            Console.WriteLine("1 - Game rules".PadLeft(65));
            Console.WriteLine("2 - Players and results".PadLeft(74));
            Console.WriteLine("3 - START THE GAME".PadLeft(69));
            Console.WriteLine("4 - Logout".PadLeft(61));
            Console.WriteLine("----------------------------------------------".PadLeft(83));
        }

        public static void Menu(string userRegistrationGreet)
        {
            int count = 5;
            LoginPage.GreetText();
            PrintMenuItems(userRegistrationGreet);

            if (!selection)
            {
                menuIemSelectionInformationalString = "Select your choice and press ENTER: ";
            }
            if (selection)
            {
                menuIemSelectionInformationalString = "You must select your choice and press ENTER!!!";
                selection = false;
            }

            Console.WriteLine(menuIemSelectionInformationalString);
            choise = Console.ReadLine();

            Console.Clear();

            if (!String.IsNullOrEmpty(choise.Trim()))
            {
                switch (choise)
                {
                    case "1":
                        GameRulePage.ShowGameRules(GameData.GameRules.quitToGameMenu);
                        break;
                    case "2":
                        PlayersAndResultsPage.PlayerInformationPanel(GameData.GameRules.quitToGameMenu);
                        break;
                    case "3":
                        StartGamePage.StartTheGame(GameData.GameRules.quitToGameMenu);
                        break;
                    case "4":
                        Console.Clear();
                        GameData.Login.loggedUser = "";
                        GameData.Login.loggedin = false;
                        GameProcess.RunGame();
                        break;
                    default:
                        Console.Clear();
                        selection = true;
                        Menu(LoginPage.isUserRegistered);
                        break;
                }
            }
            else
            {
                Console.Clear();
                Menu(LoginPage.isUserRegistered);
            }
        }
    }
}
