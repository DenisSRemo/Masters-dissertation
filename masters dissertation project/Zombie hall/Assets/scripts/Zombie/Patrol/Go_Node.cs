using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Go_Node : Behaviour
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


            zombie.transform.position = Vector3.MoveTowards(zombie.transform.position, blackboard.Nodes[blackboard.i].position, blackboard.speed * Time.deltaTime);
            blackboard.target = blackboard.Nodes[blackboard.i].position;
            if (Vector3.Distance(zombie.transform.position, blackboard.Nodes[blackboard.i].position) <= 1.0f)
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
