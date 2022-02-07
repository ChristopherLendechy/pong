using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class Score : MonoBehaviour
{
    // Start is called before the first frame update
    public int leftScore = 0;
    public int rightScore = 0;
    
    void Start()
    {
        
    }

    // Update is called once per frame

    private void OnTriggerEnter(Collider other)
    {
         string s = other.gameObject.name;
         if (s == "LeftGoal")
         {
             rightScore += 1;
             Debug.Log("Right side scored! Score is: " +  leftScore + " left! " + rightScore+ " right!");
             if (rightScore != 11) return;
             Debug.Log("Game Over, Right Paddle Wins");
             leftScore = 0;
             rightScore = 0;
         }
         else
         {
             leftScore += 1;
             Debug.Log("Left side scored! Score is: " +  leftScore + " left! " + rightScore+ " right!");
             if (leftScore != 11) return;
             Debug.Log("Game Over, Left Paddle Wins");
             leftScore = 0;
             rightScore = 0;
         }
         
    }
}
