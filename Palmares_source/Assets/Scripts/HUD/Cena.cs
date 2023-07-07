using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cena : MonoBehaviour {

	public float time;
	public string scene;

	// Use this for initialization
	void Start () {
		StartCoroutine (End ());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator End(){
		yield return new WaitForSeconds (time);
		SceneManager.LoadScene (scene);
	}
}
