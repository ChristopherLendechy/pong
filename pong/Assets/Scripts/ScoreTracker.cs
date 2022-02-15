using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class ScoreTracker : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    public int rScore = 0;

    public int lScore = 0;
    // Start is called before the first frame update
    void Start()
    {
        ResetScore();
    }

    // Update is called once per frame
    public void ChangeScore(string side)
    {
        if (side == "left")
        {
            lScore++;
            
            scoreText.text = lScore + " - " + rScore;
            scoreText.color = Color.cyan;
        }
        else
        {
            rScore++;
            scoreText.text = lScore + " - " + rScore;
            scoreText.color = Color.yellow;
        }
    }
    public void ResetScore()
    {
        //scoreText.text = Ball.FindObjectOfType<Ball>()
        lScore = 0;
        rScore = 0;
        scoreText.color = Color.white;
        scoreText.text = lScore + " - " + rScore;
    }

    public void GameOver(string s)
    {
        scoreText.text = s + " wins!";
        Invoke(nameof(Start),2);
    }
}
