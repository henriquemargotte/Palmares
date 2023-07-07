using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour {

	public float vel;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += new Vector3 (0, vel, 0);
		//if(transform.position.y >= 2300) SceneManager.LoadScene ("Menu1");
	}

	void OnTriggerEnter2D(Collider2D other){
		SceneManager.LoadScene ("Menu1");
	}
}
