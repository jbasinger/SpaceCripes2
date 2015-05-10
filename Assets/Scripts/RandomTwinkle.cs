using UnityEngine;
using System.Collections;

public class RandomTwinkle : MonoBehaviour {

	private Animator anim;
	private float timer;

	// Use this for initialization
	void Start () {
		anim = gameObject.GetComponent<Animator>();
		SetupTimer();
	}
	
	// Update is called once per frame
	void Update () {
		timer -= Time.unscaledDeltaTime;
		if(timer <= 0){
			SetupTimer();
			anim.Play("Star");
		}
	}

	void SetupTimer(){
		timer = Random.Range (1f,10f);
	}
}
