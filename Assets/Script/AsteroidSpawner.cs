using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public GameObject asteroidPrefab; // 소행성 프리팹
    public float spawnDelay = 0.5f; // 생성 간격
    public float spawnDistance = 100f; // 카메라 밖에서 생성할 거리

    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
        InvokeRepeating("SpawnAsteroid", 0f, spawnDelay);
    }

    void SpawnAsteroid()
    {
        // 카메라의 뷰포트 좌표를 사용하여 소행성 생성
        Vector3 spawnPosition = GetRandomSpawnPosition();

        // 소행성 생성
        Instantiate(asteroidPrefab, spawnPosition, Quaternion.identity);
    }

    Vector3 GetRandomSpawnPosition()
    {
        // 카메라의 뷰포트에서 랜덤한 위치 선택
        float randomX = Random.Range(0f, 1f);
        float randomY = Random.Range(0f, 1f);

        // 카메라의 뷰포트 좌표를 월드 좌표로 변환
        Vector3 viewportPosition = new Vector3(randomX, randomY, 0);
        Vector3 worldPosition = mainCamera.ViewportToWorldPoint(viewportPosition);

        // 카메라에서 spawnDistance만큼 떨어진 위치로 조정
        Vector3 direction = (worldPosition - mainCamera.transform.position).normalized;
        return mainCamera.transform.position + direction * spawnDistance;
    }
}
