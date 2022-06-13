using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    [SerializeField] GameObject explosionPrefab;
    public static int power;

    /// <summary>
    ///  PlayerStatus.cs からplayer情報を取得するための関数
    /// </summary>
    public void Create(int attackPower)
    {
        BulletManager.power = attackPower;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("EnemyA"))
        {
            string objName = collision.gameObject.name;
            //Debug.Log(collision.gameObject.name);
            EnemyControllerA obj = collision.gameObject.GetComponent<EnemyControllerA>();
            obj.Deamaged(power);
        }
        if (collision.gameObject.CompareTag("EnemyB"))
        {
            string objName = collision.gameObject.name;
            //Debug.Log(collision.gameObject.name);
            EnemyControllerB obj = collision.gameObject.GetComponent<EnemyControllerB>();
            obj.Deamaged(power);
        }
        Destroy(this.gameObject);
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        //Debug.Log("Bulletに衝突したオブジェクト：" + collision.gameObject.name);
    }
}
