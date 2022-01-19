using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lever_door_script : MonoBehaviour
{
    /// <summary>
    /// this class deals with the level for the safe room
    /// </summary>
    public Transform Position1;
    public Transform Position2;
    public GameObject door;
    bool open = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player" && Input.GetKeyDown(KeyCode.E))
        {
           
            if(open)
            {
                door.SetActive(false);
                open = false;
            }
            else
            {
                door.SetActive(true);
                open = true;
            }
        }
    }
}
