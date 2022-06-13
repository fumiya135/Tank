using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    [SerializeField] public GameObject target;
    [SerializeField] public List<Wave> waveList;
    [SerializeField] public WaveNumText waveNumText;
    [SerializeField, Min(0)] public int waveIndex = 0;

    List<Wave> cloneList = new List<Wave>();    
    int cloneIndex = 0;                         
    bool isActive = false;
    bool listEnd = false;                       // waveList終了フラグ
    public bool waveEnd = false;                // all wave終了フラグ

    private void Start()
    {
        isActive = false;
    }

    public void WaveStart()
    {
        StartWave(waveIndex);

        waveNumText.SetActive(true);
        waveNumText.PrintOutWaveNumText(waveIndex + 1);
    }

    void Update()
    {
        if (isActive == true)
        {
            // ウェーブの削除確認
            for (int i = 0; i < cloneList.Count; ++i)
            {
                if (cloneList[i] && cloneList[i].IsDelete())
                {
                    Destroy(cloneList[i].gameObject);
                }
            }

            if (waveList.Count <= 0 || IsEnd())
            {
                waveEnd = true;
                return;
            }

            // ウェーブが終わった
            if (cloneList[cloneIndex].IsEnd())
            {
                // 次のウェーブへ
                NextWave();
                Debug.Log("next wave");
            }
        }
    }

    // ウェーブ開始
    void StartWave(int _index)
    {
        cloneList.Add((Wave)Instantiate(waveList[_index]));
        waveList[_index].Set_target(target);
        isActive = true;
    }

    // 次のウェーブへ
    void NextWave()
    {
        if (waveIndex < (waveList.Count - 1))
        {
            ++waveIndex;
            ++cloneIndex;
            StartWave(waveIndex);

            waveNumText.SetActive(true);
            waveNumText.PrintOutWaveNumText(waveIndex + 1);
        }
        else
        {
            listEnd = true;
        }
    }

    // 全てのウェーブが終了したか
    public bool IsEnd()
    {
        return listEnd;
    }

}
