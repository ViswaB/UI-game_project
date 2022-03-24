using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //The GameManager will be how we access variables between Canvases. 

    public static int score;
    public static int multiplier;

    // Start is called before the first frame update
    void Start()
    {
        multiplier = 1;                //This is where the upgrade equation will likely be
        score = 0;
    }

   
}
