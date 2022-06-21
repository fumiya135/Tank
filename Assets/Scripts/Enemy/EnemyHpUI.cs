using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHpUI : MonoBehaviour
{
    public Slider slider;

    void Update()
    {
        // �X���C�_�[�̌������J���������ɌŒ�
        slider.transform.rotation = Camera.main.transform.rotation;
    }

    public void SetMaxHp(int value)
    {
        slider.maxValue = value;
    }

    public void SetHp(int value)
    {
        slider.value = value;
    }
}
