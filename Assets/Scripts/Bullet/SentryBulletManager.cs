using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SentryBulletManager : MonoBehaviour
{
    [SerializeField] GameObject explosionPrefab;
    private static int power;

    /// <summary>
    ///  PlayerStatus.cs ����player�����擾���邽�߂̊֐�
    /// </summary>
    public void Create(int attackPower)
    {
        SentryBulletManager.power = attackPower;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            string objName = collision.gameObject.name;
            Debug.Log(collision.gameObject.name);
            PlayerController obj = collision.gameObject.GetComponent<PlayerController>();
            obj.Deamaged(power);
        }
        Destroy(this.gameObject);
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        //Debug.Log("Bullet�ɏՓ˂����I�u�W�F�N�g�F" + collision.gameObject.name);
    }
}
