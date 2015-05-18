using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {

	public AudioSource GameMusic;
	public AudioSource WinMusic;
	public AudioSource LoseMusic;

	private bool musicIsOn;
	private bool sfxAreOn;

	// Use this for initialization
	void Start () {
		musicIsOn = true;
		sfxAreOn = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SetMusic(bool value){
		musicIsOn = value;
		if(!musicIsOn){
			StopAllMusic();
		} else {
			GameMusic.Play();
		}
	}

	public void SetSFX(bool value){
		sfxAreOn = value;
	}

	public bool MusicIsOn(){
		return musicIsOn;
	}

	public bool SFXAreOn(){
		return sfxAreOn;
	}

	public void PlayGameMusic(){
		if(!GameMusic.isPlaying){
			GameMusic.Play();
		}
	}

	public void PlayWinMusic(){
		GameMusic.Stop();
		WinMusic.Play();
	}

	public void PlayLoseMusic(){
		GameMusic.Stop();
		LoseMusic.Play();
	}

	public void StopAllMusic(){
		GameMusic.Stop();
		WinMusic.Stop();
		LoseMusic.Stop();
	}
}
