using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggCollectionManager : MonoBehaviour
{
    public GameObject chicken;
    [Range(0, 50)]
    //public int numberOfChickens = 3;
    //public Transform chickenParent;
    private GameObject spawnedChicken;

    public GameObject egg;
    public float eggInterval;
    public Transform eggParent;

    private GameManager _gameManager;
    private AudioSource _grabAudio;

    private GameObject[] _chicks;
    private GameObject[] _chickens;

    public Vector3 tableSize;

    void Start()
    {
        _gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();

        _grabAudio = GetComponent<AudioSource>();
    }

    public void ReadyToCollect()
    {
        StartCoroutine(SpawnLate());



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
