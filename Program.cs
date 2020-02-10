using System.Xml.Linq;
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
            string path = @"B:\mytest.txt";
            List<string> randomWordsList = new List<string>();
            int numberOfRows = 2000;
            
           using(var WebClient = new System.Net.WebClient())
           {
               //var json = WebClient.DownloadString("https://random-word-api.herokuapp.com/word?key=<YourApiKey>&number=<Numbers of words needed>");
               var json = WebClient.DownloadString("https://random-word-api.herokuapp.com/word?key=48HASETW&number=2003");
               randomWordsList = json.Split("\", \"").ToList();
               randomWordsList.Remove(randomWordsList[0]);
               randomWordsList.Remove(randomWordsList[randomWordsList.Count()-1]);
           }
            using (StreamWriter fs = File.AppendText(path))
            {

                Random random = new Random();
                StringBuilder seedString = new StringBuilder();
                seedString.AppendLine("INSERT INTO TOBACCO (Title, [Description], Price, isOnStock)\n (VALUES)");
                string[] Vendors = {"Serbetli", "Al Fakher", "Fumari", "Darkside", "Tungiers", "Al Fahama", "Afzal"};
                for(int i=0; i<numberOfRows;i++)
                {
                    int randPrice = random.Next(1000);
                    int randWord1 = random.Next(2000);
                    int randWord2 = random.Next(2000);
                    int randWord3 = random.Next(2000);
                    int randBool = random.Next(2);
                    int randVendor = random.Next(7);
                    seedString.AppendLine($"(N'{Vendors[randVendor]} {randomWordsList[randPrice]}', {randPrice}, N'{randomWordsList[randWord1]} {randomWordsList[randWord2]} {randomWordsList[randWord3]} ', {randBool}),");
                }
                seedString.Remove(seedString.Length-3,1);
                fs.WriteLine(seedString);
                System.Console.WriteLine(seedString);
            }
        }
    }
}
