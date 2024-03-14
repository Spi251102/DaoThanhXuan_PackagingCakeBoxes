using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI numberLevel;
    public int number;
    public bool unlock;
    public bool completed;

    

    public void SetNumberLevel(int n)
    {
        numberLevel.text = n.ToString();
    }

      
}
