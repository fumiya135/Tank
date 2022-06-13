using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] public PlayerStatusScriptable player;
    [SerializeField] public WaveManager _waveManager;

    public PlayerHealthBar healthBar;
    public ExpBar expBar;
    public CurrentLevel currentlevel;
    public GunNum gunNum;
    public GunNumMax gunNumMax;
    public WaveNum waveNum;
    public WaveNumMax waveNumMax;

    private void Start()
    {
        healthBar.SetMaxHealth(player.Get_hpMax());
        waveNumMax.WaveNumMaxText(_waveManager.waveList.Count);
    }

    private void Update()
    {
        healthBar.SetHealth(player.Get_hp());

        expBar.SetMaxExp(player.Get_expNextLevel());
        expBar.SetExp(player.Get_exp());

        currentlevel.CurrentLevelText(player.Get_level());

        gunNum.GunNumText(player.Get_currentRemainingBullets());
        gunNumMax.GunNumMaxText(player.Get_remainingMaxBullets());

        waveNum.WaveNumText(_waveManager.waveIndex + 1);
    }
}
