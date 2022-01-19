using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class safe_room : MonoBehaviour
{

    public GameObject Winner;
    // Start is called before the first frame update
    void Start()
    {
        Winner.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //if the player finds the supplies and enters a safe room, the player finishes the level
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {

            var player = collision.GetComponent<player>();
            if(player.objectivePicked)
            {
                Winner.SetActive(true);
                Time.timeScale = 0;
            }
        }

    }
}
