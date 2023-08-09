using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class How_To_Play_Controller : MonoBehaviour
{
    private string MAIN_MENU_SCENE = "Main Menu";
    public void returnToMainMenu()
    {
        SceneManager.LoadScene(MAIN_MENU_SCENE);
    }
}