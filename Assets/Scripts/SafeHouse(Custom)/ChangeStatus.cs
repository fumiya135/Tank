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

    public void Confirm() // PlayerStatus, Reinforcement óºï˚èëÇ´ä∑Ç¶
    {
        player.Set_customPoint(customPoint);

        //--------ã≠âªì‡óe------------
        // HP
        int playerHp = player.Get_hpMax();
        int hp = hp_level - reinforcement.Get_hp_level();
        playerHp += hp * 5;        // <----ã≠âªî{ó¶
        player.Set_hpMax(playerHp);
        Debug.Log("hpÇÕ" + playerHp + "è„è∏ÇµÇΩÅB");

        // Speed
        float playerSpeed = player.Get_moveSpeed();
        int speed = speed_level - reinforcement.Get_speed_level();
        playerSpeed += speed * 3;       /// <----ã≠âªî{ó¶
        player.Set_moveSpeed(playerSpeed);
        Debug.Log("speedÇÕ" + playerHp + "è„è∏ÇµÇΩÅB");

        // Attack
        int playerAttack1 = player.Get_attackPower();
        int playerAttack2 = player.Get_chargeAttackPower();
        int attack = attack_level - reinforcement.Get_attack_level();
        playerAttack1 += attack * 3;       // <----ã≠âªî{ó¶
        playerAttack2 += attack * 3;       //
        player.Set_attackPower(playerAttack1);
        player.Set_chargeAttackPower(playerAttack2);
        Debug.Log("attackÇÕ" + playerAttack1 + "è„è∏ÇµÇΩÅB");

        // reloadTime
        double playerReloadTime = player.Get_reloadTime();
        float reloadTime = reloadTime_level - reinforcement.Get_reloadTime_level();
        playerReloadTime -= reloadTime * 0.2;      // <-----ã≠âªî{ó¶
        player.Set_reloadTime((float)playerReloadTime);
        Debug.Log("reloadTimeÇÕ" + playerReloadTime + "íZèkÇµÇΩÅB");

        //-----------ã≠âªÉåÉxÉãÇï€éù--------
        reinforcement.Set_hp_level(hp_level);
        reinforcement.Set_speed_level(speed_level);
        reinforcement.Set_attack_level(attack_level);
        reinforcement.Set_reloadTime_level(reloadTime_level);
    }

    // É{É^Éìèàóù

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

    // UIèoóÕ

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
