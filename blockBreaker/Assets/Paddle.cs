using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

    // Use this for initialization

    public bool autoplay = false;
    private ballout ball;
    // Update is called once per frame
    void Start()
    {
        ball = GameObject.FindObjectOfType<ballout>();
    }
	void Update () {
        if (!autoplay)
        { MovewithMouse(); }
        else      
        {
            Autoplay();
        }

    }
    void MovewithMouse()
    {
        float mousePosInBLocks = Input.mousePosition.x / Screen.width * 15;
        Vector3 paddlePos = new Vector3(0.5f, this.transform.position.y, 0f);
        paddlePos.x = Mathf.Clamp(mousePosInBLocks, 1f, 14.9f);
        this.transform.position = paddlePos;

    }
    void Autoplay()
    {
        Vector3 ballpos = ball.transform.position;
        Vector3 paddlePos = new Vector3(0.5f, this.transform.position.y, 0f);
        paddlePos.x = Mathf.Clamp(ballpos.x, 1f, 14.9f);
        this.transform.position = paddlePos;

    }
}
