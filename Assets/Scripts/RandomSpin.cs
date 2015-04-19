using UnityEngine;
using System.Collections;

public class RandomSpin : MonoBehaviour {

	public float minRange;
	public float maxRange;

	private float torque;
	private Rigidbody2D body;

	// Use this for initialization
	void Start () {
		body = gameObject.GetComponent<Rigidbody2D>();
		torque = Random.Range(minRange,maxRange);
	}
	
	// Update is called once per frame
	void Update () {
		body.AddTorque(torque);
	}
}
