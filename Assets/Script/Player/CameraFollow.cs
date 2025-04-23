using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // 따라갈 오브젝트 (플레이어)
    public float smoothSpeed = 0.125f; // 부드러운 이동 속도
    public Vector3 offset; // 카메라와 타겟 간의 오프셋
    public float zOffset = -10f; // 카메라 Z값 고정

    void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset; // 목표 위치
        desiredPosition.z = zOffset; // Z값을 고정
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed); // 부드럽게 이동
        transform.position = smoothedPosition; // 카메라 위치 업데이트
    }
    private void Awake()
    {
        // 씬 전환 시에도 플레이어 오브젝트를 유지
        DontDestroyOnLoad(gameObject);
    }

}
