using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
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
    }

    public void startFeeding()//called from button
    {
        eGameStatus = GameState.Feeding;
        onFeedingStarted.Invoke();
    }

}
