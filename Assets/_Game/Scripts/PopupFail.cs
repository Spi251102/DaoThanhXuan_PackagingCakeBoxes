using DG.Tweening.Core.Easing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupFail : MonoBehaviour
{
    [SerializeField] Button btReset;
    [SerializeField] Button btHome;

    GameManager gameManager;

    private void OnEnable()
    {
        gameManager = GameManager.instance;

        btReset.onClick.AddListener(OnClickBtReset);
        btHome.onClick.AddListener(OnClickBtHome);             
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

}
