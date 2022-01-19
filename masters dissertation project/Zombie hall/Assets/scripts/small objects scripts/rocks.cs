using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rocks : MonoBehaviour
{

    [SerializeField] private lever Lever;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // the rocks were programmed to be destroyed after a certain time so they were not interfier with the character's movement
    void Update()
    {
        if ( Input.GetKeyDown(KeyCode.E)&&Lever.pulled==true)
        {
            Destroy(gameObject, 5);
        }

        
    }
  
    //the rockes are designed to chip a little bit of health from the zombies

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Zombie")
        {
            var enemy = collision.collider.GetComponent<Zombie>();
            enemy.TakeHit(90);
        }
         if (collision.collider.tag == "Zombie2")
        {
            var enemy = collision.collider.GetComponent<Zombie>();
            enemy.TakeHit(90);
        }
    }
}
