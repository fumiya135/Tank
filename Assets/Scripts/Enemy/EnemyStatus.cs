using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatus : MonoBehaviour
{
    [SerializeField] public int _hp = 10;
    [SerializeField] public int _hpMax = 10;
    [SerializeField] public int _attackPower = 1;
    [SerializeField] public float _moveSpeed = 3;

    public int Get_hp()
    {
        return this._hp;
    }
    public void Set_hp(int value)
    {
        _hp = value;
    }

    public int Get_hpMax()
    {
        return this._hpMax;
    }
    public void Set_hpMax(int value)
    {
        _hpMax = value;
    }

    public int Get_attackPower()
    {
        return this._attackPower;
    }
    public void Set_attackPower(int value)
    {
        _attackPower = value;
    }

    public float Get_moveSpeed()
    {
        return this._moveSpeed;
    }
    public void Set_moveSpeed(int value)
    {
        _moveSpeed = value;
    }
}
