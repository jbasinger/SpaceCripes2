using UnityEngine;
using System.Collections;

public class WorldState : MonoBehaviour {

	public int maxHitPoints;
	public int hitPoints;
	public GameObject heartPrefab;
	public int minStars;
	public int maxStars;
	public GameObject starPrefab;


	private Color myColor;
	private GameObject hpBar;
	private GameObject[] hearts;
	private float heartWidth;
	private CircleCollider2D radius;

	// Use this for initialization
	void Start () {
		myColor = gameObject.GetComponent<SpriteRenderer>().color;
		radius = gameObject.GetComponent<CircleCollider2D>();
		//radius = Instantiate(gameObject.GetComponent<CircleCollider2D>(),transform.position,Quaternion.identity) as CircleCollider2D;
		//radius.radius += 0.15f;
		SetupStars();
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

	public void AddHealth(){
		if(1+hitPoints > maxHitPoints) return;
		Vector3 newHeartPos = hpBar.transform.position;
		newHeartPos.x -= hitPoints*heartWidth;
		GameObject newHeart = Instantiate(heartPrefab,newHeartPos,Quaternion.identity) as GameObject;
		hearts[hitPoints] = newHeart;
		hitPoints++;
	}

	//This should probably be somewhere else, but I'm running out of time here!
	public void SetupStars(){
		int numStars = Random.Range (minStars, maxStars);
		if(numStars < 0) numStars = 0;
		for(int i=0; i < numStars; i++){
		
			Vector3 rndPos = Vector3.zero;
			while(radius.OverlapPoint(rndPos)){
				rndPos = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range (0,Screen.width),Random.Range (0,Screen.height),0f));
				rndPos.z = 0f;
			}

			Instantiate(starPrefab,rndPos,Quaternion.identity);
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

		if(hearts != null){
			foreach(GameObject h in hearts){
				if(h) Destroy(h);
			}
		}

		hearts = new GameObject[hitPoints];

		for(int i=0;i<hitPoints;i++){
			Vector3 newHeartPos = hpBar.transform.position;
			newHeartPos.x -= i*heartWidth;
			GameObject newHeart = Instantiate(heartPrefab,newHeartPos,Quaternion.identity) as GameObject;
			hearts[i] = newHeart;
		}

	}

}
