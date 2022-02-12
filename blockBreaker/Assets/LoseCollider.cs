using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour {

    // Use this for initialization
    private LevelManager levelManager;
    void OnTriggerEnter2D(Collider2D tr )
    {
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        levelManager.LoadLevel("Lose");
       
   }
    void OnCollisionEnter2D(Collision2D col )
    { }


}
