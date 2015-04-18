using UnityEngine;
using System.Collections;

public class MeteorManager : MonoBehaviour {

	public int maxMeteorCount;
	public Transform baseMeteor;

	// Use this for initialization
	void Start () {
		UpdateMeteorCount();
	}
	
	// Update is called once per frame
	void Update () {
		UpdateMeteorCount();
	}

	void UpdateMeteorCount(){
		while(gameObject.transform.childCount < maxMeteorCount){

			GameObject newMeteor = Instantiate(baseMeteor,Vector3.zero,Quaternion.identity);
			newMeteor.transform.parent = this.gameObject.transform;
		}
	}
}
