using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly : MonoBehaviour
{
	public float flyghSpeed = 2f;
	public float waypointReachedDistance = 0.1f;

	public DetetionZone bitDetetionZone;
	public List<Transform> waypoints;
	public Collider2D deathCollider;
	Animator animator;
	Rigidbody2D rb;
	Damgeable damgeable;
	Transform nextWaypoint;
	int waypoinNumber = 0;

	public bool _hasTarget = false;

	public bool HasTarget
	{
		get { return _hasTarget; }
		private set
		{
			_hasTarget = value;
			animator.SetBool(AnimationStrings.hasTarget, value);
		}
	}
	public bool CanMove
	{
		get
		{
			return animator.GetBool(AnimationStrings.canMove);
		}
	}

	private void Awake()
	{

		animator = GetComponent<Animator>();
		rb = GetComponent<Rigidbody2D>();
		damgeable = GetComponent<Damgeable>();
	}
	private void Start()
	{
		nextWaypoint = waypoints[waypoinNumber];
	}
	// Start is called before the first frame update


	// Update is called once per frame
	private void OnEnable()
	{
		//damgeable.damageableDeath += OnDeath();
	}
	void Update()
    {
		HasTarget = bitDetetionZone.detectedColliders.Count > 0;
    }
	private void FixedUpdate()
	{
		if (damgeable.IsAlive)
		{
			if (CanMove)
			{
				Flight();
			}
			else
			{
				rb.velocity = Vector3.zero;
			}
		}
		
		
	}

	private void Flight()
	{
		// di chuyen toi waypoin
		Vector2 directionToWaypoint = (nextWaypoint.position - transform.position).normalized;
		float distance = Vector2.Distance(nextWaypoint.position, transform.position);
		rb.velocity = directionToWaypoint * flyghSpeed;
		UpdateDirection();
		if(distance <= waypointReachedDistance)
		{
			waypoinNumber++;
			if(waypoinNumber >= waypoints.Count)
			{
				waypoinNumber = 0;
			}
			nextWaypoint = waypoints[waypoinNumber];
		}

	}

	private void UpdateDirection()
	{
		Vector3 locScale = transform.localScale;
		//throw new NotImplementedException();
		if(transform.localScale.x > 0)
		{
			//right
			if (rb.velocity.x < 0)
			{
				transform.localScale = new Vector3(-1 * locScale.x, locScale.y, locScale.z);
			}
			else
			{
				if (rb.velocity.x > 0)
				{
					transform.localScale = new Vector3(1 * locScale.x, locScale.y, locScale.z);
				}
			}
		}
	}
	public void OnDeath()
	{
		
			rb.gravityScale = 2f;
			rb.velocity = new Vector2(0, rb.velocity.y);
			deathCollider.enabled = true;
		
	}
}
