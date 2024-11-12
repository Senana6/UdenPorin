using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTraffic : MonoBehaviour
{
    public Material RedTraffic;
    public Material BlueTraffic;

    public GameObject Player1;
    public GameObject Player2;

    public float switchInterval = 2.0f; 
    private Renderer objRenderer;

    public bool IsRed = true;

    // Start is called before the first frame update
    void Start()
    {
        objRenderer = GetComponent<Renderer>();
        StartCoroutine(SwitchColor());
    }

   
    IEnumerator SwitchColor()
    {
        while (true)
        {
            if (IsRed)
            {
                objRenderer.material = RedTraffic;
            }
            else
            {
                objRenderer.material = BlueTraffic;
            }

            // �F�𔽓]
            IsRed = !IsRed;

            // �w�肵���Ԋu�����҂�
            yield return new WaitForSeconds(switchInterval);
        }
    }

    // �g���K�[�ɓ������Ƃ��̏���
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Player1 || other.gameObject == Player2)
        {
            UpdatePlayerMovement();
        }
    }

    // �g���K�[����o���Ƃ��̏���
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == Player1 || other.gameObject == Player2)
        {
            // �v���C���[���g���K�[����o���瓮����悤�ɂ���
            EnablePlayerMovement(Player1, true);
            EnablePlayerMovement(Player2, true);
        }
    }

    // �v���C���[�̓������X�V����
    private void UpdatePlayerMovement()
    {
        if (IsRed)
        {
            EnablePlayerMovement(Player1, true);  // Player1�͓�����
            EnablePlayerMovement(Player2, false); // Player2�͓����Ȃ�
        }
        else
        {
            EnablePlayerMovement(Player1, false); // Player1�͓����Ȃ�
            EnablePlayerMovement(Player2, true);  // Player2�͓�����
        }
    }

    // �v���C���[��MovementScript��L���܂��͖����ɂ���
    private void EnablePlayerMovement(GameObject player, bool enable)
    {
        var movementScript = player.GetComponent<SampleStagePlayer>(); // MovementScript�͊e�v���C���[�̈ړ��𐧌䂷��X�N���v�g��
        if (movementScript != null)
        {
            movementScript.enabled = enable;
        }
    }

}
