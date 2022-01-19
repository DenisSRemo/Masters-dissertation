using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    private bool allow=true;
    public float firerate = 0.1f;
    private float timetoshoot = 0f;
    public int nrbullets=30;
  
    

    void Update()
    {
        
        if (Input.GetMouseButton(0)&&nrbullets<30)
        {
            if(Time.time-timetoshoot>=firerate)
            {
                Shoot();
                timetoshoot = Time.time;
                nrbullets++;
            }
           
        }
        else
        {
            //before shooting you must press R to reload
            //the magazine has 30 bullets
            if (Input.GetKeyDown(KeyCode.R))
            {
                nrbullets = 0;
            }
        }
            
    }



    void Shoot()
    {
        
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        
    }
}
