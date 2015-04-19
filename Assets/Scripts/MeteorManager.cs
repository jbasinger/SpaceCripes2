using UnityEngine;
using System.Collections;

public class MeteorManager : MonoBehaviour {

	public int maxMeteorCount;
	public Transform baseMeteor;
	public GameObject[] powerUps = new GameObject[2];

	private float rndAngle;
	private Vector3 rndMeteorStart;
	private float distanceToCornerOfScreen;
	private float meteorStartDistance;

	private int level;

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

		level = GameObject.Find("LevelManager").GetComponent<LevelManager>().level;
		int meteorCount = maxMeteorCount + (level/4); //Banking on truncation here.

		while(gameObject.transform.childCount < meteorCount){

			rndAngle = Random.value*Mathf.PI*2;
			meteorStartDistance = distanceToCornerOfScreen + Random.value*5.0f;
			
			rndMeteorStart = new Vector3(Mathf.Cos(rndAngle)*(meteorStartDistance),Mathf.Sin(rndAngle)*(meteorStartDistance),0);

			if(Random.value > 0.85){
				int pu = Random.value > 0.5 ? 0 : 1;
				GameObject powerUp = Instantiate(powerUps[pu],rndMeteorStart,Quaternion.identity) as GameObject;
				powerUp.transform.parent = this.gameObject.transform;
			} else {
				Transform newMeteor = Instantiate(baseMeteor,rndMeteorStart,Quaternion.identity) as Transform;
				newMeteor.transform.parent = this.gameObject.transform;
				PlanetaryGravity grav = newMeteor.GetComponent<PlanetaryGravity>();
				float gForce = grav.gravitationCoefficient;
				newMeteor.GetComponent<PlanetaryGravity>().gravitationCoefficient = gForce + ((level-1)*gForce/10);
			}
		}
	}



}
