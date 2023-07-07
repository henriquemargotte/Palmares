using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour {
	public float vel;
	public float points;
	public float time;
	public float maxTime;
	public float minPoints;
	public BoxCollider2D boxColl;
	public BoxCollider2D boxCollUp;
	public BoxCollider2D boxCollDown;
	public BoxCollider2D boxAtual;
	public Image clock;
	public Sprite[] relogios;
	public AudioSource fs;
	public GameObject[] itens = new GameObject[2];

	[HideInInspector]
	public Animator anim;
	private float controlTime = 0;
	private int spriteTimer = 0;

	private InterScene inter;

	// Use this for initialization
	void Start () {
		if (GameObject.Find ("InterScene") != null) {
			inter = GameObject.Find ("InterScene").GetComponent<InterScene> ();
			Instantiate (inter.sun [inter.nivel]);
		}
		anim = GetComponent<Animator> ();
	}

	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		clock.sprite = relogios[spriteTimer];
		if (time - controlTime >= 3.75f) {
			controlTime = time;
			spriteTimer += 1;
		}
		if (time >= maxTime) {
			if (points < minPoints) {
				print ("perdeu");
				Destroy (inter.gameObject);
				SceneManager.LoadScene ("Derrota1");
			}
			if (points >= minPoints) {
				print ("ganhou");
				inter.nivel += 1;
				SceneManager.LoadScene ("Fase1");
			}
		}

		if (Input.GetKey (KeyCode.W)) {
			anim.SetBool ("Up", true);
			anim.SetBool ("Right", false);
			anim.SetBool ("Down", false);
			transform.Translate (Vector2.up * vel * Time.deltaTime);
			boxColl.enabled = false;
			boxCollDown.enabled = false;
			boxCollUp.enabled = true;
			boxAtual = boxCollUp;
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
			boxAtual = boxCollDown;
			if (!fs.isPlaying) {
				fs.Play();
			}
		} else if (Input.GetKey (KeyCode.A)) {
			anim.SetBool ("Up", false);
			anim.SetBool ("Right", true);
			anim.SetBool ("Down", false);
			transform.Translate (Vector2.left * vel * Time.deltaTime);
			transform.localScale = new Vector3 (-1f, transform.localScale.y, transform.localScale.z);
			boxColl.enabled = true;
			boxCollDown.enabled = false;
			boxCollUp.enabled = false;
			boxAtual = boxColl;
			if (!fs.isPlaying) {
				fs.Play();
			}
		} else if (Input.GetKey (KeyCode.D)) {
			anim.SetBool ("Up", false);
			anim.SetBool ("Right", true);
			anim.SetBool ("Down", false);
			transform.Translate (Vector2.right * vel * Time.deltaTime);
			transform.localScale = new Vector3 (1f, transform.localScale.y, transform.localScale.z);
			boxColl.enabled = true;
			boxCollDown.enabled = false;
			boxCollUp.enabled = false;
			boxAtual = boxColl;
			if (!fs.isPlaying) {
				fs.Play();
			}
		} else {
			anim.SetBool ("Up", false);
			anim.SetBool ("Right", false);
			anim.SetBool ("Down", false);
			fs.Stop ();
		}

	}
}