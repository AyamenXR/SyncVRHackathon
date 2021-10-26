using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleCollision : MonoBehaviour
{
    public HeartSpawner heartSpawner;
    //public int feedCount;
    
    void Start()
    {
        //feedCount = 0;
    }

    private void Update()
    {
        //Debug.Log(feedCount);
    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.gameObject.CompareTag("Chick") || other.gameObject.CompareTag("Chicken"))
        {
                other.gameObject.GetComponent<Animator>().SetTrigger("Eat");
                heartSpawner.SpawnHeart(other);

                //Count++;
                GameManager.FeedAnimal();
        }

    }

    //public int Count
    //{
    //    get { return feedCount; }
    //    private set { feedCount = value; }
    //}
}
