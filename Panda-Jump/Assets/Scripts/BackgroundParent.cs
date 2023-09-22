using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundParent : MonoBehaviour
{
    private float height;
    [SerializeField] private float speed;

    [SerializeField] private bool goingDown;
    [SerializeField] private float timer = 1;
    private float timerCounter;
    void Start()
    {
        height = transform.GetChild(0).GetComponent<SpriteRenderer>().bounds.size.y;
        timerCounter = 0;
    }
    void Update()
    {
        if (transform.position.y < transform.parent.transform.position.y - height)
        {
            Vector3 pos = transform.parent.transform.position;
            transform.position = new Vector3(transform.position.x, pos.y, 10);
        }

        if (goingDown)
        {
            if (timerCounter < timer)
            {
                timerCounter += Time.deltaTime;

                GoDownMovement();
            }
            else
            {
                timerCounter = 0;
                goingDown = false;
            }
        }
    }

    private void GoDownMovement()
    {
        transform.Translate(new Vector3(0, -1, 10) * speed * Time.deltaTime);
    }

    public void GoDown()
    {
        goingDown = true;
    }
}
