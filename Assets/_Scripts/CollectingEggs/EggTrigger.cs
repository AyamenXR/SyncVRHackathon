using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChickenFarm {
    public class EggTrigger : MonoBehaviour
    {
        private EggCollectionManager _eggCollectionManager;
        public bool isCollected;

        // Start is called before the first frame update
        void Start()
        {
            _eggCollectionManager = GameObject.FindGameObjectWithTag("EggCollectionManager").GetComponent<EggCollectionManager>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!_eggCollectionManager.isHolding && !isCollected)
            {
                if (other.gameObject.CompareTag("LeftHand") || other.gameObject.CompareTag("RightHand"))
                {
                    _eggCollectionManager.HoldEgg(other.gameObject.tag, this.gameObject);
                }

            }
        }
    }

}
