using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyControllerA : MonoBehaviour
{
    [SerializeField] public GameObject target;
    NavMeshAgent agent;
    Animator animator;
    BoxCollider boxCollider;

    [SerializeField] public GameObject expObjectPrefab;

    [SerializeField] public float attackDistance = 4.0f; 

    public bool capableAttack = false;
    public bool generateExp = false;
    private bool isDead = false;

    EnemyStatus enemy = new EnemyStatus();

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider>();

        target = GameObject.FindWithTag("Player");
        agent.speed = enemy.Get_moveSpeed();
    }

    private void Update()
    {

        if (enemy.Get_hp() <= 0) {
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

            if (generateExp == false) {
                for (int i = 0; i < 3; i++) {
                    GenerateExp();
                }
                generateExp = true;
            }
        }
    }

    // SpiderAttackCollisionÇ©ÇÁåƒÇ—èoÇ≥ÇÍÇÈ
    public void Attack()
    {
        if (capableAttack == true)
        {
            PlayerController playerController = target.gameObject.GetComponent<PlayerController>();
            playerController.Deamaged(enemy.Get_attackPower());
        }
    }

    // BulletManagerÇ©ÇÁåƒÇ—èoÇ≥ÇÍÇÈ
    public void Deamaged(int attackPower)
    {
        int deamage = enemy.Get_hp();
        deamage -= attackPower;
        enemy.Set_hp(deamage);
        //Debug.Log("enemyÇÃhpÇÕ" + enemy.Get_hp());
    }


    private void MoveState()
    {
        capableAttack = false;
        agent.isStopped = false;
        animator.SetBool("attackBool", false);
        animator.SetBool("moveBool", true);
        agent.destination = target.transform.position;
    }
    private void AttackState()
    {
        capableAttack = true;
        agent.isStopped = true;
        animator.SetBool("moveBool", false);
        animator.SetBool("attackBool", true);
    }

    private void DeadState()
    {
        agent.isStopped = true;
        boxCollider.enabled = false;
        animator.SetBool("attackBool", false);
        animator.SetBool("moveBool", false);
        animator.SetBool("deadBool", true);
        Destroy(this.gameObject, 5.0f);
    }

    private void GenerateExp()
    {
        Vector3 genatePos = this.transform.position + Vector3.up;
        GameObject expObject = (GameObject)Instantiate(expObjectPrefab,
                                                       genatePos,
                                                       Quaternion.Euler(90, transform.root.eulerAngles.y, 0));
    }

    public void Set_target(GameObject _target)
    {
        EnemyControllerA obj = gameObject.GetComponent<EnemyControllerA>();
        obj.target = _target;
    }
}

