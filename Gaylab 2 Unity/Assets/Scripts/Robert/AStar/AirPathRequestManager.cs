using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class AirPathRequestManager : MonoBehaviour {

	Queue<PathRequest> airPathRequestQueue = new Queue<PathRequest>();
	PathRequest airCurrentPathRequest;

	static AirPathRequestManager instance;
	Pathfinding pathfinding;

	bool isProcessingPath;

	void Start() {
		instance = this;
		pathfinding = GetComponent<Pathfinding>();
	}

	public static void RequestPath(Vector3 pathStart, Vector3 pathEnd, Action<Vector3[], bool> callback) {
		PathRequest newRequest = new PathRequest(pathStart,pathEnd,callback);
		instance.airPathRequestQueue.Enqueue(newRequest);
		instance.TryProcessNext();
	}

	void TryProcessNext() {
		if (!isProcessingPath && airPathRequestQueue.Count > 0) {
			airCurrentPathRequest = airPathRequestQueue.Dequeue();
			isProcessingPath = true;
			pathfinding.StartFindPath(airCurrentPathRequest.pathStart, airCurrentPathRequest.pathEnd);
		}
	}

	public void FinishedProcessingPath(Vector3[] path, bool success) {
		airCurrentPathRequest.callback(path,success);
		isProcessingPath = false;
		TryProcessNext();
	}

	struct PathRequest {
		public Vector3 pathStart;
		public Vector3 pathEnd;
		public Action<Vector3[], bool> callback;

		public PathRequest(Vector3 _start, Vector3 _end, Action<Vector3[], bool> _callback) {
			pathStart = _start;
			pathEnd = _end;
			callback = _callback;
		}

	}
}