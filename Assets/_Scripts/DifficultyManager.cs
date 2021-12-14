using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChickenFarm
{
    public class DifficultyManager : MonoBehaviour
    {
        public DifficultyData[] difficultyData;
        public string mode;
        private ChickenSpawner chickenSpawner;
        private FeedManager feedManager;
        private EggCollectionManager eggCollectionManager;

        private void Start()
        {
            chickenSpawner = GameObject.FindGameObjectWithTag("ChickenSpawner").GetComponent<ChickenSpawner>();
            feedManager = GameObject.FindGameObjectWithTag("FeedManager").GetComponent<FeedManager>();
            eggCollectionManager = GameObject.FindGameObjectWithTag("EggCollectionManager").GetComponent<EggCollectionManager>();
            Debug.Log(chickenSpawner.numberOfChicks);
        }
        public void SetLightDifficulty()
        {
            chickenSpawner.numberOfChicks = difficultyData[0].numberOfChicks;
            chickenSpawner.numberOfChickens = difficultyData[0].numberOfChickens;
            feedManager.maxThrowCount = difficultyData[0].feedMaxThrowCount;
            eggCollectionManager.remainCollectTime = difficultyData[0].collectEggTime;
            eggCollectionManager.eggInterval = difficultyData[0].eggSpawnInterval;
            mode = difficultyData[0].difficulty.ToString();
            Debug.Log(mode);
        }

        public void SetNormalDifficulty()
        {
            chickenSpawner.numberOfChicks = difficultyData[1].numberOfChicks;
            chickenSpawner.numberOfChickens = difficultyData[1].numberOfChickens;
            feedManager.maxThrowCount = difficultyData[1].feedMaxThrowCount;
            eggCollectionManager.remainCollectTime = difficultyData[1].collectEggTime;
            eggCollectionManager.eggInterval = difficultyData[1].eggSpawnInterval;
            mode = difficultyData[1].difficulty.ToString();
            Debug.Log(mode);
        }
        public void SetIntenceDifficulty()
        {
            chickenSpawner.numberOfChicks = difficultyData[2].numberOfChicks;
            chickenSpawner.numberOfChickens = difficultyData[2].numberOfChickens;
            feedManager.maxThrowCount = difficultyData[2].feedMaxThrowCount;
            eggCollectionManager.remainCollectTime = difficultyData[2].collectEggTime;
            eggCollectionManager.eggInterval = difficultyData[2].eggSpawnInterval;
            mode = difficultyData[2].difficulty.ToString();
            Debug.Log(mode);
        }
    }
}

