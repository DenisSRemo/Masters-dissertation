using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlusOneBullet : MonoBehaviour
{
    // Start is called before the first frame update

   // [SerializeField] private weapon weapon;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //it was noticed during playtesting a bug with the UI.
    //It makes the character fire every time the player presses a button to clise the UI
    public void PlusOneBulletFunction(weapon weapon)
    {
       // weapon.nrBulletsTotal++;
    }
}
