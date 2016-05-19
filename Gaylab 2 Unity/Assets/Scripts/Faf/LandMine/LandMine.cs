using UnityEngine;
using System.Collections;
// Faf

public class LandMine : MonoBehaviour
{
    public float expPower;
    public float expHeight;
    public float expRadius;
    public float expDamage;
	public ShieldAndHealth hpScript;
    public float expTime; // Same time as ParticlePlayTime

    public ParticleSystem expParticle;
    // Update is called once per frame
    void Start()
    {
        expParticle.Pause();
        expTime = expParticle.duration;
    }
    void OnTriggerEnter(Collider hitcol)
    {
        if (hitcol.tag == "tagname") // Tagname can be changed
        {
            Rigidbody rb = hitcol.GetComponent<Rigidbody>();
            rb.AddExplosionForce(expPower, transform.position, expRadius, expHeight);
            expParticle.Play();
            hpScript.curHealth -= expDamage;
            Destroy(gameObject, expTime);
        }
    }
}

