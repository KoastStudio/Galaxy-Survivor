using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f; // �̵� �ӵ�
    public float rotationSpeed = 200f; // ȸ�� �ӵ�
    public GameObject missilePrefab; // �̻��� ������
    public Transform missileSpawnPoint; // �̻��� �߻� ��ġ

    void Update()
    {
        Move(); // ���� �̵�
        Rotate(); // �¿� ȸ��

        if (Input.GetKeyDown(KeyCode.Space)) // �����̽��ٷ� �̻��� �߻�
        {
            Shoot();
        }
    }

    void Move()
    {
        float moveY = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime; // ���� �̵�
        transform.Translate(0, moveY, 0);
    }

    void Rotate()
    {
        float rotate = Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime; // �¿� ȸ��
        transform.Rotate(0, 0, -rotate); // z���� �������� ȸ��
    }

    void Shoot()
    {
        Instantiate(missilePrefab, missileSpawnPoint.position, missileSpawnPoint.rotation); // �̻��� �߻�
    }

    private void Awake()
    {
        // �� ��ȯ �ÿ��� �÷��̾� ������Ʈ�� ����
        DontDestroyOnLoad(gameObject);
    }
}
