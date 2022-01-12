using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChickenFarm
{
    public class HeartSpawner : MonoBehaviour
    {
        public GameObject heart;

        public void SpawnHeart(GameObject animal)
        {
            Vector3 spawnPos = new Vector3(animal.transform.position.x, 1f, animal.transform.position.z);
            GameObject spawnedHeart = Instantiate(heart, spawnPos, heart.transform.rotation);
            Destroy(spawnedHeart, 1f);
        }
    }
}

