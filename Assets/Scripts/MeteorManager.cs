using UnityEngine;
using System.Collections;

public class MeteorManager : MonoBehaviour {

	public int maxMeteorCount;
	public Transform baseMeteor;

	private float rndAngle;
	private Vector3 rndMeteorStart;
	private float distanceToCornerOfScreen;
	private float meteorStartDistance;

	// Use this for initialization
	void Start () {

		GameObject world = GameObject.Find("World");
		distanceToCornerOfScreen = Vector2.Distance(world.transform.position, Camera.main.ScreenToWorldPoint(new Vector3(Screen.width,Screen.height)));

		UpdateMeteorCount();
	}
	
	// Update is called once per frame
	void Update () {
		UpdateMeteorCount();
	}

	void UpdateMeteorCount(){
		while(gameObject.transform.childCount < maxMeteorCount){

			rndAngle = Random.value*Mathf.PI*2;
			meteorStartDistance = distanceToCornerOfScreen + Random.value*5.0f;
			
			rndMeteorStart = new Vector3(Mathf.Cos(rndAngle)*(meteorStartDistance),Mathf.Sin(rndAngle)*(meteorStartDistance),0);

			Transform newMeteor = Instantiate(baseMeteor,rndMeteorStart,Quaternion.identity) as Transform;
			newMeteor.transform.parent = this.gameObject.transform;
		}
	}
}
