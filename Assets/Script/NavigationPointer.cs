using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigationPointer : MonoBehaviour
{
    public Transform target; // 방향을 가리킬 타겟 오브젝트
    public Camera mainCamera; // 메인 카메라
    public float offset = 0.1f; // 카메라 테두리에서의 오프셋

    void Update()
    {
        if (target != null && mainCamera != null)
        {
            // 타겟의 위치로부터 방향 벡터 계산
            Vector3 direction = target.position - mainCamera.transform.position;
            direction.Normalize();

            // 타겟 방향으로 회전
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

            // 카메라의 뷰포트 좌표를 사용하여 테두리에 위치 설정
            Vector3 viewportPosition = mainCamera.WorldToViewportPoint(target.position);
            Vector3 screenPosition;

            // 뷰포트 좌표의 범위를 체크하여 테두리 위치를 결정
            if (viewportPosition.x < 0.5f) // 왼쪽
                screenPosition = new Vector3(0 + offset, viewportPosition.y, 0);
            else // 오른쪽
                screenPosition = new Vector3(1 - offset, viewportPosition.y, 0);

            if (viewportPosition.y < 0.5f) // 아래쪽
                screenPosition = new Vector3(screenPosition.x, 0 + offset, 0);
            else // 위쪽
                screenPosition = new Vector3(screenPosition.x, 1 - offset, 0);

            // 뷰포트 좌표를 월드 좌표로 변환
            transform.position = mainCamera.ViewportToWorldPoint(screenPosition + new Vector3(0, 0, 10)); // z 값 조정
        }
    }
}
