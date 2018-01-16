using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    [SerializeField] ParticleSystem explodeParticle;
    [SerializeField] float projectileDamage = 20f;
    [SerializeField] AudioClip explosionClip;

    private Rigidbody rigidbody;
    

    void Start () {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.velocity = (transform.forward * 10f);
    }
	
	void FixedUpdate () {
        
    }

    public void CreateExplosion(Vector3 pos, float radius, float force)
    {
        Collider[] objects = UnityEngine.Physics.OverlapSphere(pos, radius);
        foreach (Collider h in objects)
        {
            Rigidbody r = h.GetComponent<Rigidbody>();
            if (r != null)
            {
                r.AddExplosionForce(force, pos, radius);
                PlayerHealth p = h.GetComponent<PlayerHealth>();
                if(p != null)
                    p.TakeDamage(projectileDamage, pos);
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        CreateExplosion(collision.contacts[0].point, 3f, 100f);
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = explosionClip;
        audio.Play();
        explodeParticle.Play();
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
        Destroy(gameObject, 1f);
    }

}
