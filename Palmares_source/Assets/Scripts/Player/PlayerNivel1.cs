using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNivel1 : Player {
	//1 Nivel
	public bool faca;
	public bool[] cana = new bool[2];
	public GameObject canaItem;
	public AudioSource canaSom;

	private GameObject facaObj;
	private GameObject[] canaObj = new GameObject[2];

	private bool trigCana, trigItem, trigDeposito;
	private Collider2D outroCana, outroItem, outroDeposito;

	void FixedUpdate () {
		if (Input.GetKeyDown (KeyCode.G)) {
			print ("Key");
			if (faca && !cana[0] && !cana[1]) {
				facaObj.SetActive (true);
				facaObj.transform.parent = null;
				facaObj.GetComponent<BoxCollider2D> ().isTrigger = true;
				facaObj.transform.localPosition = new Vector3 (facaObj.transform.position.x, facaObj.transform.position.y, -0.1f);
				faca = false;
			}
		}
		if (trigCana) {
			Cana ();
		}
		if (trigItem) {
			Item ();
		}
		if (trigDeposito) {
			Deposito ();
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.CompareTag ("Cana")) {
			if (!trigCana) {
				outroCana = other;
				trigCana = true;
			}
		}
		if (other.CompareTag ("Item")) {
			if (!trigItem) {
				outroItem = other;
				trigItem = true;
			}
		}
		if (other.CompareTag ("Deposito")) {
			if (!trigDeposito) {
				outroDeposito = other;
				trigDeposito = true;
			}
		}
	}
	void OnTriggerExit2D(Collider2D other){
		if (other.CompareTag ("Cana")) {
			outroCana = null;
			trigCana = false;
		}
		if (other.CompareTag ("Item")) {
			outroItem = null;
			trigItem = false;
		}
		if (other.CompareTag ("Deposito")) {
			outroDeposito = null;
			trigDeposito = false;
		}
	}

	void Cana(){
		if (Input.GetKeyDown (KeyCode.Space) && faca && !cana [0] && !cana [1]) {
			outroCana.GetComponent<Cana> ().quant -= 1;
			canaSom.Play ();
			if (outroCana.GetComponent<Cana> ().quant % 2 != 0 && outroCana.GetComponent<Cana> ().quant < 9) {
				Instantiate (canaItem, new Vector3 (Random.Range (transform.position.x, outroCana.transform.position.x), Random.Range (transform.position.y, outroCana.transform.position.y), -0.2f), Quaternion.Euler (0, 0, Random.Range (0, 360)));
			}
			boxAtual.enabled = false;
			boxAtual.enabled = true;
		}
	}

	void Item(){
		if (Input.GetKeyDown (KeyCode.F)) {
			if (outroItem.gameObject.name == "Faca" && !faca && !cana[0] && !cana[1]) {
				facaObj = outroItem.gameObject;
				outroItem.gameObject.transform.parent = gameObject.transform;
				outroItem.GetComponent<BoxCollider2D> ().isTrigger = false;
				//outroItem.gameObject.SetActive (false);
				outroItem.transform.localPosition = new Vector3 (0.14f, 0, -0.1f);
				faca = true;
				boxAtual.enabled = false;
				boxAtual.enabled = true;
			}
			else if (outroItem.gameObject.name == "CanaItem(Clone)" && !faca) {
				if (!cana [0]) {
					cana [0] = true;
					outroItem.transform.localScale = new Vector3 (1.5f, 1.5f, 1);
					outroItem.GetComponent<BoxCollider2D> ().isTrigger = false;
					outroItem.transform.rotation = Quaternion.identity;
					outroItem.gameObject.transform.parent = gameObject.transform;
					outroItem.transform.localPosition = new Vector3 (0, 0, -0.1f);
					canaObj [0] = outroItem.gameObject;
					boxAtual.enabled = false;
					boxAtual.enabled = true;
				} else if (!cana [1]) {
					cana [1] = true;
					outroItem.transform.localScale = new Vector3 (1.5f, 1.5f, 1);
					outroItem.GetComponent<BoxCollider2D> ().isTrigger = false;
					outroItem.transform.rotation = Quaternion.identity;
					outroItem.gameObject.transform.parent = gameObject.transform;
					outroItem.transform.localPosition = new Vector3 (0, 0, -0.1f);
					canaObj [1] = outroItem.gameObject;
					boxAtual.enabled = false;
					boxAtual.enabled = true;
				}
			}
		}
	}

	void Deposito(){
		if (Input.GetKeyDown (KeyCode.G)) {
			if(cana[0]){
				Destroy (canaObj [0]);
				cana [0] = false;
				points += 1;
			}
			if(cana[1]){
				Destroy (canaObj [1]);
				cana [1] = false;
				points += 1;
			}
		}
	}
}