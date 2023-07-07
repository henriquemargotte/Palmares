using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cana : MonoBehaviour {

	public int quant;
	public Sprite[] sprites;
	
	// Update is called once per frame
	void Update () {
		GetComponent<SpriteRenderer> ().sprite = sprites[quant];
		if (quant <= 1) {
			GetComponent<PolygonCollider2D> ().enabled = false;
		}
	}
}
