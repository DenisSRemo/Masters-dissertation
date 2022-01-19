using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class body_animation : MonoBehaviour
{


    [SerializeField] private Animator animator;
    private bool walking;


    
    void Start()
    {
        walking = false;
        animator.SetBool("walking", false);
    }

    
    void Update()
    {

        if (Input.GetKey("a"))
        {
            walking = true;
            animator.SetBool("walking", walking);
        }
        else
        if (Input.GetKey("d"))
        {
            walking = true;
            animator.SetBool("walking", walking);
        }
        else
        {
            walking = false;
            animator.SetBool("walking", walking);
        }
    }
}
