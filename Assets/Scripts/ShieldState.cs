using UnityEngine;
using System.Collections;

public class ShieldState : MonoBehaviour {

	public float speed;
	public GameObject[] parts = new GameObject[3];

	private float direction;
	private float mahMagnitude;
	private GameObject world;

	// Use this for initialization
	void Start () {
		direction = Random.value > 0.5 ? 1 : -1;
		world = GameObject.Find("World");
		speed += Random.Range(-10f,10f);
	}
	
	// Update is called once per frame
	void Update () {
		mahMagnitude = speed*Time.deltaTime*direction;
		this.gameObject.transform.RotateAround(world.transform.position,Vector3.forward,mahMagnitude);
	}

	void OnCollisionEnter2D(Collision2D coll){
		if(coll.gameObject.tag == "Meteor"){
			foreach(GameObject part in parts){
				GameObject newPart = Instantiate(part,gameObject.transform.position,Quaternion.identity) as GameObject;
				newPart.AddComponent<Explosivo>();
				Destroy (newPart, 1.5f);
			}
			Destroy(gameObject);
		}
	}

}
