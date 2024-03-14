using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupCompleted : MonoBehaviour
{
    [SerializeField] Button btReset;
    [SerializeField] Button btHome;
    [SerializeField] Button btNextRight;
    GameManager gameManager;

    private void OnEnable()
    {
        gameManager = GameManager.instance;
           
        btReset.onClick.AddListener(OnClickBtReset);
        btHome.onClick.AddListener(OnClickBtHome);
        btNextRight.onClick.AddListener(OnClickBtNextRight);
        if (gameManager.levelPlay >= gameManager.levelList.Count)
        {
            btNextRight.interactable = false;
        }
    }

    public void OnClickBtReset()
    {
        gameObject.SetActive(false);
        gameManager.PlayLevel();
    }

    public void OnClickBtHome()
    {
        gameManager.BackHome();
    }

    public void OnClickBtNextRight()
    {
        gameObject.SetActive(false);
        if(gameManager.currentLevel > gameManager.levelPlay)
        {
            gameManager.levelPlay += 1;
        } 
        else
        {
            gameManager.currentLevel += 1;
            gameManager.levelPlay = gameManager.currentLevel;
            
        }
        gameManager.PlayLevel();
    }
}
