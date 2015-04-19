using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public int level;

	public GameObject[] numberPrefabs = new GameObject[10];

	private GameObject levelLabel;
	private ArrayList levelNumberLabels;

	private Vector3 rhsLabel;
	private float kerning = 0.1f;

	// Use this for initialization
	void Start () {

		levelNumberLabels = new ArrayList();
		levelLabel = GameObject.Find("LevelLabelStart");
		float labelWidth = levelLabel.GetComponent<SpriteRenderer>().bounds.size.x;
		rhsLabel = new Vector3(levelLabel.transform.position.x + labelWidth/2, levelLabel.transform.position.y,0f);

		DrawLevel();

		Reset();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void LevelUp(){
		level++;
		DrawLevel();
	}

	public void Reset(){
		level = 2;
		DrawLevel();
	}

	public void DrawLevel(){

		foreach(GameObject number in levelNumberLabels){
			Destroy(number);
		}

		levelNumberLabels = new ArrayList();
		string levelStr = level.ToString();
		Vector3 pos = rhsLabel;
		foreach(char c in levelStr.ToCharArray()){
			GameObject number = Instantiate(numberPrefabs[int.Parse(c.ToString())],rhsLabel,Quaternion.identity) as GameObject;
			float numberWidth = number.GetComponent<SpriteRenderer>().bounds.size.x;
			pos.x += kerning + numberWidth/2;
			number.transform.position = pos;
			levelNumberLabels.Add(number);
		}
	}
}
