using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgmManager : MonoBehaviour
{
    [SerializeField] public AudioValueScriptableObject data;
    [SerializeField] public AudioSource audioSourse;

    void Start()
    {
        audioSourse = GetComponent<AudioSource>();
    }

    private void Update()
    {
        audioSourse.volume = data.Get_bgmValue();
    }
}
