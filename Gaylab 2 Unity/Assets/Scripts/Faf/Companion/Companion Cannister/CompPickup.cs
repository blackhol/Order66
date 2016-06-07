using UnityEngine;
using System.Collections;

public class CompPickup : MonoBehaviour
{
    public CompanionManager compManager;
    // Particle system moet op eigen object.
    void Start()
    {
        gameObject.GetComponent<ParticleSystem>().Play();
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            compManager.pickups++;
            Destroy(gameObject);
        }
    }
}
