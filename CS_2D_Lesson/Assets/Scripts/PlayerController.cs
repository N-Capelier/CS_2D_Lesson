using UnityEngine;

public class PlayerController : MonoBehaviour
{

    int lifePoints = 5;

    [SerializeField] [Range(0, 50)] float moveSpeed = 20.2f;
    string playerName = "Hero";
    public bool isGrounded = false;

    Rigidbody2D rb;
    Vector2 direction;
    [SerializeField] [Range(0, 500)] private float jumpForce;

    Animator animator;
    SpriteRenderer sr;
    PlayerAttack playerAttack;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        playerAttack = GetComponent<PlayerAttack>();
    }

    void Update()
    {
        GetUserInput();
        AnimateCharacter();
        Jump();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    //Just an exemple
    float SqrRoot(float number)
    {
        return Mathf.Sqrt(number);
    }

    void AnimateCharacter()
    {



        if(playerAttack.isAttacking == true)
        {
            return;
        }

        //Exemple
        float myNumber = SqrRoot(rb.velocity.x);

        if(rb.velocity.x > 0.25f)
        {
            animator.Play("Run Anim");
            sr.flipX = false;
        }
        else if(rb.velocity.x < -0.25f)
        {
            animator.Play("Run Anim");
            sr.flipX = true;
        }
        else/* if(idlePose == true)*/
        {
            animator.Play("Idle Anim");
        }


    }

    void GetUserInput()
    {
        direction = Vector2.zero;
        if(Input.GetKey(KeyCode.D))
        {
            direction = new Vector2(1, 0);
        }

        if (Input.GetKey(KeyCode.Q))
        {
            direction = new Vector2(-1, 0);
        }
    }

    void MovePlayer()
    {
        rb.velocity = new Vector2(direction.x * moveSpeed, rb.velocity.y);
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(new Vector2(0, jumpForce));
        }
    }
}
