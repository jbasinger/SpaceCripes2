using UnityEngine;
using System.Collections;

public class AlienBrain : MonoBehaviour {

	public int speed;
	public int hitPoints;

	public GameObject alienPart0Prefab;
	public GameObject alienPart1Prefab;
	public GameObject alienPart2Prefab;
	public GameObject alienPart3Prefab;
	public GameObject alienPart4Prefab;
	public GameObject alienPart5Prefab;
	public GameObject alienPart6Prefab;

	private const float RECONTEMPLATE_WHY_I_AM_AN_ALIEN_AND_NOT_A_WIZARD_TIME = 2.0f;

	private int direction = 1;
	private GameObject world;
	private float mahAngle;
	private Vector2 mahVector;
	private float mahMagnitude;
	private Vector2 mahScale;
	private float timer = 0f;
	private GameObject[] alienParts = new GameObject[7];

	private StateManager state;

	// Use this for initialization
	void Start () {
		state = GameObject.Find("StateManager").GetComponent<StateManager>();
		world = GameObject.Find("World");
		UpdateDirectionAndTimer();
		//Randomly remove or add 10% of the speed. Make stuff look more fun?
		speed += Random.Range(-speed/10,speed/10);

		alienParts[0] = alienPart0Prefab;
		alienParts[1] = alienPart1Prefab;
		alienParts[2] = alienPart2Prefab;
		alienParts[3] = alienPart3Prefab;
		alienParts[4] = alienPart4Prefab;
		alienParts[5] = alienPart5Prefab;
		alienParts[6] = alienPart6Prefab;

	}
	
	// Update is called once per frame
	void Update () {

		if(state.IsStopped()) return;

		timer -= Time.deltaTime;

		UpdateDirectionAndTimer();

		mahMagnitude = speed*Time.deltaTime*direction;
		this.gameObject.transform.RotateAround(world.transform.position,Vector3.forward,mahMagnitude);

	}

	void UpdateDirectionAndTimer(){
		if(timer <= 0){
			direction = Random.Range(0,10) % 2 == 0 ? direction : direction*-1;
			timer = RECONTEMPLATE_WHY_I_AM_AN_ALIEN_AND_NOT_A_WIZARD_TIME + Random.Range(-1,2);
			mahScale = this.gameObject.transform.localScale;
			mahScale.x *= direction;
			this.gameObject.transform.localScale = mahScale;
		}
	}

	void OnCollisionEnter2D(Collision2D coll){
		if(coll.gameObject.tag == "Alien"){
			direction *= -1;
		}
		if(coll.gameObject.tag == "Meteor" || coll.gameObject.tag == "PowerUp"){

			hitPoints -= 1;

			if(hitPoints <= 0){
				foreach(GameObject part in alienParts){
					GameObject newPart = Instantiate(part,gameObject.transform.position,Quaternion.identity) as GameObject;
					newPart.AddComponent<Explosivo>();
					Destroy (newPart, 3f);
				}
				Destroy(gameObject);
			}
		}
	}
}
