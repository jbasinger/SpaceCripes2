using UnityEngine;
using System.Collections;

public class PowerupCollision : MonoBehaviour {

	public GameObject explosion0Prefab;
	public GameObject explosion1Prefab;

	public AudioClip explosion0Sound;
	public AudioClip explosion1Sound;
	public AudioClip explosion2Sound;
	public AudioClip explosion3Sound;
	
	private GameObject world;
	private AudioClip[] sfx = new AudioClip[4];

	// Use this for initialization
	void Start () {
		world = GameObject.Find("World");
		
		sfx[0] = explosion0Sound;
		sfx[1] = explosion1Sound;
		sfx[2] = explosion2Sound;
		sfx[3] = explosion3Sound;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D coll){

		//Explosions!
		if(coll.gameObject.tag == "Alien" || coll.gameObject.name == "World" || coll.gameObject.tag == "Shield"){

			Vector3 pos = coll.transform.position;
			if(coll.gameObject.name == "World"){
				pos = gameObject.transform.position;
			}
			
			GameObject exp0 = Instantiate(explosion0Prefab,pos,Quaternion.identity) as GameObject;
			GameObject exp1 = Instantiate(explosion1Prefab,pos,Quaternion.identity) as GameObject;
			exp0.transform.parent = world.transform;
			exp1.transform.parent = world.transform;
			Destroy (exp0, 0.75f);
			Destroy (exp1, 0.75f);
			
			Destroy(gameObject);
		}

		if(coll.gameObject.tag == "Alien"){
			AudioSource.PlayClipAtPoint(sfx[Random.Range (0,sfx.Length-1)],transform.position);
		}

	}


}
