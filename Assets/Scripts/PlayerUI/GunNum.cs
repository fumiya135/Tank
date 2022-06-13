using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunNum : MonoBehaviour
{
    public Text text;

    public void GunNumText(int bullet)
    {
        text.text = bullet.ToString(" 0");
    }
}
