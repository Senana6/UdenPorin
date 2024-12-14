using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadWallPlayerSearch : MonoBehaviour
{
    private DeadWallMove parentScript; // �e�̃X�N���v�g���Q��
    private bool isTouchingPlayer = false; // Player�ɐG��Ă��邩�ǂ����̃t���O

    void Start()
    {
        // �e�I�u�W�F�N�g�� DeadWallMove �X�N���v�g���擾
        parentScript = GetComponentInParent<DeadWallMove>();

        if (parentScript == null)
        {
            Debug.LogError("�e�I�u�W�F�N�g�� DeadWallMove �X�N���v�g���A�^�b�`����Ă��܂���I");
        }
    }

    void Update()
    {
        if (parentScript != null)
        {
            // Player�ɐG��Ă��Ȃ��ꍇ�APlayerSearch��false�ɐݒ�
            if (!isTouchingPlayer)
            {
                parentScript.PlayerSearch = false;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Player�^�O�̃I�u�W�F�N�g�ɐG�ꂽ�ꍇ
        if (other.CompareTag("Player"))
        {
            isTouchingPlayer = true;
            if (parentScript != null)
            {
                parentScript.PlayerSearch = true; // �e�� PlayerSearch �� true �ɐݒ�
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        // Player�^�O�̃I�u�W�F�N�g���痣�ꂽ�ꍇ
        if (other.CompareTag("Player"))
        {
            isTouchingPlayer = false;
        }
    }
}
