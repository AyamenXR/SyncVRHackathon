using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChickenFarm
{
    public class AnimalTrigger : MonoBehaviour
    {
        private SortingManager _sortingManager;
        public bool isSorted;

        private void Start()
        {
            _sortingManager = GameObject.FindGameObjectWithTag("SortingManager").GetComponent<SortingManager>();
            isSorted = false;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (GameManager.eGameStatus == GameManager.GameState.Sorting)
            {
                if (!_sortingManager.isHolding && !isSorted)
                {
                    if (other.gameObject.CompareTag("LeftHand") || other.gameObject.CompareTag("RightHand"))
                    {
                        _sortingManager.HoldAnimal(other.gameObject.tag, this.gameObject);
                    }
                }
            }
            //else
            //{
            //    Debug.Log("not in sorting");
            //}
        }
    }
}

