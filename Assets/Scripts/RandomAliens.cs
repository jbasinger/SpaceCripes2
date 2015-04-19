using UnityEngine;
using System.Collections;

public class RandomAliens : MonoBehaviour {

	public GameObject world;
	public GameObject baseAlien;
	public int numberOfAliens;

	private GameObject levelManager;

	// Use this for initialization
	void Start () {
		levelManager = GameObject.Find("LevelManager");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void GenerateAliens(){
		float worldRadius = world.GetComponent<CircleCollider2D>().radius;
		float halfHeightOfAlien = baseAlien.transform.localScale.y/4;

		if(levelManager == null){
			levelManager = GameObject.Find("LevelManager");
		}

		int level = levelManager.GetComponent<LevelManager>().level;
		int alienCount = numberOfAliens + (level/2);
		if(alienCount > 20) alienCount = 20;

		for(int i=0; i<alienCount;i++){
			
			float rndAngle = Random.value*Mathf.PI*2;
			
			Vector3 rndCirclePoint = new Vector3(Mathf.Cos(rndAngle)*(worldRadius+halfHeightOfAlien),Mathf.Sin(rndAngle)*(worldRadius+halfHeightOfAlien),0);
			
			GameObject alien = Instantiate(baseAlien,rndCirclePoint,Quaternion.identity) as GameObject;
			alien.transform.rotation = Quaternion.AngleAxis(rndAngle*Mathf.Rad2Deg-90,new Vector3(0f,0f,1f));
			MutateAlien(alien,level);
			alien.transform.SetParent(world.transform);
			
		}
	}

	void MutateAlien(GameObject alien, int level){
		if(level == 1) return;
		if(level == 2 || level == 3){
			if(Random.Range (0,21)%3 == 0){
				alien.AddComponent<BulkyAlien>();
			}
		}
		if(level == 4){
			if(Random.Range (0,21)%3 == 0){
				if(Random.Range (0,22)%2 == 0){
					alien.AddComponent<BulkyAlien>();
				} else {
					alien.AddComponent<SpeedyAlien>();
				}
			}
		}
		if(level >= 5){
			if(Random.Range (0,22)%2 == 0){
				alien.AddComponent<BulkyAlien>();
			} 
			if(Random.Range (0,21)%3 == 0){
				alien.AddComponent<SpeedyAlien>();
			}
		}

	}
}
