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

    [SerializeField] List<ObjData> objList;     // オブジェクトリスト
    int nowObj = 0;                             // 今のオブジェクト

    int frame = 0;
    bool waveEnd = false;

    void Start()
    {
        // 全てのオブジェクトを無効にする
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

        // オブジェクトを有効にする
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

    // 次のオブジェクトへ
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

    // ウェーブ終了
    public bool IsEnd()
    {
        // オブジェクト毎の終了判定
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

        // 全てのオブジェクトが有効になっていれば終了
        return waveEnd;
    }

    // 全てのオブジェクトが消えたか
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