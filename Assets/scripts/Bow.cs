using UnityEngine;
using System.Collections;

public class Bow : MonoBehaviour {

	/// <summary>
	/// The arrow prefab to link.
	/// </summary>
	public Rigidbody2D arrow;	// Prefab of the arrow.

	/// <summary>
	/// Speed of the arrow shot
	/// </summary>
	public float speed = 5;		

	/// <summary>
	/// The arrow spawn delay in seconds.
	/// </summary>
	public int arrowSpawnDelay = 1;

	// private fields
	Rigidbody2D arrowInstance;
	bool arrowShot = false;

	void Start()
	{
		arrowInstance = Instantiate(arrow, transform.position, Quaternion.Euler(new Vector3(0,0,0))) as Rigidbody2D;
		arrowInstance.transform.parent = transform;
		arrowInstance.transform.rotation = transform.rotation;
		arrowInstance.isKinematic = true;
	}

	void Update()
	{

	}

	public void shootArrow( Vector2 direction )
	{
		if(arrowInstance != null)
		{
			arrowInstance.isKinematic = false;
			arrowInstance.velocity = direction*speed;
			arrowInstance.transform.parent = null;
			arrowShot = true;
			arrowInstance = null;
			StartCoroutine (spawnArrow());
		}
	}

	
	IEnumerator spawnArrow()
	{
		yield return new WaitForSeconds(arrowSpawnDelay);
		if(arrowShot)
		{
			arrowInstance = Instantiate(arrow, transform.position, Quaternion.Euler(new Vector3(0,0,0))) as Rigidbody2D;
			arrowInstance.transform.parent = transform;
			arrowInstance.transform.rotation = transform.rotation;
			arrowInstance.isKinematic = true;
			arrowShot = false;
		}
	}
}
