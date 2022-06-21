using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonControler : MonoBehaviour
{
    private float moveSpeed = 15;
    private float turnSpeed = 5;

    // ���ӓ_
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
        // �J�����ƃ}�E�X�̈ʒu������Ray������
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        // �v���C���[�̍�����Plane���X�V���āA�J�����̏������ɒn�ʔ��肵�ċ������擾
        plane.SetNormalAndPosition(Vector3.up, transform.localPosition);
        if (plane.Raycast(ray, out distance))
        {
            // ���������Ɍ�_���Z�o���āA��_�̕�������
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