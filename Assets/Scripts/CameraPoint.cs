using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPoint : MonoBehaviour
{
    public GameObject Player1;  // �I�u�W�F�N�g1
    public GameObject Player2;  // �I�u�W�F�N�g2
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Player1 != null && Player2 != null)
        {
            // �I�u�W�F�N�g1�ƃI�u�W�F�N�g2�̈ʒu���擾
            Vector3 position1 = Player1.transform.position;
            Vector3 position2 = Player2.transform.position;

            // ���Ԓn�_���v�Z
            Vector3 midpoint = (position1 + position2) / 2;

            // ���̃X�N���v�g���A�^�b�`���ꂽGamePlayer�𒆊Ԓn�_�Ɉړ�
            transform.position = midpoint;
        }
    }
}
