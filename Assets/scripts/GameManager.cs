using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public int arrowCount = 0;
	
	static GameManager instance;

	// Use this for initialization
	void Awake () {
		if(instance == null)
		{
			DontDestroyOnLoad (gameObject);
			instance = this;
		}
		else if (instance != this)
		{
			Destroy(gameObject);
		}
	}

	static public GameManager Instance()
	{
		if(instance == null)
		{
			instance = new GameManager();
		} 

		return instance;
	}

}
