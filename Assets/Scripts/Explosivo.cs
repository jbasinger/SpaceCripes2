using UnityEngine;
using System.Collections;

public class Explosivo : MonoBehaviour {

	private Rigidbody2D body;
	private float timer;
	private Vector3 rndVec;
	private float rndAngle;
	private GameObject world;
	private float rndMag;

	// Use this for initialization
	void Start () {
		world = GameObject.Find("World");
		body = gameObject.GetComponent<Rigidbody2D>();

		body.AddTorque(Random.Range(-5f,5f));

		rndMag = 5f;//Random.Range(3f,8f);
		rndAngle = Random.Range(-90,90);

		rndVec = gameObject.transform.position - world.transform.position;
		rndVec *= rndMag;
		rndVec = Quaternion.AngleAxis(rndAngle,new Vector3(0f,0f,1f)) * rndVec;

		timer = 0.5f;
	}
	
	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;
		if(timer > 0){
			body.AddForce(rndVec);
		}
	}
}
