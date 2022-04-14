using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    private Animator anim;
    private TrailRenderer trail;

    [SerializeField] private LayerMask jumpableGround;

    private float dirX = 0f;
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float jumpForce = 14f;
    [SerializeField] private float machspeed = 20f;

    private enum MovementState { idle, running, jumping, falling, landed, mach_run, mach_jump, mach_fall}
    private MovementState state = MovementState.idle;

    [SerializeField] private AudioSource jumpSoundEffect;
    private double nextUpdate = 0.000000000000000000000001;



    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        trail = GetComponent<TrailRenderer>();

        trail.enabled = false;
    }

    // Update is called once per frame
    private void Update()
    {
        if(Time.time>=nextUpdate)
        {
            Debug.Log(Time.time+">="+nextUpdate);
             // Change the next update (current second+1)
            nextUpdate=Mathf.FloorToInt(Time.time)+0.000000000000000000000001;
             // Call your fonction
            UpdateEverySecond();
        }
    }

    void UpdateEverySecond()
    {
        dirX = Input.GetAxisRaw("Horizontal");

        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

       if (Input.GetButtonDown("Jump") && IsGrounded())
       {
           jumpSoundEffect.Play();
           rb.velocity = new Vector2(rb.velocity.x, jumpForce);
       } 

        UpdateAnimationUpdate();
    }

    private void UpdateAnimationUpdate()
    {
        MovementState state;
        if (dirX > 0f)
       {
           state = MovementState.running;
           sprite.flipX = false;
           moveSpeed += 0.24f;
           if ( moveSpeed >= machspeed )
           {
               state = MovementState.mach_run;
               moveSpeed = machspeed;
           }
       }
       else if (dirX < 0f)
       {
           state = MovementState.running;
           sprite.flipX = true;
           moveSpeed += 0.24f;
           if ( moveSpeed >= machspeed )
           {
               state = MovementState.mach_run;
               moveSpeed = machspeed;
           }
       }
       else
       {
           state = MovementState.idle;
            moveSpeed = 10f;
       }

       if (rb.velocity.y > .1f)
       {
           state = MovementState.jumping;
           if ( moveSpeed >= machspeed )
           {
               state = MovementState.mach_jump;
           }

       }
       else if (rb.velocity.y < -.1f)
       {
           state = MovementState.falling;
           if ( moveSpeed >= machspeed )
           {
               state = MovementState.mach_fall;
           }
       }

       if ( moveSpeed == machspeed )
       {
           trail.enabled = true;
       }
       else
       {
           trail.enabled = false;
       }

       anim.SetInteger("state", (int)state);
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Finish"))
        {
            rb.bodyType = RigidbodyType2D.Static;
        }
    }
}
