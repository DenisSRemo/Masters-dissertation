using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Through_Door : Behaviour
{


    public Zombie zombie;
    private float timing;
    public override void onInitialize()
    {

        base.onInitialize();
        timing = Time.time;
        
    }

    public override Status update()
    {
        while (true)
        {
           
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
