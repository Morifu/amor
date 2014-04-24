using UnityEngine;
using System.Collections;

public class SiteLock : MonoBehaviour {

	// Use this for initialization
	void Start () {
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
				Application.LoadLevel("mainMenu");

		*/		
			//	


}

	}

	// Update is called once per frame
	void Update () {
		Application.LoadLevel("mainMenu"); //
	}


}
