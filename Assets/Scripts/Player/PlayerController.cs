using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("status")]
    [SerializeField] public PlayerStatusScriptable player;
    [SerializeField] public ReinforcementScriptable reinforcement;

    [Header("audioClip")]
    [SerializeField] public AudioClip shootSE;
    [SerializeField] public AudioClip damageSE;

    [Header("reload UI")]
    public ReloadImage reloadImage;
    public ChargeImage chargeImage;

    [Header("bullet Prefab")]
    public GameObject bulletPrefab;
    public GameObject ChargeBulletPrefab;

    [Header("Dead Explosion")]
    public GameObject explosionPrefab;
    public GameObject DeadUI;

    private bool isDead = false;
    private bool isShoot = true;
    private bool isCharged = false;
    private float reloadStartTime = 0.0f;
    private float chargeStartTime = 0.0f;

    void Start()
    {
        // プレイヤーデータの初期化
        if (player.Get_firstPlayed() == false)
        {
            player.Inisialize();
            reinforcement.Inisialize();
        }

        player.Set_hp(player.Get_hpMax());
        player.Set_currentRemainingBullets(player.Get_remainingMaxBullets());

    }

    void Update()
    {
        if (isDead == true)
        {
            Dead();
        }

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

        if (GameObject.Find("SE") != null)
        {
            SeManager se = GameObject.Find("SE").GetComponent<SeManager>();
            se.PlaySE(shootSE);
        }
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

        if (GameObject.Find("SE") != null)
        {
            SeManager se = GameObject.Find("SE").GetComponent<SeManager>();
            se.PlaySE(shootSE);
        }
    }

    private void ChargeTime()
    {
        chargeStartTime -= Time.deltaTime;
        chargeImage.IsActive(chargeStartTime);
    }

    public void Dead()
    {
        Instantiate(explosionPrefab, gameObject.transform.position, Quaternion.identity);

        if (DeadUI != null)
        {
            DeadUI.SetActive(true);
        }
        this.gameObject.SetActive(false);
    }

    public void Damaged(int enemyPower)
    {
        if (GameObject.Find("SE") != null) {
            SeManager se = GameObject.Find("SE").GetComponent<SeManager>();
            se.PlaySE(damageSE);
        }

        int hp = player.Get_hp();
        hp -= enemyPower;
        player.Set_hp(hp);

        if (player.Get_hp() <= 0)
        {
            isDead = true;
        }
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
        player.Set_expTotal(player.Get_expTotal() + 1);
        if (player.Get_exp() >= player.Get_expNextLevel())
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
}
