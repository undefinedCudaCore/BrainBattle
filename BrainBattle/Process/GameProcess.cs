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
            string playerName = "";
            string playerSurename;

            if (str.Contains(" "))
            {
                string[] nameSurname = str.Split(" ");

                for (int i = 0; i < nameSurname.Length; i++)
                {

                    playerNameSubstring1 = nameSurname[i].Substring(0, 1).ToUpper();
                    playerNameSubstring2 = nameSurname[i].Substring(1, nameSurname[i].Length - 1);
                    playerName += playerNameSubstring1 + playerNameSubstring2 + " ";
                }
            }
            else if (!String.IsNullOrEmpty(str))
            {
                playerNameSubstring1 = str.Substring(0, 1).ToUpper();
                playerNameSubstring2 = str.Substring(1, str.Length - 1);
                playerName = playerNameSubstring1 + playerNameSubstring2;
            }
            playerName = playerName.Trim();

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

            return color;
        }

        public static List<int> RandomIndexFromZeroToFour(int index)
        {
            List<int> randomIndex = new List<int>();
            Random random = new Random();

            //To get random nubers lis from 0 to 4 - length 4__index needed 0
            if (index == 0)
            {
                for (int i = 0; i < 100; i++)
                {
                    randomIndex.Add(random.Next(index, 4));
                }
                randomIndex = randomIndex.ToArray().Distinct().ToList();
            }

            //To get random nubers lis from 0 (0 const) to 4 - length 2__index needed 1
            if (index == 1)
            {
                randomIndex.Add(0);
                randomIndex.Add(random.Next(1, 4));

                randomIndex = randomIndex.ToArray().Distinct().ToList();
            }

            //To get random nubers lis from 0 to 8 - length 8__index needed 2
            if (index == 2)
            {
                for (int i = 0; i < 100; i++)
                {
                    randomIndex.Add(random.Next(0, 8));
                }
                randomIndex = randomIndex.ToArray().Distinct().ToList();
            }

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

        public static Dictionary<string, List<string>> GetRandomDictionaryValue(Dictionary<string, List<string>> questionsAndAnswersForRandomize)
        {
            Dictionary<string, List<string>> randomizedDicQuestionsAndAnswers = new Dictionary<string, List<string>>();
            Random rand = new Random();

            randomizedDicQuestionsAndAnswers = questionsAndAnswersForRandomize.OrderBy(x => rand.Next()).ToDictionary(item => item.Key, item => item.Value);

            return randomizedDicQuestionsAndAnswers;
        }
    }
}
