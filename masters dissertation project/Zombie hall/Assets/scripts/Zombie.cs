using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    private Transform target;
    public GameObject player;
    public float speed;
    public int health;
    // Start is called before the first frame update
    void Start()
    {
        speed = 3f;
        health = 100;
    }

    // Update is called once per frame
    void Update()
    {
        target = player.transform;
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
            health = health - 25;
        if (health <= 0)
            Destroy(gameObject);
    }
}
