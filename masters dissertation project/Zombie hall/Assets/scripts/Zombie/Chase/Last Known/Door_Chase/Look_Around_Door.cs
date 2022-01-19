using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Look_Around_Door : Behaviour
{

    public Zombie zombie;
    public Transform location;
    public Blackboard blackboard;
    public override void onInitialize()
    {
        
        base.onInitialize();

       
    }

    public override Status update()
    {
        while (true)
        {
            
            zombie.transform.position = Vector3.MoveTowards(zombie.transform.position, location.position, blackboard.speed * Time.deltaTime);
            blackboard.target = location.position;
            //if (zombie.transform.position.x <= location.position.x)
            //{
            //   zombie.r = 1;
            //}
            //else
            //    zombie.r = -1;

            if (Vector3.Distance(zombie.transform.position, location.position) <= 0.5f)
            {
                return Status.Success;
            }
            

            return Status.Running;
        }


        return base.update();
    }

    public override void onTerminate(Status status)
    {
        
        base.onTerminate(status);
    }
}
