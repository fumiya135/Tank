using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveObj : MonoBehaviour
{
    enum END_TYPE
    {
        NONE = 0,
        EXISTENCE,  // ���݂��Ă�����E�F�[�u�I���ɂȂ�Ȃ�
    }

    [SerializeField] END_TYPE endType = END_TYPE.NONE;

    // �E�F�[�u���I�����Ă�����
    public bool IsEnd()
    {
        if (endType == END_TYPE.EXISTENCE)
        {
            if (gameObject) { return false; }
        }

        return true;
    }
}
