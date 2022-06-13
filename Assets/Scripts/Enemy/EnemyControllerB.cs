using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyControllerB : MonoBehaviour
{
    [SerializeField] public GameObject target;
    NavMeshAgent agent;
    //Animator animator;
    BoxCollider boxCollider;

    [SerializeField] public GameObject expObjectPrefab;
    [SerializeField] public GameObject SentryBulletPrefab;
    [SerializeField] public GameObject BulletPoint;
    [SerializeField] public float attackDistance = 4.0f;
    [SerializeField] public float attackCoroutine = 3.0f;

    public bool capableAttack = false;
    public bool generateExp = false;
    private bool isDead = false;
    private bool isAttack = true;

    EnemyStatus enemy = new EnemyStatus();
    private float bulletSpeed = 50;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        //animator = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider>();

        target = GameObject.FindWithTag("Player");
        agent.speed = enemy.Get_moveSpeed();
    }

    private void Update()
    {

        if (enemy.Get_hp() <= 0)
        {
            isDead = true;
        }

        Vector2 targetPos = new Vector2(target.transform.position.x, target.transform.position.z);
        Vector2 agentPos = new Vector2(transform.position.x, transform.position.z);
        if (isDead == false)
        {
            if (attackDistance >= Vector2.Distance(agentPos, targetPos))
            {
                AttackState();
            }
            else
            {
                MoveState();
            }
        }
        else
        {
            DeadState();

            if (generateExp == false)
            {
                for (int i = 0; i < 3; i++)
                {
                    GenerateExp();
                }
                generateExp = true;
            }
        }
        gameObject.transform.LookAt(target.transform.position);
    }

    public void Attack()
    {
        if (capableAttack == true)
        {
            if (isAttack == true)
            {
                // íeÇîÚÇŒÇ∑èàóù
                //GameObject bulletPoint = GameObject.Find("SentryBulletPoint");
                GameObject bullet = (GameObject)Instantiate(SentryBulletPrefab, BulletPoint.transform.position,
                                                            Quaternion.Euler(90, transform.root.eulerAngles.y, 0));
                // playerèÓïÒÇê∂ê¨ÇµÇΩbulletÇ…èëÇ´çûÇﬁ
                SentryBulletManager script = bullet.GetComponent<SentryBulletManager>();
                script.Create(enemy.Get_attackPower());

                Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
                bulletRigidbody.AddForce(BulletPoint.transform.up * bulletSpeed);

                StartCoroutine("ReturnAttackBullet");
            } 
        }
    }

    // BulletManagerÇ©ÇÁåƒÇ—èoÇ≥ÇÍÇÈ
    public void Deamaged(int attackPower)
    {
        int deamage = enemy.Get_hp();
        deamage -= attackPower;
        enemy.Set_hp(deamage);
        Debug.Log("enemyÇÃhpÇÕ" + enemy.Get_hp());
    }


    private void MoveState()
    {
        capableAttack = false;
        agent.isStopped = false;
        //animator.SetBool("attackBool", false);
        //animator.SetBool("moveBool", true);
        agent.destination = target.transform.position;
    }
    private void AttackState()
    {
        capableAttack = true;
        agent.isStopped = true;
        //animator.SetBool("moveBool", false);
        //animator.SetBool("attackBool", true);
        Attack();
    }

    private void DeadState()
    {
        agent.isStopped = true;
        boxCollider.enabled = false;
        //animator.SetBool("attackBool", false);
        //animator.SetBool("moveBool", false);
        //animator.SetBool("deadBool", true);
        Destroy(this.gameObject);
    }

    private void GenerateExp()
    {
        Vector3 genatePos = this.transform.position + Vector3.up;
        GameObject expObject = (GameObject)Instantiate(expObjectPrefab,
                                                       genatePos,
                                                       Quaternion.Euler(90, transform.root.eulerAngles.y, 0));
    }

    private IEnumerator ReturnAttackBullet()
    {
        isAttack = false;
        yield return new WaitForSeconds(attackCoroutine);
        isAttack = true;
    }

    public void Set_target(GameObject _target)
    {
        EnemyControllerB obj = gameObject.GetComponent<EnemyControllerB>();
        obj.target = _target;
    }
}