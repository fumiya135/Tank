using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveNumText : MonoBehaviour
{
    public Text text;
    private Animator animator;

    public void SetActive(bool value)
    {
        this.gameObject.SetActive(value);
        StartCoroutine("Animation");
    }

    public void PrintOutWaveNumText(int value)
    {
        text.text = value.ToString("Wave 0");

    }

    private IEnumerator Animation()
    {
        yield return new WaitForSeconds(4);
        this.gameObject.SetActive(false);
    }
}
