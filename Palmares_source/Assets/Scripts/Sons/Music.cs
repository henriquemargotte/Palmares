using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour {

	public AudioClip[] musicas;

	private AudioSource aud;

	// Use this for initialization
	void Awake () {
		aud = GetComponent<AudioSource> ();
		aud.clip = musicas [Random.Range (0, musicas.Length)];
		aud.Play ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!aud.isPlaying) {
			aud.clip = musicas [Random.Range (0, musicas.Length)];
			aud.Play ();
		}
	}

	public void ControlVolume(float volume){
		aud.volume = volume;
	}

	public void OnOff(){
		aud.mute = !aud.mute;
	}
}
