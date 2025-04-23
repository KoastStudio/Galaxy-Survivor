using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f; // 이동 속도
    public float rotationSpeed = 200f; // 회전 속도
    public GameObject missilePrefab; // 미사일 프리팹
    public Transform missileSpawnPoint; // 미사일 발사 위치

    void Update()
    {
        Move(); // 상하 이동
        Rotate(); // 좌우 회전

        if (Input.GetKeyDown(KeyCode.Space)) // 스페이스바로 미사일 발사
        {
            Shoot();
        }
    }

    void Move()
    {
        float moveY = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime; // 상하 이동
        transform.Translate(0, moveY, 0);
    }

    void Rotate()
    {
        float rotate = Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime; // 좌우 회전
        transform.Rotate(0, 0, -rotate); // z축을 기준으로 회전
    }

    void Shoot()
    {
        Instantiate(missilePrefab, missileSpawnPoint.position, missileSpawnPoint.rotation); // 미사일 발사
    }

    private void Awake()
    {
        // 씬 전환 시에도 플레이어 오브젝트를 유지
        DontDestroyOnLoad(gameObject);
    }
}
