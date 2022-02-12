using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playercontroller : MonoBehaviour {

    // Use this for initialization
   
    public float by;
    public float health = 350;
    public float padding=1;
    public float beamspeed;
    public float firerate;
     float xmin;
     float xmax ;
    public GameObject lazerPrefab;
    public AudioClip fire;

    void Start () {
        float dis = transform.position.z - Camera.main.transform.position.z;
        Vector3 lefty =Camera.main.ViewportToWorldPoint(new Vector3(0,0,dis));
        Vector3 righty = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, dis));
        xmin = lefty.x+padding;
        xmax = righty.x-padding;
    }
	void Fire()
    {
        Vector3 offset = new Vector3(0, 1, 0);
        GameObject beam = Instantiate(lazerPrefab, transform.position+offset, Quaternion.identity) as GameObject;
        beam.GetComponent<Rigidbody2D>().velocity = new Vector3(0, beamspeed);
        AudioSource.PlayClipAtPoint(fire, transform.position);
    }
	// Update is called once per frame
	void Update () {
       if(Input.GetKeyDown(KeyCode.Space))
        {
            InvokeRepeating("Fire", 0.00001f, firerate);
        


        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            CancelInvoke("Fire");
        }
            if (Input.GetKey(KeyCode.RightArrow))
        {

            transform.position += Vector3.right * by * Time.deltaTime;

        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left * by * Time.deltaTime;

        }

        float newX = Mathf.Clamp(transform.position.x, xmin, xmax);
        transform.position = new Vector3(newX, transform.position.y,transform.position.z);
        
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
                Destroy(gameObject);
                LevelManager man =GameObject.Find("LevelManager").GetComponent<LevelManager>();
                man.LoadLevel("Win");
            }

        }
    }
}
