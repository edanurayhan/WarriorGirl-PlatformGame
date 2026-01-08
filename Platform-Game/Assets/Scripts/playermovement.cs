using UnityEngine;

public class playermovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumppower;
    [SerializeField] private float wallSlideSpeed;
    [SerializeField] private float wallClimbSpeed; 

    [SerializeField] private LayerMask groundlayer;
    [SerializeField] private LayerMask walllayer;

    private Rigidbody2D rb;
    private Animator anim;
    private BoxCollider2D boxcollider;

    private float walljumpcooldown;
    private float horizontalınput;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxcollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        horizontalınput = Input.GetAxis("Horizontal");

        if (horizontalınput > 0.01f)
        {
            transform.localScale = new Vector3(7f, 7f, 7f);
        }
        else if (horizontalınput < -0.01f)
        {
            transform.localScale = new Vector3(-7f, 7f, 7f);
        }

      
        anim.SetBool("run", horizontalınput != 0);
        anim.SetBool("grounded", isGrounded());

        
        if (walljumpcooldown > 0.4f)
        {
                rb.linearVelocity = new Vector2(horizontalınput * speed, rb.linearVelocity.y);
           
            if (OnWall() && !isGrounded())
            {
                rb.gravityScale = 0;

                rb.linearVelocity = new Vector2(rb.linearVelocity.x, -wallSlideSpeed);

                bool isPushingTowardsWall = (horizontalınput > 0 && transform.localScale.x > 0) ||
                                            (horizontalınput < 0 && transform.localScale.x < 0);

                if (isPushingTowardsWall && Input.GetKey(KeyCode.Space))
                {
                    rb.linearVelocity = new Vector2(rb.linearVelocity.x, wallClimbSpeed);
                }
            }
            else
            {
                rb.gravityScale = 7; 
            }

    
            if (Input.GetKeyDown(KeyCode.Space)) 
                Jump();
        }
        else
        {
            walljumpcooldown += Time.deltaTime;
        }
    }

    private void Jump()
    {
        bool isPushingTowardsWall = (horizontalınput > 0 && transform.localScale.x > 0) ||
                                    (horizontalınput < 0 && transform.localScale.x < 0);

        if (isGrounded())
        {
        
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumppower);
            anim.SetTrigger("jump");
        }
        
        else if (OnWall() && !isGrounded() && !isPushingTowardsWall)
        {
            walljumpcooldown = 0;

           
            rb.linearVelocity = new Vector2(-Mathf.Sign(transform.localScale.x) * (jumppower * 0.7f), jumppower);
        }
    }

    
    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxcollider.bounds.center, boxcollider.bounds.size, 0, Vector2.down, 0.1f, groundlayer);
        return raycastHit.collider != null;
    }

    
    private bool OnWall()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxcollider.bounds.center, boxcollider.bounds.size, 0, new Vector2(transform.localScale.x, 0), 0.1f, walllayer);
        return raycastHit.collider != null;
    }

    public bool canAttack()
    {
        return horizontalınput == 0 && isGrounded() && !OnWall();
    }
}