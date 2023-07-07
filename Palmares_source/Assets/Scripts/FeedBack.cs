using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedBack : MonoBehaviour {

	public GameObject item;
	public GameObject itemVarObj;
	public Sprite[] itemSprites;
	public float itemVar;
	public float itemVarMax;
	public string itemType;

	private Sprite itemAtual;

	public GameObject deposito;
	public GameObject depVarObj;
	public Sprite[] depositoSprites;
	public float depositoVar;
	public float depositoVarMax;
	public string depType;

	private Sprite depositoAtual;

	// Use this for initialization
	void Start () {
		//itemAtual = item.GetComponent<SpriteRenderer> ().sprite;
		//depositoAtual = deposito.GetComponent<SpriteRenderer> ().sprite;
	}
	
	// Update is called once per frame
	void Update () {
		//ITEM
		if (item != null) {
			if (itemType == "Cana") {
				itemVar = itemVarObj.GetComponent<PlayerNivel2> ().caixaCanas;
			} else if (itemType == "Garapa") {
				itemVar = itemVarObj.GetComponent<PlayerNivel3> ().garapasJarro;
			}

			for (int i = itemSprites.Length - 1; i > 0; i -= 1) {
				if (itemVar < 1) {
					itemAtual = itemSprites [itemSprites.Length - 1];
				} else if (itemVar >= itemVarMax) {
					itemAtual = itemSprites [0];
				} else if (itemVar <= ((itemVarMax - 2) / (itemSprites.Length - 2)) * (itemSprites.Length - i) && itemVar > ((itemVarMax - 2) / (itemSprites.Length - 2)) * (itemSprites.Length - i - 1)) {
					itemAtual = itemSprites [i];
				}
			}
			item.GetComponent<SpriteRenderer> ().sprite = itemAtual;
		}

		//DEPÓSITO
		if (deposito != null) {
			if (depType == "Cana") {
				depositoVar = depVarObj.GetComponent<PlayerNivel1> ().points;
			} else if (depType == "Garapa") {
				depositoVar = depVarObj.GetComponent<PlayerNivel2> ().points;
			} else if (depType == "Melado") {
				depositoVar = depVarObj.GetComponent<PlayerNivel3> ().points;
			} else if (depType == "Acucar") {
				depositoVar = depVarObj.GetComponent<PlayerNivel4> ().points;
			}

			for (int i = 0; i < depositoSprites.Length - 1; i += 1) {
				if (depositoVar < 1) {
					depositoAtual = depositoSprites [0];
				} else if (depositoVar >= depositoVarMax) {
					depositoAtual = depositoSprites [depositoSprites.Length-1];
				} else if (depositoVar <= ((depositoVarMax - 2) / (depositoSprites.Length - 2)) * (i) && depositoVar > ((depositoVarMax - 2) / (depositoSprites.Length - 2)) * (i - 1)) {
					depositoAtual = depositoSprites [i];
				}
			}
			deposito.GetComponent<SpriteRenderer> ().sprite = depositoAtual;
		}
	}
}
