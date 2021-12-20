using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortingManager : MonoBehaviour
{
    public GameObject sortingStatic;
    public GameObject rightHoldPos;
    public GameObject leftHoldPos;
    public bool isHolding;
    public bool isCompleted;

    private GameManager _gameManager;
    private ChickenSpawner _chickenSpawner;
    public int sortedAnimalCount;
    private int _animalCount;
    public float releaseTime = 0.5f;

    private AudioSource _grabAudio;

    //gizmo, walkable area
    public Vector3 tableSize;
    //private Vector3 animalPos;

    public GameObject[] chicks;
    public GameObject[] chickens;

    void Start()
    {
        chicks = GameObject.FindGameObjectsWithTag("Chick");
        chickens = GameObject.FindGameObjectsWithTag("Chicken");
        _grabAudio = GetComponent<AudioSource>();

        _gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        _chickenSpawner = GameObject.FindGameObjectWithTag("ChickenSpawner").GetComponent<ChickenSpawner>();
        _animalCount = _chickenSpawner.numberOfChickens + _chickenSpawner.numberOfChicks;

    }
    private void Update()
    {
        if(sortedAnimalCount == _animalCount && !isCompleted) {
            _gameManager.CompleteSorting();
            isCompleted = true;
        }
    }

    public void ReadyToSort()
    {
        rightHoldPos.SetActive(true);
        leftHoldPos.SetActive(true);
        sortingStatic.SetActive(true);

        sortedAnimalCount = 0;

        //AvoidWalkAbove();
    }

    public void FinishSorting()
    {
        sortingStatic.SetActive(false);
    }

    //Move animal on the table
    public void MoveAnimalOnTable()
    {
        foreach (GameObject chick in chicks)
        {
            //randomly generate animal position
            Vector3 movePos = transform.position + new Vector3(Random.Range(-tableSize.x / 2, tableSize.x / 2),
                                                    0,
                                                    Random.Range(-tableSize.z / 2, tableSize.z / 2));
            chick.transform.position = movePos;
            Debug.Log("Chick hold");
        }

        foreach (GameObject chicken in chickens)
        {
            //randomly generate animal position
            Vector3 movePos = transform.position + new Vector3(Random.Range(-tableSize.x / 2, tableSize.x / 2),
                                                    0,
                                                    Random.Range(-tableSize.z / 2, tableSize.z / 2));
            chicken.transform.position = movePos;
            Debug.Log("Chicken hold");
        }
    }

    //Hold animal
    public void HoldAnimal(string handtype, GameObject animal)
    {
        if (handtype == "RightHand")
        {
            animal.transform.SetParent(rightHoldPos.transform);
            animal.layer = LayerMask.NameToLayer("GrabbedAnimal");
            FreezePosition(animal);
        }
        if (handtype == "LeftHand")
        {
            animal.transform.SetParent(leftHoldPos.transform);
            animal.layer = LayerMask.NameToLayer("GrabbedAnimal");
            FreezePosition(animal);
        }

        animal.GetComponent<AnimalController>().StopWalking();
        isHolding = true;
        _grabAudio.Play();
    }

    private void FreezePosition(GameObject animal)
    {
        var rb = animal.GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeAll;
    }


    public void ReleaseAnimal(GameObject animal)
    {
        isHolding = false;
        StartCoroutine(Release(animal)) ;
        FreezeXZ(animal);
        sortedAnimalCount++;
        //rightHandPrefab.SetActive(true);
        //leftHandPrefab.SetActive(true);

    }

    private IEnumerator Release(GameObject animal)
    {
        yield return new WaitForSeconds(releaseTime);
        animal.transform.parent = null;

        if (animal.tag == "Chicken")
        {
            animal.layer = LayerMask.NameToLayer("Chicken");
        }

        if (animal.tag == "Chick")
        {
            animal.layer = LayerMask.NameToLayer("Chick");
        }
    }

    private void FreezeXZ(GameObject animal)
    {
        var rb = animal.GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ ;
    }

    public void DestroyAnimals()
    {
        foreach (GameObject chick in chicks)
        {
            Destroy(chick);
        }
        foreach (GameObject chicken in chickens)
        {
            Destroy(chicken);
        }
    }

    public void ResetSorting()
    {
        sortedAnimalCount = 0;
    }


    //private void AvoidWalkAbove()
    //{
    //    foreach (GameObject chick in _chicks)
    //    {
    //        var rb = chick.GetComponent<Rigidbody>();
    //        rb.constraints = RigidbodyConstraints.FreezePositionY;
    //        Debug.Log("chick y freezed");
    //    }
    //    foreach (GameObject chicken in _chickens)
    //    {
    //        var rb = chicken.GetComponent<Rigidbody>();
    //        rb.constraints = RigidbodyConstraints.FreezePositionY;
    //        Debug.Log("chicken y freezed");
    //    }
    //}

    //private void LimitWalkableArea(GameObject animal)
    //{
    //    animalPos = animal.transform.position;
    //    animalPos.x = Mathf.Clamp(animalPos.x, -tableSize.x / 2, tableSize.x / 2);
    //    animalPos.z = Mathf.Clamp(animalPos.z, -tableSize.z / 2, tableSize.z / 2);
    //}

#if UNITY_EDITOR

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(0, 1, 0, 0.5f);
        Gizmos.DrawCube(transform.position, tableSize);
    }
#endif
}
