using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachspeedMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Animator anim;

    [SerializeField] private LayerMask jumpableGround;

    private float dirX = 0f;
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float machspeed = 20f;
    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        
    }

    // Update is called once per frame
    private void Update()
    {
       if (dirX > 0f)
       {
           sprite.flipX = false;
           moveSpeed += 0.02f;
           if ( moveSpeed >= machspeed )
           {
               moveSpeed = machspeed;
           }
       }
       else if (dirX < 0f)
       {
           sprite.flipX = true;
           moveSpeed += 0.02f;
           if ( moveSpeed >= machspeed )
           {
               moveSpeed = machspeed;
           }
        if ( moveSpeed == machspeed )
        {
            this.transform.parent.gameObject.SetActive(false);
        }
       }
    }
}
