using BrainBattle.UI;
using System.Text;

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

        public static StringBuilder MakeFirstLetterUpperCase(string str)
        {
            string playerNameSubstring1;
            string playerNameSubstring2;
            string playerName = str.Trim();
            string playerSurename;

            StringBuilder playerName3 = new StringBuilder();



            if (playerName.Contains(" "))
            {
                string[] nameSurname = playerName.Split(" ");

                for (int i = 0; i < nameSurname.Length; i++)
                {

                    playerNameSubstring1 = nameSurname[i].Substring(0, 1).ToUpper();
                    playerNameSubstring2 = nameSurname[i].Substring(1, nameSurname[i].Length - 1);
                    playerName3.Append(playerNameSubstring1 + playerNameSubstring2 + " ");
                }

                //playerNameSubstring1 = nameSurname[1].Substring(0, 1).ToUpper();
                //playerNameSubstring2 = nameSurname[1].Substring(1, nameSurname[1].Length - 1);
                //playerSurename = playerNameSubstring1 + playerNameSubstring2;

                //playerName = playerName + " " + playerSurename;
            }
            else if (!String.IsNullOrEmpty(playerName))
            {
                playerNameSubstring1 = playerName.Substring(0, 1).ToUpper();
                playerNameSubstring2 = playerName.Substring(1, playerName.Length - 1);
                playerName3.Append(playerNameSubstring1 + playerNameSubstring2);
            }

            return playerName3;
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
        //}

        public static List<int> RandomIndexFromZeroToFour()
        {
            List<int> randomIndex = new List<int>();
            Random random = new Random();

            for (int i = 0; i < 100; i++)
            {
                randomIndex.Add(random.Next(0, 4));
            }
            randomIndex = randomIndex.ToArray().Distinct().ToList();

            return randomIndex;
        }

        public static string PlayerResultInGameEnd(string currUser)
        {
            Dictionary<string, int> playerResult;
            int count1 = 0;
            int count2 = 0;
            string top = "";
            string star = "";
            string currUserPlaceInTopAndScore = "";

            playerResult = PlayersAndResultsPage.PlayerResults2().OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

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
                if (currUser == item.Key)
                {
                    currUserPlaceInTopAndScore = top
                        + GameProcess.MakeFirstLetterUpperCase(item.Key)
                        + " "
                        + item.Value + star;
                }
            }
            return currUserPlaceInTopAndScore;
        }

        public static Dictionary<string, string> DisplayAllQuestionsAndAnswers(string question, string answer)
        {
            Dictionary<string, string> questionAndAnswersOfOnePlayerForOneGame = new Dictionary<string, string>();

            //if (!String.IsNullOrEmpty(question))
            //{
            questionAndAnswersOfOnePlayerForOneGame.Add(question, answer);
            //}

            return questionAndAnswersOfOnePlayerForOneGame;
        }

    }
}
