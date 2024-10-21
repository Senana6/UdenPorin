//�T���v���V�[���̃f�o�b�O�p�L�����̃X�N���v�g

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleStagePlayer : MonoBehaviour
{
    public float moveSpeed = 5f; // �ړ����x
    public float jumpForce = 7f; // �W�����v�̗�
    private bool isGrounded; // �v���C���[���n�ʂɂ��邩�ǂ���
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Rigidbody�R���|�[�l���g���擾
    }

    void Update()
    {
        Move();
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }
    }

    void Move()
    {
        float moveHorizontal = Input.GetAxis("Horizontal"); // AD�L�[���� (A: -1, D: 1)

        // X���ɉ����č��E�ړ�
        Vector3 movement = new Vector3(moveHorizontal, 0f, 0f) * moveSpeed * Time.deltaTime;
        rb.MovePosition(transform.position + movement);
    }

    void Jump()
    {
        // ������ɗ͂������ăW�����v
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        isGrounded = false; // �󒆂ɂ����Ԃɐ؂�ւ�
    }

    // �n�ʂɐڐG���Ă��邩���m�F
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true; // �n�ʂɐڐG���Ă���Ƃ��ɃW�����v�\��Ԃɖ߂�
        }
    }
}
