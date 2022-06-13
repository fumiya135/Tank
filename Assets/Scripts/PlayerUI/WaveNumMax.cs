using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveNumMax : MonoBehaviour
{
    public Text text;

    public void WaveNumMaxText(int value)
    {
        text.text = value.ToString("/0");
    }
}
