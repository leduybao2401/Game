using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
//phay hien va cham
public class DetetionZone : MonoBehaviour
{
	public UnityEvent noCollidersRemain;
    public List<Collider2D> detectedColliders = new List<Collider2D>();
    Collider2D col;
	private void Awake()
    {
        col = GetComponent<Collider2D>();
    }
	private void OnTriggerEnter2D(Collider2D collision)
	{
		detectedColliders.Add(collision);
	}
	private void OnTriggerExit2D(Collider2D collision)
	{
		detectedColliders.Remove(collision);
		if(detectedColliders.Count <= 0)
		{
			noCollidersRemain.Invoke();
		}
	}
}
