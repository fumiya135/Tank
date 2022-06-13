using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickController : MonoBehaviour
{
    Image clickImage;
    int phase;
    List<Vector3> position = new List<Vector3>(){
        new Vector3(-330,147,0),
        new Vector3(0,147,0),
        new Vector3(330,147,0),
    };

    // Use this for initialization
    void Start()
    {
        phase = -1;
        clickImage = GetComponent<Image>();
        clickImage.enabled = false;
    }
    void Update()
    {
        clickImage.color = new Color(1, 1, 1, Mathf.PingPong(Time.time, 1));
    }
    void ViewClickImage(int _phase)
    {
        if (_phase >= position.Count)
        {
            _phase = -1;
            clickImage.enabled = false;
            return;
        }
        this.transform.localPosition = position[_phase];
        clickImage.enabled = true;
    }

    public void ViewClickIcon()
    {
        phase = 0;
        ViewClickImage(phase);
    }
    public void PushButton(int _number)
    {
        if (_number != phase)
        {
            return;
        }
        phase++;
        ViewClickImage(phase);
    }
}