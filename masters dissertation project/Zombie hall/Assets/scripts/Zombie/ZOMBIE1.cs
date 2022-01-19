using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZOMBIE1 : MonoBehaviour
{
    /// <summary>
    /// the top of a zombie's behaviour tree
    /// </summary>
    public BehaviourTree ZombieAI;
         
           public Sequence Patrol;
                  public Behaviour Find_Node;
                  public Behaviour Go_To_Node;
   
    public Selector Chase;
           public Behaviour Visible;
           public Behaviour Chasing;
           public Selector Last_Known_Location;
                  public Sequence Same_Room;
                         public Behaviour Go_Location;
                         public Behaviour Look_Around_Room;
                  public Sequence Door;
                         public Behaviour Go_To_Door;
                         public Behaviour Through_Door;
                         public Behaviour Look_Around_Door;
                         public Behaviour Find_Door;

    public Blackboard blackboard;

    private void Start()
    {
        
        ZombieAI.addchild(Patrol);
                 Patrol.addchild(Find_Node);
                 Patrol.addchild(Go_To_Node);
        
        ZombieAI.addchild(Chase);
                 Chase.addchild(Visible);
                 Chase.addchild(Chasing);
                 Chase.addchild(Last_Known_Location);  
                       Last_Known_Location.addchild(Same_Room);
                                           Same_Room.addchild(Go_Location);
                                           Same_Room.addchild(Look_Around_Room);
                       Last_Known_Location.addchild(Door);
                                           Door.addchild(Find_Door);
                                           Door.addchild(Go_To_Door);
                                           Door.addchild(Through_Door);
                                           Door.addchild(Look_Around_Door);

    }
    void Update()
    {
        ZombieAI.tick();
    }
}
