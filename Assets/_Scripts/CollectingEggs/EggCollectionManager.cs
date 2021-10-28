using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggCollectionManager : MonoBehaviour
{
    public GameObject rightHoldPos;
    public GameObject leftHoldPos;

    public GameObject chicken;
    [Range(0, 50)]
    //public int numberOfChickens = 3;
    //public Transform chickenParent;
    private GameObject spawnedChicken;

    public GameObject egg;
    public float eggInterval;
    public Transform eggParent;
    public int collectedEggCount;

    public bool isHolding;
    public float releaseTime = 0.5f;

    private GameManager _gameManager;
    private AudioSource _grabAudio;

    public Vector3 tableSize;

    void Start()
    {
        _gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        _grabAudio = GetComponent<AudioSource>();
        collectedEggCount = 0;
    }

    public void ReadyToCollect()
    {
        StartCoroutine(SpawnLate());
        rightHoldPos.SetActive(true);
        leftHoldPos.SetActive(true);


        StartCollecting();//後で移動
    }

    public void StartCollecting()
    {
        StartCoroutine(SpawnEggs());
    }

    private IEnumerator SpawnLate()
    {
        yield return new WaitForSeconds(1f);
        SpawnChickensOnTable();
    }

    private void SpawnChickensOnTable()
    {
        Vector3 spawnPos = transform.position + new Vector3(Random.Range(-tableSize.x / 2, tableSize.x / 2),
                                                    -tableSize.y / 2,
                                                    Random.Range(-tableSize.z / 2, tableSize.z / 2));

        //random rotation
        float num = Random.Range(-180f, 180f);
        Quaternion randomQ = Quaternion.Euler(0, num, 0);

        GameObject _spawnedChicken = Instantiate(chicken, spawnPos, randomQ);
        spawnedChicken = _spawnedChicken;
        spawnedChicken.transform.SetParent(this.gameObject.transform);
        //spawnedChicken.GetComponent<AnimalTrigger>().enabled = false;
    }

    private IEnumerator SpawnEggs()
    {
        while (true)
        {
            yield return new WaitForSeconds(eggInterval);
            Vector3 eggSpawnPos = spawnedChicken.transform.position
                - new Vector3(0, 0, 0.2f);
            GameObject spawnedEgg = Instantiate(egg, eggSpawnPos, Quaternion.identity);
            spawnedEgg.transform.SetParent(eggParent);
            Debug.Log("eggspawned");
        }
    }

    //Hold egg
    public void HoldEgg(string handtype, GameObject egg)
    {
        if (handtype == "RightHand")
        {
            egg.transform.SetParent(rightHoldPos.transform);
            egg.layer = LayerMask.NameToLayer("GrabbedAnimal");
        }
        if (handtype == "LeftHand")
        {
            egg.transform.SetParent(leftHoldPos.transform);
            egg.layer = LayerMask.NameToLayer("GrabbedAnimal");
        }

        egg.GetComponent<Rigidbody>().useGravity = false;
        isHolding = true;
        _grabAudio.Play();
        egg.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
    }

    public void ReleaseEgg(GameObject egg)
    {
        isHolding = false;
        StartCoroutine(Release(egg));
        collectedEggCount++;
        egg.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;


        //rightHandPrefab.SetActive(true);
        //leftHandPrefab.SetActive(true);

    }

    private IEnumerator Release(GameObject egg)
    {
        yield return new WaitForSeconds(releaseTime);
        egg.transform.parent = null;

        if (egg.tag == "Egg")
        {
            egg.layer = LayerMask.NameToLayer("Egg");
        }
        Destroy(egg, 1f);
    }

    //private void DestroyAnimals()
    //{
    //    foreach (GameObject chick in _chicks)
    //    {
    //        Destroy(chick);
    //    }
    //    foreach (GameObject chicken in _chickens)
    //    {
    //        Destroy(chicken);
    //    }
    //}

#if UNITY_EDITOR

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(0, 1, 0, 0.5f);
        Gizmos.DrawCube(transform.position, tableSize);
    }
#endif
}
