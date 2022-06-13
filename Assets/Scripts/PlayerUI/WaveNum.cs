using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveNum : MonoBehaviour
{
    public Text text;

    public void WaveNumText(int value)
    {
        text.text = value.ToString(" 0");
    }
}
