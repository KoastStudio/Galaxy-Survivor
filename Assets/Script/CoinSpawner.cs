using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coinPrefab; // ���� ������
    public float spawnDelay = 2f; // ���� ����

    void Start()
    {
        InvokeRepeating("SpawnCoin", 0f, spawnDelay);
    }

    void SpawnCoin()
    {
        // ���� ����
        Instantiate(coinPrefab);
    }
}
