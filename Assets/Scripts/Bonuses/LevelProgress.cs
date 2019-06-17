using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelProgress : MonoBehaviour
{
    #region Singleton
    public static LevelProgress Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);
    }
    #endregion
    private int score;
    private int coins = 0;

    public int Score
    {
        get => score;
        set
        {
            score = value;
            HUD.Instance.UpdateUI();
        }
    }

    public int Coins {
        get => coins;
        set
        {
            coins = value;
            score++;
            HUD.Instance.UpdateUI();
        }
    } 
    
}
