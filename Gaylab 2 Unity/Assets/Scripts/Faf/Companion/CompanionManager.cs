using UnityEngine;
using System.Collections;

public class CompanionManager : MonoBehaviour
{
    public enum CompMode { Regularstate, Followstate, Scoutstate, IdleState };
    public CompMode compMode;

    public Transform target;
    NavMeshAgent agent;

    public bool hasMoved;
    public GameObject companionCanvas;
    public Transform scoutTarget;
    public int flyHeight;
    public float followDis;

    public float fOWRadius;
    public Transform sphereCastTar; // Should be on the ground, onder de companion.
    public LayerMask enemyLayermask;
    public Collider[] EnemyColliders;

    void Start ()
    {
        agent = GetComponent<NavMeshAgent>();
	}

	void Update ()
    {
        Move();
        switch (compMode)
        {
            case CompMode.Regularstate:
                Move();
                break;
            case CompMode.Followstate:
                FollowMoving();
                break;
            case CompMode.Scoutstate:
                Scouting();
                // komt nog
                break;
            case CompMode.IdleState:
                // does nothing
                break;
        }
    }

    public void Move()
    {
        agent.SetDestination(target.position);
        transform.position = new Vector3(transform.position.x, flyHeight, transform.position.z);
    }

    public void FollowMoving()
    {
        float distance;
        distance = Vector3.Distance(transform.position, scoutTarget.position);

        agent.SetDestination(scoutTarget.position);
        transform.position = new Vector3(transform.position.x, flyHeight, transform.position.z);
        // print(distance);
        if (distance < followDis) // fix so that the scoutmode doesnt loop 
        {
            compMode = CompMode.Scoutstate;
            hasMoved = true;
        } 
    }

    public void Scouting()
    {
        EnemyColliders = Physics.OverlapSphere(sphereCastTar.position, fOWRadius, enemyLayermask);
        // shows how many enemy colliders are seen in an array
        foreach(Collider hitcol in EnemyColliders)
        {
            Debug.Log(hitcol.gameObject);
        }

        agent.SetDestination(scoutTarget.position);
        transform.position = new Vector3(transform.position.x, flyHeight, transform.position.z);

        if (hasMoved == true && Input.GetButtonDown("PickUp"))
        {
            companionCanvas.SetActive(true);
        }
    }

    public void RelocateBut()
    {
        hasMoved = false;
        compMode = CompMode.Followstate;
        companionCanvas.SetActive(false);
    }
    
    public void CallBackBut()
    {
        hasMoved = false;
        companionCanvas.SetActive(false);
        compMode = CompMode.Regularstate;
    }
}
