using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsGroundScript : MonoBehaviour
{
    private string groundTag = "Ground";
    private string trampolineTag = "Trampoline"; // �g�����|�����p�^�O
    public bool isGround = false;
    public bool isGroundEnter, isGroundStay, isGroundExit;
    public float bounceForce = 15f; // ���˂��

    private Rigidbody playerRb;

    private void Start()
    {
        // �e�I�u�W�F�N�g�� Rigidbody ���擾
        playerRb = GetComponentInParent<Rigidbody>();
    }

    // �ڒn�����Ԃ����\�b�h
    public bool Ground()
    {
        if (isGroundEnter || isGroundStay)
        {
            isGround = true;
        }
        else if (isGroundExit)
        {
            isGround = false;
        }

        isGroundEnter = false;
        isGroundStay = false;
        isGroundExit = false;
        return isGround;
    }

    private void OnTriggerEnter(Collider other)
    {
        // �n�ʔ���
        if (other.tag == groundTag)
        {
            isGroundEnter = true;
        }

        // �g�����|��������
        if (other.tag == trampolineTag)
        {
            if (playerRb != null)
            {
                // ������ɒ��˂�͂�������
                playerRb.velocity = new Vector3(playerRb.velocity.x, 0, playerRb.velocity.z); // �c�����̑��x�����Z�b�g
                playerRb.AddForce(Vector3.up * bounceForce, ForceMode.Impulse);
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        // �n�ʂɐG��Ă���ꍇ�̏���
        if (other.tag == groundTag)
        {
            isGroundStay = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // �n�ʂ��痣�ꂽ�ꍇ�̏���
        if (other.tag == groundTag)
        {
            isGroundExit = true;
        }
    }

    void Update()
    {
        // ���t���[���ڒn��Ԃ��X�V
        Ground();
    }
}