namespace BrainBattle.Process
{
    public static class GameData
    {
        public static class Login
        {
            public static string loggedUser { get; set; }
            public static bool loggedin { get; set; }

            public const string loginToGameChoise = "To Login enter '1'. If you want to leave the game enter 'q'.";
            public const string enterCredentials = "Enter your name and last name: ";
            public const string wrongCredentials = "You entered wrong credentials, try again. ";
            public const string awaitForBadChoise = "Game closing, if you want to play again - start game all over again. Wait for 5 seconds.";
            //public const string gameIsClosingTime = "You entered wrong credentials, try again. ";
            public const string newUserWelcome = "Thank you for your registration.";
            public const string existingUserWelcome = "You are a registered user, and points will be added to your account.";

        }

        public static class GameRules
        {
            public const string quitToGameMenu = "Enter 'q' to go back to GAME MENU.";
            public const string quitToGameMenuPressed = "If you want to go back to GAME MENU you must type 'q' and press ENTER key.";
            public const string rule1 = "Congratulations!!!";
            public const string rule2 = "On joining the BrainBattle " +
                "brainstorming program. This brain teaser allows you to " +
                "choose from four question categories.";
            public const string rule3 = "After choosing a " +
                "category, you will start the game, and you will have to " +
                "choose from 4 possible options, which is the correct answer " +
                "to your question.";
        }

        public static class PlayersAndResults
        {
            public static string choosePlayersOrResults = "Choose what you want to see:";
            public static string choosePlayersOrResultsPressed = "You must choose between player list and result list!!! - Or go back to menu.";
            public const string choosePlayers = "P - To see the player list, type 'P' and press ENTER.";
            public const string chooseResults = "R - To see player results, type 'R' and press ENTER.";

        }
    }
}
