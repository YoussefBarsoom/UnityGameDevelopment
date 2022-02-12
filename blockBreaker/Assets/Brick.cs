using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {
  
    private int timesHit;
    public AudioClip crack;
    public static int breakableCount = 0;
    public Sprite[] hitSprite;
    private bool isBreakable;
    private LevelManager levelmanager;
    public GameObject smoke;
	// Use this for initialization
	void Start () {
        timesHit = 0;
        isBreakable = (this.tag == "Breakable");
        if(isBreakable)
        {
            breakableCount++;
            print(breakableCount);
       
        }
        levelmanager = GameObject.FindObjectOfType<LevelManager>();
	}
    void OnCollisionEnter2D(Collision2D col)
    {
        
         isBreakable = (this.tag == "Breakable");
        if (isBreakable)
        {
            Handlehits();
        }
    }
    void Handlehits()
    {

        timesHit++;
        int maxHits = hitSprite.Length + 1;
        if (timesHit >= maxHits)
        {
            
            AudioSource.PlayClipAtPoint(crack, transform.position);
            breakableCount--;
            levelmanager.BrickDestroyed();
            GameObject puff =Instantiate(smoke, gameObject.transform.position, Quaternion.identity);
            puff.GetComponent<ParticleSystem>().startColor = gameObject.GetComponent<SpriteRenderer>().color;
            Destroy(gameObject);
            
        }
        else
        { LoadSprite(); }

    }
    void LoadSprite()
    {
        int spriteIndex = timesHit - 1;
        if (hitSprite[spriteIndex]!= null)
        {
            this.GetComponent<SpriteRenderer>().sprite = hitSprite[spriteIndex];
        }
        else
        { Debug.LogError("Brick Sprite Missing"); }
    }
	// Update is called once per frame
	void Update () {
		
	}
    void SimulateWin()
    {
        levelmanager.LoadNextLevel();
    }
}
