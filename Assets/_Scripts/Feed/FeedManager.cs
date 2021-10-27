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
    public GameObject feedSacks;
    public GameObject FeedThrowTrigger;

    public int maxThrowCount;
    private int throwCount;
    private bool feedFinished;

    private GameObject spawnedFeed;
    private AudioSource _audio;

    private GameManager _gameManager;

    void Start()
    {
        _audio = GetComponent<AudioSource>();
        throwCount = 0;
        _gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    
    void Update()
    {
        //Invoke UE "onFeedingCompleted"
        if (throwCount == maxThrowCount && !feedFinished)
        {
            _gameManager.CompleteFeedAnimal();
            feedFinished = true;
        }   
    }

    public void SpawnFeed(string handtype)
    {
        if(throwCount < maxThrowCount)
        {
            _audio.Play();

            if (handtype == "RightHand")
            {
                GameObject _spawnedFeed = Instantiate(feed, rightFeedSpawner.transform.position, transform.rotation);
                _spawnedFeed.transform.SetParent(rightFeedSpawner.transform);
                spawnedFeed = _spawnedFeed;
            }
            if (handtype == "LeftHand")
            {
                GameObject _spawnedFeed = Instantiate(feed, leftFeedSpawner.transform.position, transform.rotation);
                _spawnedFeed.transform.SetParent(leftFeedSpawner.transform);
                spawnedFeed = _spawnedFeed;
            }

            isThrown = false;
        }


    }

    public void ThrowFeed(string handtype)
    {
        if (throwCount < maxThrowCount)
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
            throwCount++;
        }

    }

    public void ReadyToFeed()
    {
        rightFeedSpawner.SetActive(true);
        leftFeedSpawner.SetActive(true);
        feedSacks.SetActive(true);
        FeedThrowTrigger.SetActive(true);
    }
    public void FinishFeed()
    {
        rightFeedSpawner.SetActive(false);
        leftFeedSpawner.SetActive(false);
        feedSacks.SetActive(false);
        FeedThrowTrigger.SetActive(false);
    }
}
