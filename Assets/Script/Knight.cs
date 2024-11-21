using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D), typeof(TouchingDirection), typeof(Damgeable))]
public class Knight : MonoBehaviour
{
    public float walkSpeed = 3f;
    public float walkStopRate = 0.6f;
    Vector2 moveInput;
    public DetetionZone acttackZone; //phat hien dich
    Rigidbody2D rb;
    TouchingDirection touchingDirection;
    Animator animator;
    Damgeable damgeable;
    public DetetionZone clifffDetectionZone; //check co roi xuong

    public enum WalkableDirection { Right, Left }
    private WalkableDirection _walkDirection;
    private Vector2 walkDrectionVector = Vector2.right;

    public WalkableDirection WalkDirection
    {
        get { return _walkDirection; }
        set {
            if (_walkDirection != value)
            {
                gameObject.transform.localScale = new Vector2(gameObject.transform.localScale.x * -1, gameObject.transform.localScale.y);
                if (value == WalkableDirection.Right)
                {
                    walkDrectionVector = Vector2.right;

                } else if (value == WalkableDirection.Left)
                {
                    walkDrectionVector = Vector2.left;
                }
            }

            _walkDirection = value; }
    }

    public bool _hasTarget = false;
    public bool HasTarget { get { return _hasTarget; } private set
        {
            _hasTarget = value;
            animator.SetBool(AnimationStrings.hasTarget, value);
        }
    }

    public bool CanMove { get; private set; }
    public float AttackCooldown
    {
        get
        {
            return animator.GetFloat(AnimationStrings.attackCooldown);
        }
        private set
        {
            animator.SetFloat(AnimationStrings.attackCooldown, MathF.Max(value, 0));
        }
    }


    //public void CanMove
    //{
    //    get
    //    {
    //        return animator.Getbool(AnimationStrings.canMove);
    //    }
    //}
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        touchingDirection = GetComponent<TouchingDirection>();
        animator = GetComponent<Animator>();
        damgeable = GetComponent<Damgeable>();

    }
    private void Update()
    {
        HasTarget = acttackZone.detectedColliders.Count > 0;
        if (AttackCooldown > 0)
        {
            AttackCooldown -= Time.deltaTime; // time hoi chieu
        }

    }

    private void FixedUpdate()
    {
        if (touchingDirection.isGrounded && touchingDirection.isOnWall ) 
        {
            FlipDirection();
        }
        //if (!damgeable.LocVelocity)
        //{
			//if (CanMove)
			rb.velocity = new Vector2(walkSpeed * walkDrectionVector.x, rb.velocity.y);
			//else rb.velocity = new Vector2(Mathf.Lefp(rb.velocity.x, 0 ,walkStopRate), rb.velocity.y);
		//}

	}

	private void FlipDirection()
	{
		if(WalkDirection == WalkableDirection.Right)
        {
            WalkDirection = WalkableDirection.Left;
        }else if(WalkDirection == WalkableDirection.Left)
        {
            WalkDirection = WalkableDirection.Right;
        }
        else
        {
            Debug.LogError("Current walkable direction is not set to legal values of right or left");

        }
	}
    public void OnHit(int damege, Vector2 knockback)
    {
		
		rb.velocity = new Vector2(knockback.x, rb.velocity.y + knockback.y);
	}
    public void OnCliffDetected()
    {
        if (touchingDirection.isGrounded)
        {
            FlipDirection();
        }
    }

}

	// Start is called before the first frame update
	

    // Update is called once per frame
    
