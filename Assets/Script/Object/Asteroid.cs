using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float speed = 30f; // 이동 속도
    public float lifetime = 15f; // 생명 주기
    public int scorePenalty = 300; // 점수 감소량

    private Vector3 direction; // 이동 방향

    void Start()
    {
        // 카메라의 위치를 가져옴
        Camera mainCamera = Camera.main;
        Vector3 cameraPosition = mainCamera.transform.position;

        // 카메라 밖의 랜덤 위치 생성
        Vector3 spawnPosition = cameraPosition + (Random.insideUnitSphere * 50f); // 50 단위 거리

        // 소행성의 초기 위치 설정
        transform.position = spawnPosition;

        // 플레이어의 위치를 가져옴
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            Vector3 playerPosition = player.transform.position;

            // 플레이어 방향으로 이동
            direction = (playerPosition - spawnPosition).normalized; // 방향 벡터
        }

        // 일정 시간 후에 소행성을 삭제
        Destroy(gameObject, lifetime);
    }

    void Update()
    {
        // 설정된 방향으로 이동
        transform.Translate(direction * speed * Time.deltaTime);
    }

    // 충돌 처리
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // 플레이어와 충돌 시 점수 감소
            ScoreManager scoreManager = FindObjectOfType<ScoreManager>();
            if (scoreManager != null)
            {
                scoreManager.AddScore(-scorePenalty); // 점수 감소
            }

            // 소행성 삭제
            Destroy(gameObject);
        }
    }
}
