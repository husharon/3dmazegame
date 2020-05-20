using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    GameManagerScript GMS;

    public float timeTotal;
    private float timeLeft;

    public Text timer;

    void Start()
    {
        timeLeft = timeTotal;
        GMS = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= 1 * Time.deltaTime;
        timer.text = "Time Left: " + timeLeft.ToString("0") + "/" + timeTotal.ToString("0");

        //end game
        if (timeLeft <= 0)
        {
            GMS.GameOver();
        }
    }
}
