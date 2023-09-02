using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    [SerializeField] private GameObject platform;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject platformParent;

    public float distance;
    void Start()
    {
        Spawn(-5 + distance -.5f);
        Spawn(-5 + distance * 2);
        Spawn(-5 + distance * 3);
        Spawn(-5 + distance * 4);
        Spawn(-5 + distance * 5);
        Spawn(-5 + distance * 6);
    }

    public void Spawn(Vector2 spawnPoint)
    {

        GameObject spawnedPlatform = Instantiate(platform, new Vector2(spawnPoint.x, spawnPoint.y), transform.rotation);

        spawnedPlatform.GetComponent<Platform>().AsignComponents(GetComponent<PlatformSpawner>(), player);

        spawnedPlatform.transform.parent = platformParent.transform;
    }
    public void Spawn(float spawnHeight)
    {
        var rng = new System.Random();
        double xValue = rng.NextDouble() * 7.6 - 3.8;

        Spawn(new Vector2((float)xValue, spawnHeight));
    }
}
