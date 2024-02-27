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

        internal static class QuestionsAndAnswersByCategory
        {
            internal static Dictionary<string, List<string>> mathematicsQuestionsAndAnswers = new Dictionary<string, List<string>>
            {
                { "What is the highest common factor of the numbers 30 and 132", new List<string>() { "6", "3", "7", "9" } },
                { "123+4-5+67-89 = ?", new List<string>() { "100", "105", "101", "99" } },
                { "From the number 0 to the number 1000, the letter “A” appears only in?",  new List<string>() { "1000", "3000", "100", "1050" }},
                { "If 1=3, 2=3, 3=5, 4=4, and 5=4, what is 6=?", new List<string>() { "3", "-3", "6", "9" } },
                { "Which number is the equivalent to 3^(4)/3^(2)?", new List<string>() { "9", "-3", "6", "3" } },
                { "What is next in the following number series: 256, 289, 324, 361 . . . ?", new List<string>() { "400", "200", "800", "600" } },
                { "At a Christmas party, everyone shook hands with everyone else. There were a " +
                    "total of 66 handshakes that happened during the party. How many people were present?", new List<string>() { "12", "16", "20", "9" } },
                { "How many vertices are present on a cube?", new List<string>() { "8", "6", "10", "14" } }
            };

            internal static Dictionary<string, int> mathematicsQuestionPoints = new Dictionary<string, int>
            {
                { "What is the highest common factor of the numbers 30 and 132", 7 },
                { "123+4-5+67-89 = ?", 8 },
                { "From the number 0 to the number 1000, the letter “A” appears only in?",  20},
                { "If 1=3, 2=3, 3=5, 4=4, and 5=4, what is 6=?", 13 },
                { "Which number is the equivalent to 3^(4)/3^(2)?", 2 },
                { "What is next in the following number series: 256, 289, 324, 361 . . . ?", 23 },
                { "At a Christmas party, everyone shook hands with everyone else. There were a " +
                    "total of 66 handshakes that happened during the party. How many people were present?", 5 },
                { "How many vertices are present on a cube?", 18 }
            };

            internal static Dictionary<string, List<string>> historyQuestionsAndAnswers = new Dictionary<string, List<string>>
            {
                { "The United States bought Alaska from which country?", new List<string>() { "Russia", "Mexico", "China", "Italy" } },
                { "Who was the fourth president of the United States?", new List<string>() { "James Madison", "Bill Gates", "Barack Obama", "Osama bin Laden" } },
                { "Fill in the blank: The 19th Amendment guarantees ____ the right to vote", new List<string>() { "Woman", "Man", "Yeti", "Alien" } },
                { "Which year was George H.W. Bush elected president?", new List<string>() { "1988", "1989", "1995", "2001" } },
                { "What country did the U.S. men’s Olympic hockey team defeat in the semi-finals of the 1980 Winter Olympics in Lake Placid, a game commonly known as the “Miracle on Ice”?", new List<string>() { "The Soviet Union", "USA", "China", "Spain" } },
                { "When did the construction of the Great Wall of China begin?", new List<string>() { "1569", "1455", "1820", "1312" } },
                { "Where did Albert Einstein live before moving to the United States?", new List<string>() { "Germany", "Poland", "Netherlands", "France" } },
                { "How old was Queen Elizabeth II when she was crowned the Queen of England?", new List<string>() { "27", "26", "28", "25" } }
            };

            internal static Dictionary<string, int> historyQuestionPoints = new Dictionary<string, int>
            {
                { "The United States bought Alaska from which country?", 7 },
                { "Who was the fourth president of the United States?", 8 },
                { "Fill in the blank: The 19th Amendment guarantees ____ the right to vote", 20 },
                { "Which year was George H.W. Bush elected president?", 13 },
                { "What country did the U.S. men’s Olympic hockey team defeat in the semi-finals of the 1980 Winter Olympics in Lake Placid, a game commonly known as the “Miracle on Ice”?", 2 },
                { "When did the construction of the Great Wall of China begin?", 23 },
                { "Where did Albert Einstein live before moving to the United States?", 5 },
                { "How old was Queen Elizabeth II when she was crowned the Queen of England?", 18 }
            };

            internal static Dictionary<string, List<string>> wildLifeQuestionsAndAnswers = new Dictionary<string, List<string>>
            {
                { "What is the world’s smallest mammal?", new List<string>() { "Etruscan shrew", "Cheetah", "Kangaroo", "Bear" } },
                { "What is the world’s largest mammal?", new List<string>() { "Antarctic blue whale", "Elephant", "Kookaburra", "Unicorn" } },
                { "How many legs does a spider typically have?", new List<string>() { "8", "10", "6", "7" } },
                { "Which bird is known for its beautiful tail feathers and courtship dance?", new List<string>() { "Peacock", "Butterfly", "Chickens", "Owl" } },
                { "What is the national bird of the United States?", new List<string>() { "Bald eagle", "Lyrebird", "Arctic tern", "Owl" } },
                { "Which marine creature has the nickname “sea cow”?", new List<string>() { "Manatee", "Sloth", "Clownfish", "Pangolin" } },
                { "What is the fastest land animal?", new List<string>() { "Cheetah", "Tiger", "Lion", "Antilope" } },
                { "What is the tallest bird in the world?", new List<string>() { "Ostrich", "Hummingbird", "Giraffe", "Bald eagle" } }
            };

            internal static Dictionary<string, int> wildLifeQuestionPoints = new Dictionary<string, int>
            {
                { "What is the world’s smallest mammal?", 7 },
                { "What is the world’s largest mammal?", 8 },
                { "How many legs does a spider typically have?", 20 },
                { "Which bird is known for its beautiful tail feathers and courtship dance?", 13 },
                { "What is the national bird of the United States?", 2 },
                { "Which marine creature has the nickname “sea cow”?", 23 },
                { "What is the fastest land animal?", 5 },
                { "What is the tallest bird in the world?", 18 }
            };

            internal static Dictionary<string, List<string>> carsQuestionsAndAnswers = new Dictionary<string, List<string>>
            {
                { "What is the nickname of retired professional golfer Jack Nicklaus? Its origin goes back to the mascot of his high school in Upper Arlington, Ohio and it is incorporated into his brand's logo.", new List<string>() { "The Golden Bear", "The Silver Mustang", "The Golden Ostrich", "The Silver Eagle" } },
                { "First manufactured in 1982, what was the first American-produced Japanese car? The vehicle rolled off the assembly line at the Marysville Auto Plant in Ohio and became the best-selling Japanese car in the United States for 15 straight years.", new List<string>() { "Honda Accord", "Toyota Sienna", "Nissan Rouge", "Nissan Quest" } },
                { "According to Motoring Research, what car series was the most popular in the world with over one million new registrations in 2018? Second place was the Toyota Corolla and third place was the Honda Civic.", new List<string>() { "Ford F-Series", "Mazda 3-series", "Toyota Corolla", "Nissan 350z" } },
                { "What internationally-recognized car brand, commissioned in 1934 by the country's notorious leader, translates in English to 'People's car?'", new List<string>() { "Volkswagen", "Skoda", "Seat", "BMW" } },
                { "The Sentra, Altima, and Pathfinder are all car models made by what maker?", new List<string>() { "Nissan", "Toyota", "Mitsubishi", "Honda" } },
                { "Described on its own website as \"Trucker's Disneyland,\" the \"World's Largest Truckstop\" includes eight restaurants, a chiropractor, and a barbershop. The complex is located off of I-80 near Walcott in what state?", new List<string>() { "Iowa", "Texas", "California", "Alabama" } },
                { "The Accent, Santa Fe, and Palisade are all car models manufactured by what international automotive company?", new List<string>() { "Hyundai", "Honda", "Kia", "Toyota" } },
                { "Spanning more than 1,800 miles, the World Solar Challenge is an every-other-year car race for solar-powered vehicles across what country?", new List<string>() { "Australia", "France", "Denmark", "Poland" } }
            };

            internal static Dictionary<string, int> carsQuestionPoints = new Dictionary<string, int>
            {
                { "What is the nickname of retired professional golfer Jack Nicklaus? Its origin goes back to the mascot of his high school in Upper Arlington, Ohio and it is incorporated into his brand's logo.", 7 },
                { "First manufactured in 1982, what was the first American-produced Japanese car? The vehicle rolled off the assembly line at the Marysville Auto Plant in Ohio and became the best-selling Japanese car in the United States for 15 straight years.", 8 },
                { "According to Motoring Research, what car series was the most popular in the world with over one million new registrations in 2018? Second place was the Toyota Corolla and third place was the Honda Civic.", 20 },
                { "What internationally-recognized car brand, commissioned in 1934 by the country's notorious leader, translates in English to 'People's car?'", 13 },
                { "The Sentra, Altima, and Pathfinder are all car models made by what maker?", 2 },
                { "Described on its own website as \"Trucker's Disneyland,\" the \"World's Largest Truckstop\" includes eight restaurants, a chiropractor, and a barbershop. The complex is located off of I-80 near Walcott in what state?", 23 },
                { "The Accent, Santa Fe, and Palisade are all car models manufactured by what international automotive company?", 5 },
                { "Spanning more than 1,800 miles, the World Solar Challenge is an every-other-year car race for solar-powered vehicles across what country?", 18 }
            };
        }
    }
}
