using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum GameState { Play, Pause };

//This class will be the enter point of Game scene
public class GameController : MonoBehaviour
{
    #region Singleton
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
    #endregion
    [Header("Map setup")]
    public DungeonMap MapController;
    public int ElementsInMap;
    public MapExtended Map;
    [Range(0f,1f)]
    public float outlinePercent = 0.02f;
    public float tileSize = 1;
    [Space]
    [Header("PlayerSettings")]
    public Transform playerTransform;
    public PlayerInstance PlayerData;

    private void Start()
    {
        Debug.Log(Application.persistentDataPath);
        PlayerInit();
        //InitMap
        MapController.Init(ElementsInMap, Map, outlinePercent, tileSize);

        //This code is only for test
        BonusController bc = new BonusController();
        //PlayerData.Save();
        PlayerData.Load();
        
    }

    public UnityEvent GameOverEvent;

    #region Methods
    private void PlayerInit()
    { 
        if (Map.mapSize.x % 2 == 0)
            playerTransform.position = Vector3.one * tileSize / 2;
        else
            playerTransform.position = new Vector3(0f, tileSize / 2, 0f);
        playerTransform.localScale = Vector3.one * tileSize;
    }
    #endregion
}
