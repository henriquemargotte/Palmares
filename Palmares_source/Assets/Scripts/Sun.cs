using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : MonoBehaviour {

	public GameObject[] sun = new GameObject[5];
	public int dayTime;

	// Use this for initialization
	void Start () {
		Instantiate (sun [dayTime]);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
