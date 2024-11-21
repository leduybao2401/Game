using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
	public int healthRestore = 20;
	public Vector3 spinRotationSpeed = new Vector3(0, 180, 0);
	AudioSource pickupSource;

	private void Awake()
	{
		pickupSource = GetComponent<AudioSource>();
	}
	void Start()
	{

	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
		Damgeable damgeable = collision.GetComponent<Damgeable>();
		if (damgeable && damgeable.Health < damgeable.MaxHealth)
		{
			bool wasHealth= damgeable.Heal(healthRestore);


			if (wasHealth)
			{
				if (pickupSource)
					AudioSource.PlayClipAtPoint(pickupSource.clip, gameObject.transform.position, pickupSource.volume);


				   Destroy(gameObject);
			}
				
		}
	}
	private void Update()
	{
		//di chuyen pickup
		transform.eulerAngles += spinRotationSpeed * Time.deltaTime;
	}


}
