using UnityEngine;
using System.Collections;

public class ColorFlipOut : MonoBehaviour {

	const float TIMER_BASE = 0.1f;

	float timer = 0f;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		timer -= Time.deltaTime;

		if(timer <= 0){
			gameObject.GetComponent<SpriteRenderer>().color = new Color(Random.value,Random.value,Random.value);
			timer = TIMER_BASE;
		}

	}
}
