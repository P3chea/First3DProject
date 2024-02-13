using UnityEngine;

public class Move : MonoBehaviour
{

    public float speed = 2f;
    public float jump = 5f;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Vector2 movement;
    
    private Animator run;

    private bool isFacingRight = true;
    void Start()
    {
       rb = GetComponent<Rigidbody2D>();
       sr = GetComponent<SpriteRenderer>();
       run = GetComponent<Animator>();
    }

    void Update()
    {
        Walk();
        Jump();
    }
    void Walk()
    {
        movement.x = Input.GetAxis("Horizontal");
        run.SetFloat("IsRunning", Mathf.Abs(movement.x));
        rb.velocity = new Vector2(movement.x * speed, rb.velocity.y);
       
        if(movement.x > 0 && !isFacingRight || movement.x < 0 && isFacingRight )
        {
            Flip();
            isFacingRight = !isFacingRight;
        }
    }

    private void Flip()
    {
        sr.flipX = movement.x > 0;
    }

    void Jump()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, jump);
        }
    }
}
