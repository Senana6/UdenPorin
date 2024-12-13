using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beltconveyor : MonoBehaviour
{
    [SerializeField] private float conveyorSpeed = 1.0f; // �R���x�A�̑��x
    [SerializeField] public bool conveyorMove = true;   // �R���x�A���������ǂ���

    private void OnCollisionStay(Collision collision)
    {
        if (conveyorMove && collision.rigidbody != null)
        {
            // �R���x�A�̃��[�J�����W -X �����Ɉړ��͂�������
            Vector3 conveyorDirection = -transform.right * conveyorSpeed;

            // �ڐG�I�u�W�F�N�g�̑��x�ɃR���x�A�̑��x�����Z
            collision.rigidbody.velocity += conveyorDirection;
        }
    }
}
