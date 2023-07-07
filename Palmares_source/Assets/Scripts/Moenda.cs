using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moenda : MonoBehaviour {

	public int canas;
	public int garapa;
	public float tempo;
	public Sprite[] mesaSprite = new Sprite[2];
	public GameObject mesa;
	public AudioSource som;
	
	// Update is called once per frame
	void Update () {
		if (canas > 0) {
			StartCoroutine (Processar ());
			som.Play ();
		}
		if (garapa > 0) {
			mesa.GetComponent<SpriteRenderer> ().sprite = mesaSprite [1];
		}
		else 			
			mesa.GetComponent<SpriteRenderer> ().sprite = mesaSprite [0];
	}

	IEnumerator Processar(){
		canas -= 1;
		//Mudar animação
		yield return new WaitForSeconds (tempo);
		garapa += 1;
	}
}
