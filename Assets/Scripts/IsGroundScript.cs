using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsGroundScript : MonoBehaviour
{
    private string groundTag = "Ground";
    public bool isGround = false;
    public bool isGroundEnter, isGroundStay, isGroundExit;

    //�ڒn�����Ԃ����\�b�h
    //��������̍X�V���ɌĂԕK�v������
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
        if (other.tag == groundTag)
        {
            isGroundEnter = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == groundTag)
        {
            isGroundStay = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
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
