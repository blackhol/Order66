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

	Vector3	oldPos;
	float moveSpeed = 5;
	bool mayDash = true;
	public float walkSpeed = 5;
	public float dashSpeed = 800;
	public float dashDistrance = 10;
	public float dashCooldown = 2;
	public float dashDmg = 0;

	public float jumpStrength = 1;
	public int maxJumpCount = 1;
	int curJumpCount;
	[HideInInspector] public bool canJump = false;

	private Vector3 offsetPos;

	void FixedUpdate () {
		RotateView ();
		Movement ();
		Jump ();
		DashDistance ();
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
			
		if (Input.GetButtonDown("Dash")){
			if (mayDash) {
				StartCoroutine(StartDash(moveDir));
			}
		} else {
			transform.Translate(new Vector3 (moveDir.x, 0, moveDir.z) * moveSpeed * Time.deltaTime, Space.Self);
		}
	}

	public void DashDistance (){
		if (!mayDash) {
			if (Vector3.Distance (oldPos, transform.position) >= dashDistrance) {
				gameObject.GetComponent<Rigidbody> ().Sleep ();
			}
		}
	}

	public IEnumerator StartDash (Vector3 moveDir){
		mayDash = false;
		oldPos = transform.position; 

		Rigidbody rb = gameObject.GetComponent<Rigidbody> ();
		rb.AddRelativeForce(moveDir * dashSpeed);

		yield return new WaitForSeconds(dashCooldown);
		mayDash = true;
	}

	public void Jump () {
		if (canJump) {
			if (Input.GetButtonDown ("Jump")) {
				if (!Physics.Raycast (offsetPos, transform.up, range) && curJumpCount < maxJumpCount) {
					curJumpCount++;
					Rigidbody rb = gameObject.GetComponent<Rigidbody> ();
					rb.velocity = rb.velocity + Vector3.up * jumpStrength;
				} 
			} else if (Physics.Raycast (offsetPos, -transform.up, range + floorRange)) {
				curJumpCount = 0;
			}
		}
	}
}
