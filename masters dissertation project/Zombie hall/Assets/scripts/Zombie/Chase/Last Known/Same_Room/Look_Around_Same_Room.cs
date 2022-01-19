using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Look_Around_Same_Room : Behaviour
{
    public override void onInitialize()
    {

        base.onInitialize();

        
    }

    public override Status update()
    {
        while (true)
        {
           

            return Status.Success;
        }


        return base.update();
    }

    public override void onTerminate(Status status)
    {
        
        base.onTerminate(status);
    }
}
