using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAI : BehaviourTree
{
    public Blackboard blackboard;
    public override void onInitialize()
    {
        base.onInitialize();
        if (children.Count != 0)
            currentChild = children[0];

        


    }

    public override Status update()
    {


        while (true)
        {
            Status s = currentChild.tick();

            if (blackboard.patrol)
                currentChild = children[0];
            if (blackboard.chase)

                currentChild = children[1];



            if (currentChild == children[1] && s == Status.Success)

            {
                blackboard.patrol = true;
                blackboard.chase = false;


            }


            return Status.Running;
        }


        

        return Status.Invalid;
        return base.update();
    }

    public override void onTerminate(Status status)
    {
        base.onTerminate(status);
    }
}
