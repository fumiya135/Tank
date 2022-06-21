using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "reinforcement_data", menuName = "ScriptableObject/Data/reinforcement_data", order = 2)]
[System.Serializable]
public class ReinforcementScriptable : ScriptableObject
{
    [SerializeField] public static int reinforce_level = 10;

    public int hp_max = reinforce_level;
    public int speed_max = reinforce_level;
    public int attack_max = reinforce_level;
    public int reloadTime_max = reinforce_level;

    public int hp_level = 0;
    public int speed_level = 0;
    public int attack_level = 0;
    public int reloadTime_level = 0;

    public void Inisialize()
    {
        hp_level = 0;
        speed_level = 0;
        attack_level = 0;
        reloadTime_level = 0;
    }

    public int Get_level()
    {
        return reinforce_level;
    }

    public int Get_hp_level()
    {
        return hp_level;
    }
    public void Set_hp_level(int value)
    {
        hp_level = value;
    }
    public int Get_speed_level()
    {
        return speed_level;
    }
    public void Set_speed_level(int value)
    {
        speed_level = value;
    }
    public int Get_attack_level()
    {
        return attack_level;
    }
    public void Set_attack_level(int value)
    {
        attack_level = value;
    }
    public int Get_reloadTime_level()
    {
        return reloadTime_level;
    }
    public void Set_reloadTime_level(int value)
    {
        reloadTime_level = value;
    }
}