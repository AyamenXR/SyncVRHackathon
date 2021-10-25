using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedAnimal : MonoBehaviour
{
    //private ParticleCollision _particleCollision;
    
    void Start()
    {
       // _particleCollision = GameObject.FindGameObjectWithTag("FeedParticle").GetComponent<ParticleCollision>();
    }

    public void FinishEating()
    {
        GetComponent<Animator>().SetBool("Eat", false);
    }
}
