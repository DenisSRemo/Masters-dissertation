using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{

    public float speed = 20f;
    public Rigidbody2D rb;
    private float startTime;
    public GameObject gameObject;
   
    void Start()
    {
        rb.velocity = transform.right * speed;
        startTime = Time.time;
        
    }

    void Update()
    {
        float t = Time.time - startTime;
        if (t >= 1)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Zombie")
            Destroy(gameObject);
    }
}
