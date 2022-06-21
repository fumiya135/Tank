using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "audio_value_data", menuName = "ScriptableObject/Data/audio_value_data", order = 4)]
[System.Serializable]
public class AudioValueScriptableObject : ScriptableObject
{
    [SerializeField, Range(0, 1)] public float seValue;
    [SerializeField, Range(0, 1)] public float bgmValue;

    public float Get_seValue()
    {
        return seValue;
    }
    public void Set_seValue(float value)
    {
        seValue = value;
    }

    public float Get_bgmValue()
    {
        return bgmValue;
    }
    public void Set_bgmValue(float value)
    {
        bgmValue = value;
    }
}
