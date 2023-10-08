using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lava : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private PlayerMovement player;

    void Update()
    {
        if (player.GetScore() != 0)
            transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    public void LavaPos(Vector2 pos)
    {
        if(pos.y - 5> transform.position.y)
            transform.position = new Vector2(transform.position.x, pos.y -5);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Time.timeScale = 1;
            EndGameManager.SetHighScore(player.GetScore());
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

    }
}
