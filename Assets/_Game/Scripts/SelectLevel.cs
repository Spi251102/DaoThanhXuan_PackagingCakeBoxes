using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SelectLevel : MonoBehaviour
{
    [SerializeField] Level levelLock;
    [SerializeField] Level levelUnlock;
    [SerializeField] Level levelCompleted;
    [SerializeField] Transform parent;
    List<Level> levels = new List<Level>();
    GameManager gameManager;
    private void Start()
    {
        gameManager = GameManager.instance;
        for (int i = 1; i < gameManager.levelList.Count + 1; i++)
        {
            if( i < gameManager.currentLevel)
            {
                Level level = Instantiate(levelCompleted, parent);
                levels.Add(level);
                level.number = i;
                level.unlock = gameManager.currentLevel > i;
                level.SetNumberLevel(i);
                //level.completed = gameManager.currentLevel > i;
            }
            else if( i > gameManager.currentLevel)
            {
                Level level = Instantiate(levelLock, parent);
                levels.Add(level);
                level.number = i;
                level.unlock = gameManager.currentLevel > i;
                level.GetComponent<Button>().interactable = false;
            }
            else
            {
                Level level = Instantiate(levelUnlock, parent);
                levels.Add(level);
                level.number = i;
                level.unlock = gameManager.currentLevel > i;
                level.SetNumberLevel(i);
            }
        }

        for (int i = 0; i < levels.Count; i++)
        {
            int buttonIndex = i; // Lưu lại chỉ số của button

            levels[buttonIndex].GetComponent<Button>().onClick.AddListener(() => OnClickBtLevel(levels[buttonIndex], buttonIndex));
        }
    }

    public void OnClickBtLevel(Level level, int buttonIndex)
    {
        gameManager.levelPlay = levels[buttonIndex].number;
        gameManager.PlayLevel();
    }
}
