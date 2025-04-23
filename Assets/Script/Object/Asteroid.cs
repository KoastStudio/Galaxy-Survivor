using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float speed = 30f; // �̵� �ӵ�
    public float lifetime = 15f; // ���� �ֱ�
    public int scorePenalty = 300; // ���� ���ҷ�

    private Vector3 direction; // �̵� ����

    void Start()
    {
        // ī�޶��� ��ġ�� ������
        Camera mainCamera = Camera.main;
        Vector3 cameraPosition = mainCamera.transform.position;

        // ī�޶� ���� ���� ��ġ ����
        Vector3 spawnPosition = cameraPosition + (Random.insideUnitSphere * 50f); // 50 ���� �Ÿ�

        // ���༺�� �ʱ� ��ġ ����
        transform.position = spawnPosition;

        // �÷��̾��� ��ġ�� ������
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            Vector3 playerPosition = player.transform.position;

            // �÷��̾� �������� �̵�
            direction = (playerPosition - spawnPosition).normalized; // ���� ����
        }

        // ���� �ð� �Ŀ� ���༺�� ����
        Destroy(gameObject, lifetime);
    }

    void Update()
    {
        // ������ �������� �̵�
        transform.Translate(direction * speed * Time.deltaTime);
    }

    // �浹 ó��
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // �÷��̾�� �浹 �� ���� ����
            ScoreManager scoreManager = FindObjectOfType<ScoreManager>();
            if (scoreManager != null)
            {
                scoreManager.AddScore(-scorePenalty); // ���� ����
            }

            // ���༺ ����
            Destroy(gameObject);
        }
    }
}
