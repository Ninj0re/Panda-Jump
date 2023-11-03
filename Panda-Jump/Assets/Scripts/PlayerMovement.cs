using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;
using TMPro;
using UnityEngine.UIElements;
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
    [SerializeField] private UIManager managerUI;
    [SerializeField] private ButtonController buttonController;
    [SerializeField] private GameObject[] backgrounds;
    bool started;
    bool startChecker;
    [SerializeField] private GameObject lastPlatform;

    void Awake()
    {
        mainCam = Camera.main;
        touchPos = Vector2.zero;
        moveState = false;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        if (!started)
        {
            CheckStartInput();
            return;
        }

        else
        {
            if (!startChecker)
            {
                StartGame();
                startChecker = true;
            }
        }
        if (buttonController.IsPaused() || EndGameManager.isGameEnded)
                return;
        Input();
        Move();
        AnimatonController();
        FlipController();
    }
    private void CheckStartInput()
    {
        if (Touch.fingers[0].isActive)
            started = true;
    }
    private void StartGame()
    {
        managerUI.StartGame();
        anim.SetBool("gameStarted", true);
        jumpSpeed = 25;
        Jump();
    }
    private void IncreaseSpeed()
    {
        if (score > 120)
            return;
        Time.timeScale += 0.005f;
        //rb.gravityScale += 0.075f;
        //jumpSpeed += 0.15f;
    }
    private void AnimatonController()
    {
        if (rb.velocity.y > 0)
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
        if (touchPos.y > transform.position.y + 5)
            return;
        if (touchPos.x > transform.position.x)
        {
            spriteRenderer.flipX = false;
        }
        else
        {
            spriteRenderer.flipX = true;
        }
    }
    private void Input()
    {

        if (Touch.fingers[0].isActive)
        {
            var touch = Touch.activeTouches[0];
            touchPos = touch.screenPosition;
            touchPos = mainCam.ScreenToWorldPoint(touchPos);
            moveState = true;
        }
        else
        {
            moveState = false;
            touchPos = Vector3.zero;
        }

    }
    private void Move()
    {
        if (touchPos.y > transform.position.y + 5)
            return;
        //if (Mathf.Abs(touchPos.x - transform.position.x) > 2)
            //transform.Translate(moveDir.normalized * speed * Time.deltaTime, 0);
        if (moveState)
        {
            Vector2 moveDir = new Vector2(touchPos.x - transform.position.x, 0);
            if (Mathf.Abs(moveDir.x) > Mathf.Abs(moveDir.normalized.x))
            {
                moveDir = moveDir.normalized;
            }
            //rb.velocity = new Vector2(moveDir.x * speed, rb.velocity.y);
            transform.Translate(moveDir * speed * Time.deltaTime, 0);
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
    public void AddScore(int point, GameObject platform)
    {
        if (!FlyState())
            return;
        score += point;
        if (point != 0)
        {
            for (var i = 0; i < backgrounds.Length; i++)
            {
                backgrounds[i].GetComponent<BackgroundParent>().GoDown();
                IncreaseSpeed();
            }
        }
        lastPlatform = platform;

    }
    public int GetScore()
    {
        return score;
    }

    public void Revive()
    {
        transform.position = new Vector2(lastPlatform.transform.position.x, lastPlatform.transform.position.y + 1.25f);
    }
    public bool FlyState()
    {
        if (rb.velocity.y < 0)
            return true;
        return false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            if (rb.velocity.y <= 0)
                Jump();
        }
    }
}
