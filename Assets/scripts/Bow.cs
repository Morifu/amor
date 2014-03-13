using UnityEngine;
using System.Collections;

public class Bow : MonoBehaviour {

	public Rigidbody2D arrow;				// Prefab of the rocket.
	public float speed = 20f;				// The speed the rocket will fire at.
	
	
	private Animator anim;					// Reference to the Animator component.

	public void shootArrow()
	{
		// ... instantiate the rocket facing right and set it's velocity to the right. 
		Rigidbody2D bulletInstance = Instantiate(arrow, transform.position, Quaternion.Euler(new Vector3(0,0,0))) as Rigidbody2D;
		bulletInstance.velocity = new Vector2(speed, 0);
	}
}
