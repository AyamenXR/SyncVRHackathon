using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChickenFarm
{
    public class FeedThrowTrigger : MonoBehaviour
    {
        private FeedManager _feedManager;

        // Start is called before the first frame update
        void Start()
        {
            _feedManager = GameObject.FindGameObjectWithTag("FeedManager").GetComponent<FeedManager>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!_feedManager.isThrown)
            {
                if (other.gameObject.CompareTag("LeftHand") || other.gameObject.CompareTag("RightHand"))
                {
                    _feedManager.ThrowFeed(other.gameObject.tag);
                }
            }
        }
    }
}

