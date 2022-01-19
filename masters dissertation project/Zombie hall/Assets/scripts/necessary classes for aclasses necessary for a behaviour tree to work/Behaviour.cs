using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Behaviour : MonoBehaviour
{
    public enum Status
    {
        Success,
        Running,
        Failure,
        Invalid
    };

    public Status currentStatus;
    public virtual void onInitialize()
    {
       
    }

    public virtual Status update()
    {
        return Status.Invalid;
    }

    public virtual void onTerminate(Status status)
    {
        
    }


    public Behaviour()
    {
        currentStatus = Status.Invalid;
    }

    public Status tick()
    {
        //currentStatus = Status.Invalid;
        
        if (currentStatus == Status.Invalid)
            onInitialize();
        currentStatus = update();
       
        if (currentStatus != Status.Running)
        {
            onTerminate(currentStatus);
            //if (currentStatus == Status.Success||currentStatus==Status.Failure)
            //{
            //    currentStatus = Status.Invalid;
            //}
        }

        return currentStatus;
    }
}
