using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    //Scores
    public static int feedScore;

    public delegate void FeedHandler();
    public static event FeedHandler WhenAnimalFed;

    //Enum
    public enum GameState
    {
        Intro,
        Feeding,
        Sorting,
        EggCollection
    }

    public static GameState eGameStatus;

    //UnityEvents
    [Header("Feeding")]
    public UnityEvent onAwake;
    //public UnityEvent onStartActivated;
    public UnityEvent onFeedingStarted;
    public UnityEvent onFeedingCompleted;

    [Header("Sorting")]
    public UnityEvent onSortingStarted;
    public UnityEvent onSortingCompleted;

    [Header("CollectingEggs")]
    public UnityEvent onCollectingEggsStarted;
    public UnityEvent onCollectingEggsCompleted;
    public UnityEvent onReset;

    [Header("SortingTimer")]
    public float sortingTime = 0f;
    public TextMeshProUGUI sortingTimeText;



    //Feeding
    private void Start()
    {
        eGameStatus = GameState.Intro;
        onAwake.Invoke();

        feedScore = 0;

        sortingTime = 0;

        
    }

    private void FixedUpdate()
    {
        Debug.Log(eGameStatus);
        
        if (eGameStatus == GameState.Sorting)
        {
            sortingTime += Time.deltaTime;

        }
        sortingTimeText.text = sortingTime.ToString("F0");

    }
    //public void OnStartSelect()
    //{
    //    onStartActivated.Invoke();
    //}

    public void StartFeeding()//called from UI Start Feeding panel button
    {
        eGameStatus = GameState.Feeding;
        onFeedingStarted.Invoke();
    }

    public static void FeedAnimal()//called from ParticleCollision.cs
    {
        if (eGameStatus == GameState.Feeding)
        {
            feedScore += 1;
            WhenAnimalFed();
        }
    }

    public void CompleteFeedAnimal()//called from FeedManager.cs
    {
        onFeedingCompleted.Invoke();
    }

    //Sorting
    public void StartSorting()//called from UI Complete StartSorting Panel Button
    {
        onSortingStarted.Invoke();
        eGameStatus = GameState.Sorting;
    }

    public void CompleteSorting()//called from SortinManager.cs
    {
        onSortingCompleted.Invoke();
        eGameStatus = GameState.Intro;
    }

    //Collect Egg
    public void StartCollectingEgg()//called from UI StartCollecting Panel Button
    {
        onCollectingEggsStarted.Invoke();
        eGameStatus = GameState.EggCollection;
    }

    public void CompleteCollectingEgg()//called from EggCollectionManager.cs
    {
        onCollectingEggsCompleted.Invoke();
        eGameStatus = GameState.Intro;
    }

    public void Reset()
    {
        feedScore = 0;
    }

}
