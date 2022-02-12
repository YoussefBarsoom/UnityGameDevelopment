using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
    public GameObject enemyPrefab;
    public float width;
    public float height;
    public float by;
    public float spawndelay = 0.5f;
    private bool movingRight = false;
    private float xmax;
    private float xmin;
	// Use this for initialization
	void Start () {
        float dis = transform.position.z - Camera.main.transform.position.z;
        Vector3 lefty = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, dis));
        Vector3 righty = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, dis));
        xmin = lefty.x;
        xmax = righty.x;

        SpawnUntilFull();
	}
    void SpawnEnemies()
    {
    
        foreach (Transform child in transform)
        {
            GameObject enemy = Instantiate(enemyPrefab, child.transform.position, Quaternion.identity) as GameObject;
            enemy.transform.parent = child;
        }
    }
    public void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(width, height));
    }

    // Update is called once per frame
    void Update() {
        if (movingRight)
        {
            transform.position += new Vector3(by * Time.deltaTime, 0, 0);
        }
        else
        {
            transform.position += new Vector3(-by * Time.deltaTime, 0, 0);
        }
        float rightEdgeofForm = transform.position.x + (0.5f * width);
        float leftEdgeofForm = transform.position.x - (0.5f * width);
        if (rightEdgeofForm > xmax)
        {
         movingRight = false;
        }else if(leftEdgeofForm < xmin)
        { movingRight = true; }
        if (AllmembersDead())

        {
            SpawnUntilFull();

        }
    }
    void SpawnUntilFull()
    {
        Transform freePosition = NextFreePosition();
        if (freePosition)
        {
            GameObject enemy = Instantiate(enemyPrefab, freePosition.position, Quaternion.identity) as GameObject;
            enemy.transform.parent = freePosition;

        }
        if (NextFreePosition())
        {
            Invoke("SpawnUntilFull", spawndelay);
        }
    }
    Transform NextFreePosition()
    {
        foreach (Transform childPositonGameObject in transform)
        {
            if (childPositonGameObject.childCount == 0)
            { return childPositonGameObject; }
        }
        return null;

    }
    bool AllmembersDead()
    {
        foreach (Transform childPositonGameObject in transform)
        {
            if (childPositonGameObject.childCount > 0)
            { return false; }
        }
        return true;
    }
}
