using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : Spawner
{
    private System.Random rng = new System.Random();

    void Start()
    {
        Spawn(-7 + distance);
        Spawn(-7 + distance * 2);
        Spawn(-7 + distance * 3);
    }
    protected override GameObject Spawn(Vector2 spawnPoint)
    {
        GameObject spawnedCoin = base.Spawn(spawnPoint);

        spawnedCoin.GetComponent<Coin>().AsignComponents(GetComponent<CoinSpawner>());
        Coin.spawnHeight = spawnPoint.y + distance;
        
        return spawnedCoin;
    }
}
