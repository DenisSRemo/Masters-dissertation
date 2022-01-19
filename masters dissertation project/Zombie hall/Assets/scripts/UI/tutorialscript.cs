using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorialscript : MonoBehaviour
{

    /// <summary>
    /// this class deals with the UI in the tutorial levels. Later it was used in other levels for some UI elements
    /// </summary>

    [SerializeField] private GameObject tutorial_panel;
    private bool active;
    private float time;
    [SerializeField] private string intro_line;
    // Start is called before the first frame update
    void Start()
    {
        active = false;
        tutorial_panel.SetActive(false);
       // time = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
       
            
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Player")
        {
            if(active==false)
            {
                tutorial_panel.SetActive(true);
                active = true;
                time = Time.time;
                Time.timeScale = 0;
                FindObjectOfType<weapon>().Fire(false);
                FindObjectOfType<AudioManager>().Play(intro_line);
            }
        }

    }

    
    public void functionforbutton()
    {
        tutorial_panel.SetActive(false);
        FindObjectOfType<weapon>().Fire(true);
        Time.timeScale = 1;

    }



    public void functionforbutton2()
    {
        tutorial_panel.SetActive(false);
        Time.timeScale = 0;
        FindObjectOfType<weapon>().Fire(false);
    }

}
