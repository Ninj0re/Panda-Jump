using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : Spawner
{

    void Start()
    {
        Spawn(new Vector2(-3.2f, -5 + distance));
        Spawn(-5 + distance * 2);
        Spawn(-5 + distance * 3);
        Spawn(-5 + distance * 4);
        Spawn(-5 + distance * 5);
        Spawn(-5 + distance * 6);
    }
    protected override GameObject Spawn(Vector2 spawnPoint)
    {
        GameObject spawnedPlatform = base.Spawn(spawnPoint);

        spawnedPlatform.GetComponent<Platform>().AsignComponents(GetComponent<PlatformSpawner>(), player);

        return spawnedPlatform;
    }
}
