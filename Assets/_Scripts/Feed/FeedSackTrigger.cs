using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChickenFarm
{
    public class FeedSackTrigger : MonoBehaviour
    {
        private FeedManager _feedManager;

        // Start is called before the first frame update
        void Start()
        {
            _feedManager = GameObject.FindGameObjectWithTag("FeedManager").GetComponent<FeedManager>();
            _feedManager.isThrown = true;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (_feedManager.isThrown)
            {
                if (other.gameObject.CompareTag("LeftHand") || other.gameObject.CompareTag("RightHand"))
                {
                    _feedManager.SpawnFeed(other.gameObject.tag);
                }
            }
        }
    }
}

