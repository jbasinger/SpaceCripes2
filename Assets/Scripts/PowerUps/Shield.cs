using UnityEngine;
using System.Collections;

public class Shield : MonoBehaviour {

	public AudioClip shieldUpSound;
	public GameObject shieldPrefab;
	public float radius;

	private SoundManager soundManager;

	// Use this for initialization
	void Start () {
		soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnCollisionEnter2D(Collision2D coll){
		if(coll.gameObject.name == "World" || coll.gameObject.tag == "Shield"){

			if(soundManager.SFXAreOn()){
				AudioSource.PlayClipAtPoint(shieldUpSound,transform.position);
			}

			GameObject[] otherShields = GameObject.FindGameObjectsWithTag("Shield");

			if(otherShields.Length >= 3) return;

			float rndAngle  = Random.value*Mathf.PI*2;
			Vector3 rndCirclePoint = new Vector3(Mathf.Cos(rndAngle)*(radius),Mathf.Sin(rndAngle)*(radius),0);

			GameObject shield = Instantiate(shieldPrefab,rndCirclePoint,Quaternion.identity) as GameObject;
			shield.transform.rotation = Quaternion.AngleAxis(rndAngle*Mathf.Rad2Deg,new Vector3(0f,0f,1f));

		}
	}
}
