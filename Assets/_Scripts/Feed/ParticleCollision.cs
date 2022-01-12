using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChickenFarm
{
    public class ParticleCollision : MonoBehaviour
    {
        private HeartSpawner heartSpawner;

        void Start()
        {
            heartSpawner = GameObject.FindGameObjectWithTag("HeartSpawner").GetComponent<HeartSpawner>();
        }

        private void OnParticleCollision(GameObject other)
        {
            if (other.gameObject.CompareTag("Chick") || other.gameObject.CompareTag("Chicken"))
            {
                other.gameObject.GetComponent<Animator>().SetTrigger("Eat");
                heartSpawner.SpawnHeart(other);
                GameManager.FeedAnimal();
            }

        }
    }
}

