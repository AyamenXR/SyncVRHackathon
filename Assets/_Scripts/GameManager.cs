using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

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

    public UnityEvent onReset;

    //Feeding
    private void Start()
    {
        eGameStatus = GameState.Intro;
        onAwake.Invoke();

        feedScore = 0;
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

    public static void FeedAnimal()
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
    public void StartSorting()//called from UI Complete Feeding Panel Button
    {
        onSortingStarted.Invoke();
    }




    public void Reset()
    {
        feedScore = 0;
    }

}
