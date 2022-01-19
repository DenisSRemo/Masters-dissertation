using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chasing : Behaviour
{

    public Zombie zombie;
    public player player;
    public Blackboard blackboard;
    public override void onInitialize()
    {

        base.onInitialize();

       
    }

    public override Status update()
    {
        while (true)
        {
            blackboard.Last_known_position = player.transform.position;
            if (blackboard.playerseen)
            {
                zombie.transform.position = Vector3.MoveTowards(zombie.transform.position, player.transform.position, blackboard.speed * Time.deltaTime);
                blackboard.target = player.transform.position;
            }
           
            else
            {
                
                return Status.Failure;
            }

            if (Vector3.Distance(zombie.transform.position, player.transform.position) <= 0.5f)
            {
                return Status.Success;
            }
            
             

            return Status.Running;
        }


        return base.update();
    }

    public override void onTerminate(Status status)
    {
        
        base.onTerminate(status);
    }
}
