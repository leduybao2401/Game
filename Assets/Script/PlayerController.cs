using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D), typeof(TouchingDirection), typeof(Damgeable))]
public class PlayerController : MonoBehaviour
{
    public float walkSpeech = 8f;
	public float runSpeech = 10f;
	public float airWalkSpeed = 3f;
	public float jumpImpulse = 10f;
    public Text WinText;
	Vector2 moveInput;
    Rigidbody2D rb;
    Animator animator;
    Damgeable damgeable;
    TouchingDirection touchingDirections;
    public float CurentMoveSpeed { get 
        {
            if (CanMove)
            {
				if (IsMoving && !touchingDirections.isOnWall)
				{
					if (touchingDirections.isGrounded)
					{
						if (IsRuning)
						{
							return runSpeech;
						}
						else
						{
							return walkSpeech;
						}
					}
					else
					{
						//air move
						return airWalkSpeed;
					}

				}
				else
				{
					//idle is 0
					return 0;
				}
            }
            else
            {
                //Movement locked
                return 0;
            }

        } }
	private void Awake()
	{
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        touchingDirections = GetComponent<TouchingDirection>();
       damgeable = GetComponentInChildren<Damgeable>();
	}
    [SerializeField]
    private bool _isMoving = false;
	public bool IsMoving { get
        {
            return _isMoving; 
        } private set
        {
            _isMoving = value;
            //animator.SetBool("IsMoving", value);
			animator.SetBool(AnimationStrings.IsMoving, value);
            

		} }
	[SerializeField]
	private bool _isRuning = false;
    public bool IsRuning
	{
        get
        {
            return _isRuning;
        }
        set
        {
			_isRuning = value;
			//animator.SetBool("IsRuning", value);
			animator.SetBool(AnimationStrings.IsRuning, value);
		}
    }
    public bool _IsFacingRight = true;
	public bool IsFacingRight { get { return _IsFacingRight; } private set {
           if(_IsFacingRight != value)
            {
                transform.localScale *= new Vector2(-1,1);
            }
            _IsFacingRight = value;
            ;} }

    public bool CanMove
    {
        get
        {
            return animator.GetBool(AnimationStrings.canMove);
        }
    }
    public bool IsAlive
    {
        get
        {
			return animator.GetBool(AnimationStrings.canMove);
		}
    }

	//public bool LocVelotity { get {
 //           return animator.GetBool(AnimationStrings.lockVelocity);
 //       }
 //       set
 //       {
	//		animator.SetBool(AnimationStrings.lockVelocity, value);
	//	}
 //   }

	

	private void FixedUpdate()
	{
        //cheack trung don hay ko 
        if(!damgeable.LocVelocity) //false
        rb.velocity = new Vector2(moveInput.x * CurentMoveSpeed, rb.velocity.y);
        animator.SetFloat(AnimationStrings.yVelocity, rb.velocity.y);
	}
	public void  OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
        if (IsAlive)
        {
			IsMoving = moveInput != Vector2.zero;
			SetFacingDirection(moveInput);
        }
        else
        {
            IsMoving = false;
        }
		
    }

	private void SetFacingDirection(Vector2 moveInput)
	{
		if(moveInput.x > 0 && !IsFacingRight)
        {
            IsFacingRight = true;
        }else if (moveInput.x < 0 && IsFacingRight)

        {
            IsFacingRight = false;
        }
	}

	public void OnRun(InputAction.CallbackContext context)
	{
        if (context.started)
        {
            IsRuning = true;
        }else if (context.canceled)
        {
            IsRuning = false;
        }
	}
	public void OnJump(InputAction.CallbackContext context)
    {
        // check song hay chet
        if (context.started && touchingDirections.isGrounded && CanMove)
        {
            animator.SetTrigger(AnimationStrings.jumpTriger);
            rb.velocity = new Vector2(rb.velocity.x, jumpImpulse);

		}
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        // check song hay chet
        if (context.started)
        {
            animator.SetTrigger(AnimationStrings.attackTriger);

        }
    }

    public void OnRangAttack(InputAction.CallbackContext context)
    {
        // check song hay chet
        if (context.started)
        {
            animator.SetTrigger(AnimationStrings.rangedAttackTriger);

        }
    }

    public void OnHit(int damage, Vector2 knockback)
    {
		
        rb.velocity = new Vector2(knockback.x, rb.velocity.y + knockback.y);
    }
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.tag == "Win")
        {
            WinText.gameObject.SetActive(true);
        }    
	}

}
