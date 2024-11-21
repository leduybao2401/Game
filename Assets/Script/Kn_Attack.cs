using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kn_Attack : MonoBehaviour
{
	public int attackDamage = 10;
	public Vector2 knockback = Vector2.zero;
	// Start is called before the first frame update

	private void OnTriggerEnter2D(Collider2D collision)
	{

        Damgeable damgeable = collision.GetComponent<Damgeable>();
        if(damgeable != null)
        {
			Vector2 deleveredKnockback = transform.parent.localScale.x > 0 ? knockback : new Vector2(-knockback.x, knockback.y);
            bool gotHit = damgeable.Hit(attackDamage, deleveredKnockback);
			if (gotHit)
		
			Debug.Log(collision.name + "hit for" + attackDamage);
        }
             
	}
}
