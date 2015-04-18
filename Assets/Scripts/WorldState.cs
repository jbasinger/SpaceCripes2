using UnityEngine;
using System.Collections;

public class WorldState : MonoBehaviour {

	public int maxHitPoints;
	public int hitPoints;

	private Color myColor;

	// Use this for initialization
	void Start () {
		myColor = gameObject.GetComponent<SpriteRenderer>().color;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D coll){
		if(coll.gameObject.tag == "Meteor"){
			hitPoints -= 1;
		}
	}

	public void Reset(){
		
		ColorFlipOut worldFlippinOut = gameObject.GetComponent<ColorFlipOut>();
		
		if(worldFlippinOut){
			Destroy(worldFlippinOut);
			gameObject.GetComponent<SpriteRenderer>().color = myColor;
		}
		
		gameObject.GetComponent<RandomAliens>().GenerateAliens();
		hitPoints = maxHitPoints;
	}

}
