using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrolling :Sequence
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
            if (currentChild == children[0] && s == Status.Success)
            {
                currentChild = children[1];
            }
            else
                 if (currentChild == children[1] && s == Status.Success)
            {
                currentChild = children[0];
            }

            //if (blackboard.playerseen)
            //    return Status.Success;
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
