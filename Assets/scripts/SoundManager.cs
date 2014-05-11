using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour {
	
	public AudioClip soundA; //assign clips from inspector
	public AudioClip soundB;
	
	public void PlayBG()
	{
		audio.loop = true;
		audio.PlayOneShot(soundA);
	}
	
	public void PlayWin()
	{
		audio.Stop ();
		audio.loop = false;
		audio.PlayOneShot(soundB);
	}
}
