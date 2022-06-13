using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    GameObject target;
    [System.Serializable]
    struct ObjData
    {
        public int generateFrame;
        public WaveObj waveObj;
    }

    [SerializeField] List<ObjData> objList;     // �I�u�W�F�N�g���X�g
    int nowObj = 0;                             // ���̃I�u�W�F�N�g

    int frame = 0;
    bool waveEnd = false;

    void Start()
    {
        // �S�ẴI�u�W�F�N�g�𖳌��ɂ���
        for (int i = 0; i < objList.Count; ++i)
        {
            if (objList[i].waveObj)
            {
                if (objList[i].waveObj.gameObject.CompareTag("EnemyA")) {
                    EnemyControllerA obj = objList[i].waveObj.gameObject.GetComponent<EnemyControllerA>();
                    obj.Set_target(target); 
                }
                if (objList[i].waveObj.gameObject.CompareTag("EnemyB")) {
                    EnemyControllerB obj = objList[i].waveObj.gameObject.GetComponent<EnemyControllerB>();
                    obj.Set_target(target);
                }
                objList[i].waveObj.gameObject.SetActive(false);
            }
        }
    }

    void Update()
    {
        if (objList.Count <= 0 || waveEnd) return;

        ++frame;

        // �I�u�W�F�N�g��L���ɂ���
        while (frame >= objList[nowObj].generateFrame)
        {
            if (objList[nowObj].waveObj)
            {
                objList[nowObj].waveObj.gameObject.SetActive(true);
            }

            NextObj();

            if (waveEnd) { break; }
        }
    }

    // ���̃I�u�W�F�N�g��
    void NextObj()
    {
        if (nowObj < (objList.Count - 1))
        {
            ++nowObj;
            frame = 0;
        }
        else
        {
            waveEnd = true;
        }
    }

    // �E�F�[�u�I��
    public bool IsEnd()
    {
        // �I�u�W�F�N�g���̏I������
        for (int i = 0; i < objList.Count; ++i)
        {
            if (objList[i].waveObj)
            {
                if (!objList[i].waveObj.IsEnd())
                {
                    return false;
                }
            }
        }

        // �S�ẴI�u�W�F�N�g���L���ɂȂ��Ă���ΏI��
        return waveEnd;
    }

    // �S�ẴI�u�W�F�N�g����������
    public bool IsDelete()
    {
        for (int i = 0; i < objList.Count; ++i)
        {
            if (objList[i].waveObj)
            {
                if (objList[i].waveObj.gameObject)
                {
                    return false;
                }
            }
        }

        return true;
    }

    public void Set_target(GameObject _target)
    {
        target = _target;
    }
}