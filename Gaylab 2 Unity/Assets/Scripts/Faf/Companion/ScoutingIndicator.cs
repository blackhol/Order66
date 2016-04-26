using UnityEngine;
using System.Collections;

public class ScoutingIndicator : MonoBehaviour
{
   // public GameObject particle;
   // public bool compMayMove;
    public int rayDis;

    public RaycastHit hit;
    public Transform rayEndPos;

    public CompanionManager compScript;

    // Use this for initialization
    void Start ()
    {
	
	}
	
	// Update is called once per frame
    void Update()
    {
        if (Input.GetButton("PickUp") && compScript.hasMoved == false ) // Or any other button asigned to it 
        {
                ShootCompanion();
        }
    }
    void ShootCompanion()
    {
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        Debug.DrawRay(transform.position, fwd, Color.blue);

        if (Physics.Raycast(transform.position, fwd, out hit, rayDis))
        {

            print("i hit something");
            print(hit.point);
            rayEndPos.position = hit.point;
            compScript.compMode = CompanionManager.CompMode.Followstate;
        }

    }
}
