using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleCollision : MonoBehaviour
{
    //public int count;
    private GameObject chick;
    private GameObject chicken;

    
    void Start()
    {
        //count = 0;
    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.gameObject.CompareTag("Chick") || other.gameObject.CompareTag("Chicken"))
        {
            if (!other.gameObject.GetComponent<Animator>().GetBool("Walk"))
            {
                other.gameObject.GetComponent<Animator>().SetBool("Eat", true);

            }
        }

        //Count++;
        //Destroy(this.gameObject);
    }

    //public int Count
    //{
    //    get { return count; }
    //    private set { count = value; }
    //}
}
