using UnityEngine;
using System.Collections;

public class MeteorCollision : MonoBehaviour {

	public GameObject meteor0Prefab;
	public GameObject meteor1Prefab;
	public GameObject meteor2Prefab;
	public GameObject meteor3Prefab;

	public GameObject[] parts = new GameObject[4];

	// Use this for initialization
	void Start () {
		parts[0] = meteor0Prefab;
		parts[1] = meteor1Prefab;
		parts[2] = meteor2Prefab;
		parts[3] = meteor3Prefab;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D coll){
		if(coll.gameObject.tag == "Alien" || coll.gameObject.name == "World"){

			foreach(GameObject part in parts){
				GameObject newPart = Instantiate(part,gameObject.transform.position,Quaternion.identity) as GameObject;
				newPart.AddComponent<Explosivo>();
				Destroy (newPart, 1.5f);
			}

			Destroy(gameObject);
		}


	}
}
