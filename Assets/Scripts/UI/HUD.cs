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
    public OptionsWindowHud Options;

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
        if (Input.GetKeyDown(KeyCode.Escape))
            ShowWindow(Options.gameObject);
    }

    public void UpdateUI()
    {
        txtCoins.text = "COINS: " + LevelProgress.Instance.Coins.ToString();
        txtScore.text = "SCORE: " + LevelProgress.Instance.Score.ToString();
    }

    void ShowWindow(GameObject windowToShow)
    {
        windowToShow.SetActive(true);
        GameController.Instance.State = GameState.Pause;
    }
}
