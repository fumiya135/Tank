using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunNumMax : MonoBehaviour
{
    public Text text;

    public void GunNumMaxText(int bullet)
    {
        text.text = bullet.ToString("/0");
    }
}
