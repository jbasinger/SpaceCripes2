using UnityEngine;
using System.Collections;

public class SplashScreen : MonoBehaviour {

	public float seconds;
	public string sceneName;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		seconds -= Time.unscaledDeltaTime;
		if(seconds <= 0){
			Application.LoadLevel(sceneName);
		}
	}
}
