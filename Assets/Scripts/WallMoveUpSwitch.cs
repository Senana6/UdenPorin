//����u������ǂ��オ��X�N���v�g
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMoveUpSwitch : MonoBehaviour
{
    public bool switchPushing = false; // �X�C�b�`��������Ă��邩
    public GameObject UpGround;
    private Vector3 initialPosition; // �����ʒu
    [Header("�����鉺���ʒu������")]
    public float lowerLimit = -10f; // ������Y�ʒu
    [Header("������x�͑������������ǂ�")]
    public float speed = -5f; // �㉺���鑬�x

    // Start is called before the first frame update
    void Start()
    {
        // �����ʒu��ۑ�
        initialPosition = UpGround.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (switchPushing)
        {
            // ���ɉ�����A�����܂ŒB������~�܂�
            if (UpGround.transform.position.y > initialPosition.y + lowerLimit)
            {
                UpGround.transform.position += new Vector3(0, -speed * Time.deltaTime, 0);
            }
        }
        else
        {
            // �����ʒu�܂Ŗ߂�
            if (UpGround.transform.position.y < initialPosition.y)
            {
                UpGround.transform.position += new Vector3(0, speed * Time.deltaTime, 0);
            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "CarryBox")
        {
            switchPushing = true;
        }
    }

    
}
