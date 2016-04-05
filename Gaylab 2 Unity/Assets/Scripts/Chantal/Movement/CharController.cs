/* 7S_CRCO_001 & 7S_CAMC_001
 * Made by: Chantal
 */ 

using UnityEngine;
using System.Collections;

public class CharController : MonoBehaviour {

	public Transform camera;
	public float rotateSpeed = 25;
	Vector2 rot;
	public Vector2 xRotClamp = new Vector2 (-55f, 25f);

	public Vector3 offset;
	public float range = 1;
	public float floorRange = 0.5f;

	float moveSpeed = 5;
	public float walkSpeed = 5;
	public float dashSpeed = 10;

	public float jumpStrength = 1;
	public int maxJumpCount = 1;
	int curJumpCount;

	private Vector3 offsetPos;


	void Update () {
		RotateView ();
		Movement ();
		Jump ();
//		DrawDebugs ();
	}

//	void DrawDebugs(){
//		// rot check
//		Debug.DrawRay (transform.position, transform.forward * 100, Color.cyan);
//
//		// dir check
//		Debug.DrawRay(offsetPos, -transform.right 	* range * 25, 	Color.magenta);
//		Debug.DrawRay(offsetPos, transform.right 	* range * 25, 	Color.red);
//		Debug.DrawRay(offsetPos, -transform.forward * range * 25, 	Color.blue);
//		Debug.DrawRay(offsetPos, transform.forward 	* range * 25, 	Color.green);
//	}

	public void RotateView(){
		rot.x -= Input.GetAxis ("Mouse Y") * rotateSpeed * Time.deltaTime;
		rot.y += Input.GetAxis ("Mouse X") * rotateSpeed * Time.deltaTime;
		rot.x = Mathf.Clamp (rot.x, xRotClamp.x, xRotClamp.y);

		camera.localEulerAngles = new Vector3(rot.x, 0, 0);
		transform.eulerAngles 	= new Vector3(0, rot.y, 0);
	}

	public void Movement(){
		//offsetPos also used in Jump!
		offsetPos 			= transform.position + offset;
		Vector3 moveDir 	= new Vector3(0,0,0);

		float hor = Input.GetAxis ("Horizontal");
		if (hor != 0) {
			if (!Physics.Raycast (offsetPos, transform.right * hor, range)) {
				moveDir.x = hor;
			}
		}

		float ver = Input.GetAxis ("Vertical");
		if(ver != 0){
			if (!Physics.Raycast (offsetPos, transform.forward * ver, range)) {
				moveDir.z = ver;
			}
		}

		transform.Translate(new Vector3 (moveDir.x, 0, moveDir.z) * MoveSpeedCalculation() * Time.deltaTime, Space.Self);
	}

	public float MoveSpeedCalculation(){
		if (Input.GetButton("Dash")){
			moveSpeed = dashSpeed;
		} else {
			moveSpeed = walkSpeed;
		}
		return (moveSpeed);
	}

	public void Jump () {
		if (Input.GetButtonDown("Jump")){
			if (!Physics.Raycast (offsetPos, transform.up, range) && curJumpCount < maxJumpCount) {
				curJumpCount++;
				gameObject.GetComponent<Rigidbody> ().velocity = gameObject.GetComponent<Rigidbody> ().velocity + Vector3.up * jumpStrength;
			} 
		}else if(Physics.Raycast (offsetPos, -transform.up, range + floorRange)) {
			curJumpCount = 0;
		}
	}
}
