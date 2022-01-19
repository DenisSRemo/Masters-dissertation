using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aim : MonoBehaviour
{
    [SerializeField] private LayerMask layer;

    private Rigidbody2D rb;
    private bool facingRight;
    private BoxCollider2D boxCollider2D;

    private float bbbb;

    [SerializeField] private bool crouching = false;
    private bool move = false;

    [SerializeField] private bool right;

   
   


    void Start()
    {
        rb = transform.GetComponent<Rigidbody2D>();
        facingRight = true;
       


        right = true;
        boxCollider2D = transform.GetComponent<BoxCollider2D>();


        bbbb = transform.position.z;
        Vector3 u;

    }


    void Update()
    {

        Vector3 pos = transform.position;

       


        // Flip(right);
        Vector3 u;
        u.x = transform.position.x;
        u.y = transform.position.y;
        u.z = bbbb;
        transform.position = u;
       
        //rotate towards mouse


        Vector2 positionOnScreen = Camera.main.WorldToViewportPoint(transform.position);
        Vector2 mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);
        float angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);

        angle = angle - 180;

       // Debug.Log(angle);
        if(angle>=-30||angle<=-150)
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        
        if (positionOnScreen.x >= mouseOnScreen.x&&(angle >= -30 || angle <= -150))
        {
            transform.Rotate(0, 180, 180);


        }

      


      

    }

    
    float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }


  
   


    private void Flip(bool right)
    {
        if (right == true && !facingRight || right == false && facingRight)
        {
            facingRight = !facingRight;
            transform.Rotate(0, 180f, 0);

        }
    }






}
