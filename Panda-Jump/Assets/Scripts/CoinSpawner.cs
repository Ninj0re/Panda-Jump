using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : Spawner
{
    public float spawnHeight;
    public float heightToSpawn;
    private System.Random rng = new System.Random();

    void Start()
    {
        heightToSpawn = -7 + distance;
        spawnHeight = -7 + distance * 3;

        Spawn(-7 + distance);
        Spawn(-7 + distance * 2);
        Spawn(-7 + distance * 3);
    }

    void Update()
    {
        if(player.transform.position.y > heightToSpawn)
        {
            int randomizer = rng.Next(3)+ 2;
            heightToSpawn += distance/3 * randomizer;
            spawnHeight += distance/3 * randomizer;

            Spawn(spawnHeight);
        }
    }
    protected override GameObject Spawn(Vector2 spawnPoint)
    {
        GameObject spawnedCoin = base.Spawn(spawnPoint);

        spawnedCoin.GetComponent<Coin>().AsignComponents(GetComponent<CoinSpawner>());
        
        return spawnedCoin;
    }
}
