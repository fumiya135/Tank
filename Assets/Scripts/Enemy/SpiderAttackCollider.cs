using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderAttackCollider : MonoBehaviour
{
    [SerializeField] public GameObject spider;
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            EnemyControllerA obj = spider.gameObject.GetComponent<EnemyControllerA>();
            obj.Attack();
        }
    }
}
