using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterDoor : MonoBehaviour
{
    [SerializeField] private Transform B;
    
    [SerializeField] private player Player;

    [SerializeField] private List<Collider2D> zombies;
    public bool player_exited;
    [SerializeField] private float timing;
    public GameObject Location;


   

    public bool exit;
    public bool enter;
    void Start()
    {
        player_exited = false;

        timing = Time.time;
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

  

    //the player and the zombies would use a door depending on different conditions
    private void OnTriggerStay2D(Collider2D collision)
    {
      
            if (collision.tag == "Player" && Input.GetKeyDown(KeyCode.S))
            {

                Vector3 u = B.transform.position;

                Player.transform.position = u;





            }
        //}
       
      


        



        if (collision.tag == "Zombie")
        {
            var enemy = collision.GetComponent<Zombie>();
            if (enemy.through_door)
            {
                Vector3 v = B.transform.position;
                enemy.transform.position = v;
                enemy.through_door = false;
            }
        }

        if (collision.tag == "Zombie2")
        {
            var enemy = collision.GetComponent<Zombie2>();
            if (enemy.exiting)
            {
                Vector3 v = B.transform.position;
                enemy.transform.position = v;
                 enemy.exiting = false;
                enemy.doors.RemoveAt(0);
            }

        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        //    if (collision.tag == "Player" && Input.GetKeyDown(KeyCode.S))
        //    {

        //    Vector3 u = B.transform.position;
            
        //    Player.transform.position = u;
        //}


        if (collision.tag == "Zombie")
        {
            var enemy = collision.GetComponent<Zombie>();
            if(enemy.through_door)
            {
                Vector3 v = B.transform.position;
                enemy.transform.position = v;
                enemy.through_door = false;
            }
        }


    }

}
