using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "clone_player_data", menuName = "ScriptableObject/Data/clone_player_data", order = 3)]
[System.Serializable]
public class CloneDataScriptableObject: ScriptableObject
{
    // リザルト リセット用
    [SerializeField] public int _level;
    [SerializeField] public int _exp;
    [SerializeField] public int _expTotal;
    [SerializeField] public int _expNextLevel;
    [SerializeField] public int _customPoint;

    public int Get_level()
    {
        return this._level;
    }
    public void Set_level(int value)
    {
        _level = value;
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
}
