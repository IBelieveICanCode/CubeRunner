using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class HUD : MonoBehaviour
{
    #region Singleton
    public static HUD Instance;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);
    }
    #endregion

    [Header("Info")]
    [SerializeField]
    private Text txtScore;
    [SerializeField]
    private Text txtCoins;

    private void Start()
    {
        UpdateUI();
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
            Restart();
    }

    public void UpdateUI()
    {
        txtCoins.text = "Coins: " + LevelProgress.Instance.Coins.ToString();
        txtScore.text = "Score: " + LevelProgress.Instance.Score.ToString();
    }
}
