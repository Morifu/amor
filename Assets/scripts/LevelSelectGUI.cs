using UnityEngine;
using System.Collections;

public class LevelSelectGUI : MonoBehaviour {

	public Rect position;
	public GUISkin buttonSkins;
	public GUIStyle style;
	public GUIContent[] buttons;

	int selected = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI() 
	{
		GUI.depth = -1;

		selected = GUI.SelectionGrid(position, selected, buttons, 3,style);

	}
}
