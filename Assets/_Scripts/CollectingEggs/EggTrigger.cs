using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        //if (GameManager.eGameStatus == GameManager.GameState.EggCollection)
        //{
            if (!_eggCollectionManager.isHolding && !isCollected)
            {
                if (other.gameObject.CompareTag("LeftHand") || other.gameObject.CompareTag("RightHand"))
                {
                    _eggCollectionManager.HoldEgg(other.gameObject.tag, this.gameObject);
                }

            }
        //}
        else
        {
            Debug.Log("not in eggcollection");
        }
    }
}
