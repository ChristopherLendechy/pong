using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using UnityEngine;
using Debug = UnityEngine.Debug;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    // Start is called before the first frame update
    
    public int leftScore = 0;
    public int rightScore = 0;
    
    private ScoreTracker _tracker;
    private string _s;
    void Start()
    {
        _tracker = GameObject.Find("Text").GetComponent<ScoreTracker>();
    }

    // Update is called once per frame

    private void OnTriggerEnter(Collider other)
    {
        if ((other.gameObject.name != "p1") || (other.gameObject.name != "p2"))
        {
            _s = other.gameObject.name;
            if (_s == "LeftGoal")
            {
                rightScore += 1;
                _tracker.ChangeScore("right");
                Debug.Log("Right side scored! Score is: " + leftScore + " left! " + rightScore + " right!");
                if (rightScore == 11)
                {
                    _tracker.GameOver("Right Side");
                    leftScore = 0;
                    rightScore = 0;
                }

                // Debug.Log("Game Over, Right Paddle Wins");


            }
            if (_s == "RightGoal")
            {

                leftScore += 1;
                _tracker.ChangeScore("left");
                Debug.Log("Left side scored! Score is: " + leftScore + " left! " + rightScore + " right!");
                if (leftScore == 11)
                {
                    _tracker.GameOver("Left Side");
                    leftScore = 0;
                    rightScore = 0;
                }

                // Debug.Log("Game Over, Left Paddle Wins");

            }
         
        } 

    }
}
