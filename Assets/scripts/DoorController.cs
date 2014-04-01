using UnityEngine;
using System.Collections;

public class DoorController : MonoBehaviour {
	public bool Shooted = false; 
	public bool Opened = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		/*if (Opened == true) {
			Rigidbody2D openDoor = Instantiate(openDoor, transform.position, Quaternion.Euler(new Vector3(0,0,0)));
			//arrowInstance.velocity = direction*speed;
			Destroy(gameObject, 0);
		}
		else if (Opened == false) {
			Rigidbody2D Door = Instantiate(Door, transform.position, Quaternion.Euler(new Vector3(0,0,0)));
			//arrowInstance.velocity = direction*speed;
			Destroy(gameObject, 0);
		}*/
	}

	void OnCollisionEnter2D(Collision2D other) {
		if (!Shooted) {
			if (other.gameObject.tag == "Arrow") {
				Opened = true;
				Shooted=true;

			}
		}
	}
}
