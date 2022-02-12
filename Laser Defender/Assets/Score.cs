using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {
    public static int score;
    private Text text;
    void Start()
    {
        text = GetComponent<Text>();
    }

	// Use this for initialization

    public void scorepoint(int points)
    {
        score += points;
        text.text = score.ToString();

    }
   public static void reset()
    {


        score = 0;

    }
}
