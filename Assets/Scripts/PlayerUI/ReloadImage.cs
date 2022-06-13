using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReloadImage : MonoBehaviour
{
    public Image reloadImage_fill;

    public void StartReloadUi()
    {
        gameObject.active = true;

        reloadImage_fill.fillAmount = 0;
    }

    public void IsActive(float value)
    {
        reloadImage_fill.fillAmount = value;
    }

    public void EndReloadUi()
    {
        gameObject.active = false;
    }
}
