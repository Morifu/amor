using UnityEngine;
using System.Collections;

public class AudioOnOff : MonoBehaviour {
	public bool isOnButton = false;

	void OnMouseUp() 
	{
		if(isOnButton)
		{
			AudioListener.pause = false;
		}
		else
		{
			AudioListener.pause = true;
		}
	}

}
