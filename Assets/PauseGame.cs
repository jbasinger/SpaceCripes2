using UnityEngine;
using System.Collections;

public class PauseGame : MonoBehaviour {

	
	public Sprite normalButtonSprite;
	public Sprite clickedButtonSprite;
	public GameObject pauseMenu;

	SpriteRenderer render;

	// Use this for initialization
	void Start () {
		render = this.GetComponent<SpriteRenderer>();
		SetPause(false);
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetKeyDown(KeyCode.Space)){
			SetPause (!IsPaused ());
		}

		if(normalButtonSprite != null && clickedButtonSprite != null){
			if(IsPaused()){
				render.sprite = clickedButtonSprite;
			} else {
				render.sprite = normalButtonSprite;
			}
		}
	}

	void OnMouseDown(){
		SetPause (!IsPaused());
	}

	public void SetPause(bool isPaused){
		Time.timeScale = isPaused ? 0 : 1;
		pauseMenu.SetActive(isPaused);
	}
	public bool IsPaused(){
		return Time.timeScale == 0;
	}
}
