using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour {

	public GameObject canvas;

	private bool active;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.P)) {
			if (!active) {
				Time.timeScale = 0;
				canvas.SetActive (true);
				active = true;
			} else {
				Resume ();
			}
		}
		else if (Input.anyKeyDown && active && !Input.GetKeyDown(KeyCode.Mouse0) && !Input.GetKeyDown(KeyCode.Mouse1)) {
			Resume ();
		}
	}

	public void Resume(){
		Time.timeScale = 1;
		canvas.SetActive (false);
		active = false;
	}

	public void ControlVolume(float volume){
		AudioListener.volume = volume;
	}
}
