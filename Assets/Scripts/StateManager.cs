using UnityEngine;
using System.Collections;

public class StateManager : MonoBehaviour {

	//Game Start Prefabs
	public Transform GetReadyPrefab;
	public Transform CountDown1Prefab;
	public Transform CountDown2Prefab;
	public Transform CountDown3Prefab;
	public Transform GoPrefab;

	//Game End Prefabs
	public Transform YouLosePrefab;
	public Transform YouWinPrefab;
	public Transform PlayAgainPrefab;

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

	private Transform getReady;
	private Transform countDown3;
	private Transform countDown2;
	private Transform countDown1;
	private Transform go;

	private Transform youWin;
	private Transform youLose;
	private Transform playAgain;

	private GameState state = GameState.NotStarted;
	private delegate void StateHelper();
	StateHelper helper;

	// Use this for initialization
	void Start () {
	
		world = GameObject.Find("World");

		//Game Start Prefabs
		getReady = Instantiate(GetReadyPrefab,Vector3.zero,Quaternion.identity) as Transform;
		countDown3 = Instantiate(CountDown3Prefab,Vector3.zero,Quaternion.identity) as Transform;
		countDown2 = Instantiate(CountDown2Prefab,Vector3.zero,Quaternion.identity) as Transform;
		countDown1 = Instantiate(CountDown1Prefab,Vector3.zero,Quaternion.identity) as Transform;
		go = Instantiate(GoPrefab,Vector3.zero,Quaternion.identity) as Transform;

		//Game End Prefabs
		youWin = Instantiate(YouWinPrefab,Vector3.zero,Quaternion.identity) as Transform;
		youLose = Instantiate(YouLosePrefab,Vector3.zero,Quaternion.identity) as Transform;

		Vector3 playAgainPos = world.transform.position + new Vector3(0f,-2f,0f);
		playAgain = Instantiate(PlayAgainPrefab,playAgainPos,Quaternion.identity) as Transform;

		Reset();

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

		if(state == GameState.Ending && Input.anyKeyDown){
			Reset();
			state = GameState.NotStarted;
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
		if(world.transform.childCount == 0){
			state = GameState.Won;
		}
		if(world.GetComponent<WorldState>().hitPoints <= 0){
			state = GameState.Lost;
		}
	}

	void WinGame(){
		Debug.Log("You win!");
		state = GameState.Ending;
		ClearMeteorsAndAliens();
		youWin.gameObject.SetActive(true);
		playAgain.gameObject.SetActive(true);
	}

	void LoseGame(){
		Debug.Log ("You lose!");
		state = GameState.Ending;
		ClearMeteorsAndAliens();
		world.AddComponent<ColorFlipOut>();
		youLose.gameObject.SetActive(true);
		playAgain.gameObject.SetActive(true);
	}

	void ClearMeteorsAndAliens(){
		GameObject[] aliens = GameObject.FindGameObjectsWithTag("Alien");
		GameObject[] meteors = GameObject.FindGameObjectsWithTag("Meteor");
		foreach(GameObject alien in aliens){
			Destroy(alien);
		}
		foreach(GameObject meteor in meteors){
			Destroy(meteor);
		}
	}

	void Reset(){
		getReady.gameObject.SetActive(false);
		countDown1.gameObject.SetActive(false);
		countDown2.gameObject.SetActive(false);
		countDown3.gameObject.SetActive(false);
		go.gameObject.SetActive(false);

		youWin.gameObject.SetActive(false);
		youLose.gameObject.SetActive(false);
		playAgain.gameObject.SetActive(false);

		world.gameObject.GetComponent<WorldState>().Reset();

	}

	public bool IsStopped(){
		return state != GameState.Playing;
	}

}

