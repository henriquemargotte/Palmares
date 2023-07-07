using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public InterScene inter;
	public GameObject[] objTroca; 
	public GameObject player;
	public Vector3[] startPosition = new Vector3[5];

	// Use this for initialization
	void Awake () {
		if (GameObject.Find ("InterScene") == null) {
			print ("null");
		}
		else inter = GameObject.Find ("InterScene").GetComponent<InterScene> ();
		Instantiate (inter.sun [inter.nivel]);

		player.transform.position = startPosition [inter.nivel];

		objTroca[inter.nivel].GetComponent<TrocaNivel> ().active = true;

	}
	

}
