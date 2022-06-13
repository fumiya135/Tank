using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] public Transform target;

    [SerializeField, Range(3.0f, 50.0f)] public float heightToPlayer = 30.0f;
    [SerializeField, Range(0f, 50.0f)] public float weightToPlayer = 5.0f;

    void Start()
    {
        gameObject.transform.rotation = Quaternion.identity;
    }

    void Update()
    {
        Vector3 distance;
        Vector3 targetPos = target.transform.position;
        distance = new Vector3(0, heightToPlayer, weightToPlayer);
        transform.position = targetPos + distance;

        transform.LookAt(target);
    }
}
