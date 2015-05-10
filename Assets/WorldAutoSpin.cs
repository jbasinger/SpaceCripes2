using UnityEngine;
using System.Collections;

public class WorldAutoSpin : MonoBehaviour {

	public float speed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float factor = Time.deltaTime*speed;
		this.transform.Rotate(Vector3.back*factor);
	}
}
