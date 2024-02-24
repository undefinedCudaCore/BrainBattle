using BrainBattle.UI;

namespace BrainBattle.Process
{
    internal static class GameProcess
    {
        public static Dictionary<string, Dictionary<string, List<int>>> userData;
        public static void RunGame()
        {
            bool isNull;

            LoginPage.Greeting(false);

            userData = LoginPage.AddLoginToList(out isNull);

            while (isNull)
            {
                userData = LoginPage.AddLoginToList(out isNull);
            }
        }

        public static string MakeFirstLetterUpperCase(string str)
        {
            string playerNameSubstring1;
            string playerNameSubstring2;
            string playerName;
            string playerSurename;

            if (str.Contains(" "))
            {
                string[] nameSurname = str.Split(" ");

                playerNameSubstring1 = nameSurname[0].Substring(0, 1).ToUpper();
                playerNameSubstring2 = nameSurname[0].Substring(1, nameSurname[0].Length - 1);
                playerName = playerNameSubstring1 + playerNameSubstring2;

                playerNameSubstring1 = nameSurname[1].Substring(0, 1).ToUpper();
                playerNameSubstring2 = nameSurname[1].Substring(1, nameSurname[1].Length - 1);
                playerSurename = playerNameSubstring1 + playerNameSubstring2;

                playerName = playerName + " " + playerSurename;
            }
            else
            {
                playerNameSubstring1 = str.Substring(0, 1).ToUpper();
                playerNameSubstring2 = str.Substring(1, str.Length - 1);
                playerName = playerNameSubstring1 + playerNameSubstring2;
            }

            return playerName;
        }

        internal static string RandomPlayerColor()
        {
            Random random = new Random();
            int randomColorIndex;
            string color = "";
            string[] randomColorList = new string[] {
                "Blue",
                "Cyan",
                "DarkBlue",
                "DarkCyan",
                "DarkGray",
                "DarkGreen",
                "DarkMagenta",
                "DarkRed",
                "Green",
                "Red",
                "White",
                "Yellow"
            };

            randomColorIndex = random.Next(0, 12);
            color = randomColorList[randomColorIndex];

            //Console.ForegroundColor
            //= ConsoleColor.Red;
            return color;
        }
        //public static void SetLoginValues(string setuSerName, bool setLoggedIn)
        //{
        //    LoginPage.loggedUser = setuSerName;
        //    LoginPage.loggedin = setLoggedIn;
        //}

        //public static void ResetLoginValues(string retuSerName, bool retLoggedIn)
        //{
        //    LoginPage.loggedUser = retuSerName;
        //    LoginPage.loggedin = retLoggedIn;
    }
}
