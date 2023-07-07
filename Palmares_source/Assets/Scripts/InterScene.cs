using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterScene : MonoBehaviour {

	public int nivel;
	public GameObject[] sun = new GameObject[5];

	// Use this for initialization
	void Start () {
		if (GameObject.Find ("InterScene") != gameObject) {
			Destroy(GameObject.Find ("InterScene"));
		}
		DontDestroyOnLoad (gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	}
}
