using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNivel3 : Player {
	//Nivel 3
	public int garapas;
	public int garapasJarro;
	public int melados;
	public int garapasCaldeira;
	public int meladosCaldeira;
	public int interact;
	public Sprite[] cald;

	private bool trigItem, trigDeposito, trigCaldeira;
	private Collider2D otherItem, otherDeposito, otherCaldeira;

	void FixedUpdate(){
		if (trigItem) {
			Item ();
		}
		if (trigDeposito) {
			Deposito ();
		}
		if (trigCaldeira) {
			Caldeira ();
		}
		if(otherCaldeira != null){
			if(interact >= 99 && meladosCaldeira == 0){
				otherCaldeira.gameObject.GetComponent<SpriteRenderer>().sprite = cald[0];
			}
			if (interact >= 99 && meladosCaldeira > 0) {
				otherCaldeira.gameObject.GetComponent<SpriteRenderer>().sprite = cald[3];
			}
			if (interact < 99 && interact > 50) {
				otherCaldeira.gameObject.GetComponent<SpriteRenderer>().sprite = cald[1];
			}
			if (interact <= 50 && interact > 0) {
				otherCaldeira.gameObject.GetComponent<SpriteRenderer>().sprite = cald[2];
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.CompareTag ("Caldeira")) {
			if (!trigCaldeira) {
				otherCaldeira = other;
				trigCaldeira = true;
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
		if (other.CompareTag ("Caldeira")) {
			otherCaldeira = null;
			trigCaldeira = false;
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
			if (otherItem.gameObject.name == "Jarro" && garapasJarro >= 1 && garapas < 3 && melados == 0) {
				garapas += 1;
				garapasJarro -= 1;
				itens [0].SetActive (true);
			}
		}
	}

	void Caldeira(){
		if(Input.GetKey (KeyCode.G)){
			if (garapas > 0) {
				garapas -= 1;
				garapasCaldeira += 1;
				if (garapas == 0) {
					itens [0].SetActive (false);
				}
			}
		}
		if (Input.GetKey (KeyCode.F)) {
			if (melados < 3 && garapas == 0 && meladosCaldeira > 0) {
				melados += 1;
				meladosCaldeira -= 1;
				if (melados > 0) {
					itens [1].SetActive (true);
				}
			}
		}
		if (Input.GetKey (KeyCode.E) && melados == 0 && garapas == 0 && garapasCaldeira > 0) {
			anim.SetBool ("Caldeira", true);
			if (interact <= 0) {
				if (garapasCaldeira >= 1) {
					garapasCaldeira -= 1;
					meladosCaldeira += 1;
					interact = 100;
				}
			}
			interact -= 1;
		}
		else 
			anim.SetBool ("Caldeira", false);
	}

	void Deposito(){
		if (Input.GetKeyDown (KeyCode.G)) {
			points += melados;
			melados = 0;
			itens [1].SetActive (false);
		}
	}
}
