using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearPiston : MonoBehaviour
{
    [Header("�ړ��ݒ�")]
    public float upperLimit = 5f;  // ����ʒu
    public float lowerLimit = 0f;  // �����ʒu
    public float speed = 2f;       // �ړ����x
    public float interval = 1f;    // �ō��_�E�Œ�_�ł̒�~����

    private bool movingUp = true;  // ���ݏ�����Ɉړ�����
    private bool isPaused = false; // �ꎞ��~�����ǂ���

    void Update()
    {
        if (isPaused) return; // �ꎞ��~���͓��삵�Ȃ�

        // ���݂̈ʒu���擾
        Vector3 currentPosition = transform.position;

        // ������Ɉړ����̏ꍇ
        if (movingUp)
        {
            currentPosition.y += speed * Time.deltaTime;
            if (currentPosition.y >= upperLimit)
            {
                currentPosition.y = upperLimit;
                StartCoroutine(PauseMovement(false)); // �������ɕύX
            }
        }
        else
        {
            // �������Ɉړ�
            currentPosition.y -= speed * Time.deltaTime;
            if (currentPosition.y <= lowerLimit)
            {
                currentPosition.y = lowerLimit;
                StartCoroutine(PauseMovement(true)); // ������ɕύX
            }
        }

        // �I�u�W�F�N�g�̈ʒu���X�V
        transform.position = currentPosition;
    }

    // �ꎞ��~���s���R���[�`��
    private IEnumerator PauseMovement(bool newDirection)
    {
        isPaused = true; // ������~
        yield return new WaitForSeconds(interval); // �w�莞�ԑҋ@
        movingUp = newDirection; // �ړ��������X�V
        isPaused = false; // ������ĊJ
    }
}
