using UnityEngine;
using System.Collections;
// Faf

public class LandMine : MonoBehaviour
{
    public float expPower;
    public float expHeight;
    public float expRadius;
    public float expDamage;
    private Collider[] hitObjects;
    public HealthScript hpScript;
    public LayerMask objectLayer;
    public float radius;
    public float expTime; // Same time as ParticlePlayTime

    public ParticleSystem expParticle;


    // Update is called once per frame
    void Start()
    {
        expParticle.Pause();
        expTime = expParticle.duration;
    }
    void Update()
    {
        Explosion();
    }

    void Explosion()
    {
        hitObjects = Physics.OverlapSphere(transform.position, radius, objectLayer);
        foreach (Collider hitcol in hitObjects)
        {
            Debug.Log(hitcol.gameObject);
            Rigidbody rb = hitcol.GetComponent<Rigidbody>();
            if (rb && hitcol.tag == "tagname") // Tagname can be changed
            {
                expParticle.Play();
                rb.AddExplosionForce(expPower, transform.position, expRadius, expHeight);
                hpScript.curHealth -= expDamage;
                Destroy(gameObject, expTime);
            }
        }
    }
}

