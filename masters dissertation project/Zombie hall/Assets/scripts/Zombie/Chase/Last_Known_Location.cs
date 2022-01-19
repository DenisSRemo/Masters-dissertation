using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Last_Known_Location : Selector
{

    public Zombie zombie;
    public player Player;
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
            if(blackboard.playerseen)
            {
                currentChild = children[0];

            }
            else
            {
                currentChild = children[1];
            }
            Status s = currentChild.tick();

            if (s == Status.Success)
                return Status.Success;

            return Status.Running;
        }

        base.update();

    }
    public override void onTerminate(Status status)
    {
        base.onTerminate(status);
    }
}
