using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballout : MonoBehaviour {
    private Paddle paddle;
    private bool started=false;
    private Vector3 paddletoballVector;
	void Start () {
        paddle = GameObject.FindObjectOfType<Paddle>();
        paddletoballVector = this.transform.position - paddle.transform.position;
        
	}
	
	// Update is called once per frame
	void Update () {
        if (!started)
        {
            this.transform.position = paddle.transform.position + paddletoballVector;

            if (Input.GetMouseButtonDown(0))
            {
                started = true;
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(2f, 10f);
            }
        }
	}
    void OnCollisionEnter2D(Collision2D col)
    {
        Vector2 tweak = new Vector2(Random.Range(0f, 0.5f), Random.Range(0f, 0.5f));
        if (started)
        {
            GetComponent<AudioSource>().Play();
            this.GetComponent<Rigidbody2D>().velocity += tweak;
        }
    }
}
