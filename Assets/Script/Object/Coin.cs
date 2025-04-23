using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public float lifetime = 5f; // ���� �ֱ�
    public int scoreValue = 500; // ���� ����

    void Start()
    {
        // ī�޶��� ��ġ�� ������
        Camera mainCamera = Camera.main;
        Vector3 cameraPosition = mainCamera.transform.position;

        // ī�޶� ���� ���� ��ġ ����
        Vector3 spawnPosition = cameraPosition + (Random.insideUnitSphere * 50f); // 50 ���� �Ÿ�

        // ������ �ʱ� ��ġ ����
        transform.position = spawnPosition;

        // ���� �ð� �Ŀ� ������ ����
        Destroy(gameObject, lifetime);
    }

    // �浹 ó��
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // �÷��̾�� �浹 �� ���� �߰�
            ScoreManager scoreManager = FindObjectOfType<ScoreManager>();
            if (scoreManager != null)
            {
                scoreManager.AddScore(scoreValue); // ���� ����
            }

            // ���� ����
            Destroy(gameObject);
        }
    }
}
