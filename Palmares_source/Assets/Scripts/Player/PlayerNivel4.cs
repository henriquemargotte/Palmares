using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNivel4 : Player {
	//Nivel 4
	public int meladosPurga;
	public int acucarPurga;
	//public int acucar;
	public int interact;
	public Sprite[] purgaCheia;

	private bool trigDeposito, trigPurga, parentPurga;
	private Collider2D otherDeposito, otherPurga;
	private GameObject purgaPr;

	void FixedUpdate(){
		if (purgaPr != null) {
			purgaPr.GetComponent<SpriteRenderer> ().sprite = purgaCheia [acucarPurga];
		}
		if (trigDeposito) {
			Deposito ();
		}
		if (trigPurga) {
			Purga ();
		}
		if (Input.GetKey (KeyCode.E) && parentPurga) {
			if (interact <= 0) {
				if (meladosPurga >= 1) {
					meladosPurga -= 1;
					acucarPurga += 1;
					interact = 100;
				}
			}
			interact -= 1;
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.CompareTag ("Purga")) {
			if (!trigPurga) {
				otherPurga = other;
				trigPurga = true;
			}
		}
		if (other.CompareTag ("Deposito")) {
			if (!trigDeposito) {
				otherDeposito = other;
				trigDeposito = true;
			}
		}
	}

	void OnTriggerExit2D(Collider2D other){
		if (other.CompareTag ("Purga")) {
			otherPurga = null;
			trigPurga = false;
		}
		if (other.CompareTag ("Deposito")) {
			otherDeposito = null;
			trigDeposito = false;
		}
	}

	void Purga(){
		if (Input.GetKey (KeyCode.F) && !parentPurga) {
			//acucar += acucarPurga;
			//acucarPurga = 0;
			otherPurga.transform.parent = gameObject.transform;
			otherPurga.transform.localPosition = new Vector3(0, 0, otherPurga.transform.position.z);
			purgaPr = otherPurga.gameObject;
			//purgaPr.transform.position = new Vector3 (0, 0, purgaPr.transform.position.z);
			parentPurga = true;
		}

	}

	void Deposito(){
		if (Input.GetKeyDown (KeyCode.G) && parentPurga) {
			points += acucarPurga;
			acucarPurga = 0;
			if (meladosPurga == 0) {
				Destroy (purgaPr);
				parentPurga = false;
				meladosPurga = 3;
			}
		}
	}
}
