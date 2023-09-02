using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;

public class PlayerMovement : MonoBehaviour
{
    private Camera mainCam;
    private Vector2 touchPos;
    private bool moveState;

    [SerializeField] private float speed;
    [SerializeField] private float jumpSpeed;
    private Rigidbody2D rb;

    private int score;

    void Awake()
    {
        mainCam = Camera.main;
        touchPos = Vector2.zero;
        moveState = false;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Input();
        Move();
    }
    private void Input()
    {
        
        if (Touch.fingers[0].isActive)
        {
            var touch = Touch.activeTouches[0];
            touchPos = touch.screenPosition;

            touchPos = mainCam.ScreenToWorldPoint(touchPos);
            moveState= true;
        }
        else
        {
            moveState = false;
            touchPos = Vector2.zero;   
        }
            
    }

    private void Move()
    {
        if (moveState)
        {
            transform.Translate(new Vector2(touchPos.x - transform.position.x, 0) * speed * Time.deltaTime);
        }
    }

    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
    }
    private void OnEnable()
    {
        EnhancedTouchSupport.Enable();
    }

    private void OnDisable()
    {
        EnhancedTouchSupport.Disable();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 6)
        {
            if(rb.velocity.y <= 0)
                Jump();
        }
    }

    public void AddScore(int point)
    {
        score += point;
    }

    public bool FlyState()
    {
        if (rb.velocity.y < 0)
            return false;

        return true;
    }
}
