using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "player_data", menuName = "ScriptableObject/Data/player_data", order = 1)]
[System.Serializable]
public class PlayerStatusScriptable : ScriptableObject
{
    [Header("基礎ステータス")]
    [SerializeField] public int _level;
    [SerializeField] public int _hp;
    [SerializeField] public int _hpMax;
    [SerializeField] public int _exp;
    [SerializeField] public int _expTotal;
    [SerializeField] public int _expNextLevel;
    [SerializeField] public int _customPoint;

    [Header("移動、旋回")]
    [SerializeField] public float _moveSpeed;
    [SerializeField] public float _turnSpeed;

    [Header("リロード")]
    [SerializeField] public float _reloadTime;
    [SerializeField] public int _remainingMaxBullets;
    [SerializeField] public int _currentRemainingBullets;

    [Header("攻撃１")]
    [SerializeField] public int _attackPower;
    [SerializeField] public float _attackCoroutine;
    [SerializeField] public float _attackBulletSpeed;

    [Header("攻撃２")]
    [SerializeField] public int _chargeAttackPower;
    [SerializeField] public float _chargeAttackCoroutine;
    [SerializeField] public float _chargeAttackBulletSpeed;
    [SerializeField] public float _chargeTime;

    [Header("進行度")]
    [SerializeField] public bool _firstPlayed;
    [SerializeField] public int _story;

    //------------初期ステ--------------------------

    public void Inisialize()
    {
        // 基礎ステータス
        _level = 1;
        _hp = 20;
        _hpMax = 20;
        _exp = 0;
        _expTotal = 0;
        _expNextLevel = 10;
        _customPoint = 3;
        // 移動・旋回
        _moveSpeed = 10.0f;
        _turnSpeed = 80.0f;
        // リロード
        _reloadTime = 2.0f;
        _remainingMaxBullets = 5;
        _currentRemainingBullets = 5;
        // 攻撃１
        _attackPower = 2;
        _attackCoroutine = 0.5f;
        _attackBulletSpeed = 2000;
        // 攻撃２
        _chargeAttackPower = 2;
        _chargeAttackCoroutine = 10f;
        _chargeAttackBulletSpeed = 2000;
        _chargeTime = 2;
        // 進行度
        _firstPlayed = true;
        _story = 0;
    }

    //---------基礎ステータス------------------------

    public int Get_level()
    {
        return this._level;
    }
    public void Set_level(int value)
    {
        _level = value;
    }

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

    public int Get_exp()
    {
        return this._exp;
    }
    public void Set_exp(int value)
    {
        _exp = value;
    }

    public int Get_expTotal()
    {
        return this._expTotal;
    }
    public void Set_expTotal(int value)
    {
        _expTotal = value;
    }

    public int Get_expNextLevel()
    {
        return this._expNextLevel;
    }
    public void Set_expNextLevel(int value)
    {
        _expNextLevel = value;
    }

    public int Get_customPoint()
    {
        return this._customPoint;
    }
    public void Set_customPoint(int value)
    {
        _customPoint = value;
    }

    //---------移動、回転----------------------------

    public float Get_moveSpeed()
    {
        return this._moveSpeed;
    }
    public void Set_moveSpeed(float value)
    {
        _moveSpeed = value;
    }

    public float Get_turnSpeed()
    {
        return this._turnSpeed;
    }
    public void Set_turnSpeed(float value)
    {
        _turnSpeed = value;
    }

    //---------リロード------------------------------

    public float Get_reloadTime()
    {
        return this._reloadTime;
    }
    public void Set_reloadTime(float value)
    {
        _reloadTime = value;
    }

    public int Get_remainingMaxBullets()
    {
        return this._remainingMaxBullets;
    }
    public void Set_remainingMaxBullets(int value)
    {
        _remainingMaxBullets = value;
    }

    public int Get_currentRemainingBullets()
    {
        return this._currentRemainingBullets;
    }
    public void Set_currentRemainingBullets(int value)
    {
        _currentRemainingBullets = value;
    }

    //---------攻撃１--------------------------------

    public int Get_attackPower()
    {
        return this._attackPower;
    }
    public void Set_attackPower(int value)
    {
        _attackPower = value;
    }

    public float Get_attackCoroutine()
    {
        return this._attackCoroutine;
    }
    public void Set_attackCoroutine(int value)
    {
        _attackCoroutine = value;
    }

    public float Get_attackBulletSpeed()
    {
        return this._attackBulletSpeed;
    }
    public void Set_attackBulletSpeed(int value)
    {
        _attackBulletSpeed = value;
    }

    //----------攻撃２-------------------------------
    public int Get_chargeAttackPower()
    {
        return this._chargeAttackPower;
    }
    public void Set_chargeAttackPower(int value)
    {
        _chargeAttackPower = value;
    }

    public float Get_chargeAttackCoroutine()
    {
        return this._chargeAttackCoroutine;
    }
    public void Set_chargeAttackCoroutine(float value)
    {
        _chargeAttackCoroutine = value;
    }

    public float Get_chargeAttackBulletSpeed()
    {
        return this._chargeAttackBulletSpeed;
    }
    public void Set_chargeAttackBulletSpeed(float value)
    {
        _chargeAttackBulletSpeed = value;
    }

    public float Get_chargeTime()
    {
        return this._chargeTime;
    }
    public void Set_chargeTime(float value)
    {
        _chargeTime = value;
    }

    //---------チェック ---------------------------------

    public bool Get_firstPlayed()
    {
        return this._firstPlayed;
    }
    public void Set_firstPlayed(bool value)
    {
        _firstPlayed = value;
    }

    public float Get_story()
    {
        return this._story;
    }
    public void Set_story(int value)
    {
        _story = value;
    }
}
