using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coinPrefab; // 内牢 橇府普
    public float spawnDelay = 2f; // 积己 埃拜

    void Start()
    {
        InvokeRepeating("SpawnCoin", 0f, spawnDelay);
    }

    void SpawnCoin()
    {
        // 内牢 积己
        Instantiate(coinPrefab);
    }
}
