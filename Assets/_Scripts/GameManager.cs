using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

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
    [Header("Game structure Events")]
    public UnityEvent onStartActivated;
    public UnityEvent onFeedingStarted;
    //public UnityEvent onSortingSelected;

    private void Start()
    {
        eGameStatus = GameState.Intro;
        onStartActivated.Invoke();

        feedScore = 0;
    }

    public void startFeeding()//called from button
    {
        eGameStatus = GameState.Feeding;
        onFeedingStarted.Invoke();
    }



    public static void FeedAnimal()
    {
        //if(eGameStatus == GameState.Feeding)
        //{
            feedScore += 1;
            WhenAnimalFed();
            Debug.Log(feedScore);
        //}
    }

    public void Reset()
    {
        feedScore = 0;
    }

}
