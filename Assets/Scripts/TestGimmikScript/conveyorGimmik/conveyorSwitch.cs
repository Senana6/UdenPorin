//���̃X�N���v�g�̓g���K�[�ɃA�^�b�`���鎖

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class conveyorSwitch : MonoBehaviour
{
    public GameObject BeltConveyor; // ���䂷��x���g�R���x�A�I�u�W�F�N�g
    private Beltconveyor beltConveyorScript; // �x���g�R���x�A�̃X�N���v�g

    private void Start()
    {
        // BeltConveyor ���� Beltconveyor �X�N���v�g���擾
        if (BeltConveyor != null)
        {
            beltConveyorScript = BeltConveyor.GetComponent<Beltconveyor>();
        }
        else
        {
            Debug.LogError("BeltConveyor �����蓖�Ă��Ă��܂���I");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // �v���C���[���X�C�b�`�ɐG�ꂽ�ꍇ
        if (other.CompareTag("Player") && beltConveyorScript != null)
        {
            beltConveyorScript.conveyorMove = false; // �R���x�A���~
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // �v���C���[���X�C�b�`���痣�ꂽ�ꍇ
        if (other.CompareTag("Player") && beltConveyorScript != null)
        {
            beltConveyorScript.conveyorMove = true; // �R���x�A���ĊJ
        }
    }


}
