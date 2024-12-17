using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    public float scrollSpeedX = 0.5f; // X�����̃X�N���[�����x
    public float scrollSpeedY = 0.0f; // Y�����̃X�N���[�����x
    private Material backgroundMaterial;
    private Vector2 offset;

    void Start()
    {
        // �w�i�̃}�e���A�����擾
        backgroundMaterial = GetComponent<Renderer>().material;
        offset = backgroundMaterial.mainTextureOffset;
    }

    void Update()
    {
        // �L�����N�^�[�̑��x�⎞�Ԃɉ����ăI�t�Z�b�g��ύX
        offset.x += scrollSpeedX * Time.deltaTime;
        offset.y += scrollSpeedY * Time.deltaTime;

        // �I�t�Z�b�g���}�e���A���ɓK�p
        backgroundMaterial.mainTextureOffset = offset;
    }
}
