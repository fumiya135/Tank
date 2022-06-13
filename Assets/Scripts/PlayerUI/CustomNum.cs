using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomNum : MonoBehaviour
{
    public Text text;

    public void PrintOutPoint(int value)
    {
        text.text = value.ToString("0");
    }
}
