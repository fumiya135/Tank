using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpController : MonoBehaviour
{
    GameObject player;
    SphereCollider expObject;
    Rigidbody rigidbody;

    private void Start()
    {
        expObject = GetComponent<SphereCollider>();
        rigidbody = GetComponent<Rigidbody>();

        Vector3 force = new Vector3(Random.Range(-2, 2), 0, Random.Range(-2, 2));
        rigidbody.AddForce(force * 2, ForceMode.Force);
    }

    public void Update()
    {
        Vector3 acc, vel = Vector3.zero;

        player = GameObject.Find("Tank");

        float distance = Vector3.Distance(player.transform.position, this.gameObject.transform.position);
        if (distance < 5)
        {
            Vector3 diff = (player.transform.position - this.transform.position);
            acc = diff * 0.1f;
            vel += acc;
            vel *= 0.9f;
            transform.position += vel;
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player") == true)
        {
            Destroy(this.gameObject);
            PlayerController obj = collider.gameObject.GetComponent<PlayerController>();
            obj.ExpAdd();
        }
    }
}
