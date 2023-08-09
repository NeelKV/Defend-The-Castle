using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_Manager : MonoBehaviour
{
    public static Game_Manager instance;

    public static int coin_Count = 0;

    public static int arrow_damage = 1;

    //following variables will be used to see if towers have been unlocked
    public static bool char2Unlocked = false;
    public static bool char3Unlocked = false;

    private int char_Index;
    public int CharIndex
    {
        get { return char_Index; }
        set { char_Index = value; }
    }


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }


    public static void coinCount(int count)
    {
        coin_Count += count;
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    }

    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        //add code to include different towers
    }
}