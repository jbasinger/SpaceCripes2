using UnityEngine;
using System.Collections;

public class StateManager : MonoBehaviour {

	public Transform GetReadyPrefab;
	public Transform CountDown1Prefab;
	public Transform CountDown2Prefab;
	public Transform CountDown3Prefab;
	public Transform GoPrefab;

	private enum GameState {
		NotStarted,
		Starting,
		Playing,
		Won,
		Lost,
		Ending
	};

	private float timer;
	private float dT;
	private float magnitude;
	private int direction = 1;
	private GameObject world;

	private Transform label;
	private Transform getReady;
	private Transform countDown3;
	private Transform countDown2;
	private Transform countDown1;
	private Transform go;

	private GameState state = GameState.NotStarted;
	private delegate void StateHelper();
	StateHelper helper;

	// Use this for initialization
	void Start () {
	
		world = GameObject.Find("World");
		getReady = Instantiate(GetReadyPrefab,Vector3.zero,Quaternion.identity) as Transform;
		countDown3 = Instantiate(CountDown3Prefab,Vector3.zero,Quaternion.identity) as Transform;
		countDown2 = Instantiate(CountDown2Prefab,Vector3.zero,Quaternion.identity) as Transform;
		countDown1 = Instantiate(CountDown1Prefab,Vector3.zero,Quaternion.identity) as Transform;
		go = Instantiate(GoPrefab,Vector3.zero,Quaternion.identity) as Transform;

		getReady.gameObject.SetActive(false);
		countDown1.gameObject.SetActive(false);
		countDown2.gameObject.SetActive(false);
		countDown3.gameObject.SetActive(false);
		go.gameObject.SetActive(false);

	}
	
	// Update is called once per frame
	void Update () {

		dT = Time.deltaTime;
		timer -= dT;

		if(helper != null){
			helper();
		}

		if(state == GameState.NotStarted){
			StartGame();
		}

		if(state == GameState.Playing){
			CheckWinLoseConditions();
		}

		if(state == GameState.Won){
			WinGame();
		}

		if(state == GameState.Lost){
			LoseGame();
		}
	}

	void StartGame(){
		timer = 2f;
		getReady.gameObject.SetActive(true);
		helper = ShowGetReady;
		state = GameState.Starting;
	}

	void ShowGetReady(){
		if(timer < 0){
			getReady.gameObject.SetActive(false);
			countDown3.gameObject.SetActive(true);
			timer = 1f;
			helper = ShowCountDown3;
		}
	}

	void ShowCountDown3(){
		if(timer < 0){
			countDown3.gameObject.SetActive(false);
			countDown2.gameObject.SetActive(true);
			timer = 1f;
			helper = ShowCountDown2;
		}
	}

	void ShowCountDown2(){
		if(timer < 0){
			countDown2.gameObject.SetActive(false);
			countDown1.gameObject.SetActive(true);
			timer = 1f;
			helper = ShowCountDown1;
		}
	}

	void ShowCountDown1(){
		if(timer < 0){
			countDown1.gameObject.SetActive(false);
			go.gameObject.SetActive(true);
			timer = 1f;
			helper = ShowGo;

		}
	}

	void ShowGo(){
		if(timer < 0){
			go.gameObject.SetActive(false);
			timer = 0;
			state = GameState.Playing;
			helper = null;
		}
	}

	void CheckWinLoseConditions(){
	}

	void WinGame(){
	}

	void LoseGame(){
	}

	public bool IsStopped(){
		return state != GameState.Playing;
	}

}
