using UnityEngine;
using System.Collections;

public class MeteorCollision : MonoBehaviour {

	public GameObject meteor0Prefab;
	public GameObject meteor1Prefab;
	public GameObject meteor2Prefab;
	public GameObject meteor3Prefab;

	public GameObject explosion0Prefab;
	public GameObject explosion1Prefab;

	public AudioClip explosion0Sound;
	public AudioClip explosion1Sound;
	public AudioClip explosion2Sound;
	public AudioClip explosion3Sound;

	private GameObject[] parts = new GameObject[4];
	private AudioClip[] sfx = new AudioClip[4];
	private GameObject world;
	private SoundManager soundManager;

	// Use this for initialization
	void Start () {

		world = GameObject.Find("World");
		soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();

		parts[0] = meteor0Prefab;
		parts[1] = meteor1Prefab;
		parts[2] = meteor2Prefab;
		parts[3] = meteor3Prefab;

		sfx[0] = explosion0Sound;
		sfx[1] = explosion1Sound;
		sfx[2] = explosion2Sound;
		sfx[3] = explosion3Sound;

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D coll){
		if(coll.gameObject.tag == "Alien" || coll.gameObject.name == "World" || coll.gameObject.tag == "Shield"){

			if(soundManager.SFXAreOn()){
				AudioSource.PlayClipAtPoint(sfx[Random.Range (0,sfx.Length-1)],transform.position);
			}

			foreach(GameObject part in parts){
				GameObject newPart = Instantiate(part,gameObject.transform.position,Quaternion.identity) as GameObject;
				newPart.AddComponent<Explosivo>();
				Destroy (newPart, 1.5f);
			}

			Vector3 pos = coll.transform.position;
			if(coll.gameObject.name == "World"){
				pos = gameObject.transform.position;
			}

			GameObject exp0 = Instantiate(explosion0Prefab,pos,Quaternion.identity) as GameObject;
			GameObject exp1 = Instantiate(explosion1Prefab,pos,Quaternion.identity) as GameObject;

			if(coll.gameObject.tag != "Shield"){
				exp0.transform.parent = world.transform;
				exp1.transform.parent = world.transform;
			}

			Destroy (exp0, 0.75f);
			Destroy (exp1, 0.75f);

			Destroy(gameObject);
		}


	}
}
