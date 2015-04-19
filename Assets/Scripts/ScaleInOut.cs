using UnityEngine;
using System.Collections;

public class ScaleInOut : MonoBehaviour {

	private int direction = 1;
	private float magnitude;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		/*
		if(transform.localScale.x >= 1.2f || transform.localScale.x <= 0.8f){
			direction *= -1;
		}
		
		magnitude = direction*Time.deltaTime;
		
		transform.localScale = new Vector3(transform.localScale.x + magnitude,transform.localScale.y + magnitude,0f);
		*/
	}
}
