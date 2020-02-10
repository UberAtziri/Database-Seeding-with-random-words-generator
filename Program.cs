using System.Linq;
using System.Text;
using System.IO;
using System;
using System.Collections.Generic;

namespace LearningConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //Here you need type path to file (C:\..)
            string path = @"<Path to your file>";
            List<string> randomWordsList = new List<string>();
            //number of rows need to be seeded
            int numberOfRows = 2000;
            int randPrice = 0;
            int randWord1 = 0;
            int randWord2 = 0;
            int randWord3 = 0;
            int randBool = 0;
            int randVendor = 0;
            
           using(var WebClient = new System.Net.WebClient())
           {
               //Get api key from this site https://random-word-api.herokuapp.com and match target number of words.
               var json = WebClient.DownloadString("https://random-word-api.herokuapp.com/word?key=<YourApiKey>&number=<Numbers of words needed>");
               randomWordsList = json.Split("\", \"").ToList();
               randomWordsList.Remove(randomWordsList[0]);
               randomWordsList.Remove(randomWordsList[randomWordsList.Count()-1]);
           }
            using (StreamWriter fs = File.AppendText(path))
            {

                Random random = new Random();
                StringBuilder seedString = new StringBuilder();
                //Need to be changed demands on your sql query
                seedString.AppendLine("INSERT INTO TOBACCO (Title, [Description], Price, isOnStock)\n (VALUES)");
                string[] Vendors = {"Serbetli", "Al Fakher", "Fumari", "Darkside", "Tungiers", "Al Fahama", "Afzal"};
                for(int i=0; i<numberOfRows;i++)
                {
                    //Need to be changed demands on quantity of random words
                    randWord1 = random.Next(2000);
                    randWord2 = random.Next(2000);
                    randWord3 = random.Next(2000);
                    randPrice = random.Next(1000);
                    randBool = random.Next(2);
                    randVendor = random.Next(7);
                    seedString.AppendLine($"(N'{Vendors[randVendor]} {randomWordsList[randPrice]}', {randPrice}, N'{randomWordsList[randWord1]} {randomWordsList[randWord2]} {randomWordsList[randWord3]} ', {randBool}),");
                }
                seedString.Remove(seedString.Length-3,1);
                fs.WriteLine(seedString);
            }
        }
    }
}
