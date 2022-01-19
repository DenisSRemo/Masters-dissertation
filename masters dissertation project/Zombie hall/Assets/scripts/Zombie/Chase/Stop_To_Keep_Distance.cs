using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stop_To_Keep_Distance : Behaviour
{

    public Blackboard blackboard;
    public Zombie zombie;
    public override void onInitialize()
    {

        base.onInitialize();

       
    }

    public override Status update()
    {
        while (true)
        {

            zombie.transform.position = Vector3.MoveTowards(zombie.transform.position,zombie.transform.position, 0 * Time.deltaTime);
            return Status.Running;
        }


        return base.update();
    }

    public override void onTerminate(Status status)
    {
       
        base.onTerminate(status);
    }
}
