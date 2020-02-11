using System.Collections.Generic;
using System.Text;
using System.Linq;


namespace DbSeed
{
    public class RandomQueryString
    {
        private StringBuilder _string = new StringBuilder();
        private RandomNumbers randomNumbers = new RandomNumbers();
        private List<string> randomWordsList = new List<string>();

        public StringBuilder GetStringWithRandomQuery(string UrlPath, int numberOfRows)
        {
            using(var WebClient = new System.Net.WebClient())
           {
                var json = WebClient.DownloadString(UrlPath);
               randomWordsList = json.Split("\", \"").ToList();
               randomWordsList.Remove(randomWordsList[0]);
               randomWordsList.Remove(randomWordsList[randomWordsList.Count()-1]);
           }

            _string.AppendLine("INSERT INTO TOBACCO (Title, [Description], Price, isOnStock)\n (VALUES)");
            string[] Vendors = {"Serbetli", "Al Fakher", "Fumari", "Darkside", "Tungiers", "Al Fahama", "Afzal"};
            for(int i=0; i<numberOfRows;i++)
                {
                List<int> randomNumbersList = randomNumbers.GenerateRandomSeedsList(3, 998);
                 _string.AppendLine($"(N'{Vendors[randomNumbers.GetCrazyAbstractionLvl(7)]} {randomWordsList[randomNumbers.GetRandomPrice(1000)]}', {randomNumbers.GetRandomPrice(1000)}, N'{randomWordsList[randomNumbersList[0]]} {randomWordsList[randomNumbersList[1]]} {randomWordsList[randomNumbersList[2]]} ', {randomNumbers.GetRandomBool()}),");
                }
            _string.Remove(_string.Length-3,1);
            return _string;
        }
    }
}