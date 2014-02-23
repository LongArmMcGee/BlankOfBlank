using UnityEngine;
using System.Collections;

public class GUITest : MonoBehaviour {
	
	public Texture2D upArrow;
	public Texture2D downArrow;
	public Texture2D rightArrow;
	public Texture2D leftArrow;

	private int arrowGroupX = 800;
	private int arrowGroupY = 600;
	private int arrowBtnWidth = 32;
	private int arrowBtnHeight = 32;

	void OnGUI () {
		if (GUI.Button (new Rect (arrowGroupX, arrowGroupY - 32, 32, 32), new GUIContent (upArrow))) {
				
		}
		GUI.Button (new Rect (arrowGroupX,arrowGroupY+32,arrowBtnWidth,arrowBtnHeight), new GUIContent (downArrow));
		GUI.Button (new Rect (arrowGroupX+32,arrowGroupY,arrowBtnWidth,arrowBtnHeight), new GUIContent (rightArrow));
		GUI.Button (new Rect (arrowGroupX-32,arrowGroupY,arrowBtnWidth,arrowBtnHeight), new GUIContent (leftArrow));
		//GUI.Label (new Rect (10,40,100,20), GUI.tooltip);

	}
	
}