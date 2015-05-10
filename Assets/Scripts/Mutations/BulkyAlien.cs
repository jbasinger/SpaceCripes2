using UnityEngine;
using System.Collections;

public class BulkyAlien : MonoBehaviour {

	private Color origColor;
	private Vector3 origScale;

	// Use this for initialization
	void Start () {
		gameObject.GetComponent<AlienBrain>().hitPoints = 2;
		origColor = gameObject.GetComponent<SpriteRenderer>().color;
		gameObject.GetComponent<SpriteRenderer>().color = new Color(Random.Range(0.5f,1.0f),Random.Range(0.5f,1.0f),Random.Range(0.5f,1.0f));
		origScale = transform.localScale;
		transform.localScale = transform.localScale * 1.5f;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D coll){
		if(coll.gameObject.tag == "Meteor" || coll.gameObject.tag == "PowerUp"){
			gameObject.GetComponent<SpriteRenderer>().color = origColor;
			transform.localScale = origScale;
			Destroy(this);
		}
	}

}
