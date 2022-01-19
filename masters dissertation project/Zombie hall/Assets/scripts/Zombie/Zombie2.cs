using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie2 : MonoBehaviour
{



    [SerializeField] public Transform target;
    public GameObject player;
    public float speed;
    public float health;
    
    public List<Transform> doors;
    [SerializeField] private List<Transform> positions;
    private float timing;
    public bool exiting;
    public float damageMultiplier;


    // Start is called before the first frame update
    void Start()
    {
        speed = 2f;
        health = 100;
        timing = Time.time;
        exiting = false;
        damageMultiplier = 1f;

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(player.transform.position.y - gameObject.transform.position.y);

        //the target depends if the zombie and the player are in the same room
        if (Mathf.Abs( player.transform.position.y - gameObject.transform.position.y) >= 5)
        {
            target = doors[0];
            
                exiting = true;

        }

        else
        {
            
                    target = player.transform;
            
        }

       
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        if (health <= 0)
            Destroy(gameObject);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
        {
            //the damage is based on the type of weapon chosen by the player
           if( FindObjectOfType<weapon>().pistol)
            health = health - 60*damageMultiplier;
           else
                 if (FindObjectOfType<weapon>().SMG)
                health = health - 25*damageMultiplier;
           else
                 if (FindObjectOfType<weapon>().AR)
                health = health - 40*damageMultiplier;
        }
            
        if (health <= 0)
            Destroy(gameObject);
       
    }


    public void TakeHit(float damage)
    {
        health = health - damage;
    }
}

