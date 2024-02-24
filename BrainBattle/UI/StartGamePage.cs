using BrainBattle.Process;

namespace BrainBattle.UI
{
    internal class StartGamePage
    {
        private static string goBack;
        private static string chosenCategory;
        private static bool wrongCategory;

        public static void StartTheGame(string quit)
        {
            LoginPage.GreetText();

            Console.WriteLine("Choose one of four categories to play with:".PadLeft(10));
            Console.WriteLine("----------------------------------------------".PadLeft(83));
            Console.WriteLine("1 - Mathematics".PadLeft(65));
            Console.WriteLine("2 - History".PadLeft(61));
            Console.WriteLine("3 - Wild life".PadLeft(63));
            Console.WriteLine("4 - Cars".PadLeft(58));
            Console.WriteLine("----------------------------------------------".PadLeft(83));

            if (wrongCategory)
            {
                Console.WriteLine("You must choose one category!!!");
                wrongCategory = false;
            }

            Console.WriteLine("Type number and press ENTER:");
            Console.WriteLine();

            chosenCategory = Console.ReadLine();

            switch (chosenCategory)
            {
                case "1":
                    EnterToGame(chosenCategory);
                    break;
                case "2":
                    EnterToGame(chosenCategory);
                    break;
                case "3":
                    EnterToGame(chosenCategory);
                    break;
                case "4":
                    EnterToGame(chosenCategory);
                    break;
                default:
                    Console.Clear();
                    wrongCategory = true;
                    StartTheGame(GameData.GameRules.quitToGameMenuPressed);
                    break;
            }

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

        public static void EnterToGame(string category)
        {
            wrongCategory = true;

            Console.Clear();
            LoginPage.GreetText();

            Console.WriteLine("ENTERED");
        }
    }
}
