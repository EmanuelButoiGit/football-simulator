using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Score : MonoBehaviour
{
    public static int redScore = 0;
    public static int blueScore = 0;
    public static float MATCH_TIME = 15f; 
    public static float timeRemaining; // seconds
    public static bool start = false;
    public Text text;
    
    public string DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);  
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public static int CalculateRedPoints(){
        int points = 0;
        if(redScore > blueScore){
            points = 3;
        }
        else if(redScore == blueScore){
            points = 1;
        }
        else{
            points = 0;
        }
        return points;
    }

    public static int CalculateBluePoints(){
        int points = 0;
        if(redScore > blueScore){
            points = 0;
        }
        else if(redScore == blueScore){
            points = 1;
        }
        else{
            points = 3;
        }
        return points;
    }

    // Update is called once per frame
    void Update()
    {
        if(start == true){
            timeRemaining -= Time.deltaTime;
        }
        text.text = "BLU " + blueScore + " - " + redScore + " RED " + "    TIME: " + DisplayTime(timeRemaining);
    }
}
