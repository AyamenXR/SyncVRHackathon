using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartSpawner : MonoBehaviour
{
    public GameObject heart;

    //private Vector3 pos = new Vector3(0.34f, 1f, 0.29f);

    private void Start()
    {
        
        //Instantiate(heart, pos, heart.transform.rotation);
    }

    public void SpawnHeart(GameObject animal)
    {
        Vector3 spawnPos = new Vector3(animal.transform.position.x, 1f, animal.transform.position.z);
        GameObject spawnedHeart = Instantiate(heart, spawnPos, heart.transform.rotation);
        Destroy(spawnedHeart, 1f);
    }
}
