using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sequence : Composite
{
    public Behaviour currentChild;

    public override void onInitialize()
    {
        base.onInitialize();
        if(children.Count!=0)
        currentChild = children[0];
    }

    public override Status update()
    {
        base.update();
        if(children.Count!=0)
        while (true)
        {
            Status s = currentChild.tick();
            if (currentChild == children[children.Count]&& s==Status.Success)
                return Status.Success;
            if (s != Status.Success)
                return s;
            
        }

        return Status.Invalid;
    }

}

