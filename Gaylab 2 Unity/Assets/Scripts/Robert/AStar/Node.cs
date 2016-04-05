﻿using UnityEngine;
using System.Collections;

public class Node : IHeapItem<Node> {

	public 	Vector3 	worldPosition;

	public	bool 		walkable;

	public int gCost;
	public int hCost;
	public int gridX;
	public int gridY;
	public Node parent;
	int heapIndex;



	public Node (bool _walkable, Vector3 _worldPos, int _gridX, int _gridY){
		walkable 		= _walkable;
		worldPosition 	= _worldPos;
		gridY 			= _gridY;
		gridX 			= _gridX;

	}

	public int fCost{ // berekent de totale waarde van de node
		get{
			return gCost + hCost;
		}
	}

	public int HeapIndex {
		get{
			return heapIndex;
		}
		set{
			heapIndex = value;
		}
	}

	public int CompareTo (Node nodeToCompare){
		int compare = fCost.CompareTo(nodeToCompare.fCost);
		if(compare == 0){
			compare = hCost.CompareTo(nodeToCompare.hCost);
		}
		return -compare;
	}
}
