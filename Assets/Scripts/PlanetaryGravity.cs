using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class PlanetaryGravity : MonoBehaviour {

	public float gravitationCoefficient;
	public bool stayUpRight;

	private Transform world;
	private Rigidbody2D myBodyIsReady;
	private Vector3 normalDiff;
	private Quaternion rotate;

	private StateManager state;

	// Use this for initialization
	void Start () {
		state = GameObject.Find("StateManager").GetComponent<StateManager>();
		world = GameObject.Find("World").transform;
		myBodyIsReady = this.gameObject.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {

		if(state.IsStopped()) return;

		normalDiff = world.transform.position - gameObject.transform.position;
		myBodyIsReady.AddForce(normalDiff.normalized * gravitationCoefficient);
	}
}
