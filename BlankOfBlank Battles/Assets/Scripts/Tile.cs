using UnityEngine;
using System.Collections;
using FileHelpers;

[DelimitedRecord(",")] 
public class Tile /*: MonoBehaviour DON'T NEED YET*/ { 
	TileType type;
	//ArrayList entityContainer;
	TerrainCost LandEffect;
	//used for connecting tiles via 'portals' ie tunnels/caves/magic gates
	int connectedTile;
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
	Normal,
	Water,
	Wood,
	Ice,
	Desert,
	WhateverElseYouWantSteve
}
