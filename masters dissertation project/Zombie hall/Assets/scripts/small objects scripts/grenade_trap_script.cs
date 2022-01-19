using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grenade_trap_script : MonoBehaviour
{

    public float Damage = 100;
    public float BlastRadius = 1;
    public GameObject explosionEffect;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //the damage is calculated based on the disatnce between the grenade trap and the zombie
    void Explode()
    {
        if (BlastRadius > 0)
        {
            Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, BlastRadius);
            foreach (Collider2D hitCollider in hitColliders)
            {
                var enemy = hitCollider.GetComponent<Zombie>();
                if (enemy)
                {
                    var closestPosition = hitCollider.ClosestPoint(transform.position);
                    var distance = Vector3.Distance(closestPosition, transform.position);
                    var damagePercent = Mathf.InverseLerp(BlastRadius, 0, distance);
                    enemy.TakeHit(damagePercent * Damage);
                }
            }
        }
        if (BlastRadius > 0)
        {
            Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, BlastRadius);
            foreach (Collider2D hitCollider in hitColliders)
            {
                var enemy = hitCollider.GetComponent<Zombie2>();
                if (enemy)
                {
                    var closestPosition = hitCollider.ClosestPoint(transform.position);
                    var distance = Vector3.Distance(closestPosition, transform.position);
                    var damagePercent = Mathf.InverseLerp(BlastRadius, 0, distance);
                    enemy.TakeHit(damagePercent * Damage);
                }
            }
        }

        GameObject ExplosionEffectIns = Instantiate(explosionEffect, transform.position, Quaternion.identity);
        Destroy(ExplosionEffectIns, 10);
    }


   private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Zombie")
        {
            FindObjectOfType<AudioManager>().Play("grenade");
            Explode();
            Destroy(gameObject);
        }
    }
            

}
