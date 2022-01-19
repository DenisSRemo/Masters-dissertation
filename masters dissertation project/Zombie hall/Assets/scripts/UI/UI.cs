using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{

    /// <summary>
    /// this class deals with some of the UI elements in the game
    /// </summary>



    public GameObject Image, Button, Button1, Image2,Object;
    // Start is called before the first frame update
    void Start()
    {
        Image.SetActive(false);
        Button.SetActive(false);
        Image2.SetActive(false);
        Button1.SetActive(false);
        Object.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
