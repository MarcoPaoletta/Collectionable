using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject coinPrefab;

    void InstantiateCoins(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            // instiantiate the coin prefab
            // generate a random position to each coin
            // not change the rotation
            GameObject coin = Instantiate(coinPrefab, new Vector3(Random.Range(-8.5f, 8.5f), Random.Range(-4.5f, 4.5f)), Quaternion.identity);
        }
    }

    void Start()
    {
        InstantiateCoins(20);
    }

}
