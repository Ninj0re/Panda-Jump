using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int coin;
    [SerializeField] private CoinSpawner coinSpawner;
    public static float spawnHeight;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerMovement pm = collision.gameObject.GetComponent<PlayerMovement>();
        if (pm != null)
        {
            pm.AddCoin(coin);
            coinSpawner.Spawn(spawnHeight);
            Destroy(gameObject);
        }
    }

    public void AsignComponents(CoinSpawner cn)
    {
        coinSpawner = cn;
    }
}
