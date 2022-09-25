using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearController : MonoBehaviour
{
    [SerializeField] private float destroyTimer;
    private bool destroy = false;
    [SerializeField] private ParticleSystem bloodParticles;
    [SerializeField] private Rigidbody rb;
    private bool grabbed = false;
    [SerializeField] private CharacterController player_thrower = null;
    [SerializeField] private CharacterController player_hit = null;
    [SerializeField] private ParticleSystem hitParticles;


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            destroy = true;
        }

        if (collision.gameObject.tag == "Bodypart" && Mathf.Abs(rb.velocity.y) >= 4 || Mathf.Abs(rb.velocity.x) >= 4 )
        {
            if (!grabbed)
            {
                Instantiate(bloodParticles, collision.gameObject.transform.position, collision.gameObject.transform.rotation);
            }

            if (player_thrower != null && collision.gameObject.GetComponentInParent<CharacterController>() != player_thrower)
            {
                player_hit = collision.gameObject.GetComponentInParent<CharacterController>();
                if (player_hit != null)
                {
                    player_hit.takeDamage(1);
                    Instantiate(hitParticles, collision.gameObject.transform.position, collision.gameObject.transform.rotation);
                    Destroy(gameObject);
                }
                
            }
            
        }
    }

    private void Update()
    {
        if (destroy)
        {
            destroyTimer -= Time.deltaTime;
        }
        if (destroyTimer <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void setGrabbed(bool grabbed)
    {
        this.grabbed = grabbed;
    }

    public void setTimer(float timer)
    {
        destroyTimer = timer;
    }

    public void setThrower(CharacterController player)
    {
        this.player_thrower = player;
    }
}
