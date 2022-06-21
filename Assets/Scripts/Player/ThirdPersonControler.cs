using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonControler : MonoBehaviour
{
    private float moveSpeed = 15;
    private float turnSpeed = 5;

    // 注意点
    [SerializeField] public GameObject debugLookPoint;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Move();
        Turn();
        Camerawork();
    }

    void Camerawork()
    {
        Plane plane = new Plane();
        float distance = 0f;
        // カメラとマウスの位置を元にRayを準備
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        // プレイヤーの高さにPlaneを更新して、カメラの情報を元に地面判定して距離を取得
        plane.SetNormalAndPosition(Vector3.up, transform.localPosition);
        if (plane.Raycast(ray, out distance))
        {
            // 距離を元に交点を算出して、交点の方を向く
            Vector3 lookPoint = ray.GetPoint(distance);
            debugLookPoint.transform.position = lookPoint;
        }
    }

    void Move()
    {
        PlayerController controller = gameObject.GetComponent<PlayerController>();
        moveSpeed = controller.player.Get_moveSpeed();

        float movementInputValue = Input.GetAxis("Vertical");
        if (movementInputValue != null)
        {
            Vector3 movement = transform.forward * movementInputValue * moveSpeed * Time.deltaTime;
            rb.MovePosition(rb.position + movement);
        }
    }

    void Turn()
    {
        PlayerController controller = gameObject.GetComponent<PlayerController>();
        turnSpeed = controller.player.Get_turnSpeed();

        float turnInputValue = Input.GetAxis("Horizontal");
        if (turnInputValue != null)
        {
            float turn = turnInputValue * turnSpeed * Time.deltaTime;
            Quaternion turnRotation = Quaternion.Euler(0, turn, 0);
            rb.MoveRotation(rb.rotation * turnRotation);
        }
    }
}