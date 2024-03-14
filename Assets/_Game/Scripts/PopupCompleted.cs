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

    private void Start()
    {
        gameManager = GameManager.instance;
        btReset.onClick.AddListener(OnClickBtReset);
        btHome.onClick.AddListener(OnClickBtHome);
        btNextRight.onClick.AddListener(OnClickBtNextRight);
    }

    public void OnClickBtReset()
    {
        gameObject.SetActive(false);
        //gameManager.
    }

    public void OnClickBtHome()
    {
        gameManager.BackHome();
    }

    public void OnClickBtNextRight()
    {
        gameObject.SetActive(false);
        gameManager.currentLevel += 1;
    }
}
