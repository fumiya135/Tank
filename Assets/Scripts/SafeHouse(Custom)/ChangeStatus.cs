using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeStatus : MonoBehaviour
{
    // status
    [SerializeField] public PlayerStatusScriptable player;
    [SerializeField] public ReinforcementScriptable reinforcement;

    [SerializeField] public CustomNum customPointText;
    private int customPoint;

    private int hp_level;
    private int speed_level;
    private int attack_level;
    private int reloadTime_level;

    public void Start()
    {
        Reset();
    }

    public void Reset()
    {
        customPoint = player.Get_customPoint();

        hp_level = reinforcement.Get_hp_level();
        speed_level = reinforcement.Get_speed_level();
        attack_level = reinforcement.Get_attack_level();
        reloadTime_level = reinforcement.Get_reloadTime_level();

        DisplayUI();
    }

    public void Confirm() // PlayerStatus, Reinforcement 両方書き換え
    {
        player.Set_customPoint(customPoint);

        reinforcement.Set_hp_level(hp_level);
        reinforcement.Set_speed_level(speed_level);
        reinforcement.Set_attack_level(attack_level);
        reinforcement.Set_reloadTime_level(reloadTime_level);

        // 強化内容

    }

    // ボタン処理

    public void Push_hpButton()
    {
        if (customPoint > 0)
        {
            if (hp_level < reinforcement.hp_max)
            {
                hp_level += 1;
                customPoint -= 1;
            }
        }
        DisplayUI();
    }

    public void Push_speedButton()
    {
        if (customPoint > 0)
        {
            if (speed_level < reinforcement.speed_max)
            {
                speed_level += 1;
                customPoint -= 1;
            }
        }
        DisplayUI();
    }

    public void Push_attackButton()
    {
        if (customPoint > 0)
        {
            if (attack_level < reinforcement.attack_max)
            {
                attack_level += 1;
                customPoint -= 1;
            }
        }
        DisplayUI();
    }

    public void Push_reloadTimeButton()
    {
        if (customPoint > 0)
        {
            if (reloadTime_level < reinforcement.reloadTime_max)
            {
                reloadTime_level += 1;
                customPoint -= 1;
            }
        }
        DisplayUI();
    }

    // UI出力

    public void DisplayUI()
    {
        customPointText.PrintOutPoint(customPoint);

        for (int i = 0; i < reinforcement.hp_max; i++)
        {
            GameObject target = GameObject.Find("HpLevel");
            GameObject obj = target.transform.Find("Hp " + i).gameObject;
            if (i < hp_level)
            {
                obj.SetActive(true);
            }
            else
            {
                obj.SetActive(false);
            }
        }
        for (int i = 0; i < reinforcement.speed_max; i++)
        {
            GameObject target = GameObject.Find("SpeedLevel");
            GameObject obj = target.transform.Find("Speed " + i).gameObject;
            if (i < speed_level)
            {
                obj.SetActive(true);
            }
            else
            {
                obj.SetActive(false);
            }
        }
        for (int i = 0; i < reinforcement.attack_max; i++)
        {
            GameObject target = GameObject.Find("AttackLevel");
            GameObject obj = target.transform.Find("Attack " + i).gameObject;
            if (i < attack_level)
            {
                obj.SetActive(true);
            }
            else
            {
                obj.SetActive(false);
            }
        }
        for (int i = 0; i < reinforcement.reloadTime_max; i++)
        {
            GameObject target = GameObject.Find("ReloadTimeLevel");
            GameObject obj = target.transform.Find("ReloadTime " + i).gameObject;
            if (i < reloadTime_level)
            {
                obj.SetActive(true);
            }
            else
            {
                obj.SetActive(false);
            }
        }
    }

}
