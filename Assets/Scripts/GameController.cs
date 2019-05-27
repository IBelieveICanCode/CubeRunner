using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum GameState { Play, Pause };

public class GameController : MonoBehaviour
{
    public UnityEvent GameOverEvent;

    public static GameController Instance;

    private GameState state;
    public GameState State
    {
        get
        {
            return state;
        }

        set
        {
            if (value == GameState.Play)
            {
                Time.timeScale = 1.0f;
            }
            else if (value == GameState.Pause)
            {
                Time.timeScale = 0.0f;
            }
            state = value;
        }
    }


    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);        
    }
}
