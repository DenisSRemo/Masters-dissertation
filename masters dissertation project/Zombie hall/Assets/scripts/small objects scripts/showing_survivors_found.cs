using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showing_survivors_found : MonoBehaviour
{
    /// <summary>
    /// this classes helps with showing all the survivors the player find throughout the game
    /// </summary>
     [SerializeField]
    private bool S1, S2, S3, S4;

    public GameObject Survivor1, Survivor2, Survivor3, Survivor4;
    // Start is called before the first frame update
    void Start()
    {
        Survivor1.SetActive(false);
        Survivor2.SetActive(false);
        Survivor3.SetActive(false);
        Survivor4.SetActive(false);

        S1 = Keeping_count_survivors.survivor1;
        S2 = Keeping_count_survivors.survivor2;
        S3 = Keeping_count_survivors.survivor3;
        S4 = Keeping_count_survivors.survivor4;

    }

    // Update is called once per frame
    void Update()
    {
        if(S1)
            Survivor1.SetActive(true);
        if (S2)
            Survivor2.SetActive(true);
        if (S3)
            Survivor3.SetActive(true);
        if (S4)
            Survivor4.SetActive(true);
    }
}
