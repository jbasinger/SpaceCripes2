using UnityEngine;
using System.Collections;

public class MeteorCollision : MonoBehaviour {

	public GameObject meteor0Prefab;
	public GameObject meteor1Prefab;
	public GameObject meteor2Prefab;
	public GameObject meteor3Prefab;

	public AudioClip explosion0;
	public AudioClip explosion1;
	public AudioClip explosion2;
	public AudioClip explosion3;

	private GameObject[] parts = new GameObject[4];
	private AudioClip[] sfx = new AudioClip[4];

	// Use this for initialization
	void Start () {
		parts[0] = meteor0Prefab;
		parts[1] = meteor1Prefab;
		parts[2] = meteor2Prefab;
		parts[3] = meteor3Prefab;

		sfx[0] = explosion0;
		sfx[1] = explosion1;
		sfx[2] = explosion2;
		sfx[3] = explosion3;

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D coll){
		if(coll.gameObject.tag == "Alien" || coll.gameObject.name == "World"){

			AudioSource.PlayClipAtPoint(sfx[Random.Range (0,sfx.Length-1)],transform.position);

			foreach(GameObject part in parts){
				GameObject newPart = Instantiate(part,gameObject.transform.position,Quaternion.identity) as GameObject;
				newPart.AddComponent<Explosivo>();
				Destroy (newPart, 1.5f);
			}

			Destroy(gameObject);
		}


	}
}
