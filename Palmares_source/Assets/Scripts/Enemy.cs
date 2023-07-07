using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public int direcao; //1-esquerda, 2-cima, 3-direita, 4-baixo
	public float life;
	public float rangeVisaoVert;
	public float rangeTiroVert;
	public float rangeVisaoHoriz;
	public float rangeTiroHoriz;
	public float vel;
	public float tempoRecarga;
	public bool atirando;
	public bool viu;
	public GameObject player;
	public GameObject[] objNext;
	public Sprite[] sprites;
	public AudioSource vira;
	public AudioSource tiro;
	public AudioSource passos;

	private int rand;
	private float range;
	private float dano;
	private bool animActive;
	private Animator anim;

	void Start(){
		if (GetComponent<Animator> () != null) {
			anim = GetComponent<Animator> ();
			animActive = true;
		}
		StartCoroutine (Olhar ());
	}

	// Update is called once per frame
	void Update () {
		GetComponent<SpriteRenderer> ().sprite = sprites [direcao];
		if (life <= 0) {
			Destroy (gameObject);
		}
		switch (direcao) {
			case 1:{ //esquerda
				if(animActive){
					anim.SetBool ("Up", false);
					anim.SetBool ("Left", true);
					anim.SetBool ("Right", false);
					anim.SetBool ("Down", false);
				}
				range = rangeTiroHoriz;
				if (player.transform.position.x < transform.position.x && player.transform.position.x > transform.position.x - rangeVisaoHoriz &&
				    player.transform.position.y > transform.position.y - 1.25f && player.transform.position.y < transform.position.y + 1.25f) {
					viu = true;
					for (int i = 0; i < objNext.Length; i++) {
						if (objNext [i].transform.position.x < transform.position.x && objNext [i].transform.position.x > transform.position.x - rangeVisaoHoriz &&
							objNext [i].transform.position.y > transform.position.y - 1.25f && objNext [i].transform.position.y < transform.position.y + 1.25f &&
							Vector2.Distance(transform.position, objNext[i].transform.position) < Vector2.Distance(transform.position, player.transform.position)) {
							viu = false;
						}
					}
					if (viu) {
						if (player.transform.position.x < transform.position.x && player.transform.position.x > transform.position.x - rangeTiroHoriz &&
							player.transform.position.y > transform.position.y - 1.25f && player.transform.position.y < transform.position.y + 1.25f) {
							if (animActive) {
								anim.SetBool ("Run", false);
							}
							if (!atirando) {
								atirando = true;
								StartCoroutine (Tiro ());
							}
						} else {
							transform.Translate (Vector2.left * vel * Time.deltaTime);
							if (animActive) {
								anim.SetBool ("Run", true);
								if (!passos.isPlaying) {
									passos.Play ();
								}
							}
							atirando = false;
						}
					}
				} else {
					viu = false;
					atirando = false;
					if (animActive) {
						anim.SetBool ("Run", false);
					}
				}
				break;
			}
			case 2:{ //cima
				if(animActive){
					anim.SetBool ("Up", true);
					anim.SetBool ("Left", false);
					anim.SetBool ("Right", false);
					anim.SetBool ("Down", false);
				}
				range = rangeTiroVert;
				if (player.transform.position.y > transform.position.y && player.transform.position.y < transform.position.y + rangeVisaoVert &&
					player.transform.position.x > transform.position.x - 0.75f && player.transform.position.x < transform.position.x + 0.75f) {
					viu = true;
					for (int i = 0; i < objNext.Length; i++) {
						if (objNext[i].transform.position.y > transform.position.y && objNext[i].transform.position.y < transform.position.y + rangeVisaoVert &&
							objNext[i].transform.position.x > transform.position.x - 0.75f && objNext[i].transform.position.x < transform.position.x + 0.75f &&
							Vector2.Distance(transform.position, objNext[i].transform.position) < Vector2.Distance(transform.position, player.transform.position)) {
							viu = false;
						}
					}
					if (viu) {
						if (player.transform.position.y > transform.position.y && player.transform.position.y < transform.position.y + rangeTiroVert &&
							player.transform.position.x > transform.position.x - 0.75f && player.transform.position.x < transform.position.x + 0.75f) {
							if (animActive) {
								anim.SetBool ("Run", false);
							}
							if (!atirando) {
								atirando = true;
								StartCoroutine (Tiro ());
							}
						} else {
							transform.Translate (Vector2.up * vel * Time.deltaTime);
							if (animActive) {
								anim.SetBool ("Run", true);
								if (!passos.isPlaying) {
									passos.Play ();
								}
							}
							atirando = false;
						}
					}
				} else {
					viu = false;
					atirando = false;
					if (animActive) {
						anim.SetBool ("Run", false);
					}
				}
				break;
			}
			case 3:{ //direita
				if(animActive){
					anim.SetBool ("Up", false);
					anim.SetBool ("Left", false);
					anim.SetBool ("Right",true);
					anim.SetBool ("Down", false);
				}
				range = rangeTiroHoriz;
				if (player.transform.position.x > transform.position.x && player.transform.position.x < transform.position.x + rangeVisaoHoriz &&
					player.transform.position.y > transform.position.y - 1.25f && player.transform.position.y < transform.position.y + 1.25f) {
					viu = true;
					for (int i = 0; i < objNext.Length; i++) {
						if (objNext[i].transform.position.x > transform.position.x && objNext[i].transform.position.x < transform.position.x + rangeVisaoHoriz &&
							objNext[i].transform.position.y > transform.position.y - 1.25f && objNext[i].transform.position.y < transform.position.y + 1.25f &&
							Vector2.Distance(transform.position, objNext[i].transform.position) < Vector2.Distance(transform.position, player.transform.position)) {
							viu = false;
						}
					}
					if (viu) {
						if (player.transform.position.x > transform.position.x && player.transform.position.x < transform.position.x + rangeTiroHoriz &&
							player.transform.position.y > transform.position.y - 1.25f && player.transform.position.y < transform.position.y + 1.25f) {
							if (animActive) {
								anim.SetBool ("Run", false);
							}
							if (!atirando) {
								atirando = true;
								StartCoroutine (Tiro ());
							}
						} else {
							transform.Translate (Vector2.right * vel * Time.deltaTime);
							if (animActive) {
								anim.SetBool ("Run", true);
								if (!passos.isPlaying) {
									passos.Play ();
								}
							}
							atirando = false;
						}
					}
				} else {
					viu = false;
					atirando = false;
					if (animActive) {
						anim.SetBool ("Run", false);
					}
				}
				break;
			}
			case 4:{ //baixo
				if(animActive){
					anim.SetBool ("Up", false);
					anim.SetBool ("Left", false);
					anim.SetBool ("Right", false);
					anim.SetBool ("Down", true);
				}
				range = rangeTiroVert;
				if (player.transform.position.y < transform.position.y && player.transform.position.y > transform.position.y - rangeVisaoVert &&
				    player.transform.position.x > transform.position.x - 0.75f && player.transform.position.x < transform.position.x + 0.75f) {
					viu = true;
					for (int i = 0; i < objNext.Length; i++) {
						if (objNext[i].transform.position.y < transform.position.y && objNext[i].transform.position.y > transform.position.y - rangeVisaoVert &&
							objNext[i].transform.position.x > transform.position.x - 0.75f && objNext[i].transform.position.x < transform.position.x + 0.75f &&
							Vector2.Distance(transform.position, objNext[i].transform.position) < Vector2.Distance(transform.position, player.transform.position)) {
							viu = false;
						}
					}
					if (viu) {
						if (player.transform.position.y < transform.position.y && player.transform.position.y > transform.position.y - rangeTiroVert &&
						   player.transform.position.x > transform.position.x - 0.75f && player.transform.position.x < transform.position.x + 0.75f) {
							if (animActive) {
								anim.SetBool ("Run", false);
							}
							if (!atirando) {
								atirando = true;
								StartCoroutine (Tiro ());
							}
						} else {
							transform.Translate (Vector2.down * vel * Time.deltaTime);
							if (animActive) {
								anim.SetBool ("Run", true);
								if (!passos.isPlaying) {
									passos.Play ();
								}
							}
							atirando = false;
						}
					}
				} else {
					viu = false;
					atirando = false;
					if (animActive) {
						anim.SetBool ("Run", false);
					}
				}
				break;
			}

		}
	}

	IEnumerator Olhar(){
		while (true) {	
			if (!viu) {
				direcao += (Random.Range (0, 3) - 1);
				vira.Play ();
				if (direcao == 5)
					direcao = 1;
				if (direcao == 0)
					direcao = 4;
			}
			yield return new WaitForSeconds (5f);
		}
	}

	IEnumerator Tiro(){
		yield return new WaitForSeconds (tempoRecarga);
		if (!tiro.isPlaying) {
			tiro.Play ();
		}
		if (atirando && viu) {
			print ("acertou");
			dano = (range - Vector2.Distance (player.transform.position, transform.position)) * 30 / range + 10;
			if (dano > 30) {
				dano = 30;
			}
			if (dano < 10) {
				dano = 10;
			}
			player.GetComponent<PlayerFase2> ().life -= dano;
			print (dano);
			atirando = false;
		} else
			print ("errou");
	}
}
