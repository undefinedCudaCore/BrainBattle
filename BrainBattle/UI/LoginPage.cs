using BrainBattle.Process;

namespace BrainBattle.UI
{
    internal static class LoginPage
    {
        internal static Dictionary<string, Dictionary<string, List<int>>> playerData = new Dictionary<string, Dictionary<string, List<int>>>();
        internal static string currentUser;
        internal static string firstSelection;
        internal static string isUserRegistered;


        public static void GreetText()
        {
            Console.Write("----------------------------------------------");

            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.Write(" Welcome to ");

            Console.BackgroundColor = ConsoleColor.Red;
            Console.Write(" BRAIN ");

            Console.BackgroundColor = ConsoleColor.Blue;
            Console.Write(" BATTLE! ");

            Console.ResetColor();
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("----------------------------------------------".PadLeft(83));
        }
        public static void Greeting(bool nulOrEmpty)
        {
            GreetText();

            if (GameData.Login.loggedUser == "")
            {
                Console.WriteLine("Logged out, please log in.");
            }
            Console.WriteLine(GameData.Login.loginToGameChoise);

            if (nulOrEmpty)
            {
                Console.Clear();

                GreetText();

                Console.WriteLine(GameData.Login.wrongCredentials);
                Console.WriteLine(GameData.Login.loginToGameChoise);

            }

            firstSelection = Console.ReadLine();

            //if (!String.IsNullOrEmpty(firstSelection) && firstSelection == "1")
            //{
            //    Console.WriteLine(GameData.Login.enterCredentials);

            //    currentUser = Console.ReadLine();
            //}
            //else if (!String.IsNullOrEmpty(firstSelection) && firstSelection.ToLower() == "q")
            //{
            //    Environment.Exit(0);
            //}
            //else
            //{
            //    Console.WriteLine(GameData.Login.awaitForBadChoise);
            //    //Console.WriteLine(GameData.Login.gameIsClosingTime);
            //    Thread.Sleep(5000);
            //    Environment.Exit(0);
            //}

            switch (firstSelection)
            {
                case "1":
                    if (!String.IsNullOrEmpty(firstSelection) && firstSelection == "1")
                    {
                        Console.WriteLine(GameData.Login.enterCredentials);

                        currentUser = Console.ReadLine();
                    }
                    break;
                case "q":
                    if (!String.IsNullOrEmpty(firstSelection) && firstSelection.ToLower() == "q")
                    {
                        Environment.Exit(0);
                    }
                    break;
                default:
                    Console.WriteLine(GameData.Login.awaitForBadChoise);
                    Thread.Sleep(5000);
                    Console.Clear();
                    GameProcess.RunGame();
                    break;
            }
            Console.Clear();
        }

        public static Dictionary<string, Dictionary<string, List<int>>> AddLoginToList(out bool isNullOrEmpty)
        {
            isNullOrEmpty = false;
            Dictionary<string, List<int>> userPointDataByQuestionCategory = new Dictionary<string, List<int>>
            {
                { "Mathematics", new List<int>() },
                { "History", new List<int>() },
                { "Wild life", new List<int>() },
                { "Cars", new List<int>() }
            };

            if (String.IsNullOrEmpty(currentUser.Trim()))
            {
                isNullOrEmpty = true;
                Greeting(isNullOrEmpty);
                return playerData;
            }
            else if (!String.IsNullOrEmpty(currentUser.Trim()))
            {
                GameData.Login.loggedUser = currentUser;
                GameData.Login.loggedin = true;

                bool addUser = playerData.TryAdd(currentUser.ToLower(), userPointDataByQuestionCategory);
                if (!addUser)
                {
                    isUserRegistered = GameData.Login.existingUserWelcome;
                    MenuPage.Menu(isUserRegistered);
                    return playerData;

                }
                else
                {
                    isUserRegistered = GameData.Login.newUserWelcome;
                    MenuPage.Menu(isUserRegistered);
                    return playerData;
                }
            }
            else
            {

                return playerData;
            }
        }

        public static void LoggedPlayerInformation()
        {
            Console.WriteLine();
            Console.WriteLine($"Player logged in: {GameProcess.MakeFirstLetterUpperCase(LoginPage.currentUser)}");
            Console.WriteLine();
        }
    }
}
