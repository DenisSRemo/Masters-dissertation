using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class player : MonoBehaviour
{

    [SerializeField] private LayerMask layer;
    [SerializeField] private float speed;
    [SerializeField] private int maxh;
    [SerializeField] private int currenth;
    [SerializeField] private float startTime;
    [SerializeField] private int numberGranades;
    [SerializeField] private float health;

    private Rigidbody2D rb;
    private bool facingRight;
    private BoxCollider2D boxCollider2D;
    [SerializeField] private Camera camera;

    [SerializeField] private Animator animator;

    [SerializeField] private GameObject grenadePrehab;
    [SerializeField] private GameObject granadeTrapPrehab;


    [SerializeField] private bool crouching = false;
    private bool move = false;

    [SerializeField] private bool right;
    [SerializeField] private Vector3 StartingPosition;
    [SerializeField] private weapon Weapon;

    private bool exitDoor;
    private float timing;

    public Transform GranadePoint;
    [SerializeField] public bool objectivePicked;


    public TextMeshProUGUI number_grenades_text;
    public TextMeshProUGUI health_text;
    public GameObject Loser ;


    public bool rotated;

    void Start()
    {
        rb = transform.GetComponent<Rigidbody2D>();
        facingRight = true;
        startTime = Time.time;
        currenth = maxh;

        
        right = true;
        StartingPosition = gameObject.transform.position;
        boxCollider2D = transform.GetComponent<BoxCollider2D>();

        numberGranades = 1;

        health = 100;

        health_text.text = "health:" + health;

        objectivePicked = false;

        timing = Time.time;

        Loser.SetActive(false);

        number_grenades_text.text = "grenades:"+ numberGranades;

        Debug.Log(Dataexporter.ExportData());



    }
    /// <summary>
    /// the file is generated when you debug the data
    /// however it generates once per second with the player's coordinates
    /// or it generates once without the coordinates
    /// NEEDS MORE TESTING
    /// 
    /// </summary>

    void Update()
    {
        
        Dataexporter.SendToExport("( " + transform.position.x.ToString() + ", " + transform.position.y + " )");

        Debug.Log(Dataexporter.ExportData());
       

        Vector3 pos = transform.position;

         pos= HandleMovement(pos);

         //jump
         //if (Input.GetKeyDown(KeyCode.Space)&& IsGrounded())
         //{
         //    float JumpVelocity = 10f;
         //    rb.velocity=Vector2.up*JumpVelocity;
         //}

        transform.position = pos;

       // Flip(right);
        Vector3 u;
        u.x = transform.position.x;
        u.y = transform.position.y+1.0f;
        u.z = transform.position.z-20.0f;
        camera.transform.position = u;

        //rotate towards mouse


        Vector2 positionOnScreen = Camera.main.WorldToViewportPoint(transform.position);
        Vector2 mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);
        float angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);
      //  transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 180));
        if (positionOnScreen.x >= mouseOnScreen.x )
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));

           
        }
        else
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        }

        if (Input.GetKeyDown(KeyCode.W))

            exitDoor = true;


        //throws grenade
        if(Input.GetKeyDown(KeyCode.G))
        {
            if(numberGranades!=0)
            {
                FindObjectOfType<AudioManager>().Play("grenade");
                Throw();
                numberGranades--;
            }

        }

        //plants grenade trap
        if (Input.GetKeyDown(KeyCode.T))
        {
            if(numberGranades!=0)
            {
                InstallGrenadeTrap();
                numberGranades--;
            }
            
        }

        //game over
        if(health<=0)
        {
            Loser.SetActive(true);
            Time.timeScale = 0;
            Destroy(gameObject);
            Destroy(health_text);
        }

        health_text.text = "health:" + health;
        number_grenades_text.text = "grenades:" + numberGranades;
    }

    //calculates angle between character and mouse
    float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }

    //checks if there is ground under the character for it to jump
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






    void Throw()
    {
        Instantiate(grenadePrehab, GranadePoint.position, GranadePoint.rotation);
    }
  

    void InstallGrenadeTrap()
    {
        Instantiate(granadeTrapPrehab, transform.position, transform.rotation);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PickUpGrenade")
        {
            numberGranades++;
        }


        if (collision.tag == "PickUpAmmo")
        {
            Weapon.nrBulletsTotal = Weapon.nrBulletsTotal+100;
        }

        if (collision.tag == "Objective")
        {
            objectivePicked = true; ;
        }
        if (collision.tag == "InstaKill")
        {
            health = health - 100;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Zombie")
        {
            health = health - 40;
            timing = Time.time;
        }
        if (collision.collider.tag == "Zombie2")
        {
            health = health - 20;
            timing = Time.time;
        }
    }


    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Zombie")
        {
            if (Time.time - timing >= 1)
                health = health - 40;
            timing = Time.time;
        }
        if (collision.collider.tag == "Zombie2")
        {
            if (Time.time - timing >= 1)
                health = health - 20;
            timing = Time.time;
        }
    }
   
}



