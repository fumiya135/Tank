using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event3_enemy : MonoBehaviour
{
    [SerializeField] public GameObject expObjectPrefab;

    public bool isDead = false;

    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }


    private void Dead()
    {
        isDead = true;

        animator.SetBool("deadBool", true);
        Destroy(this.gameObject, 2.0f);
        for (int i = 0; i < 3; i++)
        {
            //GenerateExp();
        }
        StartCoroutine("DeadCoroutine");
    }
    private void GenerateExp()
    {
        Vector3 genatePos = this.transform.position + Vector3.up;
        GameObject expObject = (GameObject)Instantiate(expObjectPrefab,
                                                       genatePos,
                                                       Quaternion.Euler(90, transform.root.eulerAngles.y, 0));
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Dead();
        }
    }

    private IEnumerator DeadCoroutine()
    {
        yield return new WaitForSeconds(2);
        this.gameObject.SetActive(false);
    }
}
