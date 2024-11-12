using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZoneScript : MonoBehaviour
{
    public GameObject Player1;
    public GameObject Player2;
    public float respawnDelay = 1f; // ���X�|�[���̒x������

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Player1)
        {
            // Player1���G�ꂽ�ꍇ�APlayer2�̋߂��Ń��X�|�[��
            StartCoroutine(RespawnPlayer(Player1, Player2.transform.position));
        }
        else if (other.gameObject == Player2)
        {
            // Player2���G�ꂽ�ꍇ�APlayer1�̋߂��Ń��X�|�[��
            StartCoroutine(RespawnPlayer(Player2, Player1.transform.position));
        }
    }

    private IEnumerator RespawnPlayer(GameObject player, Vector3 targetPosition)
    {
        // ���X�|�[���̒x��
        yield return new WaitForSeconds(respawnDelay);

        // ���X�|�[���ʒu�̐ݒ�
        Vector3 respawnPosition = new Vector3(targetPosition.x, targetPosition.y+2, targetPosition.z);
        player.transform.position = respawnPosition;
    }
}
