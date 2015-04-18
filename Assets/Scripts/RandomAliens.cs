using UnityEngine;
using System.Collections;

public class RandomAliens : MonoBehaviour {

	public GameObject world;
	public Transform baseAlien;
	public int numberOfAliens;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void GenerateAliens(){
		float worldRadius = world.GetComponent<CircleCollider2D>().radius;
		float halfHeightOfAlien = baseAlien.transform.localScale.y/4;
		
		for(int i=0; i<numberOfAliens;i++){
			
			float rndAngle = Random.value*Mathf.PI*2;
			
			Vector3 rndCirclePoint = new Vector3(Mathf.Cos(rndAngle)*(worldRadius+halfHeightOfAlien),Mathf.Sin(rndAngle)*(worldRadius+halfHeightOfAlien),0);
			
			Transform alien = Instantiate(baseAlien,rndCirclePoint,Quaternion.identity) as Transform;
			alien.rotation = Quaternion.AngleAxis(rndAngle*Mathf.Rad2Deg-90,new Vector3(0f,0f,1f));
			
			alien.SetParent(world.transform);
			
		}
	}
}
