using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeBulletManager : MonoBehaviour
{
    [SerializeField] GameObject bigExplosionPrefab;
    [SerializeField] AudioClip explosionSE;
    public static int power;

    // �������̕����̏����̂��߂̃��X�g
    public List<GameObject> hitEnemys = new List<GameObject>();

    /// <summary>
    ///  PlayerStatus.cs ����player�����擾���邽�߂̊֐�
    /// </summary>
    public void Create(int attackPower)
    {
        ChargeBulletManager.power = attackPower;
    }

    private void OnCollisionEnter(Collision collision)
    {
        for (int i = 0; i < hitEnemys.Count; i++)
        {
            GameObject enemy = hitEnemys[i].gameObject;
            if (enemy.gameObject.CompareTag("EnemyA"))
            {
                EnemyControllerA obj = enemy.gameObject.GetComponent<EnemyControllerA>();
                obj.Deamaged(power);
            }
            if (enemy.gameObject.CompareTag("EnemyB"))
            {
                EnemyControllerB obj = enemy.gameObject.GetComponent<EnemyControllerB>();
                obj.Deamaged(power);
            }
            //Debug.Log(hitEnemys[i].gameObject.name);
        }

        if (GameObject.Find("SE") != null)
        {
            SeManager se = GameObject.Find("SE").GetComponent<SeManager>();
            se.PlaySE(explosionSE);
        }

        //Debug.Log(hitEnemys.Count);

        Destroy(this.gameObject);
        Instantiate(bigExplosionPrefab, transform.position, Quaternion.identity);
        //Debug.Log("Bullet�ɏՓ˂����I�u�W�F�N�g�F" + collision.gameObject.name);
    }

    private void ExplosionA(GameObject enemy)
    {
        EnemyControllerA obj = enemy.gameObject.GetComponent<EnemyControllerA>();
        obj.Deamaged(power);
    }

    private void ExplosionB(GameObject enemy)
    {
        EnemyControllerB obj = enemy.gameObject.GetComponent<EnemyControllerB>();
        obj.Deamaged(power);
    }

    ///  �����蔻�����Enemy�����X�g��

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("EnemyA") || other.gameObject.CompareTag("EnemyB"))
        {
            hitEnemys.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("EnemyA") || other.gameObject.CompareTag("EnemyB"))
        {
            for (int i = 0; i < hitEnemys.Count; i++)
            {
                if (hitEnemys[i] == other.gameObject)
                {
                    hitEnemys.RemoveAt(i);
                }
            }
        }
    }
}
