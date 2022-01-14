using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChickenFarm
{
    public class FeedManager : MonoBehaviour
    {
        public GameObject feed;
        public GameObject feedParticle;
        public bool isThrown;

        public GameObject rightFeedSpawner;
        public GameObject leftFeedSpawner;
        public GameObject feedStatic;
        public GameObject feedInstructionOne;
        public GameObject feedInstructionTwo;

        public int maxThrowCount;
        private int throwCount;
        private bool feedFinished;
        private bool onFeedingInstruction;

        private GameObject _mainCamera;
        private float throwDirection;
        private GameObject spawnedFeed;
        private AudioSource _audio;

        private GameManager _gameManager;
        private ChickenSpawner _chickenSpawner;

        void Start()
        {
            _audio = GetComponent<AudioSource>();
            throwCount = 0;
            _gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
            _chickenSpawner = GameObject.FindGameObjectWithTag("ChickenSpawner").GetComponent<ChickenSpawner>();
            _mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        }


        void Update()
        {
            throwDirection = _mainCamera.transform.eulerAngles.y;

            //Invoke UE "onFeedingCompleted"
            if (throwCount == maxThrowCount && !feedFinished)
            {
                _gameManager.CompleteFeedAnimal();
                feedFinished = true;
            }
        }

        public void SpawnFeed(string handtype)
        {
            if (throwCount < maxThrowCount)
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
            if (onFeedingInstruction)
            {
                feedInstructionOne.SetActive(false);
                feedInstructionTwo.SetActive(true);
            }
        }

        public void ThrowFeed(string handtype)
        {
            if (throwCount < maxThrowCount)
            {
                Destroy(spawnedFeed);

                //Quaternion spawnQ = Quaternion.Euler(0, _xrCamera.transform.rotation.y, 0);
                //Debug.Log(_xrCamera.transform.rotation.y);
                if (handtype == "RightHand")
                {
                    GameObject _spawnedFeedParticle = Instantiate(feedParticle, rightFeedSpawner.transform.position, Quaternion.Euler(0, throwDirection, 0));
                    _spawnedFeedParticle.transform.SetParent(rightFeedSpawner.transform);
                    Destroy(_spawnedFeedParticle, 2f);
                }
                if (handtype == "LeftHand")
                {
                    GameObject _spawnedFeedParticle = Instantiate(feedParticle, leftFeedSpawner.transform.position, Quaternion.Euler(0, throwDirection, 0));
                    _spawnedFeedParticle.transform.SetParent(leftFeedSpawner.transform);
                    Destroy(_spawnedFeedParticle, 2f);
                }
                isThrown = true;
                throwCount++;
            }
            if (onFeedingInstruction)
            {
                feedInstructionTwo.SetActive(false);
                onFeedingInstruction = false;
            }

        }

        public void ReadyToFeed()
        {
            rightFeedSpawner.SetActive(true);
            leftFeedSpawner.SetActive(true);
            feedStatic.SetActive(true);
            feedInstructionOne.SetActive(true);
            onFeedingInstruction = true;
            StartCoroutine(SpawnChickens());
        }

        public IEnumerator SpawnChickens()
        {
            yield return new WaitForSeconds(0.5f);
            _chickenSpawner.SpawnChicksAndChickens();
        }
        public void FinishFeed()
        {
            feedStatic.SetActive(false);
        }

        public void ResetFeeding()
        {
            throwCount = 0;
            feedFinished = false;
        }
    }
}

