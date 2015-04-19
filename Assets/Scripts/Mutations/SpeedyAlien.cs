using UnityEngine;
using System.Collections;

public class SpeedyAlien : MonoBehaviour {

	// Use this for initialization
	void Start () {
		gameObject.GetComponent<AlienBrain>().speed *= 3;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
