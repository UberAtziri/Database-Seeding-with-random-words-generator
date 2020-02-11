using System;
using System.Collections.Generic;

namespace DbSeed
{
    public class RandomNumbers
    {
        Random _random = new Random();
        private List<int> _ListOfRandomWordsSeed;
        public List<int> GenerateRandomSeedsList(int quantity, int maxRandomNext)
        {
            _ListOfRandomWordsSeed = new List<int>();
            for(int i = 0; i<quantity;i++)
            {
                _ListOfRandomWordsSeed.Add(_random.Next(maxRandomNext));
            }
            return _ListOfRandomWordsSeed;
        }
        public int GetRandomPrice(int maxRandomValue)
        {
            return _random.Next(maxRandomValue);
        }
        public int GetRandomBool()
        {
            return _random.Next(2);
        }
        public int GetCrazyAbstractionLvl(int value)
        {
            return _random.Next(value);
        }
    }
}