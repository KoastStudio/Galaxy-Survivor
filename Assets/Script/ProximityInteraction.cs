using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using static PlayerController;

public class ProximityInteraction : MonoBehaviour
{
    public GameObject uiObject; // UI ������Ʈ (��Ȱ��ȭ ���¿��� ����)
    public Transform player; // �÷��̾� �Ǵ� ī�޶�
    public float interactionRange = 5f; // ��ȣ�ۿ� ����

    private void Update()
    {
        // �÷��̾�� ������Ʈ�� �Ÿ� ���
        float distance = Vector3.Distance(player.position, transform.position);

        // �Ÿ� ���� ������ UI Ȱ��ȭ
        if (distance < interactionRange)
        {
            uiObject.SetActive(true);

            // FŰ�� ������ �� ���� ������ ��ȯ
            if (Input.GetKeyDown(KeyCode.F))
            {
                // ���� ������ ��ȯ
                SceneManager.LoadScene("InsideShip");
            }
        }
        else
        {
            uiObject.SetActive(false); // ������ ����� UI ��Ȱ��ȭ
        }
    }
}
