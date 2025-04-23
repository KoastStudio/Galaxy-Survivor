using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigationPointer : MonoBehaviour
{
    public Transform target; // ������ ����ų Ÿ�� ������Ʈ
    public Camera mainCamera; // ���� ī�޶�
    public float offset = 0.1f; // ī�޶� �׵θ������� ������

    void Update()
    {
        if (target != null && mainCamera != null)
        {
            // Ÿ���� ��ġ�κ��� ���� ���� ���
            Vector3 direction = target.position - mainCamera.transform.position;
            direction.Normalize();

            // Ÿ�� �������� ȸ��
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

            // ī�޶��� ����Ʈ ��ǥ�� ����Ͽ� �׵θ��� ��ġ ����
            Vector3 viewportPosition = mainCamera.WorldToViewportPoint(target.position);
            Vector3 screenPosition;

            // ����Ʈ ��ǥ�� ������ üũ�Ͽ� �׵θ� ��ġ�� ����
            if (viewportPosition.x < 0.5f) // ����
                screenPosition = new Vector3(0 + offset, viewportPosition.y, 0);
            else // ������
                screenPosition = new Vector3(1 - offset, viewportPosition.y, 0);

            if (viewportPosition.y < 0.5f) // �Ʒ���
                screenPosition = new Vector3(screenPosition.x, 0 + offset, 0);
            else // ����
                screenPosition = new Vector3(screenPosition.x, 1 - offset, 0);

            // ����Ʈ ��ǥ�� ���� ��ǥ�� ��ȯ
            transform.position = mainCamera.ViewportToWorldPoint(screenPosition + new Vector3(0, 0, 10)); // z �� ����
        }
    }
}
