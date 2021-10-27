using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortingManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _chicks;
    [SerializeField]
    private GameObject[] _chickens;

    //gizmo
    public Vector3 tableSize;

    void Start()
    {
        _chicks = GameObject.FindGameObjectsWithTag("Chick");
        _chickens = GameObject.FindGameObjectsWithTag("Chicken");
        MoveAnimalOnTable();
    }

    void Update()
    {
 
    }

    private void MoveAnimalOnTable()
    {
        foreach (GameObject chicks in _chicks)
        {
            //randomly generate animal position
            Vector3 movePos = transform.position + new Vector3(Random.Range(-tableSize.x / 2, tableSize.x / 2),
                                                    0,
                                                    Random.Range(-tableSize.z / 2, tableSize.z / 2));
            chicks.transform.position = movePos;
        }

        foreach (GameObject chicken in _chickens)
        {
            //randomly generate animal position
            Vector3 movePos = transform.position + new Vector3(Random.Range(-tableSize.x / 2, tableSize.x / 2),
                                                    0,
                                                    Random.Range(-tableSize.z / 2, tableSize.z / 2));
            chicken.transform.position = movePos;
        }
    }

#if UNITY_EDITOR

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(0, 1, 0, 0.5f);
        Gizmos.DrawCube(transform.position, tableSize);
    }
#endif
}
