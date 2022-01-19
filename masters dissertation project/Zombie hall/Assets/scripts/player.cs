using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player : MonoBehaviour
{

   [SerializeField] private LayerMask layer;
    public float speed;
    public int maxh;
    public int currenth;
    public float startTime;
    private Rigidbody2D rb;
    private bool facingRight;
    private BoxCollider2D boxCollider2D;
    public Camera camera;
   
    public Animator animator;
   
    
    
    
   
    public bool crouching = false;
    public bool move = false;
    
    public bool right;
    public Vector3 StartingPosition;


    



    void Start()
    {
        rb = transform.GetComponent<Rigidbody2D>();
        facingRight = true;
        startTime = Time.time;
        currenth = maxh;

        
        right = true;
        StartingPosition = gameObject.transform.position;
        boxCollider2D = transform.GetComponent<BoxCollider2D>();
    }

    
    void Update()
    {

        Vector3 pos = transform.position;

         pos= HandleMovement(pos);

         //jump
         if (Input.GetKeyDown(KeyCode.Space)&& IsGrounded())
         {
             float JumpVelocity = 16f;
             rb.velocity=Vector2.up*JumpVelocity;
         }

        transform.position = pos;

       // Flip(right);
        Vector3 u;
        u.x = transform.position.x;
        u.y = transform.position.y;
        u.z = transform.position.z-10.0f;
        camera.transform.position = u;

        //rotate towards mouse


        Vector2 positionOnScreen = Camera.main.WorldToViewportPoint(transform.position);
        Vector2 mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);
        float angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 180));
        if (positionOnScreen.x >= mouseOnScreen.x)
        {
           transform.Rotate(180,0,0);
          

        }
        
           




    }

    float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }


    private bool IsGrounded()
    {
        RaycastHit2D RaycastHit2D = Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size, 0f, Vector2.down,.1f,layer);
        return RaycastHit2D.collider != null;
    }

    private Vector3 HandleMovement(Vector3 pos)
    {
        if (Input.GetKey("d") && move == false)
        {

            pos.x += speed * Time.deltaTime;
           // right = true;

        }


        if (Input.GetKey("a"))
        {
            pos.x -= speed * Time.deltaTime;
            //right = false;

        }

        return pos;
    }



    private void Flip(bool right)
    {
        if (right == true && !facingRight || right == false && facingRight)
        {
            facingRight = !facingRight;
            transform.Rotate(0,180f,0);

        }
    }







    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "EnterDoor" && Input.GetKeyDown(KeyCode.S))
        {

            Vector3 v;
            v.x = transform.position.x;
            v.y = -10.0f;
            v.z = -15.0f;
            transform.position = v;
        }



        if (collision.tag == "ExitDoor"&& Input.GetKeyDown(KeyCode.W))
        {
            Vector3 v;
            v.x = transform.position.x;
            v.y = 0;
            v.z = 0f;
            transform.position = v;
        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "EnterDoor" && Input.GetKeyDown(KeyCode.S))
        {

            Vector3 v;
            v.x = transform.position.x;
            v.y = -10.0f;
            v.z = -15.0f;
            transform.position = v;
        }



        if (collision.tag == "ExitDoor" && Input.GetKeyDown(KeyCode.W))
        {
            Vector3 v;
            v.x = transform.position.x;
            v.y = 0;
            v.z = 0f;
            transform.position = v;
        }


    }






}
