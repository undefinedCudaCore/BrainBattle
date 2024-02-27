using BrainBattle.Process;

namespace BrainBattle.UI
{
    internal class StartGamePage
    {
        public static Dictionary<string, string> questionAndAnswerData = new Dictionary<string, string>();

        private static ConsoleColor consoleColor;
        private static string goBack;
        private static string chosenCategoryNumber;
        private static string chosenCategory;
        private static bool wrongCategory;
        private static int count1;

        public static void StartTheGame()
        {
            LoginPage.GreetText();
            LoginPage.LoggedPlayerInformation();

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

            chosenCategoryNumber = Console.ReadLine();

            switch (chosenCategoryNumber)
            {
                case "1":
                    chosenCategory = "Mathematics";
                    EnterToGame();
                    break;
                case "2":
                    chosenCategory = "History";
                    EnterToGame();
                    break;
                case "3":
                    chosenCategory = "Wild life";
                    EnterToGame();
                    break;
                case "4":
                    chosenCategory = "Cars";
                    EnterToGame();
                    break;
                default:
                    Console.Clear();
                    wrongCategory = true;
                    StartTheGame();
                    break;
            }
        }

        public static void EnterToGame()
        {
            Dictionary<string, List<string>> showRandomizedDicQuestionsAndAnswers = new Dictionary<string, List<string>>();
            wrongCategory = true;
            count1 = 1;

            Console.Clear();
            LoginPage.GreetText();
            LoginPage.LoggedPlayerInformation();

            if (chosenCategoryNumber == "1")
            {
                showRandomizedDicQuestionsAndAnswers =
                    GameProcess.GetRandomDictionaryValue(GameData.QuestionsAndAnswersByCategory.mathematicsQuestionsAndAnswers);

                GameLogic(showRandomizedDicQuestionsAndAnswers,
                    GameData.QuestionsAndAnswersByCategory.mathematicsQuestionPoints,
                    GameData.GameRules.quitToGameMenu);
            }
            if (chosenCategoryNumber == "2")
            {
                showRandomizedDicQuestionsAndAnswers =
                    GameProcess.GetRandomDictionaryValue(GameData.QuestionsAndAnswersByCategory.historyQuestionsAndAnswers);

                GameLogic(showRandomizedDicQuestionsAndAnswers,
                    GameData.QuestionsAndAnswersByCategory.historyQuestionPoints,
                    GameData.GameRules.quitToGameMenu);
            }
            if (chosenCategoryNumber == "3")
            {
                showRandomizedDicQuestionsAndAnswers =
                    GameProcess.GetRandomDictionaryValue(GameData.QuestionsAndAnswersByCategory.wildLifeQuestionsAndAnswers);

                GameLogic(showRandomizedDicQuestionsAndAnswers,
                    GameData.QuestionsAndAnswersByCategory.wildLifeQuestionPoints,
                    GameData.GameRules.quitToGameMenu);
            }
            if (chosenCategoryNumber == "4")
            {
                showRandomizedDicQuestionsAndAnswers =
                    GameProcess.GetRandomDictionaryValue(GameData.QuestionsAndAnswersByCategory.carsQuestionsAndAnswers);

                GameLogic(showRandomizedDicQuestionsAndAnswers,
                    GameData.QuestionsAndAnswersByCategory.carsQuestionPoints,
                    GameData.GameRules.quitToGameMenu);
            }
        }

        public static int HowManyQuestionsInList()
        {
            int numberOfQuestions = 0;

            if (chosenCategoryNumber == "1")
            {
                numberOfQuestions = GameData.QuestionsAndAnswersByCategory.mathematicsQuestionsAndAnswers.Count;
            }
            if (chosenCategoryNumber == "2")
            {
                numberOfQuestions = GameData.QuestionsAndAnswersByCategory.historyQuestionsAndAnswers.Count;
            }
            if (chosenCategoryNumber == "3")
            {
                numberOfQuestions = GameData.QuestionsAndAnswersByCategory.wildLifeQuestionsAndAnswers.Count;
            }
            if (chosenCategoryNumber == "4")
            {
                numberOfQuestions = GameData.QuestionsAndAnswersByCategory.carsQuestionsAndAnswers.Count;
            }

            return numberOfQuestions;
        }

        public static void GameLogic(Dictionary<string, List<string>> questionsAndAnswers, Dictionary<string, int> questionPoints, string quit)
        {
            List<int> randomIndex;
            Dictionary<string, int> playerPoints;
            string playersTopAndScore = "";

            foreach (var question in questionsAndAnswers)
            {
                Console.Clear();
                LoginPage.GreetText();
                LoginPage.LoggedPlayerInformation();

                //Display question position of all questions and user total score
                string typedAnswer;
                playerPoints = PlayersAndResultsPage.PlayerResults2().OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

                consoleColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), GameProcess.RandomPlayerColor(), true);
                Console.ForegroundColor = consoleColor;

                Console.WriteLine($"Question {count1} of {HowManyQuestionsInList()}".PadLeft(120));
                Console.ResetColor();

                foreach (var player in playerPoints)
                {
                    if (LoginPage.currentUser == player.Key)
                    {
                        Console.WriteLine($"Points: {player.Value}".PadLeft(120));
                    }
                }

                Console.WriteLine();

                count1++;

                //Display question
                Console.WriteLine("To select an answer, type an answer and press ENTER.");
                Console.WriteLine("To discard the two incorrect answers, type 'd' and press ENTER.");
                Console.WriteLine("To get the truly correct type 's', press ENTER.");
                Console.WriteLine();

                Console.Write("Question: ");

                Console.ForegroundColor = consoleColor;
                Console.WriteLine(question.Key);
                Console.ResetColor();

                Console.WriteLine();
                Console.WriteLine("----------------------------------------------".PadLeft(83));

                randomIndex = GameProcess.RandomIndexFromZeroToFour(0);
                for (int i = 0; i < question.Value.Count; i++)
                {
                    Console.Write($" << ");

                    Console.ForegroundColor = consoleColor;
                    Console.Write($"{question.Value[randomIndex[i]]}");
                    Console.ResetColor();

                    Console.Write($" >>");
                }

                Console.WriteLine();
                Console.WriteLine("----------------------------------------------".PadLeft(83));
                Console.WriteLine();

                typedAnswer = Console.ReadLine();
                typedAnswer = typedAnswer.Trim();

                //Get 1 of posible correct answer
                if (!String.IsNullOrEmpty(typedAnswer) && typedAnswer.ToLower() == "s")
                {
                    ShowOneMabyCorrectAnswer(questionsAndAnswers, question.Key);

                    typedAnswer = Console.ReadLine();
                    typedAnswer = typedAnswer.Trim();
                }

                //Get 50/50 answer
                else if (!String.IsNullOrEmpty(typedAnswer) && typedAnswer.ToLower() == "d")
                {
                    ShowFiftyFiftyOfAnswers(questionsAndAnswers, question.Key);

                    typedAnswer = Console.ReadLine();
                    typedAnswer = typedAnswer.Trim();
                }

                //Verify and display selected answer
                if (!String.IsNullOrEmpty(typedAnswer)
                    && GameProcess.MakeFirstLetterUpperCase(typedAnswer)
                    == GameProcess.MakeFirstLetterUpperCase(question.Value[0]))
                {
                    Console.WriteLine($"You chose '{typedAnswer}'. Congratulations, your answer is correct!");

                    if (questionPoints.ContainsKey(question.Key))
                    {

                        LoginPage.playerData[LoginPage.currentUser][chosenCategory].Add(questionPoints[question.Key]);
                    }
                    questionAndAnswerData.Add("Question: " + question.Key, "Answered correctly: " + typedAnswer);
                }
                else
                {
                    Console.WriteLine($"You chose '{GameProcess.MakeFirstLetterUpperCase(typedAnswer)}'. Answer is incorrect! Answer is {question.Value[0]}.");
                    questionAndAnswerData.Add("Question: " + question.Key, "Wrong answer: " + typedAnswer);
                }

                Thread.Sleep(3000);
            }

            //Display all answered questions and answers of it
            Console.Clear();
            LoginPage.GreetText();
            LoginPage.LoggedPlayerInformation();

            foreach (var asweredQuestrionsToDisplay in questionAndAnswerData)
            {

                Console.WriteLine("----------------------------------------------".PadLeft(83));

                Console.ForegroundColor = consoleColor;
                Console.WriteLine(asweredQuestrionsToDisplay.Key);
                Console.WriteLine();
                Console.WriteLine(asweredQuestrionsToDisplay.Value);
                Console.ResetColor();

            }
            Console.WriteLine("----------------------------------------------".PadLeft(83));

            questionAndAnswerData = new Dictionary<string, string>();

            //Display players total score and place in player top
            playersTopAndScore = GameProcess.PlayerResultInGameEnd(LoginPage.currentUser);
            Console.WriteLine(playersTopAndScore.PadLeft(120));

            //Go back to menu
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
                AskToPressQKeyToGoBack(quit);
            }
        }

        public static void AskToPressQKeyToGoBack(string quit)
        {
            LoginPage.GreetText();
            LoginPage.LoggedPlayerInformation();

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
                AskToPressQKeyToGoBack(quit);
            }
        }

        public static void ShowFiftyFiftyOfAnswers(Dictionary<string, List<string>> questionsAndAnswers, string currentQuestion)
        {
            List<int> randomIndex = GameProcess.RandomIndexFromZeroToFour(1);

            Console.WriteLine("-------------------50/50----------------------".PadLeft(83));

            foreach (var question in questionsAndAnswers)
            {
                if (question.Key == currentQuestion)
                {

                    for (int i = 0; i < randomIndex.Count; i++)
                    {
                        Console.Write($"   << ");

                        Console.ForegroundColor = consoleColor;
                        Console.Write($"{question.Value[randomIndex[i]]}");
                        Console.ResetColor();

                        Console.Write($" >>");
                    }
                    Console.WriteLine();
                    break;
                }
            }
            Console.WriteLine("----------------------------------------------".PadLeft(83));
        }

        public static void ShowOneMabyCorrectAnswer(Dictionary<string, List<string>> questionsAndAnswers, string currentQuestion)
        {
            List<int> randomIndex = GameProcess.RandomIndexFromZeroToFour(0);

            Console.WriteLine("----------------Posible answer----------------".PadLeft(83));

            foreach (var question in questionsAndAnswers)
            {
                if (question.Key == currentQuestion)
                {
                    Console.Write($"   << ");

                    Console.ForegroundColor = consoleColor;
                    Console.Write($"{question.Value[randomIndex[2]]}");
                    Console.ResetColor();

                    Console.Write($" >>");
                    Console.WriteLine();
                    break;
                }
            }
            Console.WriteLine("----------------------------------------------".PadLeft(83));
        }
    }
}