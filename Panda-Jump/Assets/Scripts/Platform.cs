using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Platform : MonoBehaviour
{
    [SerializeField] private int point;

    private PlatformSpawner ps;
    private GameObject player;
    private Animator anim;

    private Rigidbody2D rb;
    private bool goRight;
    [SerializeField] private float speed;

    void Start()
    {
        goRight= true;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        State();

        Destroy();

        Move();
    }

    private void Move()
    {
        if(transform.position.x > 3.8 && goRight)
        {
            goRight = !goRight;
        }
        if (transform.position.x < -3.8 && !goRight)
        {
            goRight = !goRight;
        }
        if (goRight)
        {
            rb.velocity = new Vector2(1, 0) * speed;
            Debug.Log("right");
        }
        if (!goRight)
        {
            rb.velocity = new Vector2(-1, 0) * speed;
            Debug.Log("left");
        }


    }
    private void State()
    {
        if (!player.GetComponent<PlayerMovement>().FlyState())
        {
            GetComponent<Collider2D>().enabled = true;
        }
        else
        {
            GetComponent<Collider2D>().enabled = false;
        }
    }

    private void Destroy()
    {
        if (player.transform.GetChild(player.transform.childCount - 1).transform.position.y > transform.position.y)
        {
            Destroy(gameObject);
        }
    }
    public void AsignComponents(PlatformSpawner platformSpawner, GameObject player)
    {
        ps = platformSpawner;
        this.player = player;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject otherColl = collision.gameObject;

        if (otherColl.CompareTag("Player"))
        {
            anim.SetBool("collided", true);
            otherColl.GetComponent<PlayerMovement>().AddScore(point);
            if(point != 0)
            {
                float childHeight = transform.parent.GetChild(transform.parent.childCount - 1).transform.position.y;
                ps.Spawn(childHeight+ ps.distance);
            }
            point= 0;

        }
    }
}
