using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	public AudioClip healthUpSound;

	private GameObject world;
	private SoundManager soundManager;

	// Use this for initialization
	void Start () {
		world = GameObject.Find("World");
		soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D coll){
		if(coll.gameObject.name == "World" || coll.gameObject.tag == "Shield"){
			if(soundManager.SFXAreOn()){
				AudioSource.PlayClipAtPoint(healthUpSound,transform.position);
			}
			world.GetComponent<WorldState>().AddHealth();
		}
	}
}
