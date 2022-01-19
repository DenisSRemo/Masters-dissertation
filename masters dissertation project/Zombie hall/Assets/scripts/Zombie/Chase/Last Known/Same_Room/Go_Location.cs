using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Go_Location : Behaviour
{

    public Blackboard blackboard;
    public Zombie zombie;
    public override void onInitialize()
    {

        base.onInitialize();

       
    }

    public override Status update()
    {
        while (true)
        {
            zombie.transform.position = Vector3.MoveTowards(zombie.transform.position, blackboard.Last_known_position, blackboard.speed * Time.deltaTime);
            blackboard.target = blackboard.Last_known_position;
            if (Vector3.Distance(zombie.transform.position, blackboard.Last_known_position) <= 0.5f)
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
