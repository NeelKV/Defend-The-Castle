using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_Over_Controller : MonoBehaviour
{
    public TextMeshProUGUI coinCount;

    private void Start()
    {
        coinCount.text = "X " + Game_Manager.last_Coin_Count;
    }

    private string MAIN_MENU_SCENE = "Main Menu";
    public void returnToMainMenu()
    {
        SceneManager.LoadScene(MAIN_MENU_SCENE);
    }
}