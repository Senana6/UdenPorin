using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabAndRelease : MonoBehaviour
{
    public Vector3 positionOffset; // �Ǐ]���̈ʒu�I�t�Z�b�g
    public Vector3 rotationOffset; // �Ǐ]���̉�]�I�t�Z�b�g

    private GameObject grabbedObject = null; // ���ݐG��Ă���Grabbable�I�u�W�F�N�g
    private bool isFollowing = false;       // �Ǐ]��ԃt���O

    void Update()
    {
        // R�L�[�܂���B�{�^���������ꂽ�Ƃ�
        if (Input.GetKeyDown(KeyCode.R) || Input.GetButtonDown("BButton"))
        {
            if (isFollowing)
            {
                // �Ǐ]������
                ReleaseObject();
            }
            else if (grabbedObject != null)
            {
                // �Ǐ]���J�n
                StartFollowing(grabbedObject);
            }
        }

        // �Ǐ]���Ȃ�΁A�ʒu�Ɖ�]���X�V
        if (isFollowing && grabbedObject != null)
        {
            grabbedObject.transform.position = transform.position + transform.rotation * positionOffset;
            grabbedObject.transform.rotation = transform.rotation * Quaternion.Euler(rotationOffset);
        }
    }

    private void StartFollowing(GameObject obj)
    {
        // �Ǐ]�J�n
        isFollowing = true;
    }

    private void ReleaseObject()
    {
        // �Ǐ]����
        isFollowing = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        // Grabbable�^�O�̃I�u�W�F�N�g�ɐG�ꂽ�Ƃ�
        if (other.CompareTag("Grabbable"))
        {
            grabbedObject = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Grabbable�^�O�̃I�u�W�F�N�g���痣�ꂽ�Ƃ�
        if (other.gameObject == grabbedObject)
        {
            grabbedObject = null;
        }
    }
}
