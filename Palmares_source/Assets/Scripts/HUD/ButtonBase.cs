using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonBase : MonoBehaviour {

	public string scene;
	public AudioSource onButton;
	public AudioSource click;

	public void ChangeScene(){
		click.Play ();
		SceneManager.LoadScene (scene);
		Time.timeScale = 1;
	}

	public void Exit(){
		click.Play ();
		Application.Quit ();
	}

	public void PlaySound(){
		onButton.Play ();
	}
}
