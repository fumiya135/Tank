using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // status
    [SerializeField] public PlayerStatusScriptable player;
    [SerializeField] public ReinforcementScriptable reinforcement;

    // reload UI
    public ReloadImage reloadImage;
    public ChargeImage chargeImage;

    // bullet
    public GameObject bulletPrefab;
    public GameObject ChargeBulletPrefab;

    private bool isShoot = true;
    private bool isCharged = false;
    private float reloadStartTime = 0.0f;
    private float chargeStartTime = 0.0f;

    void Start()
    {
        // プレイヤーデータの初期化
        if (player.Get_firstPlayed() == false)
        {
            player.Set_firstPlayed(true);
            StatusInitialize();
        }

        player.Set_hp(player.Get_hpMax());
        player.Set_currentRemainingBullets(player.Get_remainingMaxBullets());

    }

    void Update()
    {
        if (isShoot == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (isCharged == false)
                {
                    chargeStartTime = player.Get_chargeTime();
                    chargeImage.StartChargeUi(chargeStartTime);
                }
                isCharged = true;
            }

            if (Input.GetMouseButtonUp(0))
            {
                if (chargeStartTime >= 0)
                {
                    Attack();
                }
                if (chargeStartTime <= 0)
                {
                    ChargeAttack();
                }
                isCharged = false;
                chargeImage.EndChargeUi();
            }
        }

        if (player.Get_currentRemainingBullets() <= 0)
        {
            player.Set_currentRemainingBullets(0);
            StartCoroutine("ReloadBullet");
            player.Set_currentRemainingBullets(player.Get_remainingMaxBullets());
        }

        if (isCharged == true)
        {
           ChargeTime();
        }

        reloadImage.IsActive(ReloadTimeValue());
    }

    void Attack()
    {
        // 弾を飛ばす処理
        GameObject bulletPoint = GameObject.Find("BulletPoint");
        GameObject bullet = (GameObject)Instantiate(bulletPrefab, bulletPoint.transform.position,
                                                    Quaternion.Euler(90, transform.root.eulerAngles.y, 0));
        // player情報を生成したbulletに書き込む
        BulletManager script = bullet.GetComponent<BulletManager>();
        script.Create(player.Get_attackPower());

        Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
        bulletRigidbody.AddForce(bulletPoint.transform.up * player.Get_attackBulletSpeed());

        // 残弾を１減らす処理
        int remainingBullets = player.Get_currentRemainingBullets() - 1;
        player.Set_currentRemainingBullets(remainingBullets);
    }

    void ChargeAttack()
    {
        // 弾を飛ばす処理
        GameObject bulletPoint = GameObject.Find("BulletPoint");
        GameObject bullet = (GameObject)Instantiate(ChargeBulletPrefab, bulletPoint.transform.position,
                                                    Quaternion.Euler(90, transform.root.eulerAngles.y, 0));
        // player情報を生成したbulletに書き込む
        ChargeBulletManager script = bullet.GetComponent<ChargeBulletManager>();
        script.Create(player.Get_chargeAttackPower());

        Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
        bulletRigidbody.AddForce(bulletPoint.transform.up * player.Get_chargeAttackBulletSpeed());

        // 残弾を１減らす処理
        int remainingBullets = player.Get_currentRemainingBullets() - 1;
        player.Set_currentRemainingBullets(remainingBullets);

    }

    private void ChargeTime()
    {
        chargeStartTime -= Time.deltaTime;
        chargeImage.IsActive(chargeStartTime);
    }

    public void Deamaged(int enemyPower)
    {
        int hp = player.Get_hp();
        hp -= enemyPower;
        player.Set_hp(hp);
    }

    public void LevelUp()
    {
        int level = player.Get_level();
        float expNext = (float)player.Get_level();
        level += 1;
        player.Set_level(level);

        // 次のレベルまでの経験値計算
        expNext = Mathf.Sqrt(5 * level) + 10;
        player.Set_expNextLevel((int)expNext);

        // カスタムポイント加算
        int point = player.Get_customPoint() + 1;
        player.Set_customPoint(point);

    }

    public void ExpAdd()
    {
        int exp = player.Get_exp();
        exp += 1;
        player.Set_exp(exp);
        if (player.Get_exp() == player.Get_expNextLevel())
        {
            LevelUp();
            player.Set_exp(0);
        }
    }

    private IEnumerator ReloadBullet()
    {
        isShoot = false;
        reloadStartTime = Time.time;  // reload時の時間を保持
        reloadImage.StartReloadUi();
        yield return new WaitForSeconds(player.Get_reloadTime());
        reloadImage.EndReloadUi();
        isShoot = true;
    }

    private float ReloadTimeValue()
    {
        return (Time.time - reloadStartTime) / player.Get_reloadTime();
    }

    private float ChargeTimeValue()
    {
        return (Time.time - chargeStartTime) / player.Get_chargeAttackCoroutine();
    }

    private void StatusInitialize()
    {
        // 基礎ステータス
        player._level = 1;
        player._hp = 20;
        player._hpMax = 20;
        player._exp = 0;
        player._expNextLevel = 10;
        player._customPoint = 3;
        // 移動・旋回
        player._moveSpeed = 10.0f;
        player._turnSpeed = 80.0f;
        // リロード
        player._reloadTime = 2.0f;
        player._remainingMaxBullets = 5;
        player._currentRemainingBullets = 5;
        // 攻撃１
        player._attackPower = 3;
        player._attackCoroutine = 0.5f;
        player._attackBulletSpeed = 2000;
        // 攻撃２
        player._chargeAttackPower = 10;
        player._chargeAttackCoroutine = 10f;
        player._chargeAttackBulletSpeed = 1500;
        player._chargeTime = 2;


        // 強化レベル
        reinforcement.hp_level = 0;
        reinforcement.speed_level = 0;
        reinforcement.attack_level = 0;
        reinforcement.reloadTime_level = 0;
    }
}
