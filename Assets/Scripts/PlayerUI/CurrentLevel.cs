using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentLevel : MonoBehaviour
{
    public Text text;

    public void CurrentLevelText(int level)
    {
        text.text = level.ToString("0");
    }
}
