//�tL���̕ǂ��㏸������X�C�b�`�̃X�N���v�gby�Ћ˕���

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallRisingSwitch : MonoBehaviour
{
    public bool switchPushing = false;//�X�C�b�`��������Ă��邩
    public GameObject SwitchTrriger;
    public GameObject LWall;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (switchPushing)
        {
            LWall.transform.position += new Vector3(0, 1 * Time.deltaTime, 0);
        }
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "MonotaCarryBox")
        {
            switchPushing = true;
            //Debug.Log("MonotaCarryBox���g���K�[�ɐG��Ă���");
        }
    }

    // �g���K�[����o����
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "MonotaCarryBox")
        {
            switchPushing = false;
        }
    }

}
