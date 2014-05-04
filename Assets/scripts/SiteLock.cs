using UnityEngine;
using System.Collections;

public class SiteLock : MonoBehaviour {
	float timeStart;

	// Use this for initialization
	void Start () {
		timeStart=Time.time;
		/*Application.ExternalEval("if(document.location.host != 'http://orohimaru.zebromalz.info/amor/') { document.location=''; }");*/

		bool isPirated = true;
		
		if (Application.isWebPlayer) {

		//   
			/*
		if (Application.absoluteURL.Contains("http://www.flashgamelicense.com"))
			{ isPirated = false; }
		if (Application.absoluteURL.Contains("https://www.flashgamelicense.com"))
		{ isPirated = false; }
		//if (Application.absoluteURL.Contains("http://andrzejchrzanowski.home.pl")) 
		//{ isPirated = false; }

		if (isPirated == true)
				Application.LoadLevel("blockPirate");
				//print("Pirated web player");
		else if (isPirated == false)
				//Application.LoadLevel("mainMenu");

		*/		
			//	


}

	}

	// Update is called once per frame
	void Update () {
		if (Time.time >= timeStart+2)
		Application.LoadLevel("mainMenu"); //
	}


}
