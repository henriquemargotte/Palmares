using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueSound : MonoBehaviour {

	public AudioClip[] sons;
	public int randMax;

	private AudioSource src;
	private InterScene inter;

	// Use this for initialization
	void Start () {
		src = GetComponent<AudioSource> ();
		if (GameObject.Find ("InterScene") == null) {
			print ("null");
		}
		else inter = GameObject.Find ("InterScene").GetComponent<InterScene> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Random.Range (0, randMax) == 1 && !src.isPlaying) {
			if (inter.nivel < 4) {
				src.clip = sons [Random.Range (0, sons.Length - 1)];
				src.Play ();
			} else {
				src.clip = sons [7];
				src.Play ();
			}
		}
	}
}
