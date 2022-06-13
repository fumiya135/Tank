using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChargeImage : MonoBehaviour
{
    public Slider slider;

    public void StartChargeUi(float value)
    {
        gameObject.active = true;
        slider.minValue = -value;
        slider.maxValue = 0;
        slider.value = -value;
    }

    public void IsActive(float value)
    {
        slider.value = -value;
    }
    
    public void EndChargeUi()
    {
        slider.value = slider.minValue;
        gameObject.active = false;
    }
}
