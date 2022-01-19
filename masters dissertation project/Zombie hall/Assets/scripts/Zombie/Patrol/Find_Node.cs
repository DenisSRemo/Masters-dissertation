using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Find_Node : Behaviour
{

    public Blackboard blackboard;

    public override void onInitialize()
    {

        base.onInitialize();

       
    }

    public override Status update()
    {
        while (true)
        {
            if (blackboard.i == 0)
                blackboard.i = 1;
            else
                if (blackboard.i == 1)
                blackboard.i = 0;

            return Status.Success;
        }


        return base.update();
    }

    public override void onTerminate(Status status)
    {
        
        base.onTerminate(status);
    }
}
