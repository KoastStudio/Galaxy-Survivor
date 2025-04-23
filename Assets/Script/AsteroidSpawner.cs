using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public GameObject asteroidPrefab; // ���༺ ������
    public float spawnDelay = 0.5f; // ���� ����
    public float spawnDistance = 100f; // ī�޶� �ۿ��� ������ �Ÿ�

    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
        InvokeRepeating("SpawnAsteroid", 0f, spawnDelay);
    }

    void SpawnAsteroid()
    {
        // ī�޶��� ����Ʈ ��ǥ�� ����Ͽ� ���༺ ����
        Vector3 spawnPosition = GetRandomSpawnPosition();

        // ���༺ ����
        Instantiate(asteroidPrefab, spawnPosition, Quaternion.identity);
    }

    Vector3 GetRandomSpawnPosition()
    {
        // ī�޶��� ����Ʈ���� ������ ��ġ ����
        float randomX = Random.Range(0f, 1f);
        float randomY = Random.Range(0f, 1f);

        // ī�޶��� ����Ʈ ��ǥ�� ���� ��ǥ�� ��ȯ
        Vector3 viewportPosition = new Vector3(randomX, randomY, 0);
        Vector3 worldPosition = mainCamera.ViewportToWorldPoint(viewportPosition);

        // ī�޶󿡼� spawnDistance��ŭ ������ ��ġ�� ����
        Vector3 direction = (worldPosition - mainCamera.transform.position).normalized;
        return mainCamera.transform.position + direction * spawnDistance;
    }
}
