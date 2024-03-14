using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : FastSingleton<GameManager>
{
    UIManager uiManager;
    public int currentLevel;
    public int levelPlay;
    public float countDown;
    public List<GameObject> levelList;
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
        currentLevel = 3;
        levelPlay = currentLevel;
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
        foreach (var item in levelList)
        {
            item.gameObject.SetActive(false);
        }
    }

    public void PlayLevel()
    {
        foreach(var item in levelList)
        {
            item.gameObject.SetActive(false);
        }

        for(int i =  0; i < levelList.Count; i++)
        {
            if(i == levelPlay - 1)
            {
                levelList[i].gameObject.SetActive(true);
            }
        }
    }    
}
