using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    // Start is called before the first frame update
    public Camera camera;
    public Transform followTarget;

    Vector2 startingPostion;
    float startingZ;
    Vector2 camMoveSinceStart => (Vector2)camera.transform.position - startingPostion;
    float ZdistanceFromTarget => transform.position.z - followTarget.transform.position.z;

	float ParallaxFactor => Mathf.Abs(ZdistanceFromTarget) / clippingPlane;

    float clippingPlane => (camera.transform.position.z + (ZdistanceFromTarget > 0 ? camera.farClipPlane : camera.nearClipPlane));
	void Start()
    {
        startingPostion = transform.position;
        startingZ = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 newPostion = startingPostion + camMoveSinceStart * ParallaxFactor;
        transform.position = new Vector3(newPostion.x, newPostion.y, startingZ);

    }
}
//public int attackDamege = 10;


//	private void OnTriggerEnter2d(Collider2D collision)
//{
//	//see if it can be hit
//	Damgeable damgeable = collision.GetComponent<Damgeable>();
//	if (damgeable != null)
//	{
//		//hit the targetDe
//		damgeable.Hit(attackDamege);
//		Debug.Log(collision.name + "hit for " + attackDamege);
//	}
//	else
//	{
//		Debug.Log("noo");
//	}
//}
