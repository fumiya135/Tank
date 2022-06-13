using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultUI : MonoBehaviour
{
    [SerializeField] public Text levelText;
    [SerializeField] public Text expText;
    [SerializeField] public Text customPointText;

    public void Set_levelText(int value)
    {
        levelText.text = value.ToString("00");
    }

    public void Set_expText(int value)
    {
        expText.text = value.ToString("00");
    }

    public void Set_customPointText(int value)
    {
        customPointText.text = value.ToString("00");
    }
}
