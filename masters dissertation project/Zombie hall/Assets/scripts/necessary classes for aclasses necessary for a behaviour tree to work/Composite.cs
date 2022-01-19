using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Composite :Behaviour
{
    public List<Behaviour> children;
    public int j;

    public virtual void addchild(Behaviour behaviour)
    {
        children.Add(behaviour);
    }

    public void removechild(Behaviour behaviour)
    {
        for (int i = 0; i < children.Count; i++)
        {
            if (children[i] == behaviour)
            {
                
                j = i;
            }
        }
        children.RemoveAt(j);
    }


    public void clearchildren()
    {
        children.Clear();
    }
}
