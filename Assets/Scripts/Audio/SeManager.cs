using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeManager : MonoBehaviour
{
    [SerializeField] public AudioValueScriptableObject data;
    [SerializeField] public AudioSource audioSourse;

    void Start()
    {
        audioSourse = GetComponent<AudioSource>();
    }

    private void Update()
    {
        audioSourse.volume = data.Get_seValue();
    }

    /// <summary>
    /// StartSE
    /// </summary>
    /// <param name="clip"></param>
    public void PlaySE(AudioClip clip)
    {
        if (audioSourse != null)
        {
            audioSourse.PlayOneShot(clip);
        }
        else
        {
            Debug.Log("オーディオソースが設定されていません。");
        }
    }
}
