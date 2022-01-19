using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Visible : Behaviour
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
            if (blackboard.playerseen)
                return Status.Success;
            

            return Status.Running;
        }


        return base.update();
    }

    public override void onTerminate(Status status)
    {
        
        base.onTerminate(status);
    }
}
