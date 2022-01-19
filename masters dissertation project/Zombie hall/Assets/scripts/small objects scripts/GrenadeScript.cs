using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeScript : MonoBehaviour
{


    public float Speed;

    public float timeToExplde=3;
    public float timeOfThrow;
    public Rigidbody2D rb;
    public float Damage = 400;
    public float BlastRadius=5;

    public GameObject explosionEffect;

    void Start()
    {
        timeOfThrow = Time.time;
        rb.velocity = transform.right * Speed;
        
        

       
    }

   
    void Update()
    {
       if(Time.time-timeOfThrow>=timeToExplde)
        {
            Explode();
            Destroy(gameObject);
           
        }
    }

    // the damage is calculated based on the distance between the granade and the zombie
    void Explode()
    {
        if (BlastRadius > 0)
        {
            Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, BlastRadius);
            foreach (Collider2D hitCollider in hitColliders)
            {
                if(hitCollider.tag=="Zombie")
                {
                    var enemy = hitCollider.GetComponent<Zombie>();
                    if (enemy)
                    {
                        var closestPosition = hitCollider.ClosestPoint(transform.position);
                        var distance = Vector3.Distance(closestPosition, transform.position);
                        var damagePercent = Mathf.InverseLerp(1 / 10, BlastRadius, distance);
                        enemy.TakeHit(damagePercent * Damage * 4);
                    }
                }
                else
                    if(hitCollider.tag=="Zombie2")
                {
                    var enemy = hitCollider.GetComponent<Zombie2>();
                    if (enemy)
                    {
                        var closestPosition = hitCollider.ClosestPoint(transform.position);
                        var distance = Vector3.Distance(closestPosition, transform.position);
                        var damagePercent = Mathf.InverseLerp(1 / 10, BlastRadius, distance);
                        enemy.TakeHit(damagePercent * Damage * 4);
                    }
                }
               
            }
        }


        GameObject ExplosionEffectIns= Instantiate(explosionEffect,transform.position,Quaternion.identity);
        Destroy(ExplosionEffectIns, 10);
    }




    private void OnCollisionEnter2D(Collision2D collision)
    {
      
        
    }

   

}
