using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Text mytext = GetComponent<Text>();
        mytext.text = Score.score.ToString();
        Score.reset();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
