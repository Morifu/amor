using UnityEngine;
using System.Collections;

public class AudioOnOff : MonoBehaviour {
	public bool isOnButton = false;

	void OnMouseUp() 
	{
		if(isOnButton)
		{
			AudioListener.pause = false;
			AudioListener.volume = 1.0f;
		}
		else
		{
			AudioListener.pause = true;
			AudioListener.volume = 0.0f;
		}
	}

}
