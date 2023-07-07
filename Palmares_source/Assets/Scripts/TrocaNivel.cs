using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrocaNivel : MonoBehaviour {

	public string scene;
	public bool active;

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.CompareTag ("Player") && active) {
			SceneManager.LoadScene (scene);
		}
	}
}
