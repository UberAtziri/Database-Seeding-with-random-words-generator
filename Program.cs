using System.Security.Cryptography;
using System.Linq;
using System.Text;
using System.IO;
using System;
using System.Collections.Generic;

namespace DbSeed
{
    class Program
    {
        static void Main(string[] args)
        {
            RandomQueryString words = new RandomQueryString();

            using(StreamWriter fs = new StreamWriter("<path to file>"))
            {
                fs.Write(words.GetStringWithRandomQuery("https://random-word-api.herokuapp.com/word?key=<Your api key>>&number=<Number of words needed>", 100));
            }
        }
    }
}
