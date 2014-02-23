using UnityEngine;
using System.Collections;

public class MovementTest : MonoBehaviour {
	private float xXformPos;
	private float yXformPos;
	private int targetXMapPos;
	private int targetYMapPos;
	private int xMapPos = 0;
	private int yMapPos = 0;

	float moveHorizontal;
	float moveVertical;
	
	bool isMoving;

	private const float stepStaggerTime = .5f;
	private float nextStepTime = 0;

	private GameObject player;
	private float moveSpeed;

	private float tileSize = .32f;
	private float tileOffSet = .16F;

	private const int ROWS = 3;
	private const int COLUMNS = 13;

	bool[,] mapArray = new bool[ROWS,COLUMNS]   {{true, true,true, true,true, true,true, true,true, true,true, true,true},
												 {true, true,true, false,true, true,true, true,true, true,true, true,true},
												 {true, true,true, true,true, true,true, true,true, true,true, true,true}};

	public Texture2D upArrow;
	public Texture2D downArrow;
	public Texture2D rightArrow;
	public Texture2D leftArrow;
	
	private int arrowGroupX = 800;
	private int arrowGroupY = 600;
	private int arrowBtnWidth = 32;
	private int arrowBtnHeight = 32;

	enum Direction{Up, Down, Left, Right};

	// Use this for initialization
	void Awake () {
		//why can't i initialize outside the function?
		isMoving = false;
		tileSize = .32f;

		player = GameObject.FindGameObjectWithTag (Tags.player);
		string outstring = player.ToString();
		Debug.Log ("output string:" + outstring,player);
		moveSpeed = player.GetComponent<Attributes>().moveSpeed;

		nextStepTime = Time.time;
	}

	void Start(){
		xXformPos = player.transform.localPosition.x;
		yXformPos = player.transform.localPosition.y;
		targetXMapPos = xMapPos;
		targetYMapPos = yMapPos;
	}

	void FixedUpdate () {
		//player.transform.position.Set (xXformPos, yXformPos, 0);
		//MovementManager ();

		//xXformPos = Mathf.Lerp(xXformPos, targetXMapPos, 2);
		/*
		player.transform.position = new Vector3 (xXformPos, yXformPos, 0);
		if (xXformPos == targetXMapPos) {
			isMoving = false;
		}
		*/
		MoveToTarget ();
	}

	// Update is called once per frame
	void Update () {
		UpdateIsMoving ();
		SetTarget ();
	
	}

	void OnGUI () {
		if (GUI.Button (new Rect (arrowGroupX, arrowGroupY - 32, 32, 32), new GUIContent (upArrow))) {
			if (isMoving == false && yMapPos < (ROWS - 1)) {
				targetYMapPos = yMapPos + 1;
				nextStepTime = Time.time + stepStaggerTime;
			}
		}

		if(GUI.Button (new Rect (arrowGroupX,arrowGroupY+32,arrowBtnWidth,arrowBtnHeight), new GUIContent (downArrow))){
			if (isMoving == false && yMapPos > 0){
				targetYMapPos = yMapPos - 1;
				nextStepTime = Time.time + stepStaggerTime;
			}
		}
		if(GUI.Button (new Rect (arrowGroupX+32,arrowGroupY,arrowBtnWidth,arrowBtnHeight), new GUIContent (rightArrow))){
			if (isMoving == false && (xMapPos < (COLUMNS - 1))){
				targetXMapPos = xMapPos + 1;
				nextStepTime = Time.time + stepStaggerTime;
			}
		}
		if(GUI.Button (new Rect (arrowGroupX-32,arrowGroupY,arrowBtnWidth,arrowBtnHeight), new GUIContent (leftArrow))){
			if (isMoving == false && xMapPos > 0){
				targetXMapPos = xMapPos - 1;
				nextStepTime = Time.time + stepStaggerTime;
			}
		}
		//GUI.Label (new Rect (10,40,100,20), GUI.tooltip);
		
	}

	void GetInput(){
		moveHorizontal = Input.GetAxis ("Horizontal");
		moveVertical = Input.GetAxis ("Vertical");
	}
	
	void SetTarget(){
		GetInput ();

		if (isMoving == false) {
			if (moveHorizontal > 0 && (xMapPos < (COLUMNS - 1))){
				targetXMapPos = xMapPos + 1;
				nextStepTime = Time.time + stepStaggerTime;
			}
			else{ 
				if (moveHorizontal < 0 && xMapPos > 0){
					targetXMapPos = xMapPos - 1;
					nextStepTime = Time.time + stepStaggerTime;
				}
				else{ 
					if (moveVertical > 0 && yMapPos < (ROWS - 1)){
						targetYMapPos = yMapPos + 1;
						nextStepTime = Time.time + stepStaggerTime;
					}
					else{ 
						if (moveVertical < 0 && yMapPos > 0){
							targetYMapPos = yMapPos - 1;
							nextStepTime = Time.time + stepStaggerTime;
						}
					}
				}
			}


		}
	}

	void UpdateMapPosition(){
		player.transform.position = new Vector3 (xXformPos, yXformPos, 0);
	}

	void MoveToTarget(){
		if (targetXMapPos > xMapPos) {
			xXformPos += moveSpeed;

			if((MapToXformPos(targetXMapPos) - xXformPos) < .02F){
				xXformPos = MapToXformPos(targetXMapPos);
				xMapPos = targetXMapPos;
			}
			UpdateMapPosition ();
		}
		else{
			if (targetXMapPos < xMapPos) {
				xXformPos -= moveSpeed;
				
				if((xXformPos - (MapToXformPos(targetXMapPos)) < .02F)){
					xXformPos = MapToXformPos(targetXMapPos);
					xMapPos = targetXMapPos;
				}
				UpdateMapPosition ();
			}
			else{
				if (targetYMapPos > yMapPos) {
					yXformPos += moveSpeed;
					
					if((MapToXformPos(targetYMapPos) - yXformPos) < .02F){
						yXformPos = MapToXformPos(targetYMapPos);
						yMapPos = targetYMapPos;
					}
					UpdateMapPosition ();
				}
				else{
					if (targetYMapPos < yMapPos) {
						yXformPos -= moveSpeed;
						
						if(yXformPos - (MapToXformPos(targetYMapPos)) < .02F){
							yXformPos = MapToXformPos(targetYMapPos);
							yMapPos = targetYMapPos;
						}
						UpdateMapPosition ();
					}
				}
			}

		}

		//UpdateMapPosition ();
	}

	float MapToXformPos(int mapPos){
		float xFormPos;
		xFormPos = (float)mapPos * tileSize + tileOffSet;
		
		return xFormPos;
	}

	void UpdateIsMoving(){
		if (Time.time > nextStepTime)
						isMoving = false;
				else
						isMoving = true;
	}
}
