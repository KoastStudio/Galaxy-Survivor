using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // ���� ������Ʈ (�÷��̾�)
    public float smoothSpeed = 0.125f; // �ε巯�� �̵� �ӵ�
    public Vector3 offset; // ī�޶�� Ÿ�� ���� ������
    public float zOffset = -10f; // ī�޶� Z�� ����

    void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset; // ��ǥ ��ġ
        desiredPosition.z = zOffset; // Z���� ����
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed); // �ε巴�� �̵�
        transform.position = smoothedPosition; // ī�޶� ��ġ ������Ʈ
    }
    private void Awake()
    {
        // �� ��ȯ �ÿ��� �÷��̾� ������Ʈ�� ����
        DontDestroyOnLoad(gameObject);
    }

}
