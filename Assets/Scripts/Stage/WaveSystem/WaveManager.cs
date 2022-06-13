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
    bool listEnd = false;                       // waveList�I���t���O
    public bool waveEnd = false;                // all wave�I���t���O

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
            // �E�F�[�u�̍폜�m�F
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

            // �E�F�[�u���I�����
            if (cloneList[cloneIndex].IsEnd())
            {
                // ���̃E�F�[�u��
                NextWave();
                Debug.Log("next wave");
            }
        }
    }

    // �E�F�[�u�J�n
    void StartWave(int _index)
    {
        cloneList.Add((Wave)Instantiate(waveList[_index]));
        waveList[_index].Set_target(target);
        isActive = true;
    }

    // ���̃E�F�[�u��
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

    // �S�ẴE�F�[�u���I��������
    public bool IsEnd()
    {
        return listEnd;
    }

}
