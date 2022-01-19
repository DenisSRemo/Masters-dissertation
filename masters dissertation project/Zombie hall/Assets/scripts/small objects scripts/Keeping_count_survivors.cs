using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keeping_count_survivors : MonoBehaviour
{

    /// <summary>
    /// this class keep count of the survivors found by the player
    /// </summary>
    public static bool survivor1, survivor2, survivor3, survivor4;
   
    void Start()
    {
        survivor1 = false;
        survivor2 = false;
        survivor3 = false;
        survivor4 = false;
    }

    void Update()
    {
        Debug.Log("survivor1" + survivor1);
        Debug.Log("survivor2" + survivor2);
        Debug.Log("survivor3" + survivor3);
        Debug.Log("survivor4" + survivor4);

    }

}
