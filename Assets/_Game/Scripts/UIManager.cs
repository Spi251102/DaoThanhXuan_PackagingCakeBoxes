using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : FastSingleton<UIManager>
{
    [SerializeField] GameObject home;
    [SerializeField] GameObject gameplay;
    [SerializeField] GameObject htp;
    [SerializeField] GameObject selectLevel;
    [SerializeField] GameObject completed;
    [SerializeField] GameObject fail;

    public void SetActiveHome(bool active)
    {
        home.SetActive(active);
    }

    public void SetActiveGameplay(bool active)
    {
        gameplay.SetActive(active);
    }

    public void SetActiveHTP(bool active)
    {
        htp.SetActive(active);
    }

    public void SetActiveSeclectLevel(bool active)
    {
        selectLevel.SetActive(active);
    }

    public void ShowCompleted(bool active)
    {
        completed.SetActive(active);
    }

    public void ShowFail(bool active)
    {
        fail.SetActive(active);
    }
}
