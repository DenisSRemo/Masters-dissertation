using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{

    [SerializeField] public float health;
    [SerializeField] private Transform castPoint;
    [SerializeField] private float fovdistance;
    [SerializeField] private float distance_to_zombie;
    public bool through_door;
    public Blackboard blackboard;
    public LayerMask ActionMask;
    public LayerMask ZombieMask;
    public LayerMask ObstacleMask;
    public LayerMask DoorMask;
    [SerializeField] private bool facingRight;
    [SerializeField]public float r = -1;
    private float d1;
    private float d2;
    public float damageMultiplier;


    // Start is called before the first frame update
    void Start()
    {
        r = -1;
        health = 300;
        through_door = false;
        facingRight = true;
        d1 = fovdistance;
        d2 = fovdistance * 2;
        damageMultiplier = 1f;

    }

    // Update is called once per frame
    void Update()
    {
        
           
        if (transform.position.x <= blackboard.target.x)
        {
            r = -1;
        }
        else
            r = 1;
        if (CanSeePlayer(fovdistance,r))
        {
            blackboard.playerseen = true;
            fovdistance = d2;
        }
        else
        {
            blackboard.playerseen = false;
            fovdistance = d1;
        }

        if(ToCloseZombie(distance_to_zombie,r))
        {
            blackboard.to_close = true;

        }
        else
        {
            blackboard.to_close = false;
        }

        if(CanSeeDoor(fovdistance,r))
        {

        }
        if (health <= 0)
            Destroy(gameObject);
        Flip(r);
    }


    private void Flip(float r)
    {
        if (r < 0 && !facingRight || r > 0 && facingRight)
        {
            facingRight = !facingRight;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;

        }
    }

        private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
            if (FindObjectOfType<weapon>().pistol)
                health = health - 60*damageMultiplier;
            else
                if (FindObjectOfType<weapon>().SMG)
                health = health - 25 * damageMultiplier;
            else
                if (FindObjectOfType<weapon>().AR)
                health = health - 40 * damageMultiplier;


    }

    // function which detects the player
    private bool CanSeePlayer(float distance,float r)
    {


        bool val = false;
        float castDist = distance;
        Vector2 endPos;
        if (r<0)
        endPos = castPoint.position + Vector3.right * castDist;
        else
            endPos= castPoint.position + Vector3.left * castDist;

        RaycastHit2D hit = Physics2D.Linecast(castPoint.position, endPos,ActionMask);
        

        if (hit.collider!=null)
        {
            if (hit.collider.gameObject.CompareTag("Player")) 
            {
                val = true;
                Debug.Log(val);
                Debug.DrawLine(castPoint.position, hit.point, Color.red);
            }
            else
            {
                val = false;

                Debug.DrawLine(castPoint.position, endPos, Color.blue);
            }
               
        }
        else
        {
            Debug.DrawLine(castPoint.position, endPos, Color.blue);
        }


        //Debug.Log(val);
        return val;
    }


    private bool ToCloseZombie(float distance,float r)
    {
        bool val=false;
        float castDist = distance;
        Vector2 endPos;
        if (r < 0)
            endPos = castPoint.position + Vector3.right * castDist;
        else
            endPos = castPoint.position + Vector3.left * castDist;

        RaycastHit2D hit = Physics2D.Linecast(castPoint.position, endPos,ZombieMask);


        //if (hit.collider != null)
        //{
        //    if (hit.collider.gameObject.CompareTag("Zombie"))
        //    {
        //        val = true;
        //        Debug.DrawLine(castPoint.position, hit.point, Color.green);
        //    }
        //    else
        //    {
        //        val = false;

        //        Debug.DrawLine(castPoint.position, endPos, Color.blue);
        //    }

        //}
        //else
        //{
        //    Debug.DrawLine(castPoint.position, endPos, Color.blue);
        //}


        //Debug.Log(val);
        return val;
        
    }


    // function which detects doors
    private bool CanSeeDoor(float distance, float r)
    {


        bool val = false;
        float castDist = distance;
        Vector2 endPos;
        if (r < 0)
            endPos = castPoint.position + Vector3.right * castDist;
        else
            endPos = castPoint.position + Vector3.left * castDist;

        RaycastHit2D hit = Physics2D.Linecast(castPoint.position, endPos, DoorMask);


        //if (hit.collider != null)
        //{
        //    if (hit.collider.gameObject.CompareTag("Door"))
        //    {
        //        val = true;
        //        Debug.DrawLine(castPoint.position, hit.point, Color.red);
        //    }
        //    else
        //    {
        //        val = false;

        //        Debug.DrawLine(castPoint.position, endPos, Color.blue);
        //    }

        //}
        //else
        //{
        //    Debug.DrawLine(castPoint.position, endPos, Color.blue);
        //}


        //Debug.Log(val);
        return val;
    }



   public void TakeHit(float damage)
    {
        health = health - damage;
    }
}
