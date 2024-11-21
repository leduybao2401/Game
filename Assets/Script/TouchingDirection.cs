using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;


public class TouchingDirection : MonoBehaviour
{
    CapsuleCollider2D touchingCol;// check co năm tren mat dat
    Animator animator;
    public float groundDistance = 0.05f;
	public float wallCheckDistance = 0.2f;
	public float ceiDistance = 0.05f;
	public ContactFilter2D castFilter;

    RaycastHit2D[] groundHits = new RaycastHit2D[5];
	RaycastHit2D[] wallHits = new RaycastHit2D[5];
	RaycastHit2D[] ceiHits = new RaycastHit2D[5];
	[SerializeField]
    private bool _isGrounded;

	public bool isGrounded
    {
        get
        {
            return _isGrounded;
        }
        private set
        {
            _isGrounded = value;
            animator.SetBool(AnimationStrings.isGrounded, value);
        }
    }

	[SerializeField]
	private bool _isOnWall;

	public bool isOnWall
	{
		get
		{
			return _isOnWall;
		}
		private set
		{
			_isOnWall = value;
			animator.SetBool(AnimationStrings.isOnWall, value);
		}
	}

	[SerializeField]
	private bool _isOnCeiling;
	private Vector2 wallCheckDirection => gameObject.transform.localScale.x >0 ? Vector2.right : Vector2.left;

	public bool isOnCeiling
	{
		get
		{
			return _isOnCeiling;
		}
		private set
		{
			_isOnCeiling = value;
			animator.SetBool(AnimationStrings.isOnCeiling, value);
		}
	}
	private void Awake()
	{
        touchingCol = GetComponent < CapsuleCollider2D >();
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
 void FixedUpdate()     
    {
		isGrounded = touchingCol.Cast(Vector2.down, castFilter, groundHits, groundDistance) > 0;
        isOnWall = touchingCol.Cast(wallCheckDirection, castFilter,wallHits, wallCheckDistance) > 0;
		isOnCeiling = touchingCol.Cast(Vector2.up, castFilter, ceiHits, ceiDistance) > 0;
		//update va cham mat dat
		//co cham vao walk ?
	}
	
}
