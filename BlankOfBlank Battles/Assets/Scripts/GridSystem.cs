using UnityEngine;
using System.Collections;
using FileHelpers;

public class GridSystem : MonoBehaviour {
	//ArrayList xGrid = new ArrayList();
	//ArrayList yGrid = new ArrayList();
	//Just use a 2d array, the game maps will be of static size
	private Tile[,] gameMap;

	//game map anchor points
	//Will be used to line up game background and grid system
	public int xAnchorPoint; 
	public int yAnchorPoint;

	void Awake(){
		LoadGrid (0);
	}


	/*
	void GridSystem(ArrayList[,]){
	
	}
	*/
	private void CreateGrid(int levelId){
		//LoadGrid(level)
		//GridSystem currentLevel = new GridSystem(LoadGrid(levelId));
		//
	}
	
	//Load grid from csv and return the 2d array to be used in constructor of GridSystem (rename this class)
	private static void LoadGrid(int levelId){
		//Create FileHelper
		FileHelperEngine engine = new FileHelperEngine (typeof(Tile));
		//Read csv file
		Tile[] test = engine.ReadFile("csvtest.csv") as Tile[];

		Debug.Log ("Tile Type: " + test[0]+test[1] + 1);
	}
}
