using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public Transform player;  // �v���C���[��Transform�������ɃA�^�b�`

    // �J�����ƃv���C���[�̃I�t�Z�b�g
    private Vector3 offset = new Vector3(0, 0.15f, -0.8f);

    void LateUpdate()
    {
        // �v���C���[�̍��W�ɃI�t�Z�b�g�������ăJ������Ǐ]������
        transform.position = player.position + offset;
    }
}
