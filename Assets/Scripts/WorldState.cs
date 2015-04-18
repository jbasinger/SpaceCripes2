using UnityEngine;
using System.Collections;

public class WorldState : MonoBehaviour {

	public int hitPoints;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D coll){
		if(coll.gameObject.tag == "Meteor"){
			hitPoints -= 1;
		}
	}

}
