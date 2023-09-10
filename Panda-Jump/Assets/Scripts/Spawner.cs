using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] protected GameObject spawnObject;
    [SerializeField] protected GameObject player;
    [SerializeField] protected GameObject spawnObjectParent;

    public float distance;

    protected virtual GameObject Spawn(Vector2 spawnPoint)
    {

        GameObject spawnedObject = Instantiate(spawnObject, new Vector2(spawnPoint.x, spawnPoint.y), transform.rotation);

        spawnedObject.transform.parent = spawnObjectParent.transform;

        return spawnedObject;
    }
    public void Spawn(float spawnHeight)
    {
        var rng = new System.Random();
        double xValue = rng.NextDouble() * 7.6 - 3.8;

        Spawn(new Vector2((float)xValue, spawnHeight));
    }
}
