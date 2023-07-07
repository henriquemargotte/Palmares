using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBase : MonoBehaviour {
	//ENGENHO E QUILOMBO
	public float vel;
	public GameObject mapa;
	public AudioSource fs;
	public AudioClip[] foots;

	private Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.W)) { //Up
			anim.SetBool ("Up", true);
			anim.SetBool ("Right", false);
			anim.SetBool ("Down", false);
			transform.Translate (Vector2.up * vel * Time.deltaTime);
			if (!fs.isPlaying) {
				fs.Play();
			}
		} else if (Input.GetKey (KeyCode.S)) { //Down
			anim.SetBool ("Up", false);
			anim.SetBool ("Right", false);
			anim.SetBool ("Down", true);
			transform.Translate (Vector2.down * vel * Time.deltaTime);
			if (!fs.isPlaying) {
				fs.Play();
			}
		} else if (Input.GetKey (KeyCode.A)) { //Left
			anim.SetBool ("Up", false);
			anim.SetBool ("Right", true);
			anim.SetBool ("Down", false);
			transform.localScale = new Vector3 (-1f, transform.localScale.y, transform.localScale.z);
			transform.Translate (Vector2.left * vel * Time.deltaTime);
			if (!fs.isPlaying) {
				fs.Play();
			}
		} else if (Input.GetKey (KeyCode.D)) { //Right
			anim.SetBool ("Up", false);
			anim.SetBool ("Right", true);
			anim.SetBool ("Down", false);
			transform.localScale = new Vector3 (1f, transform.localScale.y, transform.localScale.z);
			transform.Translate (Vector2.right * vel * Time.deltaTime);
			if (!fs.isPlaying) {
				fs.Play();
			}
		} else {
			anim.SetBool ("Up", false);
			anim.SetBool ("Right", false);
			anim.SetBool ("Down", false);
			fs.Stop ();
		}
		if (Input.GetKeyDown (KeyCode.M)) {
			Time.timeScale = 0;
			mapa.SetActive (true);
		}
		if (Input.GetKeyUp (KeyCode.M)) {
			Time.timeScale = 1;
			mapa.SetActive (false);
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.CompareTag("Telhado")){
			other.gameObject.GetComponent<SpriteRenderer> ().color = new Vector4(1,1,1,0.5f);
		}
		if (other.CompareTag ("MadeiraFS")) {
			fs.clip = foots [1];
		}
		if (other.CompareTag ("PonteFS")) {
			fs.clip = foots [2];
		}
	}

	void OnTriggerExit2D(Collider2D other){
		if(other.CompareTag("Telhado")){
			other.gameObject.GetComponent<SpriteRenderer> ().color = new Vector4(1,1,1,1);
		}
		if (other.CompareTag ("MadeiraFS")) {
			fs.clip = foots [0];
		}
		if (other.CompareTag ("PonteFS")) {
			fs.clip = foots [0];
		}
	}
}
