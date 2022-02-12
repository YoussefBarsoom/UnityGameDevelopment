using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour {

    public float health = 120;
    public float speed;
    public GameObject Lazer;
    public float firerate = 0.5f;
    public int scoreValue = 100;
    private Score sk;
    public AudioClip fire;
    public AudioClip death;

    void Start()
    {

       sk =  GameObject.Find("Score").GetComponent<Score>();
    }
    void OnTriggerEnter2D(Collider2D col)
    {
       Projectile missile = col.gameObject.GetComponent<Projectile>();
        if (missile)
        {
            health -= missile.getDamage();
            missile.hit();
            if (health <= 0)
            {
                AudioSource.PlayClipAtPoint(death, transform.position);
                Destroy(gameObject);
                sk.scorepoint(scoreValue);
              
            }
                
                }
    }
    void shoot ()
    {
        Vector3 start = transform.position + new Vector3(0, -1, 0);
        GameObject missile = Instantiate(Lazer, start, Quaternion.identity) as GameObject;
        missile.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -speed);
        AudioSource.PlayClipAtPoint(fire, transform.position);

    }
    void Update()
    {
        float prob = firerate * Time.deltaTime;
        if (Random.value < prob) {
            shoot();
        }
    }


}
