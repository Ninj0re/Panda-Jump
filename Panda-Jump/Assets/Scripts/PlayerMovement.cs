using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    private Camera mainCam;
    private Vector2 touchPos;
    private bool moveState;
    private Animator anim;

    [SerializeField] private float speed;
    [SerializeField] private float jumpSpeed;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;

    [SerializeField] private int score;
    [SerializeField] private int coin;

    [SerializeField] private TMP_Text coinText;
    [SerializeField] private TMP_Text scoreText;
    void Awake()
    {
        mainCam = Camera.main;
        touchPos = Vector2.zero;
        moveState = false;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRenderer= GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Input();
        Move();
        AnimatonController();
        FlipController();
        UIController();
    }
    private void AnimatonController()
    {
        if(rb.velocity.y > 0)
        {
            anim.SetBool("jumping", true);
        }
        else
        {
            anim.SetBool("jumping", false);
        }
    }
    private void FlipController()
    {
        if(touchPos.x > transform.position.x)
        {
            spriteRenderer.flipX = false;
        }
        else
        {
            spriteRenderer.flipX = true;
        }
    }
    private void UIController()
    {
        coinText.text = "" + coin; 
        scoreText.text = ""+ score;
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
    public void AddCoin(int coin)
    {
        this.coin += coin;
    }

    public bool FlyState()
    {
        if (rb.velocity.y < 0)
            return false;

        return false;
    }
}
