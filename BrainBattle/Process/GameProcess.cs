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
