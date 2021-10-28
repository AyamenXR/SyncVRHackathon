using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalTrigger : MonoBehaviour
{
    //private GameManager _gameManager;
    private SortingManager _sortingManager;
    public bool isSorted;

    private void Start()
    {
        _sortingManager = GameObject.FindGameObjectWithTag("SortingManager").GetComponent<SortingManager>();
        //_gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();

    }

    public void Test()
    {
        if (GameManager.eGameStatus == GameManager.GameState.Feeding)
        {

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(GameManager.eGameStatus == GameManager.GameState.Feeding)
        {
            if (!_sortingManager.isHolding && !isSorted)
            {
                if (other.gameObject.CompareTag("LeftHand") || other.gameObject.CompareTag("RightHand"))
                {
                    _sortingManager.HoldAnimal(other.gameObject.tag, this.gameObject);
                }

            }
        }
        else
        {
            Debug.Log("not in sorting");
        }



    }
}
