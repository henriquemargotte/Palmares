using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class ControlAudioFX : MonoBehaviour {

	public AudioMixer effects;

	public void SetVolume(float vol){
		effects.SetFloat ("volume", vol);
	}
}
