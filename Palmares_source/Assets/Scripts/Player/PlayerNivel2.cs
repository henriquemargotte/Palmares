using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNivel2: Player {
	//2 Nivel
	public int garapas;
	public int carregCanas;
	public int caixaCanas;
	public Animator depos;

	private bool trigItem, trigDeposito, trigMoenda;
	private Collider2D otherItem, otherDeposito, otherMoenda;

	void FixedUpdate(){
		if (trigItem) {
			Item ();
		}
		if (trigDeposito) {
			Deposito ();
		}
		if (trigMoenda) {
			Moenda ();
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.CompareTag ("Moenda")) {
			if (!trigMoenda) {
				otherMoenda = other;
				trigMoenda = true;
			}
		}
		if (other.CompareTag ("Item")) {
			if (!trigItem) {
				otherItem = other;
				trigItem = true;
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
		if (other.CompareTag ("Moenda")) {
			otherMoenda = null;
			trigMoenda = false;
		}
		if (other.CompareTag ("Item")) {
			otherItem = null;
			trigItem = false;
		}
		if (other.CompareTag ("Deposito")) {
			otherDeposito = null;
			trigDeposito = false;
		}
	}

	void Item(){
		if (Input.GetKeyDown (KeyCode.F)) {
			if (otherItem.gameObject.name == "Caixa" && carregCanas < 2 && caixaCanas > 0 && garapas == 0) {
				carregCanas += 1;
				caixaCanas -= 1;
				itens [0].SetActive (true);
			}
		}
	}

	void Deposito(){
		if (Input.GetKeyDown (KeyCode.G)) {
			points += garapas;
			garapas = 0;
			itens [1].SetActive (false);
		}
	}

	void Moenda(){
		if(Input.GetKey (KeyCode.G)){
			if (carregCanas > 0) {
				depos.SetTrigger ("Dep");
				otherMoenda.GetComponent<Moenda> ().canas += 1;
				carregCanas -= 1;
				if (carregCanas == 0) {
					itens [0].SetActive (false);
				}
			}
		}
		if (Input.GetKey (KeyCode.F)) {
			if (garapas < 3 && carregCanas == 0) {
				if (otherMoenda.GetComponent<Moenda> ().garapa > 0) {
					garapas += 1;
					otherMoenda.GetComponent<Moenda> ().garapa -= 1;
					itens [1].SetActive (true);
				}
			}
		}
	}
}
