using UnityEngine;
using System.Collections;

public class SFXButton : MonoBehaviour {

	public SoundManager soundManager;
	public GameObject soundWave;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown(){
		soundManager.SetSFX(!soundManager.SFXAreOn());
		soundWave.SetActive(soundManager.SFXAreOn());
	}
}
