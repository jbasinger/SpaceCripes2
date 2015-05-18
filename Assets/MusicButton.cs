using UnityEngine;
using System.Collections;

public class MusicButton : MonoBehaviour {

	public SoundManager soundManager;
	public GameObject soundWave;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown(){
		soundManager.SetMusic(!soundManager.MusicIsOn());
		soundWave.SetActive(soundManager.MusicIsOn());
	}
}
