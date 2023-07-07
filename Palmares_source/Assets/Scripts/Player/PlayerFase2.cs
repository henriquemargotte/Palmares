using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerFase2 : MonoBehaviour {

	public float vel;
	public float life;
	public float dano;
	public BoxCollider2D boxColl;
	public BoxCollider2D boxCollUp;
	public BoxCollider2D boxCollDown;
	public bool faca;
	public bool bastao;
	public GameObject arma;
	public GameObject[] hearts = new GameObject[5];
	public AudioSource fs;
	public AudioSource atk;
	public AudioSource atkFaca;


	private GameObject otherArma;
	private GameObject otherEnemy;
	private bool trigArma;
	private bool trigEnemy;
	private Animator anim;


	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}

	// Update is called once per frame
	void Update () {
		if (life <= 40) {
			hearts [4].SetActive (false);
			if (life <= 30) {
				hearts [3].SetActive (false);
				if (life <= 20) {
					hearts [2].SetActive (false);
					if (life <= 10) {
						hearts [1].SetActive (false);
						if (life <= 0) {
							hearts [0].SetActive (false);
							//print ("perdeu");
							SceneManager.LoadScene("Derrota2");
						}
					}
				}
			}
		}

		if (faca)
			dano = 50;
		else if (bastao)
			dano = 40;
		else
			dano = 30;

		if (Input.GetKey (KeyCode.W)) {
			anim.SetBool ("Up", true);
			anim.SetBool ("Right", false);
			anim.SetBool ("Down", false);
			transform.Translate (Vector2.up * vel * Time.deltaTime);
			boxColl.enabled = false;
			boxCollDown.enabled = false;
			boxCollUp.enabled = true;
			if (!fs.isPlaying) {
				fs.Play();
			}
		} else if (Input.GetKey (KeyCode.S)) {
			anim.SetBool ("Up", false);
			anim.SetBool ("Right", false);
			anim.SetBool ("Down", true);
			transform.Translate (Vector2.down * vel * Time.deltaTime);
			boxColl.enabled = false;
			boxCollDown.enabled = true;
			boxCollUp.enabled = false;
			if (!fs.isPlaying) {
				fs.Play();
			}
		} else if (Input.GetKey (KeyCode.A)) {
			anim.SetBool ("Up", false);
			anim.SetBool ("Right", true);
			anim.SetBool ("Down", false);
			transform.Translate (Vector2.left * vel * Time.deltaTime);
			transform.localScale = new Vector3 (-1, transform.localScale.y, transform.localScale.z);
			boxColl.enabled = true;
			boxCollDown.enabled = false;
			boxCollUp.enabled = false;
			if (!fs.isPlaying) {
				fs.Play();
			}
		} else if (Input.GetKey (KeyCode.D)) {
			anim.SetBool ("Up", false);
			anim.SetBool ("Right", true);
			anim.SetBool ("Down", false);
			transform.Translate (Vector2.right * vel * Time.deltaTime);
			transform.localScale = new Vector3 (1, transform.localScale.y, transform.localScale.z);
			boxColl.enabled = true;
			boxCollDown.enabled = false;
			boxCollUp.enabled = false;
			if (!fs.isPlaying) {
				fs.Play();
			}
		} else {
			anim.SetBool ("Up", false);
			anim.SetBool ("Right", false);
			anim.SetBool ("Down", false);
			fs.Stop ();
		}
		if (Input.GetKeyDown (KeyCode.G)) {
			if (faca) {
				arma.SetActive (true);
				arma.transform.parent = null;
				arma.transform.localPosition = new Vector3 (arma.transform.position.x, arma.transform.position.y, -0.1f);
				faca = false;
			}
			if (bastao) {
				arma.SetActive (true);
				arma.transform.parent = null;
				arma.transform.localPosition = new Vector3 (arma.transform.position.x, arma.transform.position.y, -0.1f);
				bastao = false;
			}
		}

		if (trigArma) {
			Arma ();
		}
		if (trigEnemy) {
			Enemy ();
		}

	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.CompareTag ("Item")) {
			if (!trigArma) {
				otherArma = other.gameObject;
				trigArma = true;
			}
		}
		if (other.CompareTag ("Enemy")) {
			if (!trigEnemy) {
				otherEnemy = other.gameObject;
				trigEnemy = true;
			}
		}
	}

	void OnTriggerExit2D(Collider2D other){
		if (other.CompareTag ("Item")) {
			otherArma = null;
			trigArma = false;
		}
		if (other.CompareTag ("Enemy")) {
			otherEnemy = null;
			trigEnemy = false;
		}
	}

	void Arma(){
		if (Input.GetKeyDown (KeyCode.F) && !faca && !bastao) {
			if (otherArma.gameObject.name == "Faca") {
				arma = otherArma.gameObject;
				otherArma.gameObject.transform.parent = gameObject.transform;
				//otherArma.gameObject.SetActive (false);
				otherArma.transform.localPosition = new Vector3 (0.14f, 0, -0.1f);
				faca = true;
				boxColl.enabled = false;
				boxColl.enabled = true;
				boxCollDown.enabled = false;
				boxCollDown.enabled = true;
				boxCollUp.enabled = false;
				boxCollUp.enabled = true;
			}
			else if (otherArma.gameObject.name == "Bastao") {
				arma = otherArma.gameObject;
				otherArma.gameObject.transform.parent = gameObject.transform;
				//otherArma.gameObject.SetActive (false);
				otherArma.transform.localPosition = new Vector3 (0.14f, 0, -0.1f);
				bastao = true;
				boxColl.enabled = false;
				boxColl.enabled = true;
				boxCollDown.enabled = false;
				boxCollDown.enabled = true;
				boxCollUp.enabled = false;
				boxCollUp.enabled = true;
			}
		}
	}

	void Enemy(){
		if (Input.GetKeyDown (KeyCode.Space)) {
			if (!bastao && !faca)
				anim.SetTrigger ("Chute");
			else if (faca)
				atkFaca.Play ();
			atk.Play ();
			otherEnemy.gameObject.GetComponent<Enemy> ().life -= dano;
		}
	}
}
