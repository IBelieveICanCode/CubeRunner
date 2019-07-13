using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OptionsWindowHud : MonoBehaviour
{
    public void LoadNewGame()
    {
        SceneManager.LoadScene(0);
    }
}
