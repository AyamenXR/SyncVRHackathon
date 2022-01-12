using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChickenFarm
{
    public class ChickenSpawner : MonoBehaviour
    {
        public GameObject chick;
        public GameObject chicken;

        //number of animals to spawn
        [Range(0, 50)]
        public int numberOfChicks;
        [Range(0, 50)]
        public int numberOfChickens;

        //put spawned animals under parent
        public Transform chickParent;
        public Transform chickenParent;

        //gizmo
        public Vector3 size;


        public void SpawnChicksAndChickens()
        {
            SpawnAnimals(numberOfChicks, chick, chickParent);
            SpawnAnimals(numberOfChickens, chicken, chickenParent);
        }

        private void SpawnAnimals(int numberOfAnimals, GameObject animal, Transform parent)
        {
            for (int i = 0; i < numberOfAnimals; i++)
            {
                //randomly generate animal spawn position
                Vector3 spawnPos = transform.position + new Vector3(Random.Range(-size.x / 2, size.x / 2),
                                                        0,
                                                        Random.Range(-size.z / 2, size.z / 2));

                //random rotation
                float num = Random.Range(-180f, 180f);
                Quaternion randomQ = Quaternion.Euler(0, num, 0);

                GameObject spawnedAnimal = Instantiate(animal, spawnPos, randomQ);

                //put spawnedAnimal under parent
                spawnedAnimal.transform.SetParent(parent);
            }
        }

#if UNITY_EDITOR
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = new Color(0, 1, 0, 0.5f);
            Gizmos.DrawCube(transform.position, size);
        }
#endif
    }
}

