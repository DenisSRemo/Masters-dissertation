using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{

    public float speed = 20f;
    public Rigidbody2D rb;
   
    public GameObject gameObject;
   
    void Start()
    {
        rb.velocity = transform.right * speed;
        
        
    }

    void Update()
    {
       
            Destroy(gameObject,1);
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.IsTouchingLayers(12))
        {
            if (collision.tag == "headzombie")
            {
                var enemy = collision.GetComponent<Zombie>();
                enemy.damageMultiplier = 2f;
            }
            if (collision.tag == "bodyzombie")
            {
                var enemy = collision.GetComponent<Zombie>();
                enemy.damageMultiplier = 1f;
            }
            if (collision.tag == "armszombie")
            {
                var enemy = collision.GetComponent<Zombie>();
                enemy.damageMultiplier = 0.8f;
            }
            if (collision.tag == "legszombie")
            {
                var enemy = collision.GetComponent<Zombie>();
                enemy.damageMultiplier = 1f;
            }
        }
        if (collision.IsTouchingLayers(15))
        {
            if (collision.tag == "headzombie")
            {
                var enemy = collision.GetComponent<Zombie2>();
                enemy.damageMultiplier = 2f;
            }
            if (collision.tag == "bodyzombie")
            {
                var enemy = collision.GetComponent<Zombie2>();
                enemy.damageMultiplier = 1f;
            }
            if (collision.tag == "armszombie")
            {
                var enemy = collision.GetComponent<Zombie2>();
                enemy.damageMultiplier = 0.8f;
            }
            if (collision.tag == "legszombie")
            {
                var enemy = collision.GetComponent<Zombie2>();
                enemy.damageMultiplier = 1f;
            }
        }

        Destroy(gameObject);
       
    }
}
