using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseZ : Selector
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

            //if(blackboard.playerseen)
            //{
            //    currentChild = children[0];
            //}
            //if (currentStatus == Status.Success||currentStatus==Status.Failure)
            //    currentChild = children[0];


            if (currentChild == children[0] && s == Status.Success)
                currentChild = children[1];







            if (currentChild == children[1] && s == Status.Failure)
                currentChild = children[3];
            else
             if (currentChild == children[1] && s == Status.Success)
                return Status.Success;





                if (currentChild == children[3] && s == Status.Success)
            {
                currentChild= children[1];
                return Status.Success;
            }
                






            if (blackboard.to_close)
                currentChild = children[2];
            if (currentChild == children[2] && s == Status.Success)
                currentChild = children[1];

            return Status.Running;
        }

        base.update();

    }
}
