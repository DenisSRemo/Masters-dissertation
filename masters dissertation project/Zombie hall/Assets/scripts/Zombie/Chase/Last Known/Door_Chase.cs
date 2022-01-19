using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_Chase : Sequence
{
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
                currentChild = children[1];
            else
               if (currentChild == children[1] && s == Status.Success)
                currentChild = children[2];
            else
               if (currentChild == children[2] && s == Status.Success)
                currentChild = children[3];
            else
               if (currentChild == children[3] && s == Status.Success)
                return Status.Success;


            return Status.Running;
        }

        base.update();

    }
}
