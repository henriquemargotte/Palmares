using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeveloperMode : MonoBehaviour {

	public GameObject insert;
	public GameObject inter;

	private int nvl = 0;
	private bool activ = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.H)) {
			activ = !activ;
		}
		insert.SetActive (activ);
		inter.GetComponent<InterScene> ().nivel = nvl;
	}

	public void GetNvl(string nivel){
		nvl= System.Convert.ToInt32(nivel);
	}
}
