using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {

	private float factor;
	private float speed = 100;

	private GameObject world, leftButton, rightButton;
	private BoxCollider2D leftHitbox, rightHitbox;
	private Vector2 mousePos;

	public Sprite normalButtonSprite;
	public Sprite clickedButtonSprite;

	private SpriteRenderer leftButtonRenderer;
	private SpriteRenderer rightButtonRenderer;

	private StateManager state;

	// Use this for initialization
	void Start () {
		state = GameObject.Find("StateManager").GetComponent<StateManager>();
		world = GameObject.Find("World");
		leftButton = GameObject.Find("LeftButton");
		rightButton = GameObject.Find("RightButton");
		leftHitbox = leftButton.GetComponent<BoxCollider2D>();
		rightHitbox = rightButton.GetComponent<BoxCollider2D>();
	
		leftButtonRenderer = leftButton.GetComponent<SpriteRenderer>();
		rightButtonRenderer = rightButton.GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {

		if(state.IsStopped()) return;

		factor = Time.deltaTime*speed;
		mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		
		if(NeedsToRotate()){
			if (InputIsLeft()){
				factor *= -1;
				leftButtonRenderer.sprite = clickedButtonSprite;
				rightButtonRenderer.sprite = normalButtonSprite;
			} else {
				rightButtonRenderer.sprite = clickedButtonSprite;
				leftButtonRenderer.sprite = normalButtonSprite;
			}
			RotateWorld(factor);
		} else {
			leftButtonRenderer.sprite = normalButtonSprite;
			rightButtonRenderer.sprite = normalButtonSprite;
		}
	}

	void RotateWorld(float factor){
		world.transform.Rotate(Vector3.back*factor);
	}

	bool InputIsLeft(){
		return Input.GetKey(KeyCode.LeftArrow) || (Input.GetMouseButton(0) && leftHitbox.OverlapPoint(mousePos));
	}

	bool InputIsRight(){
		return Input.GetKey(KeyCode.RightArrow) || (Input.GetMouseButton(0) && rightHitbox.OverlapPoint(mousePos));
	}

	bool NeedsToRotate(){
		return InputIsLeft() || InputIsRight();
	}
}
