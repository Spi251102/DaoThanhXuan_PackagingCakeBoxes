using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : FastSingleton<GameManager>
{
    UIManager uiManager;
    public int currentLevel;
    public float countDown;
    public GameObject levelList;
    public enum TypeCharacter
    {
        FRAME,
        CAKE,
        CANDY,       
        GIFTBOX,
        
    }

    private void Start()
    {
        OnInit();   
    }

    private void OnInit()
    {
        currentLevel = 1;
        countDown = 45;
        uiManager = UIManager.instance;
    }    

    public void GameCompleted()
    {
        uiManager.ShowCompleted(true);
    }

    public void GameFail()
    {
        uiManager.ShowFail(true);
    }

    public void BackHome()
    {
        uiManager.SetActiveHome(true);
        uiManager.SetActiveGameplay(false);
        uiManager.SetActiveHTP(false);
        uiManager.SetActiveSeclectLevel(false);
        uiManager.ShowCompleted(false);
        uiManager.ShowFail(false);
    }
}
