using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectTile : MonoBehaviour
{
    public int damage = 10;
    public Vector2 moveSpeed = new Vector2(3f, 0);
	public Vector2 knockback = new Vector2(0, 0);

    Rigidbody2D rb;
	private void Awake()
	{
        rb = GetComponent<Rigidbody2D>();
	}
	// Start is called before the first frame update
	void Start()
    {
        rb.velocity = new Vector2(moveSpeed.x * transform.localScale.x, moveSpeed.y);
    }

	// Update is called once per frame
	private void OnTriggerEnter2D(Collider2D collision)
	{
		Damgeable damgeable = collision.GetComponent<Damgeable>();
		if(damgeable != null)
		{
			Vector2 deleveredKnockback = transform.localScale.x > 0 ? knockback : new Vector2(-knockback.x, knockback.y);
			bool gotHit = damgeable.Hit(damage, deleveredKnockback);
			if (gotHit)
				
				Debug.Log(collision.name + "hit for" + damage);
			Destroy(gameObject);
		}
	}
}
