using UnityEngine;
using System.Collections;

public class Tile /*: MonoBehaviour DON'T NEED YET*/ { 
	TileType type;
	ArrayList<Entity> entityContainer;
	LandEffect landEffect;
	TileType type;
	//used for connecting tiles via 'portals' ie tunnels/caves/magic gates
	Tile connectedTile;
}

//Terrain cost
enum TerrainCost{
	FastTerrain,
	NormalTerrain,
	MediumTerrain,
	HardTerrain
}

//'elemental' damage
enum TileType{
	Water,
	Wood,
	Ice,
	Desert,
	WhateverElseYouWantSteve
}
