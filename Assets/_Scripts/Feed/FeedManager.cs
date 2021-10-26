using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedManager : MonoBehaviour
{
    public GameObject feed;
    public GameObject feedParticle;
    public bool isThrown;

    public GameObject rightFeedSpawner;
    public GameObject leftFeedSpawner;

    public int ThrowAmount;

    private GameObject spawnedFeed;
    private AudioSource _audio;

    void Start()
    {
        _audio = GetComponent<AudioSource>();
    }

    
    void Update()
    {
        
    }

    public void SpawnFeed(string handtype)
    {
        _audio.Play();
        
        if(handtype == "RightHand")
        {
            GameObject _spawnedFeed = Instantiate(feed, rightFeedSpawner.transform.position, transform.rotation);
            _spawnedFeed.transform.SetParent(rightFeedSpawner.transform);
            spawnedFeed = _spawnedFeed;
        }
        if(handtype == "LeftHand")
        {
            GameObject _spawnedFeed = Instantiate(feed, leftFeedSpawner.transform.position, transform.rotation);
            _spawnedFeed.transform.SetParent(leftFeedSpawner.transform);
            spawnedFeed = _spawnedFeed;
        }
        
        isThrown = false;
    }

    public void ThrowFeed(string handtype)
    {
        Destroy(spawnedFeed);

        Quaternion spawnQ = Quaternion.Euler(-20, 0, 0);
        if (handtype == "RightHand")
        {
            GameObject _spawnedFeedParticle = Instantiate(feedParticle, rightFeedSpawner.transform.position, spawnQ);
            _spawnedFeedParticle.transform.SetParent(rightFeedSpawner.transform);
            Destroy(_spawnedFeedParticle, 2f);
        }
        if (handtype == "LeftHand")
        {
            GameObject _spawnedFeedParticle = Instantiate(feedParticle, leftFeedSpawner.transform.position, spawnQ);
            _spawnedFeedParticle.transform.SetParent(leftFeedSpawner.transform);
            Destroy(_spawnedFeedParticle, 2f);
        }
        isThrown = true;
    }



    public void FeedReset()
    {
        //feed.SetActive(false);
        //feedParticle.SetActive(false);
    }
}
