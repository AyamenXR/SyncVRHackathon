using System;

namespace ChickenFarm
{
    public enum DifficultyType
    {
        LIGHT,
        NORMAL,
        INTENCE
    }

    [System.Serializable]
    public class DifficultyData
    {
        public int numberOfChicks;
        public int numberOfChickens;
        public int feedMaxThrowCount;
        public int collectEggTime;
        public int eggSpawnInterval;
        public DifficultyType difficulty;
    }
}

