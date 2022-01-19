using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class survivorUIscript : MonoBehaviour
{
    /// <summary>
    /// this class deals with the character interaction throughout the game
    /// </summary>

    [SerializeField] private GameObject panel,panel2,panel3;
    private bool active;
    private float time;
    [SerializeField] private string voiceline;
    private bool s1, s2, s3, s4;
    [SerializeField] private int number_survivor;
    // Start is called before the first frame update
    void Start()
    {
        active = false;
        panel.SetActive(false);
        panel2.SetActive(false);
        panel3.SetActive(false);

        // time = Time.time;
        s1 = false;
        s2 = false;
        s3 = false;
        s4 = false;

    }

    // Update is called once per frame
    void Update()
    {
        if(s1)
            Keeping_count_survivors.survivor1=s1;
        if (s2)
            Keeping_count_survivors.survivor2 = s2;
        if (s3)
            Keeping_count_survivors.survivor3 = s3;
        if (s4)
            Keeping_count_survivors.survivor4 = s4;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (active == false)
            {
                panel.SetActive(true);
                panel2.SetActive(true);
                panel3.SetActive(true);
                active = true;
                time = Time.time;
                Time.timeScale = 0;
                FindObjectOfType<weapon>().Fire(false);
                FindObjectOfType<AudioManager>().Play(voiceline);
                if (number_survivor == 1)
                    s1 = true;
                if (number_survivor == 2)
                    s2 = true;
                if (number_survivor == 3)
                    s3 = true;
                if (number_survivor == 4)
                    s4 = true;

            }
        }

    }


    public void NextPanel(GameObject panel)
    {
        panel.SetActive(false);
        Time.timeScale = 0;
      FindObjectOfType<weapon>().Fire(false);
       


    }



    public void LastPanel(GameObject panel)
    {
        panel.SetActive(false);
        FindObjectOfType<weapon>().Fire(true);

        Time.timeScale =1;
    }
    public void Voiceline(string s)
    {
        FindObjectOfType<AudioManager>().Play(s);
    }

}
