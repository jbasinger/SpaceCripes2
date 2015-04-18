using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour {

	private float time;
	private float speed = 100;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		time = Time.deltaTime;

		if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow)){
			time = Input.GetKey(KeyCode.LeftArrow) ? time*-1 : time;
			transform.Rotate(Vector3.back*time*speed);
		}

	}
}
