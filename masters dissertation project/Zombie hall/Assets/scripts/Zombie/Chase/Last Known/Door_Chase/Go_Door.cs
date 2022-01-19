using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Go_Door : Behaviour
{
    public Zombie zombie;
    public Blackboard blackboard;
    public override void onInitialize()
    {

        base.onInitialize();

      
    }

    public override Status update()
    {
        while (true)
        {
            zombie.transform.position = Vector3.MoveTowards(zombie.transform.position,blackboard.target, blackboard.speed * Time.deltaTime);
            if (Vector3.Distance(zombie.transform.position, blackboard.target) <= 1f)
            {
                zombie.through_door = true;
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
