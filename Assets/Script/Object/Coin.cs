using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public float lifetime = 5f; // 생명 주기
    public int scoreValue = 500; // 코인 점수

    void Start()
    {
        // 카메라의 위치를 가져옴
        Camera mainCamera = Camera.main;
        Vector3 cameraPosition = mainCamera.transform.position;

        // 카메라 밖의 랜덤 위치 생성
        Vector3 spawnPosition = cameraPosition + (Random.insideUnitSphere * 50f); // 50 단위 거리

        // 코인의 초기 위치 설정
        transform.position = spawnPosition;

        // 일정 시간 후에 코인을 삭제
        Destroy(gameObject, lifetime);
    }

    // 충돌 처리
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // 플레이어와 충돌 시 점수 추가
            ScoreManager scoreManager = FindObjectOfType<ScoreManager>();
            if (scoreManager != null)
            {
                scoreManager.AddScore(scoreValue); // 점수 증가
            }

            // 코인 삭제
            Destroy(gameObject);
        }
    }
}
