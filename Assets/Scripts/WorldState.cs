using UnityEngine;
using System.Collections;

public class WorldState : MonoBehaviour {

	public int maxHitPoints;
	public int hitPoints;
	public GameObject heartPrefab;

	private Color myColor;
	private GameObject hpBar;
	private GameObject[] hearts;
	private float heartWidth;

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
			Destroy (hearts[hitPoints]);
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

		if(hpBar == null){
			hpBar = GameObject.Find("HpBarStart");
		}
		hpBar.SetActive(false);
		heartWidth = heartPrefab.GetComponent<SpriteRenderer>().bounds.size.x;

		hearts = new GameObject[hitPoints];

		foreach(GameObject h in hearts){
			if(h) Destroy(h);
		}

		for(int i=0;i<hitPoints;i++){
			Vector3 newHeartPos = hpBar.transform.position;
			newHeartPos.x -= i*heartWidth;
			GameObject newHeart = Instantiate(heartPrefab,newHeartPos,Quaternion.identity) as GameObject;
			hearts[i] = newHeart;
		}

	}

}
